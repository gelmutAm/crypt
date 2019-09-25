using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;
using Task2;

namespace Task12
{
    public class Program
    {
        public static string LFSR(int textLength, List<char> alphabet)
        {
            StringBuilder key = new StringBuilder();
            int maxIndexLength = Convert.ToString(alphabet.Count - 1, 2).Length;
            int cipherLength = maxIndexLength * textLength;
            int registerLength = (int)Math.Log((double)cipherLength, 2);

            List<int> startRegister = new List<int>();
            Random random = new Random();
            for(int i = 0; i < registerLength; i++)
            {
                startRegister.Add(random.Next(0, 1));
            }

            while(key.Length < cipherLength)
            {
                startRegister.Insert(0, Task1.Program.Mod((startRegister[0] + startRegister[startRegister.Count - 1]), 2));
                key.Append(startRegister[startRegister.Count - 1]);
                startRegister.RemoveAt(startRegister[startRegister.Count - 1]);
            }

            return key.ToString();
        }

        public static string AddZero(string str, int maxLength)
        {
            StringBuilder result = new StringBuilder();
            int strLength = str.Length;

            while (strLength < maxLength)
            {
                result.Append('0');
                strLength++;
            }

            return result.ToString();
        }

        public static string XorEncryption(List<char> alphabet, string key, string text)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder textCipher = new StringBuilder();
            int maxIndexLength = Convert.ToString(alphabet.Count - 1, 2).Length;

            int j = 0;
            for (int i = 0; i < text.Length; i++)
            {
                string tempForText = Convert.ToString(alphabet.IndexOf(text[i]), 2);

                if (tempForText.Length < maxIndexLength)
                {
                    textCipher.Append(AddZero(tempForText, maxIndexLength));
                }

                textCipher.Append(tempForText);
            }

            for (int i = 0; i < textCipher.Length; i++)
            {
                result.Append(Task1.Program.Mod(int.Parse(textCipher[i].ToString()) + int.Parse(key[i].ToString()), 2));
            }

            return result.ToString();
        }

        public static string XorDecryption(List<char> alphabet, string key, string cipher)
        {
            StringBuilder result = new StringBuilder();
            int maxIndexLength = Convert.ToString(alphabet.Count - 1, 2).Length;
                      
            StringBuilder originalTextBin = new StringBuilder();

            for (int i = 0; i < cipher.Length; i++)
            {
                originalTextBin.Append(Task1.Program.Mod(int.Parse(cipher[i].ToString()) + int.Parse(key[i].ToString()), 2));
            }

            for (int i = 0; i < originalTextBin.Length; i += maxIndexLength)
            {
                string temp = originalTextBin.ToString().Substring(i, maxIndexLength);

                result.Append(alphabet[Convert.ToInt32(temp, 2)]);
            }

            return result.ToString();
        }

        public static void Main(string[] args)
        {
            string text = FileManager.Read("input.txt");
            text = text.ToLower();

            List<char> alphabet = new List<char> { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л',
                'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я',
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', '?', '!', ',', ';', ':', '-', '(', ')', '"',
                ' ', '\n', '\r'};

            string key = LFSR(text.Length, alphabet);

            string cipher = XorEncryption(alphabet, key, text);
            Console.WriteLine(cipher);
            Console.WriteLine(XorDecryption(alphabet, key, cipher));
        }
    }
}
