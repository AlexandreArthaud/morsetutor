using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Morse_Tutor
{
    public partial class Form1 : Form
    {
        static bool LetterHasPlayed = false;
        static bool WordHasPlayed = false;

        public Form1()
        {
            InitializeComponent();
            Text = "Morse Tutor";

            pictureBox1.ImageLocation = Properties.Resources.MorseCodeImagePath;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.BackColor = Color.White;

            checkBox1.Checked = true;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!LetterHasPlayed)
            {
                label1.Text = "Waiting for an answer...";
                LetterHasPlayed = true;
                textBox1.Enabled = true;
                button1.Text = "Replay";

                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    RandomLetterExercice();
                }).Start();
            }
            else
            {
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    RandomLetterExercice(Program.PlayedLetter);
                }).Start();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                pictureBox1.BackColor = Color.White;
            }
            else
            {
                pictureBox1.BackColor = Color.Black;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!WordHasPlayed)
            {
                // init random word exercice
                WordHasPlayed = true;
                textBox2.Enabled = true;
                button2.Text = "Replay";

                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    RandomWordExercice();
                }).Start();

            }
            else
            {
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    RandomWordExercice(Program.PlayedWord);
                }).Start();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0 && textBox2.Text == Program.PlayedWord)
            {
                label2.Text = "Sucess! Answer was indeed: " + Program.PlayedWord;
                
                // reinit random word exercice
                WordHasPlayed = false;
                textBox2.Enabled = false;
                button2.Text = "RANDOM WORD";
                textBox2.Text = "";
            }
        }

        private void RandomLetterExercice(char letter = '\0')
        {
            label1.Text = "Playing letter";
            textBox1.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;

            if (letter != '\0')
                Program.PlayLetter(letter);
            else
                Program.PlayLetter();

            label1.Text = "Waiting for answer";
            textBox1.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void RandomWordExercice(string word="")
        {
            label2.Text = "Playing word";
            textBox2.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;

            if (word != "")
                Program.PlayWord(Program.PlayedWord);
            else
                Program.PlayWord();

            label2.Text = "Waiting for answer";
            textBox2.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
        }
    }
}
