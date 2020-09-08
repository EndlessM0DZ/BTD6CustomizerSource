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
    public partial class CustomSpeed : Form
    {
        public int speed = 10;
        Color background, TextForeColor, Window;
        Point mouseLocation = new Point();
        public CustomSpeed()
        {
            InitializeComponent();
        }
        public CustomSpeed(Color background, Color TextForeColor, Color Window)
        {
            try
            {
                InitializeComponent();
                this.BackColor = background;
                this.EnterCustomSpeedLabel.ForeColor = TextForeColor;
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

        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(SpeedText.Text) > 0 && Convert.ToInt32(SpeedText.Text) <= 2147483647)
                {
                    speed = Convert.ToInt32(SpeedText.Text);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Enter a number from 1 to 2147483647");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Enter a number from 1 to 2147483647");
            }
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Credits credits = new Credits(background, TextForeColor, Window);
            credits.ShowDialog();
        }
    }
}
