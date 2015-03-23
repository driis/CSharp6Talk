using System;

using static System.Console;
namespace CS6Examples
{
    public class ExpressionBodiedMembers : IDemo
    {
        public void Run()
        {
            var p = new Size(10, 5);

            WriteLine($"The area is {p.Area}");
            var smaller = p.Subtract(new Size(3, 2));
            WriteLine($"A smaller size is {smaller}");
        }
    }

    public class Size
    {
        public Size(int w, int h)
        {
            Width = w;
            Height = h;
        }
        public int Width { get; }
        public int Height { get; }

        // A property can now be implemented using expression syntax
        public int Area => Width * Height;

        // The above is equivalent to the explicitly implemented property:
        public int AreaE
        {
            get { return Width * Height; }
        }

        // Methods can also be implemented using expression syntax:
        public Size Subtract(Size other) => new Size(Width - other.Width, Height - other.Height);

        // We can even override methods with expression syntax:
        public override string ToString() => $"({Width},{Height})";

        // Expression syntax might be cool for methods that really are a simple single expression - but don't
        // overuse it for complex implementations.
    }
}