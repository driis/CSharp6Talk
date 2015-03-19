using System;
using static System.Console;

namespace CS6Examples
{
    public class NameOfOperator : IDemo
    {
        public void Run()
        {
            // Another new feature is the nameof operator:
            string nameOfRunMethod = nameof(Run);
            WriteLine("The name of the current method is {0}", nameOfRunMethod);
            WriteLine("The name of the current class is {0}", nameof(NameOfOperator));
            WriteLine("The name of the current namespace is {0}", nameof(CS6Examples));
            WriteLine("The name of another namespace is {0}", nameof(System.Collections.Generic));
            NameOfWorksForParametersAsWell("test");
        }

        private void NameOfWorksForParametersAsWell(string anImportantParameter)
        {
            // Nice use case for nameof: Make sure you get exception messages right
            if (anImportantParameter == null)
                throw new ArgumentNullException(nameof(anImportantParameter));

            WriteLine("This method has a parameter named {0}", nameof(anImportantParameter));
        }
    }
}