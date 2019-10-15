using System;
using System.Linq;

namespace SmallestString
{
    class Program
    {
        static string results = string.Empty;
        static void Main(string[] args)
        {            
            Run();            
            Console.Read();
        }

        private static void Run()
        {
            ulong weight;
            string result = string.Empty;
            ulong[] sum = GetSumOfCharacters();
            char[] characters = new char[26] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            Console.WriteLine("Enter the weight?");
            weight = ulong.Parse(Console.ReadLine());
            result = CalculateWeight(weight, sum, characters);
            Console.WriteLine($"The result for weight {weight} is {String.Concat(result.OrderBy(c => c))}");
            Console.WriteLine("Do you want to try again. Press the character 'Y' to run again!");
            var input = Console.ReadLine();
            if (input.Equals('Y'.ToString()) || input.Equals('y'.ToString()))
            {
                results = string.Empty;
                Run();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private static string CalculateWeight(ulong weight, ulong[] sum, char[] characters)
        {
            ulong counter = 0, lastValue = 0;

            foreach (var item in sum)
            {
                while (item <= Convert.ToUInt64(weight))
                {
                    lastValue = Convert.ToUInt64(item);
                    counter++;
                    break;
                }
            }
            ulong difference = weight - lastValue;
            results += characters[counter - 2].ToString();
            if (difference != 0) CalculateWeight(difference,sum,characters);
            return results;
        }       
        
        
        private static ulong[] GetSumOfCharacters()
        {
            int index = 1;
            ulong[] sum = new ulong[27];
            for (ulong i = 1; i < 28; i++)
            {
                if (i == 1)
                {
                    sum[i] = i;
                    index++;
                }
                else
                {
                    if (index <= 26)
                    {
                        ulong lastValue = sum[i - 1];
                        sum[i] = i * lastValue + lastValue;
                        index++;
                    }
                }
            }
            return sum;
        }
    }
}
