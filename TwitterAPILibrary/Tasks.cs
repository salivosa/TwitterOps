using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        //Twitter API v1.1 calls

        //Post a tweet passing string with text
        public async Task<object> post_tweet(string text)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);
            parameters.Add("trim_user", true);

            var response = await api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);
            return response;
        }

        //Reply a tweet passing string with text and tweet_id (status_id) parameter
        public async Task<object> post_reply_tweet(string text, string tweet_id)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);
            parameters.Add("in_reply_to_status_id", tweet_id);
            parameters.Add("auto_populate_reply_metadata", true);
            parameters.Add("trim_user", true);

            var response = await api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);
            return response;
        }

        //Get mentions of user
        public async Task<object> get_mentions()
        {
            var response = await api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/mentions_timeline.json", APIHandler.Method.GET);
            return response;
        }

        //Get Dictionary of last 
        public async Task<object> get_replies_data()
        {
            var response = await api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/mentions_timeline.json", APIHandler.Method.GET);

            var list_replies = JArray.Parse(response).Children<JObject>().Select(x => new TwitterReplyModel
            {
                reply_user = x["user"]["screen_name"].ToString(),
                replied_tweet_id = x["in_reply_to_status_id"].ToString(),
                reply_tweet_message = Regex.Replace(x["text"].ToString(), @"\@\w+\b", match => "").Trim(),
                replied_tweet_message = x["in_reply_to_status_id"].ToString() == "" ? "" : Regex.Replace(get_tweet_message(x["in_reply_to_status_id"].ToString()).Result, @"\@\w+\b", match => "").Trim()

            }).Where(w=> w.replied_tweet_id != "").ToList();

            return response;
        }

        public async Task<string> get_tweet_message(string tweet_id)
        {
            var response = await api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/show.json?id=" + tweet_id, APIHandler.Method.GET);
            var tweet = JObject.Parse(response)["text"].ToString();
            return tweet;
        }

        public async Task<object> get_tweets()
        {
            //var parameters = new Dictionary<string, object> { };
            //parameters.Add("trim_user", true);

            var response = await api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/user_timeline.json", APIHandler.Method.GET);
            return response;
        }

        public async Task<object> get_replies()
        {
            var response = await api_handler.requestAPIOAuthAsync("https://api.twitter.com/2/tweets/search/recent", APIHandler.Method.GET);
            return response;
        }
    }
}
