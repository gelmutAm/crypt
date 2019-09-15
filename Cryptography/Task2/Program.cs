using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Program
    {
        public static string FromTextToLettersSequence(string text)
        {
            char[] symbolsToRemove = new char[] { ' ', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', '?', '!', ',', ';',
                ':', '-', '(', ')', '"', '\n', '\r' };

            StringBuilder lettersSequence = new StringBuilder(text);

            for (int i = 0; i < lettersSequence.Length;)
            {
                if (symbolsToRemove.Contains(lettersSequence[i]))
                {
                    lettersSequence.Remove(i, 1);
                }
                else
                {
                    i++;
                }
            }

            return lettersSequence.ToString();
        }

        public static void Main(string[] args)
        {
            List<char> alphabet = new List<char> { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л',
                'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };

            string text = FileManager.Read("input.txt");
            Console.WriteLine(text);

            text = text.ToLower();
            text = FromTextToLettersSequence(text);

            double[] charCount = new double[33];

            for (int i = 0; i < text.Length; i++)
            {
                charCount[alphabet.IndexOf(text[i])]++;
            }

            for (int i = 0; i < charCount.Length; i++)
            {
                charCount[i] /= text.Length;
            }

            Console.WriteLine();

            for(int i = 0; i < alphabet.Count; i++)
            {
                Console.WriteLine($"{alphabet[i]} - {Math.Round(charCount[i], 3)}");
                FileManager.Write("output.txt", $"{alphabet[i]} - {Math.Round(charCount[i], 3)}");
            }
        }
    }
}
