using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        public static int Mod(int dividend, int divider)
        {
            if (dividend < 0)
            {
                return divider - (dividend % divider);
            }
            return dividend % divider;
        }

        public static string Encrypt(List<char> alphabet, string message, int alphabetLength, int k, int n)
        {
            message.ToLower();

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] == ' ')
                {
                    result.Append(' ');
                }
                else
                {
                    int originalSymbolCode = alphabet.IndexOf(message[i]);
                    int finalSimbolCode = Mod(originalSymbolCode * n + k, alphabetLength);
                    result.Append(alphabet[finalSimbolCode]);
                }
            }

            return result.ToString();
        }

        public static string Decrypt(List<char> alphabet, string message, int alphabetLength, int k, int n)
        {
            message.ToLower();

            StringBuilder result = new StringBuilder();

            int inverted_n = 1;

            for (int i = 1; i < alphabetLength; i++)
            {
                if (Mod(n * i, alphabetLength) == 1)
                {
                    inverted_n = i;
                    break;
                }
            }

            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] == ' ')
                {
                    result.Append(' ');
                }
                else
                {
                    int finalSymbolCode = alphabet.IndexOf(message[i]);
                    if (finalSymbolCode <= k)
                    {
                        finalSymbolCode += alphabetLength;
                    }
                    int originalSymbolCode = Mod((finalSymbolCode - k) * inverted_n, alphabetLength);
                    result.Append(alphabet[originalSymbolCode]);
                }
            }

            return result.ToString();
        }

        public static void Main(string[] args)
        {
            List<char> alphabet = new List<char> { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л',
                'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я',
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', '?', '!', ',', ';', ':', '-', '(', ')', '"' };

            string message = Console.ReadLine();
            string cipher = Encrypt(alphabet, message, 53, 29, 5);
            Console.WriteLine(cipher);
            Console.WriteLine(Decrypt(alphabet, cipher, 53, 29, 5));
        }
    }
}
