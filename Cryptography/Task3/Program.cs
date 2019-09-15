using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;

namespace Task3
{
    public class Program
    {
        public static string FromTextToWordsSequence(string text)
        {
            char[] symbolsToRemove = new char[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', '?', '!', ',', ';',
                ':', '-', '(', ')', '"', '\n', '\r' };

            StringBuilder wordsSequence = new StringBuilder(text);

            for (int i = 0; i < wordsSequence.Length;)
            {
                if (symbolsToRemove.Contains(wordsSequence[i]))
                {
                    wordsSequence.Remove(i, 1);
                }
                else
                {
                    i++;
                }
            }

            return wordsSequence.ToString();
        }

        public static void Main(string[] args)
        {
            string text = FileManager.Read("input.txt");
            text = text.ToLower();
            text = FromTextToWordsSequence(text);

            Dictionary<string, int> pair = new Dictionary<string, int>();

            int totalPairCount = 0;

            for(int i = 0; i < text.Length - 1; i++)
            {
                StringBuilder temp = new StringBuilder();

                if (text[i] != ' ' && text[i + 1] != ' ')
                {
                    temp.Append(text[i]);
                    temp.Append(text[i + 1]);

                    totalPairCount++;

                    if (!pair.Keys.Contains(temp.ToString()))
                    {
                        pair.Add(temp.ToString(), 1);
                    }
                    else
                    {
                        pair[temp.ToString()]++;
                    }
                }
            }

            foreach(var key in pair.Keys)
            {
                Console.WriteLine($"{key} - {Math.Round((double)pair[key] / totalPairCount, 3)}");
                FileManager.Write("output.txt", $"{key} - {Math.Round((double)pair[key] / totalPairCount, 3)}");
            }
        }
    }
}
