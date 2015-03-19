using System;
using static System.Console;

namespace CS6Examples
{
    public class StringInterpolation : IDemo
    {
        // String interpolation is a simple but powerful feature:
        // Formatting a string is now built into the language syntax

        public void Run()
        {
            // The syntax for string interpolation is to prefix the string literal with $
            // Then you can insert the value of a variable using curly brace syntax:
            int value = 42;
            string message = $"The value is {value}\n";
            WriteLine(message);

            // As expected, string interpolation calls .ToString on the object to
            // convert the object into a string:
            var foo = new Foo();
            WriteLine($"ToString'ing a Foo: {foo}\n");
            // (Actually, the compiler transforms the new syntax into the equivalent String.Format call).

            // You can use format specifiers with string interpolation:
            WriteLine($"A value with some decimals: {value:0.00}");
            var now = DateTime.Now;
            WriteLine($"Today is a: {now:dddd}");

            // You can use any expression in a string interpolation:
            WriteLine($"Adding two plus two: {2 + 2}");
            WriteLine($"Today is {(new DateTime(2015, 12, 24) - DateTime.Now).TotalDays:0} until Christmas.");
            
            //IFormattable s = $"can we format {value}";
            /*Type t = s.GetType();
            Console.WriteLine(t);*/
        }
   
        class Foo
        {
            public override string ToString()
            {
                return "Bar";
            }
        }
    }


}