// This code provides examples of a small but convenient feature in C#6:
// Static usings

// Using static is simple syntactic sugar that lets you call a static method directly, 
// without prefixing with the class name. An example:
using static System.Console;
using static System.DateTime;
// Static members in Console and DateTime are now in scope, similar to a normal using
// - but on class level.

// An observation is that while static usings might save you a bit of typing, and make some code look
// simpler; they very quickly pollute the scope. I think they should be used sparingly.

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