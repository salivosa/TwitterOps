using System;
using TwitterAPI_NETCore;
using System.Configuration;

namespace testConsole
{
    class Program
    {
        static void Main(string[] args)
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

            //var response = await task.post_tweet_async("probandoooo1234");
            //var response = await task.get_mentioned_tweets_async();
            //var response = await task.get_mentioned_tweets();
            ///var response = await task.get_tweets();
            //var response = await task.get_replies();
            //var response = await task.get_replies_data();
            //var response = await task.get_last_thread();
            //var test = task.get_replies_of_tweet(response);
            //var response = task.get_mentioned_tweets();
            //var response = task.get_tweets_of_timeline();
            var response = task.last_mention_was_replied();

    }
    }
}
