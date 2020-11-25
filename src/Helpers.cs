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

        public int ConvertBitArrayToInt(BitArray bitArray)
        {
            if (bitArray.Length > 32)
                throw new ArgumentException("Argument length shall be at most 32 bits.");

            int[] array = new int[1];
            bitArray.CopyTo(array, 0);

            if (!CheckIfIntegerIsValid(array[0]))
            {
                throw new ArgumentException("Intenger is not valid");
            }

            return array[0];
        }

        public void PrintStackInInt(List<BitArray> stack)
        {
            if(stack.Count == 0)
            {
                Console.WriteLine("Stack state: empty");
                return;
            }

            string textToPrint = "Stack state: ";
            for (var i = 0; i < stack.Count; i++)
            {
                textToPrint += ConvertBitArrayToInt(stack[i]);
                if (i + 1 < stack.Count)
                {
                    textToPrint += ", ";
                }
            }

            Console.WriteLine(textToPrint);
        }

        public bool CheckIfIntegerIsValid(int value)
        {
            if (value < 0 || value > MAX_INPUT_VALUE)
            {
                Console.WriteLine("Error: Invalid value");
                return false;
            }

            return true;
        }
        public int GetModulo(int x, int N)
        {
            return (x % N + N) % N;
        }
    }
}
