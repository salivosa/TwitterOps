using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TwitterAPI_NETCore
{
    public class Tasks
    {
        APIHandler api_handler { get; set; }

        public Tasks(string consumerKey, string consumerSecret, string tokenValue, string tokenSecret)
        {
            api_handler = new APIHandler(consumerKey, consumerSecret, tokenValue, tokenSecret);
        }

        public async Task post_tweet(string text)
        {
            var tweet = new Dictionary<string, string> { };
            tweet.Add("status", text);

            await api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, tweet);
        }

    }
}
