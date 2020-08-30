using System;
using TwitterOps;
using System.Configuration;
using System.Linq;

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
            var ops = new Operations(consumerKey, consumerSecret, tokenValue, tokenSecret);

            //Execute a task

            var tweet = ops.Tweets.GetTweetById("1299733205143023616");

            //var thread = ops.GetThreadFromTweet(tweet);
            var replies = tweet.replies;

            //var user = ops.GetUserByScreenName("salikatsu");

            //var get_shadowbanned_list = user.followers.Where(w=> w.is_protected).ToList();

            //var response = task.GetFollowersOfUser(user);

    }
    }
}
