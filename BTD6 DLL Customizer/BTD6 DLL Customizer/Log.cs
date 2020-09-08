using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTD6_DLL_Customizer
{
    public partial class EndlessLog : Form
    {
        public Point mouseLocation = new Point();
        Color background, TextForeColor, Window;
        public EndlessLog()
        {
            InitializeComponent();
        }
        public EndlessLog(Color background, Color TextForeColor, Color Window)
        {
            try
            {
                InitializeComponent();
                this.BackColor = background;
                this.textBox1.BackColor = background;
                this.textBox1.ForeColor = TextForeColor;
                this.panel1.BackColor = Window;
                this.panel2.BackColor = Window;
                this.panel3.BackColor = Window;
                this.panel4.BackColor = Window;
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

        private void EndlessLog_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.ScrollToCaret();
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
