using System;
using System.Linq;
using static System.Console;

namespace CS6Examples
{
    public class Program
    {
        public void Main(params string[] args)
        {
            if (args.Length > 0)
            {
                RunDemoByName(args.First());
            }
            else
            {
                string name = PromptForDemoToRun();
                if (!string.IsNullOrWhiteSpace(name))
                    Main(name);

            }
            
        }

        private string PromptForDemoToRun()
        {
            WriteLine("What would you like to run ?\n");
            var options = GetType().Assembly.GetTypes().Where(x => typeof(IDemo).IsAssignableFrom(x) && x != typeof(IDemo))
                .OrderBy(x => x.Name).Select((x, i) => new { Index = i +1, x.Name, Type = x }).ToArray();
            foreach(var opt in options)
            {
                WriteLine($"{opt.Index}: {opt.Name}");
            }
            string choice = ReadLine();
            int? selectedIndex = Parse.Int(choice) - 1;
            if (selectedIndex != null && selectedIndex < options.Length)
                return options[selectedIndex.Value].Name;
            return null;
        }

        private void RunDemoByName(string name)
        {
            var type = GetType().Assembly.GetTypes().FirstOrDefault(x => typeof(IDemo).IsAssignableFrom(x) && x.Name == name);
            if (type != null)
            {
                IDemo demo = (IDemo)Activator.CreateInstance(type);
                demo.Run();
            }
        }
    }

    public interface IDemo
    {
        void Run();
    }
}
