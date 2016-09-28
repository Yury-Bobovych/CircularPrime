using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularPrime
{
    class Program
    {
        static List<int> prime = new List<int>() { 2 };
        static List<int> circlePrime = new List<int>();
        static bool is_prime(int i)
        {
            for (int j = 0; j <= prime.Count - 1; j++)
            {
                if (prime[j] > Math.Sqrt(i))
                {
                    return true;                    
                }
                if (i % prime[j] == 0) break;
            }
            return false;
        }
        static int[] FindCirclPrime(int lenght)
        {          
            
            for (int i = 3; i <= lenght; i++)
            {
                if (is_prime(i))
                    prime.Add(i);   
            }
            for (int i = 0; i < prime.Count; i++)
            {
                string temp = prime[i].ToString();
                if (temp.Length == 1)
                {
                    circlePrime.Add(prime[i]);
                }
                else
                {
                    for (int j = 0; j < temp.Length-1; j++)
                    {
                        temp = temp.Substring(1) + temp[0];
                        if (!is_prime(Convert.ToInt32(temp))) break;
                        circlePrime.Add(prime[i]);
                        break;
                    }

                }
            }
            return  circlePrime.ToArray();
        }
        static void Main(string[] args)
        {
            int[] result =  FindCirclPrime(1000000);
            for (int i = 0; i < result.Length; i++)
            {
                if (i % 5 == 0)
                    Console.WriteLine();
                Console.Write($"{result[i]}      ");
                
            }
            Console.WriteLine($"conunt = {result.Length}");
            Console.ReadLine();
            }

    }
}
