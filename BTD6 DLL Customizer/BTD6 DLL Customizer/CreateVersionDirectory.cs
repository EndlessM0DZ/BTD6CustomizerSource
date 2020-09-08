using BTD6DLLCreator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTD6_DLL_Customizer
{
    public partial class CreateVersionDirectory : Form
    {
        public string version = "";
        string currentDir;
        public Point mouseLocation = new Point();
        List<EndlessLog> logs = new List<EndlessLog>();
        public string gameDir = SteamUtils.GetGameDir(960090, "BloonsTD6");
        public string steamDir = SteamUtils.GetSteamDir();
        public string Log = "";
        public bool reachedCreate = false;
        Color background, TextForeColor, Window;
        public CreateVersionDirectory()
        {
            InitializeComponent();
        }
        public CreateVersionDirectory(string currentDir, Color background, Color TextForeColor, Color Window, List<EndlessLog> logs, string Log)
        {
            try
            {
                InitializeComponent();
                this.BackColor = background;
                this.panel1.BackColor = Window;
                this.panel2.BackColor = Window;
                this.panel3.BackColor = Window;
                this.panel4.BackColor = Window;
                this.currentDir = currentDir;
                this.logs = logs;
                this.Log = Log;
                this.background = background;
                this.TextForeColor = TextForeColor;
                this.Window = Window;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedPath = "";
                if (VersionBox.Text != "" && VersionBox.Text != null)
                {
                    selectedPath = currentDir + "\\Versions\\" + VersionBox.Text;
                    bool exists = System.IO.Directory.Exists(selectedPath);
                    if (!exists)
                    {
                        System.IO.Directory.CreateDirectory(selectedPath);
                        System.IO.Directory.CreateDirectory(selectedPath + "\\Default");
                        System.IO.Directory.CreateDirectory(selectedPath + "\\Modded DLLs");
                        System.IO.Directory.CreateDirectory(selectedPath + "\\Output");
                        MessageBox.Show("Directories created successfully!");
                        Log += "CREATED DIR" + Environment.NewLine + selectedPath + Environment.NewLine + Environment.NewLine;
                        Log += "CREATED DIR" + Environment.NewLine + selectedPath + "\\Default" + Environment.NewLine + Environment.NewLine;
                        Log += "CREATED DIR" + Environment.NewLine + selectedPath + "\\Modded DLLs" + Environment.NewLine + Environment.NewLine;
                        Log += "CREATED DIR" + Environment.NewLine + selectedPath + "\\Output" + Environment.NewLine + Environment.NewLine;
                        if (logs.Count > 0)
                        {
                            logs[0].textBox1.Text = Log;
                        }
                        reachedCreate = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Version folder already exists!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Credits credits = new Credits(background, TextForeColor, Window);
            credits.ShowDialog();
        }
    }
}
