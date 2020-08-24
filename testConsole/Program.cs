using System;
using TwitterAPI_NETCore;
using System.Configuration;

namespace testConsole
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            //Example

            //Load key data
            string consumerKey = ConfigurationManager.AppSettings["consumerKey"];
            string consumerSecret = ConfigurationManager.AppSettings["consumerSecret"];
            string tokenValue = ConfigurationManager.AppSettings["tokenValue"];
            string tokenSecret = ConfigurationManager.AppSettings["tokenSecret"];

            //Load module
            var task = new Tasks(consumerKey, consumerSecret, tokenValue, tokenSecret);

            //Execute a task
            await task.post_tweet("esto es una prueba 4567");

        }
    }
}
