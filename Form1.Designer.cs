namespace FileCompare
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            panel3 = new Panel();
            lvwLeftDir = new ListView();
            panel2 = new Panel();
            txtLeftDir = new TextBox();
            btnLeftDir = new Button();
            panel1 = new Panel();
            btnCopyFromLeft = new Button();
            lblAppName = new Label();
            panel6 = new Panel();
            lvwrightDir = new ListView();
            panel5 = new Panel();
            txtRightDir = new TextBox();
            btnRightDir = new Button();
            panel4 = new Panel();
            btnCopyFromRight = new Button();
            name_left = new ColumnHeader();
            size_left = new ColumnHeader();
            date_left = new ColumnHeader();
            name_right = new ColumnHeader();
            size_right = new ColumnHeader();
            date_right = new ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.FixedSingle;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel3);
            splitContainer1.Panel1.Controls.Add(panel2);
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel6);
            splitContainer1.Panel2.Controls.Add(panel5);
            splitContainer1.Panel2.Controls.Add(panel4);
            splitContainer1.Size = new Size(1182, 553);
            splitContainer1.SplitterDistance = 586;
            splitContainer1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(lvwLeftDir);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 161);
            panel3.Name = "panel3";
            panel3.Size = new Size(584, 390);
            panel3.TabIndex = 0;
            // 
            // lvwLeftDir
            // 
            lvwLeftDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lvwLeftDir.Columns.AddRange(new ColumnHeader[] { name_left, size_left, date_left });
            lvwLeftDir.FullRowSelect = true;
            lvwLeftDir.GridLines = true;
            lvwLeftDir.Location = new Point(12, 3);
            lvwLeftDir.Name = "lvwLeftDir";
            lvwLeftDir.Size = new Size(561, 377);
            lvwLeftDir.TabIndex = 3;
            lvwLeftDir.UseCompatibleStateImageBehavior = false;
            lvwLeftDir.View = View.Details;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtLeftDir);
            panel2.Controls.Add(btnLeftDir);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 83);
            panel2.Name = "panel2";
            panel2.Size = new Size(584, 78);
            panel2.TabIndex = 0;
            // 
            // txtLeftDir
            // 
            txtLeftDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtLeftDir.Font = new Font("한컴 고딕", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            txtLeftDir.Location = new Point(12, 18);
            txtLeftDir.Name = "txtLeftDir";
            txtLeftDir.Size = new Size(451, 37);
            txtLeftDir.TabIndex = 1;
            // 
            // btnLeftDir
            // 
            btnLeftDir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLeftDir.Font = new Font("맑은 고딕", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnLeftDir.Location = new Point(469, 18);
            btnLeftDir.Name = "btnLeftDir";
            btnLeftDir.Size = new Size(94, 42);
            btnLeftDir.TabIndex = 2;
            btnLeftDir.Text = "폴더선택";
            btnLeftDir.UseVisualStyleBackColor = true;
            btnLeftDir.Click += btnLeftDir_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCopyFromLeft);
            panel1.Controls.Add(lblAppName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(584, 83);
            panel1.TabIndex = 0;
            // 
            // btnCopyFromLeft
            // 
            btnCopyFromLeft.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCopyFromLeft.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnCopyFromLeft.Location = new Point(469, 19);
            btnCopyFromLeft.Name = "btnCopyFromLeft";
            btnCopyFromLeft.Size = new Size(94, 42);
            btnCopyFromLeft.TabIndex = 1;
            btnCopyFromLeft.Text = ">>>";
            btnCopyFromLeft.UseVisualStyleBackColor = true;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("한컴 고딕", 24F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblAppName.ForeColor = Color.Blue;
            lblAppName.Location = new Point(12, 9);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(265, 52);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "File Compare";
            // 
            // panel6
            // 
            panel6.Controls.Add(lvwrightDir);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 161);
            panel6.Name = "panel6";
            panel6.Size = new Size(590, 390);
            panel6.TabIndex = 3;
            // 
            // lvwrightDir
            // 
            lvwrightDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lvwrightDir.Columns.AddRange(new ColumnHeader[] { name_right, size_right, date_right });
            lvwrightDir.FullRowSelect = true;
            lvwrightDir.GridLines = true;
            lvwrightDir.Location = new Point(12, 3);
            lvwrightDir.Name = "lvwrightDir";
            lvwrightDir.Size = new Size(566, 377);
            lvwrightDir.TabIndex = 4;
            lvwrightDir.UseCompatibleStateImageBehavior = false;
            lvwrightDir.View = View.Details;
            // 
            // panel5
            // 
            panel5.Controls.Add(txtRightDir);
            panel5.Controls.Add(btnRightDir);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 83);
            panel5.Name = "panel5";
            panel5.Size = new Size(590, 78);
            panel5.TabIndex = 3;
            // 
            // txtRightDir
            // 
            txtRightDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRightDir.Font = new Font("한컴 고딕", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            txtRightDir.Location = new Point(12, 18);
            txtRightDir.Name = "txtRightDir";
            txtRightDir.Size = new Size(451, 37);
            txtRightDir.TabIndex = 1;
            // 
            // btnRightDir
            // 
            btnRightDir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRightDir.Font = new Font("맑은 고딕", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnRightDir.Location = new Point(469, 18);
            btnRightDir.Name = "btnRightDir";
            btnRightDir.Size = new Size(94, 42);
            btnRightDir.TabIndex = 2;
            btnRightDir.Text = "폴더선택";
            btnRightDir.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnCopyFromRight);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(590, 83);
            panel4.TabIndex = 0;
            // 
            // btnCopyFromRight
            // 
            btnCopyFromRight.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnCopyFromRight.Location = new Point(25, 19);
            btnCopyFromRight.Name = "btnCopyFromRight";
            btnCopyFromRight.Size = new Size(94, 42);
            btnCopyFromRight.TabIndex = 2;
            btnCopyFromRight.Text = "<<<";
            btnCopyFromRight.UseVisualStyleBackColor = true;
            // 
            // name_left
            // 
            name_left.Text = "이름";
            name_left.Width = 300;
            // 
            // size_left
            // 
            size_left.Text = "크기";
            size_left.Width = 100;
            // 
            // date_left
            // 
            date_left.Text = "수정일";
            date_left.Width = 160;
            // 
            // name_right
            // 
            name_right.Text = "이름";
            name_right.Width = 300;
            // 
            // size_right
            // 
            size_right.Text = "크기";
            size_right.Width = 100;
            // 
            // date_right
            // 
            date_right.Text = "수정일";
            date_right.Width = 160;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 553);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "File Compare v1.0";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private Button btnCopyFromLeft;
        private Label lblAppName;
        private Panel panel4;
        private Button btnCopyFromRight;
        private TextBox txtLeftDir;
        private Button btnLeftDir;
        private Panel panel6;
        private Panel panel5;
        private TextBox txtRightDir;
        private Button btnRightDir;
        private ListView lvwLeftDir;
        private ListView lvwrightDir;
        private ColumnHeader name_left;
        private ColumnHeader size_left;
        private ColumnHeader date_left;
        private ColumnHeader name_right;
        private ColumnHeader size_right;
        private ColumnHeader date_right;
    }
}
