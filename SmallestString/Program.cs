using System;

namespace SmallestString
{
    class Program
    {
        static string result = string.Empty;
        static void Main(string[] args)
        {
            ulong[] sum = GetSumOfCharacters();
            char[] characters = new char[26] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            Console.WriteLine("Enter the weight?");
            ulong weight =  ulong.Parse(Console.ReadLine());
            string result = CalculateWeight(weight, sum, characters);

            Console.WriteLine($"The result for weight {weight} is {result}");
            Console.Read();
                         
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
            result += characters[counter - 2].ToString();
            if (difference != 0) CalculateWeight(difference,sum,characters);
            return result;
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
