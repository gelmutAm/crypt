using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;
using Task2;

namespace Task7
{
    public class Program
    {
        public static string CaesarKeyEncryption(List<char> alphabet, string keyWord, string text)
        {
            StringBuilder result = new StringBuilder();

            int j = 0;
            for(int i = 0; i < text.Length; i++)
            {
                if(j == keyWord.Length - 1)
                {
                    j = 0;
                }

                int index = Task1.Program.Mod(alphabet.IndexOf(text[i]) + alphabet.IndexOf(keyWord[j]), alphabet.Count());
                result.Append(alphabet[index]);
                j++;
            }

            return result.ToString();
        }

        public static string CaesarKeyDecryption(List<char> alphabet, string keyWord, string cipher)
        {
            StringBuilder result = new StringBuilder();

            int j = 0;
            for (int i = 0; i < cipher.Length; i++)
            {
                if (j == keyWord.Length - 1)
                {
                    j = 0;
                }

                int originalTextValueIndex = Task1.Program.Mod(alphabet.IndexOf(cipher[i]) + alphabet.Count - alphabet.IndexOf(keyWord[j]),
                    alphabet.Count);
                result.Append(alphabet[originalTextValueIndex]);
                j++;
            }

            return result.ToString();
        }

        public static void Main(string[] args)
        {
            List<char> alphabet = new List<char> { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л',
                'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я',
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', '?', '!', ',', ';', ':', '-', '(', ')', '"', ' ' };

            //string text = FileManager.Read("input.txt");
            //text = text.ToLower();

            string cipher = CaesarKeyEncryption(alphabet, "арт", "привет");
            Console.WriteLine(cipher);
            Console.WriteLine(CaesarKeyDecryption(alphabet, "арт", cipher));
        }
    }
}
