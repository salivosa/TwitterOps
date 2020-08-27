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

            var response = task.IsLastMentionRepliedByLoggedUser();

            if (!response.Item1)
                task.PostReplyTweet(response.Item2.tweet_message, response.Item2);

    }
    }
}
