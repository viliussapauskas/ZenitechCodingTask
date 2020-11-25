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

            Console.WriteLine("Enter one of the commands: Push <number>, Add, Pop, Sub");
            Console.WriteLine("Enter Exit to stop");

            var isRunning = true;

            while (isRunning)
            {
                var input = Console.ReadLine().ToLower();

                if (input.Contains("exit"))
                {
                    isRunning = false;
                }
                else if (input.Contains("push"))
                {
                    string[] words = input.Split(' ');

                    if(words.Length == 2 && Int32.TryParse(words[1], out int value))
                    {
                        Push(ref stack, value);
                        helpers.PrintStackInInt(stack);
                    }
                    else
                    {
                        Console.WriteLine("Wrong input, example of push: 'Push 10'");
                    }
                }
                else if (input == "pop")
                {
                    Pop(ref stack);
                    helpers.PrintStackInInt(stack);
                }
                else if (input == "add")
                {
                    Add(ref stack);
                    helpers.PrintStackInInt(stack);
                }
                else if (input == "sub")
                {
                    Sub(ref stack);
                    helpers.PrintStackInInt(stack);
                }
                else
                {
                    Console.WriteLine("Entered command wasnt recognized");
                }
            }
        }

        private static void Push(ref List<BitArray> stack, int number)
        {
            if (stack.Count >= STACK_CAPACITY)
            {
                Console.WriteLine("Stack limit reached");
                return;
            }

            if (!helpers.CheckIfIntegerIsValid(number))
            {
                return;
            }

            BitArray b = new BitArray(new int[] { number });
            bool[] bits = b.Cast<bool>().ToArray();

            var resultBitArray = new BitArray(10);

            for (int i = 0; i < 10; i++)
            {
                resultBitArray.Set(i, bits[i]);
            }

            stack.Add(resultBitArray);
        }

        private static BitArray Pop(ref List<BitArray> stack)
        {
            if (stack.Count > 0)
            {
                var valueToRemove = stack[^1];
                stack.RemoveAt(stack.Count - 1);

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

                if (!helpers.CheckIfIntegerIsValid(sum))
                {
                    return;
                }

                Push(ref stack, sum);
                Console.WriteLine("> " + sum.ToString());
            }
            else
            {
                Console.WriteLine("Stack does not have required operands");
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
                Console.WriteLine("> " + result.ToString());
            }
            else
            {
                Console.WriteLine("Stack does not have required operands");
            }
        }
    }
}
