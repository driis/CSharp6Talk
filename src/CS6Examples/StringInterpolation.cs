using System;
using System.Globalization;

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

            // Specifying format info for string interpolations is possible:
            string x = FormatInvariant($"{42.0m}");
            WriteLine(x);

            // System.FormattableString has a built in method for that (you could import it with using static):
            WriteLine(FormattableString.Invariant($"{42.0m}"));

            // It would be nice to be able to make a extension method for this ...
            // But compiler magic is happening here, and it doesn't know the string is a FormattedString, unless we type it
            // as such... 
            // WriteLine($"{42.0m}".Invariant());   // Doesn't work
            WriteLine(((FormattableString)$"{42.0m}").Invariant()); // Works, not pretty. Using static with FormattableString.Invariant is nicer.
            
            FormattableString f = $"{42.0m}";
            WriteLine(f.Invariant());
            WriteLine(f.FormattedWith(new CultureInfo("da-DK")));
        }

        public static string FormatInvariant(IFormattable formattable)
        {
            return formattable.ToString(null, CultureInfo.InvariantCulture);
        }
   
        class Foo
        {
            public override string ToString()
            {
                return "Bar";
            }
        }
    }

    public static class InterpolationExtensions
    {
        public static string Invariant(this IFormattable formattable)
        {
            return formattable.FormattedWith(CultureInfo.InvariantCulture);
        }

        public static string FormattedWith(this IFormattable formattable, CultureInfo culture)
        {
            return formattable.ToString(null, culture);
        }
    }
}