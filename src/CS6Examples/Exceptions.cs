using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CS6Examples
{
    public class Exceptions : IDemo
    {
        public void Run()
        {
            RunAsync().Wait();
        }

        public async Task RunAsync()
        {
            string[] urls = new[] {"http://www.stackoverflow.com", "http://www.stackoverflow.com/blah", "http://nonexistant.domain" };
            foreach(string url in urls)
            {
                try
                {
                    await CheckUrl(url);
                }
                // Exception filter: Only catch HttpRequestException with InnerException == null
                catch (HttpRequestException hre) when (hre.InnerException == null)
                {
                    string rootForm = new Uri(url).GetLeftPart(UriPartial.Authority);
                    Console.WriteLine($"Trying root form of url: {rootForm}");
                    // We can now use await in a catch block (or finally blocks), we could not do that before
                    await CheckUrl(rootForm);
                    // Note, that just because we _can_ do something, it does not mean that it is a good idea always ;)
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                Console.WriteLine();
            }
        }

        public async Task CheckUrl(string url)
        {
            var client = new HttpClient();

            var result = await client.GetAsync(new Uri(url));
            result.EnsureSuccessStatusCode();
            var body = await result.Content.ReadAsByteArrayAsync();
            Console.WriteLine($"{url} is responding with success with a body of {body.Length} bytes");
        }
    }
}