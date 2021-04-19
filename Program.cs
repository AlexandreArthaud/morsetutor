using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Morse_Tutor
{
    enum Letters
    {
        A = 1,
    }

    static class Program
    {
        static Random Rand = new Random();
        static internal char PlayedLetter;
        static internal string PlayedWord;
        static int UnitLength = 500;
        static int Frequency = 1000;
        static Dictionary<char, string> Letters = new Dictionary<char, string> {
            { 'a', "sL"},
            { 'b', "Lsss"},
            { 'c', "LsLs"},
            { 'd', "Lss" },
            { 'e', "s" },
            { 'f', "ssLs" },
            { 'g', "LLs" },
            { 'h', "ssss" },
            { 'i', "ss" },
            { 'j', "sLLL" },
            { 'k', "LsL" },
            { 'l', "sLss" },
            { 'm', "LL" },
            { 'n', "Ls" },
            { 'o', "LLL" },
            { 'p', "sLLs" },
            { 'q', "LLsL" },
            { 'r', "sLs" },
            { 's', "sss" },
            { 't', "L" },
            { 'u', "ssL" },
            { 'v', "sssL" },
            { 'w', "sLL" },
            { 'x', "LssL" },
            { 'y', "LsLL" },
            { 'z', "LLss" },
            { '1', "sLLLL" },
            { '2', "ssLLL" },
            { '3', "sssLL" },
            { '4', "ssssL" },
            { '5', "sssss" },
            { '6', "Lssss" },
            { '7', "LLsss" },
            { '8', "LLLss" },
            { '9', "LLLLs" },
            { '0', "LLLLL" },
        };

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        internal static void PlayLetter(char letter)
        {
            if (Letters.ContainsKey(letter))
            {
                char last = Letters[letter].Last();
                foreach (char l in Letters[letter])
                {
                    int length = UnitLength;
                    if (l == 'L')
                        length = UnitLength * 3;

                    Console.Beep(Frequency, length);

                    if (l != last)
                        Thread.Sleep(UnitLength); // pause between letters
                }
            }
        }

        internal static void PlayLetter()
        {
            var randomLetter = Letters.ElementAt(Rand.Next(0, Letters.Count())).Key;
            
            PlayLetter(randomLetter);
            PlayedLetter = randomLetter;
        }

        internal static void PlayWord()
        {
            var lines = Properties.Resources.top_100_words.Split(
                new string[] { "\r\n" }, StringSplitOptions.None);
            var randomWord = lines.ElementAt(Rand.Next(0, lines.Count()));

            PlayWord(randomWord);
            PlayedWord = randomWord;
        }

        internal static void PlayWord(string word)
        {

            char lastLetter = word.Last();
            foreach (char letter in word)
            {
                PlayLetter(letter);

                if (letter != lastLetter)
                {
                    Thread.Sleep(UnitLength * 3);
                }
            }
        }
    }
}
