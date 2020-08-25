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

            //var response = await task.post_tweet("testando");
            //var response = await task.get_mentions();
            //var response = await task.get_last_mention();
            ///var response = await task.get_tweets();
            //var response = await task.get_replies();
            //var response = await task.post_reply_tweet("esto es un reply", "1297603583387541509");
            var response = await task.get_replies_data();

    }
    }
}
