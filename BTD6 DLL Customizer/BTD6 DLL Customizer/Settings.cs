using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTD6_DLL_Customizer
{
    public partial class Settings : Form
    {
        public bool changedColors = false;
        string[] colorsString = { "White", "Black", "Red", "Orange", "Yellow", "Green", "Blue", "Purple" };
        Color[] colors = { Color.White, Color.Black, Color.Red, Color.Orange, Color.Yellow, Color.LimeGreen, Color.Green, Color.Blue, Color.Purple };
        Color[] allColors = {
        Color.AliceBlue, Color.AntiqueWhite, Color.Aqua, Color.Aquamarine, Color.Azure, Color.Beige, Color.Bisque, Color.Black, Color.BlanchedAlmond,
        Color.Blue, Color.BlueViolet, Color.Brown, Color.BurlyWood, Color.CadetBlue, Color.Chartreuse, Color.Chocolate, Color.Coral, Color.CornflowerBlue,
        Color.Cornsilk, Color.Crimson, Color.Cyan, Color.DarkCyan, Color.DarkGoldenrod, Color.DarkGray, Color.DarkGreen, Color.DarkKhaki, Color.DarkMagenta,
        Color.DarkOliveGreen, Color.DarkOrange, Color.DarkOrchid, Color.DarkRed, Color.DarkSalmon, Color.DarkSeaGreen, Color.DarkSlateBlue, Color.DarkSlateGray,
        Color.DarkTurquoise, Color.DarkViolet, Color.DeepPink, Color.DeepSkyBlue, Color.DimGray, Color.DodgerBlue, Color.Firebrick, Color.FloralWhite, Color.ForestGreen,
        Color.Fuchsia, Color.Gainsboro, Color.GhostWhite, Color.Gold, Color.Goldenrod, Color.Gray, Color.Green, Color.GreenYellow, Color.Honeydew, Color.HotPink, Color.IndianRed,
        Color.Indigo, Color.Ivory, Color.Khaki, Color.Lavender, Color.LavenderBlush, Color.LawnGreen, Color.LemonChiffon, Color.LightBlue, Color.LightCoral, Color.LightCyan, Color.LightGoldenrodYellow,
        Color.LightGray, Color.LightGreen, Color.LightPink, Color.LightSalmon, Color.LightSeaGreen, Color.LightSkyBlue, Color.LightSlateGray, Color.LightSteelBlue, Color.LightYellow, Color.Lime,
        Color.LimeGreen, Color.Linen, Color.Magenta, Color.Maroon, Color.MediumAquamarine, Color.MediumBlue, Color.MediumOrchid, Color.MediumPurple, Color.MediumSeaGreen, Color.MediumSlateBlue,
        Color.MediumSpringGreen, Color.MediumTurquoise, Color.MediumVioletRed, Color.MidnightBlue, Color.MintCream, Color.MistyRose, Color.Moccasin, Color.NavajoWhite, Color.Navy, Color.OldLace,
        Color.Olive, Color.OliveDrab, Color.Orange, Color.OrangeRed, Color.Orchid, Color.PaleGoldenrod, Color.PaleGreen, Color.PaleTurquoise, Color.PaleVioletRed, Color.PapayaWhip, Color.PeachPuff,
        Color.Peru, Color.Pink, Color.Plum, Color.PowderBlue, Color.Purple, Color.Red, Color.RosyBrown, Color.RoyalBlue, Color.SaddleBrown, Color.Salmon, Color.SandyBrown, Color.SeaGreen, Color.SeaShell,
        Color.Sienna, Color.Silver, Color.SkyBlue, Color.SlateBlue, Color.SlateGray, Color.Snow, Color.SpringGreen, Color.SteelBlue, Color.Tan, Color.Teal, Color.Thistle, Color.Tomato, Color.Transparent,
        Color.Turquoise, Color.Violet, Color.Wheat, Color.White, Color.WhiteSmoke, Color.Yellow, Color.YellowGreen
        };
        public Point mouseLocation = new Point();
        public List<Color> selectedColors = new List<Color>();
        Color background, TextForeColor1, Window;
        public Settings()
        {
            InitializeComponent();
        }
        public Settings(Color Window, Color background, Color TextForeColor1, Color TextForeColor2, Color Enabled, Color Disabled, Color CloseButton)
        {
            try
            {
                InitializeComponent();
                Color[] inputColors = { Window, background, TextForeColor1, TextForeColor2, Enabled, Disabled, CloseButton };
                ComboBox[] comboBoxs = { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox6, comboBox7 };
                this.BackColor = background;
                this.groupBox1.ForeColor = TextForeColor1;
                foreach (Control c in this.Controls)
                {
                    if (c is ComboBox)
                    {
                        Label l = (Label)c;
                        l.ForeColor = TextForeColor1;
                    }
                }
                this.panel1.BackColor = Window;
                this.panel2.BackColor = Window;
                this.panel3.BackColor = Window;
                this.panel4.BackColor = Window;
                this.background = background;
                this.TextForeColor1 = TextForeColor1;
                this.Window = Window;
                for (int i = 0; i < inputColors.Length; i++)
                {
                    for (int j = 0; j < allColors.Length; j++)
                    {
                        if (inputColors[i] == allColors[j])
                        {
                            comboBoxs[i].SelectedIndex = j;
                        }
                    }
                }
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                ComboBox[] comboBoxs = { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox6, comboBox7 };
                for (int i = 0; i < comboBoxs.Length; i++)
                {
                    selectedColors.Add(allColors[comboBoxs[i].SelectedIndex]);
                }
                changedColors = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Settings_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void Settings_Leave(object sender, EventArgs e)
        {
            
        }

        private void Settings_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Credits credits = new Credits(background, TextForeColor1, Window);
            credits.ShowDialog();
        }
    }
}
