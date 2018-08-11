using System;
using System.Net.Http;
using Microsoft.Owin.Hosting;

namespace HomeXTest.API
{
    public class Program
    {
        static void Main()
        {
            var baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpCient and make a request to api/values 
                
                Console.WriteLine($"Listening on {baseAddress}");
                Console.ReadLine();
            }
        }
    }
}