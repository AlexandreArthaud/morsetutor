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
        static bool LetterHasPlayed = false;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.ImageLocation = Properties.Resources.MorseCodeImagePath;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!LetterHasPlayed)
            {
                Program.PlayLetter();

                label1.Text = "Waiting for an answer...";
                LetterHasPlayed = true;
                textBox1.Enabled = true;
                button1.Text = "Replay";
            }
            else
            {
                Program.PlayLetter(Program.PlayedLetter);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox1.Text[0] == Program.PlayedLetter)
            {
                label1.Text = "Sucess! Answer was indeed: " + Program.PlayedLetter;
                
                LetterHasPlayed = false;
                textBox1.Enabled = false;
                button1.Text = "RANDOM LETTER";
                textBox1.Text = "";
            }
        }
    }
}
