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
    }
}
