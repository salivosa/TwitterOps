using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TwitterAPI_NETCore.Models;

namespace TwitterAPI_NETCore
{
    public class Tasks
    {
        private APIHandler api_handler { get; set; }

        public Tasks(string consumerKey, string consumerSecret, string tokenValue, string tokenSecret)
        {
            api_handler = new APIHandler(consumerKey, consumerSecret, tokenValue, tokenSecret);
        }

        //Twitter API v1.1 calls

        //Get tweet data based of tweet_id (status_id)
        public async Task<TweetData> get_tweet_data(string tweet_id)
        {
            var response = await api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/show.json?id=" + tweet_id, APIHandler.Method.GET);
            var tweet_data = JObject.Parse(response);

            var tweet = new TweetData(tweet_data);

            return tweet;
        }

        //Get tweet jobject data based of tweet_id (status_id)
        private async Task<JObject> get_tweet_jobject_data(string tweet_id)
        {
            var response = await api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/show.json?id=" + tweet_id, APIHandler.Method.GET);
            var tweet_data = JObject.Parse(response);
            return tweet_data;
        }

        //Post a tweet passing string with text
        public async Task<TweetData> post_tweet(string text)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);
            parameters.Add("trim_user", true);

            var response = await api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response));

            return tweet_data;
        }

        //Reply a tweet passing string with text and TweetData instance
        public async Task<TweetData> post_reply_tweet(string text, TweetData tweet)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);
            parameters.Add("in_reply_to_status_id", tweet.tweet_id);
            parameters.Add("auto_populate_reply_metadata", true);
            parameters.Add("trim_user", true);

            var response = await api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response));

            return tweet_data;
        }

        //Reply a tweet passing string with text and tweet_id (status_id)
        public async Task<TweetData> post_reply_tweet(string text, string tweet_id)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);
            parameters.Add("in_reply_to_status_id", tweet_id);
            parameters.Add("auto_populate_reply_metadata", true);
            parameters.Add("trim_user", true);

            var response = await api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response));

            return tweet_data;
        }

        //Get last tweet in which user was mentioned an returns TweetReply instance
        public TweetReply get_last_mentioned_tweet()
        {
            var response = api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/mentions_timeline.json?count=1", APIHandler.Method.GET);
            var data = (JObject)JArray.Parse(response.Result).First();

            return jobject_tweet(data);
        }

        //Get last tweet in which user was mentioned an returns JObject instance
        private async Task<JObject> get_last_mentioned_tweet_data()
        {
            var response = await api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/mentions_timeline.json?count=1", APIHandler.Method.GET);
            return (JObject)JArray.Parse(response).First;
        }

        //Get iteration of tweets made to another user
        public List<TweetReply> get_last_thread()
        {
            var last_mention = get_last_mentioned_tweet_data();
            return get_thread(last_mention.Result);
        }

        //Format instance TweetReply from JObject object
        private TweetReply jobject_tweet(JObject json)
        {
            var tweet_reply = new TweetReply
            {
                in_reply_to_status_id = json["in_reply_to_status_id"].ToString(),
                tweet_model = new TweetData(json)
            };

            return tweet_reply;
        }

        //Get a thread based of the last tweet 
        public List<TweetReply> get_thread(JObject last_mention)
        {
            var thread = new List<TweetReply>();

            thread.Add(jobject_tweet(last_mention));

            while (true)
            {
                var parent_tweet = jobject_tweet(get_tweet_jobject_data(thread.Last().in_reply_to_status_id).Result);

                thread.Add(parent_tweet);

                if (parent_tweet.in_reply_to_status_id == "")
                    break;
            }

            thread.Reverse();

            return thread;
        }
    }
}
