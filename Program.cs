using System;
using System.Collections.Generic;
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
        static internal string PlayedLetter = "";
        static int UnitLength = 1000;
        static int Frequency = 2000;
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
            Random rand = new Random();
            var randomLetter = Letters.ElementAt(rand.Next(0, Letters.Count)).Key;
            
            PlayLetter(randomLetter);

            PlayedLetter = randomLetter.ToString();
        }
    }
}
