using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptoTask1
{
    public class Program
    {
        public static int Mod(int dividend, int divider)
        {
            if(dividend < 0)
            {
                return divider - (dividend % divider);
            }

            return dividend % divider;
        }

        public static string Encrypt(List<char> alphabet, string message, int alphabetLength, int k, int n)
        {
            message.ToLower();

            StringBuilder result = new StringBuilder();

            for(int i = 0; i < message.Length; i++)
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

            for(int i = 0; i < message.Length; i++)
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

                    int originalSymbolCode = Mod((finalSymbolCode - k) / n, alphabetLength);
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

            string shiphr = Encrypt(alphabet, message, 53, 2, 3);
            Console.WriteLine(shiphr);
            Console.WriteLine(Decrypt(alphabet, shiphr, 53, 2, 3));
        }
    }
}
