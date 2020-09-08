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
    public partial class HowToUse : Form
    {
        public Point mouseLocation = new Point();
        Color background, TextForeColor, Window;
        public HowToUse()
        {
            InitializeComponent();
        }
        public HowToUse(Color background, Color TextForeColor, Color Window)
        {
            try
            {
                InitializeComponent();
                this.BackColor = background;
                this.label1.ForeColor = TextForeColor;
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

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Credits credits = new Credits(background, TextForeColor, Window);
            credits.ShowDialog();
        }
    }
}
