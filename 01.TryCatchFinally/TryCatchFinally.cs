using System;

/* Write a program that reads an integer number and calculates
 * and prints its square root. If the number is invalid or negative,
 * print "Invalid number". In all cases finally print "Good bye". 
 * Use try-catch-finally. */

class TryCatchFinally
{
    static void Main()
    {
        Console.Write("Enter a positive integer number:\n=> ");
        int inputNumber = 0;

        try
        {
            inputNumber = int.Parse(Console.ReadLine());
            NegativeCheck(inputNumber);
            double result = Math.Sqrt(inputNumber);
            Console.WriteLine("The square root of entered number is: {0:0.00}", result);
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
        finally
        {
            Console.WriteLine("Good bye.");
        }
    }

    private static void NegativeCheck(int enteredNumber)
    {
        try
        {
            if (enteredNumber <= 0)
            {
                throw new ArithmeticException();
            }
        }
        catch (ArithmeticException)
        {
            Console.WriteLine("Invalid number.\n");
            Main();
        }
    }
}