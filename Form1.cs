using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Morse_Tutor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.ImageLocation = Properties.Resources.MorseCodeImagePath;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Program.PlayLetter();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == Program.PlayedLetter)
            {
                label1.Text = "SUCCESS! \n\n Answer was indeed: " + Program.PlayedLetter;
                textBox1.Text = "";
            }
        }
    }
}
