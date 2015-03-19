// This code provides examples of two small but convenient new features in C#6:
// Static usings, and
// nameof operator

// Using static is simple syntactic sugar that lets you call a static method directly, 
// without prefixing with the class name. An example:
using System;
using static System.Console;
using static System.DateTime;
// Static members in Console and DateTime are now in scope, similar to a normal using
// - but on class level.

namespace CS6Examples
{
    public class UsingStatic : IDemo
    {
        public void Run()
        {
            // Using static members directly:
            WriteLine("Hello, world");
            WriteLine("Enter some text:");
            string input = ReadLine();
            WriteLine("You entered '{0}' at {1}", input, Now);
        }

        
    }

  
}