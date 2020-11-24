using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ZenitechCodingTask
{
    class Program
    {
        private const int STACK_CAPACITY = 5;
        private const int MAX_INPUT_VALUE = 1023;
        private readonly static Helpers helpers = new Helpers(MAX_INPUT_VALUE);
        static void Main(string[] args)
        {
            var stack = new List<BitArray>(STACK_CAPACITY);

            Push(ref stack, 10);
            Push(ref stack, 7);

            Add(ref stack);

            Push(ref stack, 25);

            Sub(ref stack);
        }

        private static void Push(ref List<BitArray> stack, int number)
        {
            if (stack.Count >= STACK_CAPACITY)
            {
                throw new Exception("Stack limit reached");
            }

            helpers.CheckIfIntegerIsValid(number);

            BitArray b = new BitArray(new int[] { number });
            bool[] bits = b.Cast<bool>().ToArray();

            var resultBitArray = new BitArray(10);

            for (int i = 0; i < 10; i++)
            {
                resultBitArray.Set(i, bits[i]);
            }

            stack.Add(resultBitArray);
            helpers.PrintStackInInt(stack);
        }

        private static BitArray Pop(ref List<BitArray> stack)
        {
            if (stack.Count > 0)
            {
                var valueToRemove = stack[stack.Count - 1];
                stack.RemoveAt(stack.Count - 1);

                helpers.PrintStackInInt(stack);
                return valueToRemove;
            }
            return null;
        }

        private static void Add(ref List<BitArray> stack)
        {
            if (stack.Count >= 2)
            {
                var removedValue1 = Pop(ref stack);
                var removedValue2 = Pop(ref stack);

                var sum = helpers.ConvertBitArrayToInt(removedValue1) + helpers.ConvertBitArrayToInt(removedValue2);

                helpers.CheckIfIntegerIsValid(sum);

                Push(ref stack, sum);
                Console.Write(sum);
                helpers.PrintStackInInt(stack);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Not enough values in stack");
            }
        }

        private static void Sub(ref List<BitArray> stack)
        {
            if (stack.Count >= 2)
            {
                var topMostValueInBits1 = Pop(ref stack);
                var topMostValueInBits2 = Pop(ref stack);

                var topMostValueAsInt1 = helpers.ConvertBitArrayToInt(topMostValueInBits1);
                var topMostValueAsInt2 = helpers.ConvertBitArrayToInt(topMostValueInBits2);

                var result = topMostValueAsInt1 - topMostValueAsInt2;

                if (result < 0 || result > MAX_INPUT_VALUE)
                {
                    result = helpers.GetModulo(result, MAX_INPUT_VALUE + 1);
                }
                else
                {
                    Push(ref stack, result);
                }
                Console.Write(result);
                helpers.PrintStackInInt(stack);
            }
        }
    }
}
