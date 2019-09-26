using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;
using Task2;
using Task9;


namespace Task13
{
    public class Program
    {
        public static List<int> FindAllFactors(int number)
        {
            List<int> result = new List<int>();

            for(int i = 1; i < Math.Sqrt((double)number); i++)
            {
                if(number % i == 0)
                {
                    result.Add(i);
                }
            }

            result.Add(number);

            return result;
        }

        public static string LCG(List<char> alphabet, int textLength)
        {
            StringBuilder result = new StringBuilder();
            Random random = new Random();
            int startValue = random.Next(1, alphabet.Count);

            int increment = random.Next(1, alphabet.Count);
            while(!(FindAllFactors(increment).Intersect(FindAllFactors(alphabet.Count)).Max() == 1))
            {
                increment = random.Next(1, alphabet.Count);
            }            
            
            List<int> potentialMultipliers = new List<int>();
            if(alphabet.Count % 4 == 0)
            {
                for (int i = 4; i < alphabet.Count; i += 4)
                {
                    potentialMultipliers.Add(i + 1);
                }
            }

            List<int> primeFactors = new List<int>();
            List<int> allModulusFactors = FindAllFactors(alphabet.Count);
            for(int i = 0; i < allModulusFactors.Count; i++)
            {
                if(FindAllFactors(allModulusFactors[i]).Count == 1)
                {
                    primeFactors.Add(allModulusFactors[i]);
                }
            }

            int multiplier = -1;
            if (potentialMultipliers.Count > 0)
            {                
                for (int i = 0; i < potentialMultipliers.Count; i++)
                {
                    int j = 0;
                    for(j = 0; j < primeFactors.Count; j++)
                    {
                        if((potentialMultipliers[i] - 1) % primeFactors[j] != 0)
                        {                            
                            break;
                        }
                    }

                    if(j == primeFactors.Count)
                    {
                        multiplier = potentialMultipliers[i];
                        break;
                    }
                }
            }
            else
            {
                for(int i = 2; i < alphabet.Count; i++)
                {
                    int j = 0;
                    for (j = 0; j < primeFactors.Count; j++)
                    {
                        if ((i - 1) % primeFactors[j] != 0)
                        {
                            break;
                        }
                    }

                    if (j == primeFactors.Count)
                    {
                        multiplier = i;
                        break;
                    }
                }
            }

            result.Append(alphabet[startValue]);
            while(result.Length < textLength)
            {
                int letterIndex = Task1.Program.Mod(multiplier * startValue + increment, alphabet.Count);
                result.Append(alphabet[letterIndex]);
                startValue = letterIndex;
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

            string key = LCG(alphabet, text.Length);

            string cipher = Task9.Program.XorEncryption(alphabet, key, text);
            Console.WriteLine(cipher);
            Console.WriteLine(Task9.Program.XorDecryption(alphabet, key, cipher));
        }
    }
}
