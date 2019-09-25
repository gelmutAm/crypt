using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;
using Task2;

namespace Task9
{
    public class Program
    {
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

        public static string XorEncryption(List<char> alphabet, string keyWord, string text)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder textCipher = new StringBuilder();
            StringBuilder keyWordCipher = new StringBuilder();
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

                if (j == keyWord.Length - 1)
                {
                    j = 0;
                }

                string tempForKey = Convert.ToString(alphabet.IndexOf(keyWord[j]), 2);

                if (tempForKey.Length < maxIndexLength)
                {
                    keyWordCipher.Append(AddZero(tempForKey, maxIndexLength));
                }

                keyWordCipher.Append(tempForKey);
                j++;
            }

            for (int i = 0; i < textCipher.Length; i++)
            {
                result.Append(Task1.Program.Mod(int.Parse(textCipher[i].ToString()) + int.Parse(keyWordCipher[i].ToString()), 2));
            }

            return result.ToString();
        }

        public static string XorDecryption(List<char> alphabet, string keyWord, string cipher)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder keyWordCipher = new StringBuilder();
            int maxIndexLength = Convert.ToString(alphabet.Count - 1, 2).Length;

            int j = 0;
            for (int i = 0; i < cipher.Length / maxIndexLength; i++)
            {
                if (j == keyWord.Length - 1)
                {
                    j = 0;
                }

                string tempForKey = Convert.ToString(alphabet.IndexOf(keyWord[j]), 2);

                if (tempForKey.Length < maxIndexLength)
                {
                    keyWordCipher.Append(AddZero(tempForKey, maxIndexLength));
                }

                keyWordCipher.Append(tempForKey);
                j++;
            }

            StringBuilder originalTextBin = new StringBuilder();

            for (int i = 0; i < cipher.Length; i++)
            {
                originalTextBin.Append(Task1.Program.Mod(int.Parse(cipher[i].ToString()) + int.Parse(keyWordCipher[i].ToString()), 2));
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

            string cipher = XorEncryption(alphabet, "абвгдеёжзиклмн", text);
            Console.WriteLine(cipher);
            Console.WriteLine(XorDecryption(alphabet, "абвгдеёжзиклмн", cipher));
        }
    }
}
