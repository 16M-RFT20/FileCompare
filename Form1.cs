using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace FileCompare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void PopulateListView(ListView lv, string folderPath)
        {
            lv.BeginUpdate();
            lv.Items.Clear();

            try
            { // 폴더(디렉터리) 먼저 추가
                var dirs = Directory.EnumerateDirectories(folderPath)
                    .Select(p => new DirectoryInfo(p)).OrderBy(d => d.Name);

                foreach (var d in dirs)
                {
                    var item = new ListViewItem(d.Name);
                    item.SubItems.Add("<DIR>");
                    item.SubItems.Add(d.LastWriteTime.ToString("g"));
                    // store DirectoryInfo so we can compare later
                    item.Tag = d;
                    item.ForeColor = Color.Black;
                    lv.Items.Add(item);
                }

                // 파일 추가
                var files = Directory.EnumerateFiles(folderPath)
                    .Select(p => new FileInfo(p))
                    .OrderBy(f => f.Name);

                foreach (var f in files)
                {
                    var item = new ListViewItem(f.Name);
                    item.SubItems.Add(f.Length.ToString("N0") + " 바이트");
                    item.SubItems.Add(f.LastWriteTime.ToString("g"));
                    // store FileInfo so we can compare later
                    item.Tag = f;
                    item.ForeColor = Color.Black;
                    lv.Items.Add(item);
                }

                // 컬럼 너비 자동 조정(컨텐츠 기준)
                for (int i = 0; i < lv.Columns.Count; i++)
                {
                    lv.AutoResizeColumn(i,
                        ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show(this, "폴더를 찾을 수 없습니다.", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show(this, "입출력 오류: " + ex.Message, "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lv.EndUpdate();
            }
        }

        // Compare two ListView controls and set item colors according to rules:
        // - identical (same LastWriteTime) -> Black
        // - different -> newer = Red, older = Gray
        // - only on one side -> Purple
        private void CompareAndColor(ListView left, ListView right)
        {
            if (left == null || right == null) return;

            var rightMap = new Dictionary<string, ListViewItem>(StringComparer.OrdinalIgnoreCase);
            foreach (ListViewItem r in right.Items)
            {
                rightMap[r.Text] = r;
                // default color
                r.ForeColor = Color.Black;
            }

            var processed = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (ListViewItem l in left.Items)
            {
                l.ForeColor = Color.Black;
                if (rightMap.TryGetValue(l.Text, out var rItem))
                {
                    processed.Add(l.Text);

                    var lInfo = l.Tag as FileSystemInfo;
                    var rInfo = rItem.Tag as FileSystemInfo;

                    if (lInfo != null && rInfo != null)
                    {
                        var lTime = lInfo.LastWriteTime;
                        var rTime = rInfo.LastWriteTime;

                        if (lTime == rTime)
                        {
                            l.ForeColor = Color.Black;
                            rItem.ForeColor = Color.Black;
                        }
                        else if (lTime > rTime)
                        {
                            l.ForeColor = Color.Red;   // New
                            rItem.ForeColor = Color.Gray; // Old
                        }
                        else
                        {
                            l.ForeColor = Color.Gray;
                            rItem.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        // If tags are missing, default to black
                        l.ForeColor = Color.Black;
                        rItem.ForeColor = Color.Black;
                    }
                }
                else
                {
                    // only on left
                    l.ForeColor = Color.Purple;
                }
            }

            // any right-side items not processed are only on right
            foreach (ListViewItem r in right.Items)
            {
                if (!processed.Contains(r.Text))
                {
                    r.ForeColor = Color.Purple;
                }
            }
        }

        private void btnLeftDir_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "폴더를 선택하세요.";

                // 현재 텍스트박스에 있는 경로를 초기 선택 폴더로 설정
                if (!string.IsNullOrWhiteSpace(txtLeftDir.Text) &&
                             Directory.Exists(txtLeftDir.Text))
                {
                    dlg.SelectedPath = txtLeftDir.Text;
                }

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtLeftDir.Text = dlg.SelectedPath;
                    PopulateListView(lvwLeftDir, dlg.SelectedPath);
                    // update colors comparing both sides
                    CompareAndColor(lvwLeftDir, lvwrightDir);
                }
            }
        }

        private void btnRightDir_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "폴더를 선택하세요.";

                // 현재 텍스트박스에 있는 경로를 초기 선택 폴더로 설정
                if (!string.IsNullOrWhiteSpace(txtRightDir.Text) &&
                             Directory.Exists(txtRightDir.Text))
                {
                    dlg.SelectedPath = txtRightDir.Text;
                }

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtRightDir.Text = dlg.SelectedPath;
                    PopulateListView(lvwrightDir, dlg.SelectedPath);
                    CompareAndColor(lvwLeftDir, lvwrightDir);
                }
            }
        }

        private void btnCopyFromLeft_Click(object sender, EventArgs e)
        {
            // Copy selected files from left list to right folder
            if (string.IsNullOrWhiteSpace(txtRightDir.Text) || !Directory.Exists(txtRightDir.Text))
            {
                MessageBox.Show(this, "대상 폴더를 선택하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selected = lvwLeftDir.SelectedItems.Cast<ListViewItem>().ToList();
            if (selected.Count == 0) return;

            foreach (var item in selected)
            {
                // skip directories
                if (item.SubItems.Count > 1 && item.SubItems[1].Text == "<DIR>") continue;

                var srcInfo = item.Tag as FileInfo;
                if (srcInfo == null) continue;

                var destPath = Path.Combine(txtRightDir.Text, srcInfo.Name);
                CopyFileWithConfirmation(srcInfo.FullName, destPath);
            }

            // refresh destination and recolor
            PopulateListView(lvwrightDir, txtRightDir.Text);
            CompareAndColor(lvwLeftDir, lvwrightDir);
        }

        private void btnCopyFromRight_Click(object sender, EventArgs e)
        {
            // Copy selected files from right list to left folder
            if (string.IsNullOrWhiteSpace(txtLeftDir.Text) || !Directory.Exists(txtLeftDir.Text))
            {
                MessageBox.Show(this, "대상 폴더를 선택하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selected = lvwrightDir.SelectedItems.Cast<ListViewItem>().ToList();
            if (selected.Count == 0) return;

            foreach (var item in selected)
            {
                // skip directories
                if (item.SubItems.Count > 1 && item.SubItems[1].Text == "<DIR>") continue;

                var srcInfo = item.Tag as FileInfo;
                if (srcInfo == null) continue;

                var destPath = Path.Combine(txtLeftDir.Text, srcInfo.Name);
                CopyFileWithConfirmation(srcInfo.FullName, destPath);
            }

            // refresh destination and recolor
            PopulateListView(lvwLeftDir, txtLeftDir.Text);
            CompareAndColor(lvwLeftDir, lvwrightDir);
        }

        // Copy file with overwrite confirmation when destination exists.
        // Shows source/destination paths and last write times.
        private void CopyFileWithConfirmation(string srcFullName, string destFullName)
        {
            try
            {
                if (File.Exists(destFullName))
                {
                    var srcTime = File.GetLastWriteTime(srcFullName);
                    var destTime = File.GetLastWriteTime(destFullName);

                    // No confirmation when source is newer OR times are equal (red->gray OR black->black)
                    if (srcTime >= destTime)
                    {
                        File.Copy(srcFullName, destFullName, true);
                        return;
                    }

                    // If source is older (gray->red), ask for confirmation
                    var message = $"대상에 동일한 이름의 파일이 이미 있습니다.\r\n덮어쓰시겠습니까?\r\n\r\n" +
                                  $"원본: {srcFullName}\r\n수정일: {srcTime}\r\n\r\n대상: {destFullName}\r\n수정일: {destTime}";

                    var result = MessageBox.Show(this, message, "덮어쓰기 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result != DialogResult.Yes) return;

                    File.Copy(srcFullName, destFullName, true);
                }
                else
                {
                    File.Copy(srcFullName, destFullName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "복사 중 오류: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
