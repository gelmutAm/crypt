using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;

namespace Task10
{
    public class Program
    {
        public static string ColumnTranspositionEncryption(string keyWord, string text)
        {
            StringBuilder result = new StringBuilder();
            int rowCount = text.Length % keyWord.Length == 0 ? text.Length / keyWord.Length : text.Length / keyWord.Length + 1;
            List<List<char>> matrix = new List<List<char>>();
            StringBuilder textCopy = new StringBuilder(text);

            for(int i = 0; i < rowCount; i++)
            {
                List<char> temp = new List<char>();

                for (int j = 0; j < keyWord.Length; j++)
                {
                    if (textCopy.Length == 0)
                    {
                        break;
                    }

                    temp.Add(textCopy[0]);
                    textCopy.Remove(0, 1);
                }

                matrix.Add(temp);
            }

            List<char> sortedKeyWord = keyWord.ToList();

            sortedKeyWord.Sort();

            int count = 0;
            int difference = keyWord.Length * rowCount - text.Length;
            int originalRowCount = rowCount;
            while(count < keyWord.Length)
            {
                int columnIndex = keyWord.IndexOf(sortedKeyWord[count]);
                rowCount = originalRowCount; 

                if (columnIndex >= keyWord.Length - difference)
                {
                    rowCount -= 1;
                }

                for(int i = 0; i < rowCount; i++)
                {
                    result.Append(matrix[i][columnIndex]);
                }

                count++;                
            }

            return result.ToString();
        }

        public static string ColumnTranspositionDecryption(string keyWord, string cipher)
        {
            StringBuilder result = new StringBuilder();
            int rowCount = cipher.Length % keyWord.Length == 0 ? cipher.Length / keyWord.Length : cipher.Length / keyWord.Length + 1;
            List<char> sortedKeyWord = keyWord.ToList();
            sortedKeyWord.Sort();

            List<List<char>> matrix = new List<List<char>>();
            int originalRowCount = rowCount;
            StringBuilder cipherCopy = new StringBuilder(cipher);
            int i = 0;
            while (i < keyWord.Length)
            {
                rowCount = originalRowCount;

                if(keyWord.IndexOf(sortedKeyWord[i]) > keyWord.Length - (keyWord.Length * rowCount - cipher.Length))
                {
                    rowCount -= 1;
                }

                List<char> temp = new List<char>();

                for(int j = 0; j < rowCount; j++)
                {
                    if(cipherCopy.Length == 0)
                    {
                        break;
                    }

                    temp.Add(cipherCopy[0]);
                    cipherCopy.Remove(0, 1);
                }

                matrix.Add(temp);
                i++;
            }

            int columnIndex = 0;
            while(columnIndex < rowCount)
            {
                for (int j = 0; j < keyWord.Length; j++)
                {
                    if(result.Length == cipher.Length)
                    {
                        break;
                    }

                    result.Append(matrix[sortedKeyWord.IndexOf(keyWord[j])][columnIndex]);
                }

                columnIndex++;
            }

            return result.ToString();
        }

        public static void Main(string[] args)
        {
            //string text = FileManager.Read("input.txt");
            //text = text.ToLower();

            string cipher = ColumnTranspositionEncryption("пушкин", "деладавноминувшихднейпреданьястариныглубокой");
            Console.WriteLine(cipher);
            Console.WriteLine(ColumnTranspositionDecryption("пушкин", cipher));
        }
    }
}
