using System;
using TwitterOps;
using System.Configuration;
using System.Linq;
using System.Collections.Generic;

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

            var lol = new List<string> { "https://pbs.twimg.com/media/DpUq61zUUAEv16G?format=jpg&name=small", "https://pbs.twimg.com/media/D7LPDN1VUAE0cx2?format=jpg&name=small", "https://pbs.twimg.com/media/Drtz9kiU4AA_MbM?format=jpg&name=small", "https://pbs.twimg.com/media/DpuEzHXU8AAy4AQ?format=jpg&name=small" };

            var media = ops.Media.UploadCustomMediaFromPath(@"C:\Users\salivosa\Downloads\ezgif.com-crop.mp4", TwitterOps.Operation.Media.MediaData.MediaCategory.tweet_video);

            var tweet = ops.Tweets.PostTweetWithMedia("lol", media);

            //var thread = ops.Tweets.PostThread(@"Once upon a time there was a lovely princess. But she had an enchantment upon her of a fearful sort which could only be broken by love's first kiss. She was locked away in a castle guarded by a terrible fire-breathing dragon. Many brave knights had attempted to free her from this dreadful prison, but non prevailed. She waited in the dragon's keep in the highest room of the tallest tower for her true love and true love's first kiss. (laughs) Like that's ever gonna happen. What a load of - (toilet flush)", false);


            //var get_shadowbanned_list = user.followers.Where(w=> w.is_protected).ToList();

            //var response = task.GetFollowersOfUser(user);

    }
    }
}
