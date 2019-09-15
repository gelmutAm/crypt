using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;
using Task3;

namespace Task4
{
    class Program
    {
        public static List<List<char>> GetPolybiusMatrix(List<char> alphabet)
        {
            List<List<char>> matrix = new List<List<char>>();
            int boundary = Math.Sqrt(alphabet.Count) % 1 == 0 ? (int)Math.Sqrt(alphabet.Count) : (int)Math.Sqrt(alphabet.Count) + 1;

            for (int i = 0; i < boundary; i++)
            {
                List<char> temp = new List<char>();

                if(alphabet.Count - boundary >= 0)
                {             
                    for (int j = 0; j < boundary; j++)
                    {
                        temp.Add(alphabet[j]);
                    }

                    matrix.Add(temp);
                    alphabet.RemoveRange(0, boundary);
                }
                else
                {
                    for(int j = 0; j < alphabet.Count; j++)
                    {
                        temp.Add(alphabet[j]);
                    }

                    matrix.Add(temp);
                    break;
                }
            }

            return matrix;
        }

        public static string Encrypt(List<List<char>> matrix, string text)
        {
            StringBuilder result = new StringBuilder();

            for(int i = 0; i < text.Length; i++)
            {
                int columnIndex = -1;
                int rowIndex = -1;
                for(columnIndex = 0; columnIndex < matrix.Count; columnIndex++)
                {
                    if(matrix[columnIndex].Contains(text[i]))
                    {
                        rowIndex = matrix[columnIndex].IndexOf(text[i]);
                        break;
                    }
                }

                result.AppendFormat($"{columnIndex}{rowIndex}");
            }

            return result.ToString();
        }

        public static string Decrypt(List<List<char>> matrix, string text)
        {
            StringBuilder result = new StringBuilder();

            for(int i = 0; i < text.Length; i += 2)
            {
                result.Append(matrix[int.Parse(text[i].ToString())][int.Parse(text[i + 1].ToString())]);
            }

            return result.ToString();
        }

        static void Main(string[] args)
        {
            List<char> alphabet = new List<char> { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л',
                'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я',
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', '?', '!', ',', ';', ':', '-', '(', ')', '"', ' ' };

            List<List<char>> matrix = GetPolybiusMatrix(alphabet);

            string text = FileManager.Read("input.txt");
            text = text.ToLower();

            string cipher = Encrypt(matrix, text);
            Console.WriteLine(cipher);
            Console.WriteLine(Decrypt(matrix, cipher));

        }
    }
}
