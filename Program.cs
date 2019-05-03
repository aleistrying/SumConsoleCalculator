using System;

namespace CoreTest_calculator_in_console_
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                CalculateValues(Console.ReadLine());
            }
        }
        static void CalculateValues(string inputString)
        {
            inputString = inputString.Replace(" ", "");
            string numberStr = "";
            int inputStringLenght = inputString.Length;
            string result = "e";
            for (int index = 0; index < inputStringLenght; index++)
            {
                if (int.TryParse(inputString[index].ToString(), out int output))
                {
                    numberStr += inputString[index];
                }
                else if(inputString[index] == '+')
                {
                    inputString = inputString.Remove(0, index+1);
                    string nextNumber = SearchForNextNumber(inputString);
                    result = Sum(numberStr, nextNumber);
                    Console.WriteLine(int.Parse(result));

                    inputString = inputString.TrimStart(nextNumber.ToCharArray());
                    inputString = inputString.Insert(0, result);
                    index = -1;
                    numberStr = "";
                    inputStringLenght = inputString.Length;
                }

            }
            Console.WriteLine("Resultado de suma: {0}",int.Parse(result));
        }
        static string SearchForNextNumber(string inputString)
        {
            string numberStr = "";
            for (int index = 0; index < inputString.Length; index++)
            {
                if (int.TryParse(inputString[index].ToString(), out int output))
                {
                    numberStr += inputString[index];
                }
                else
                {
                    break;
                }
            }
                return numberStr;
        }
        static string Sum(string str1, string str2)
        {
            int.TryParse(str1,out int result1);
            int.TryParse(str2, out int result2);
            return (result1 + result2).ToString();
        }
    }
}
