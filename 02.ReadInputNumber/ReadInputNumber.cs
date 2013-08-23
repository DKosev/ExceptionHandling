using System;

/* Write a method ReadNumber(int start, int end) that enters an 
 * integer number in given range [start…end]. If an invalid number 
 * or non-number text is entered, the method should throw an exception. 
 * Using this method write a program that enters 10 numbers: 
 * a1, a2, … a10, such that 1 < a1 < … < a10 < 100 */

class ReadInputNumber
{
    static void Main()
    {
        Console.WriteLine("Enter ten numbers in this interval [1...100]");
        Console.WriteLine("1 < a1 < a2 … < a10 < 100");

        try
        {
            ReadNumber(1, 100);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number.\n");
            Main();
        }
        catch (OverflowException)
        {
            Console.WriteLine("Invalid number.\n");
            Main();
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Invalid number.\n");
            Main();
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Invalid number.\n");
            Main();
        }
    }

    private static void ReadNumber(int start, int end)
    {
        int[] savedNumbers = new int[11];
        for (int i = 1; i <= savedNumbers.Length - 1; i++)
        {
            Console.Write("\nEnter {0} number => ", i);
            savedNumbers[i] = int.Parse(Console.ReadLine());
            if (savedNumbers[i] <= start || savedNumbers[i] >= end)
            {
                throw new ArgumentOutOfRangeException();
            }

            while (savedNumbers[i] <= savedNumbers[i - 1])
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}