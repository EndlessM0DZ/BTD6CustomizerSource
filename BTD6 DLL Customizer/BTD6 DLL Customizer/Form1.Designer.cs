namespace BTD6_DLL_Customizer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CloseButton = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.importDLLModsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDLLModsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createVersionDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openBTD6DirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openVersionDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.VersionComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.AddModsButton = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.LaunchButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.LogButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1031, 40);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.AutoSize = true;
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.Font = new System.Drawing.Font("Oetztype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.Location = new System.Drawing.Point(1003, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(28, 26);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "X";
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Oetztype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(347, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Endless DLL Customizer 2.0";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 624);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1031, 12);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1019, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(12, 584);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Red;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(12, 584);
            this.panel4.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowItemReorder = true;
            this.toolStrip1.Font = new System.Drawing.Font("Oetztype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton3,
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(12, 40);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1007, 29);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importDLLModsToolStripMenuItem,
            this.createDLLModsToolStripMenuItem,
            this.createVersionDirectoryToolStripMenuItem});
            this.toolStripDropDownButton1.Font = new System.Drawing.Font("Oetztype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(52, 26);
            this.toolStripDropDownButton1.Text = "File";
            this.toolStripDropDownButton1.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // importDLLModsToolStripMenuItem
            // 
            this.importDLLModsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.importDLLModsToolStripMenuItem.Name = "importDLLModsToolStripMenuItem";
            this.importDLLModsToolStripMenuItem.Size = new System.Drawing.Size(297, 26);
            this.importDLLModsToolStripMenuItem.Text = "Import DLL Mods";
            this.importDLLModsToolStripMenuItem.Click += new System.EventHandler(this.importDLLModsToolStripMenuItem_Click);
            // 
            // createDLLModsToolStripMenuItem
            // 
            this.createDLLModsToolStripMenuItem.Name = "createDLLModsToolStripMenuItem";
            this.createDLLModsToolStripMenuItem.Size = new System.Drawing.Size(297, 26);
            this.createDLLModsToolStripMenuItem.Text = "Create DLL Mods";
            // 
            // createVersionDirectoryToolStripMenuItem
            // 
            this.createVersionDirectoryToolStripMenuItem.Name = "createVersionDirectoryToolStripMenuItem";
            this.createVersionDirectoryToolStripMenuItem.Size = new System.Drawing.Size(297, 26);
            this.createVersionDirectoryToolStripMenuItem.Text = "Create Version Directory";
            this.createVersionDirectoryToolStripMenuItem.Click += new System.EventHandler(this.createVersionDirectoryToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openBTD6DirectoryToolStripMenuItem,
            this.openVersionDirectoryToolStripMenuItem});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(168, 26);
            this.toolStripDropDownButton3.Text = "Open Directories";
            // 
            // openBTD6DirectoryToolStripMenuItem
            // 
            this.openBTD6DirectoryToolStripMenuItem.Name = "openBTD6DirectoryToolStripMenuItem";
            this.openBTD6DirectoryToolStripMenuItem.Size = new System.Drawing.Size(285, 26);
            this.openBTD6DirectoryToolStripMenuItem.Text = "Open BTD6 Directory";
            this.openBTD6DirectoryToolStripMenuItem.Click += new System.EventHandler(this.openBTD6DirectoryToolStripMenuItem_Click);
            // 
            // openVersionDirectoryToolStripMenuItem
            // 
            this.openVersionDirectoryToolStripMenuItem.Name = "openVersionDirectoryToolStripMenuItem";
            this.openVersionDirectoryToolStripMenuItem.Size = new System.Drawing.Size(285, 26);
            this.openVersionDirectoryToolStripMenuItem.Text = "Open Version Directory";
            this.openVersionDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openVersionDirectoryToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("Oetztype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(116, 26);
            this.toolStripButton1.Text = "How to use";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(85, 26);
            this.toolStripButton2.Text = "Settings";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // VersionComboBox
            // 
            this.VersionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VersionComboBox.Font = new System.Drawing.Font("Oetztype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionComboBox.FormattingEnabled = true;
            this.VersionComboBox.Location = new System.Drawing.Point(945, 39);
            this.VersionComboBox.Name = "VersionComboBox";
            this.VersionComboBox.Size = new System.Drawing.Size(74, 28);
            this.VersionComboBox.TabIndex = 5;
            this.VersionComboBox.SelectedIndexChanged += new System.EventHandler(this.VersionComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Red;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Oetztype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(784, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Selected Version:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Black;
            this.groupBox1.Controls.Add(this.RefreshButton);
            this.groupBox1.Controls.Add(this.AddModsButton);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Font = new System.Drawing.Font("Oetztype", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(12, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1007, 556);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mods";
            // 
            // RefreshButton
            // 
            this.RefreshButton.Font = new System.Drawing.Font("Oetztype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshButton.ForeColor = System.Drawing.Color.Black;
            this.RefreshButton.Location = new System.Drawing.Point(907, 4);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(100, 29);
            this.RefreshButton.TabIndex = 10;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // AddModsButton
            // 
            this.AddModsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AddModsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddModsButton.Font = new System.Drawing.Font("Oetztype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddModsButton.ForeColor = System.Drawing.Color.Black;
            this.AddModsButton.Location = new System.Drawing.Point(114, 4);
            this.AddModsButton.Name = "AddModsButton";
            this.AddModsButton.Size = new System.Drawing.Size(157, 29);
            this.AddModsButton.TabIndex = 9;
            this.AddModsButton.Text = "Add Mods";
            this.AddModsButton.UseVisualStyleBackColor = false;
            this.AddModsButton.Click += new System.EventHandler(this.AddModsButton_Click);
            // 
            // panel5
            // 
            this.panel5.AutoScroll = true;
            this.panel5.Location = new System.Drawing.Point(6, 32);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(995, 518);
            this.panel5.TabIndex = 8;
            // 
            // LaunchButton
            // 
            this.LaunchButton.BackColor = System.Drawing.Color.Lime;
            this.LaunchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LaunchButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LaunchButton.Font = new System.Drawing.Font("Oetztype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LaunchButton.Location = new System.Drawing.Point(453, 41);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(122, 26);
            this.LaunchButton.TabIndex = 9;
            this.LaunchButton.Text = "Launch";
            this.LaunchButton.UseVisualStyleBackColor = false;
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // LogButton
            // 
            this.LogButton.Location = new System.Drawing.Point(703, 43);
            this.LogButton.Name = "LogButton";
            this.LogButton.Size = new System.Drawing.Size(75, 23);
            this.LogButton.TabIndex = 10;
            this.LogButton.Text = "Log";
            this.LogButton.UseVisualStyleBackColor = true;
            this.LogButton.Click += new System.EventHandler(this.LogButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1031, 636);
            this.Controls.Add(this.LogButton);
            this.Controls.Add(this.LaunchButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.VersionComboBox);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Oetztype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox VersionComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem importDLLModsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createDLLModsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createVersionDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem openBTD6DirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openVersionDirectoryToolStripMenuItem;
        private System.Windows.Forms.Label CloseButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button AddModsButton;
        private System.Windows.Forms.Button LaunchButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button LogButton;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}

