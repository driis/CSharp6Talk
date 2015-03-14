using System;

namespace CS6Examples
{
    public static class Support
    {

    }

    public static class Parse
    {
        public static int? Int(string value)
        {
            int n;
            if (!int.TryParse(value, out n))
                return null;
            return n;
        }
    }
}