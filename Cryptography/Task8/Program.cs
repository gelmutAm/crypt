using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;
using Task2;

namespace Task8
{
    public class Program
    {
        public static string PairEncryption(List<char> alphabet, string keyWord, string text)
        {
            StringBuilder result = new StringBuilder();
            List<char> tempAlphabet = new List<char>();
            
            tempAlphabet.AddRange(alphabet);

            keyWord = new string(keyWord.Distinct().ToArray());

            for(int i = 0; i < keyWord.Length; i++)
            {
                tempAlphabet.RemoveAt(tempAlphabet.IndexOf(keyWord[i]));
            }

            for(int i = 0; i < text.Length; i++)
            {
                if(tempAlphabet.Contains(text[i]))
                {
                    result.Append(keyWord[tempAlphabet.IndexOf(text[i])]);
                }
                else
                {
                    result.Append(tempAlphabet[keyWord.IndexOf(text[i])]);
                }
            }

            return result.ToString();
        }

        public static void Main(string[] args)
        {
            List<char> alphabet = new List<char> { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л',
                'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я',
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', '?', '!', ',', ';', ':', '-', '(', ')', '"',
                ' ', '\n', '\r'};

            string text = FileManager.Read("input.txt");
            text = text.ToLower();

            string cipher = PairEncryption(alphabet, "аабвгдеёжзийклмнопрстуфхцчшщъ", text);
            Console.WriteLine(cipher);
            Console.WriteLine(PairEncryption(alphabet, "абвгдеёжзийклмнопрстуфхцчшщъ", cipher));
        }
    }
}
