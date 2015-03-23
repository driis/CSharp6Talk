using System;

namespace CS6Examples
{
    public class AutoProperties : IDemo
    {
        public void Run()
        {
            var bar = new Bar("test");
            Console.WriteLine(bar.X);
        }
    }

    public class Bar
    {
        // A property can now be auto-implemented with only a getter
        public string X { get; }

        // A getter-only auto property can have an initializer expression:
        public int Y { get; } = 42;

        public Bar(string x)
        {
            // Constructors (and only constructors) can assign to getter-only autoproperties.
            X = x;
        }
    }
}