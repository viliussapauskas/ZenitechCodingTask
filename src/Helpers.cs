using System;
using System.Collections;
using System.Collections.Generic;

namespace ZenitechCodingTask
{
    class Helpers
    {
        private readonly int MAX_INPUT_VALUE;
        public Helpers(int maxValue)
        {
            MAX_INPUT_VALUE = maxValue;
        }

        //public void PrintStack(List<BitArray> stack)
        //{
        //    foreach (var stackItem in stack)
        //    {
        //        stackItem.Cast<bool>().ToList().ForEach(y => Console.Write(y ? 1 : 0));
        //        Console.Write($" {ConvertBitArrayToInt(stackItem)}");
        //        Console.WriteLine("");
        //    }
        //    Console.WriteLine("");
        //}

        public int ConvertBitArrayToInt(BitArray bitArray)
        {
            if (bitArray.Length > 32)
                throw new ArgumentException("Argument length shall be at most 32 bits.");

            int[] array = new int[1];
            bitArray.CopyTo(array, 0);

            CheckIfIntegerIsValid(array[0]);

            return array[0];
        }

        public void PrintStackInInt(List<BitArray> stack)
        {
            string textToPrint = " stack is ";
            foreach (var numberInBits in stack)
            {
                textToPrint += ConvertBitArrayToInt(numberInBits) + ", ";
            }

            Console.Write(textToPrint + "\n");
        }

        public void CheckIfIntegerIsValid(int value)
        {
            if (value < 0 || value > MAX_INPUT_VALUE)
            {
                throw new ArgumentException("Invalid value");
            }
        }
        public int GetModulo(int x, int N)
        {
            return (x % N + N) % N;
        }
    }
}
