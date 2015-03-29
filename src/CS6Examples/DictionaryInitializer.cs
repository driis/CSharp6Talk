using System.Collections.Generic;

using static System.Console;

namespace CS6Examples
{
    public class DictionaryInitializer : IDemo
    {
        public void Run()
        {
            // In previous versions, we already had dictionary initializers:
            var x = new Dictionary<string, string> {
                { "foo", "bar" },
                { "x", "42" }
            };
            WriteLine(x["foo"]);

            // C# 6 adds an alternative syntax for this
            var u = new Dictionary<string, string>
            {
                ["foo"] = "bar",
                ["x"] = "42"
            };
            WriteLine(u["foo"]);
        }
    }
}