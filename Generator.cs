using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Password_Generator
{
    class Generator
    {
        Random rnd;
        private List<string> Numbers;
        private List<string> Symbols;
        private List<string> AlphaUpper;
        private List<string> AlphaLower;
        public string Password;

        public Generator()
        {
            rnd = new Random(DateTime.Now.Millisecond);
            Numbers = new List<string>() {"0123456789"};
            AlphaUpper = new List<string>() {"ABCDEFGHIJKLMNOPQRSTUVWXYZ"};
            AlphaLower = new List<string>() { "abcdefghijklmnopqrstuvwxyz"};
            Symbols = new List<string>() {"!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ "};
        }

        public string PasswordGenerate(int size, bool num, bool sym, bool UpA, bool LowA)
        {
            Password = null;
            string buf = null;
            if (UpA == true)
            {
                foreach (string s in AlphaUpper)
                {
                    buf += s;
                }
            }
            if (LowA == true)
            {
                foreach (string s in AlphaLower)
                {
                    buf += s;
                }
            }
            if (num == true)
            {

                foreach (string s in Numbers)
                {
                    buf += s;
                }
            }
            if (sym == true)
            {
                foreach (string s in Symbols)
                {
                    buf += s;
                }
            }
            for (int i = 0; i < size; i++)
            {
                Password += buf[rnd.Next(buf.Length)];
            }
            return Password;
        }
        public string UserPasswordGenerate(int size, string symbols)
        {
            Password = null;
            for (int i = 0; i < size; i++)
            {
                Password += symbols[rnd.Next(symbols.Length)];
            }
            return Password;
        }
    }
}
