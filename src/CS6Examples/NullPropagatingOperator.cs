using System;
using System.Linq;
using static System.Console;
using static System.DateTime;

namespace CS6Examples
{
    public class NullPropagatingOperator : IDemo
    {
        public void Run()
        {
            Foo foo = GetFoo();

            // We can get X safely without checking for foo == null first:
            string x = foo?.X;
            WriteLine($"X is {x}");

            // The above code is more or less compiled to:
            string xx;
            if (foo == null)
                xx = null;
            else
                xx = foo.X;
            WriteLine($"X is {xx}");

            // On DBA and in other places we have had the Maybe extension method for dealing with nulls earlier. This corresponds closely to the null propagaing operator.:
            string xxx = foo.Maybe(f => f.X);
            WriteLine($"X is {xxx}");
            // However, Maybe relies on Lambdas, meaning that runtime performance will be worse than the compiled counterpart.
            // (An invocation will both be an allocation and a method call, while the null propating operator is compiled directly into if-branches inline).
            // (Not that it will matter for 99.9% of your code)

            // A use case for Maybe could still be the case when you need to access another method when the instance is not null
            WriteLine(foo.Maybe(_ => "Foo was ot null"));
            // But then again, in this case a standard if-statement is probably clearer

            // Null propagating operator can be chained:
            var yArray = foo?.Y?.ToCharArray();
            WriteLine($"Calling a method on null using null propagating operator: Result is {yArray}");

            // LIke other operators, ?. can be used inline in string interpolation expressions:
            WriteLine($"X is {foo?.X}");

            // Null propagating operator is not constricted to reference types. We can also hit value types as the result:
            int? length = foo?.X?.Length;
            WriteLine($"Length of {nameof(foo.X)} is {length}");

            // An interesting fact, when the result of an invocation of the null propagating operator is a value type
            // The result is not default(T), but rather the nullable version of the value type
            // This is useful, since the result will tell you whether "the chain was broken" by a null value; or we did in fact get to 
            WriteLine($"Type of length is {length?.GetType()}");
        }

        private Foo GetFoo()
        {
            if (Now.Ticks % 2 == 0)
                return null;

            int length = (int)(Now.Ticks % 10 + 1);
            string x = new String(Enumerable.Range('a', length).Select(ch => (char)ch).ToArray());
            return new Foo(x, null);
        }
    }

    public class Foo
    {
        public Foo(string x, string y)
        {
            X = x;
            Y = y;
        }
        public string X { get; }
        public string Y { get; } = "foo";
    }

    public static class MaybeMonad
    { 
        public static TResult Maybe<T, TResult>(this T value, Func<T,TResult> expr) 
            where T : class 
            where TResult : class
        {
            if (value == null)
                return null;
            return expr(value);           
        }
    }
}