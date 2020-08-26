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
        private static APIHandler api_handler { get; set; }

        public Tasks(string consumerKey, string consumerSecret, string tokenValue, string tokenSecret)
        {
            api_handler = new APIHandler(consumerKey, consumerSecret, tokenValue, tokenSecret);
        }

        // ----------------------------------------------------------- Twitter API v1.1 calls -----------------------------------------------------------  //

        /// <summary>
        /// Get tweet data based of tweet_id (status_id)
        /// </summary>
        public TweetData get_tweet_data(string tweet_id)
        {
            var response = api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/show.json?id=" + tweet_id, APIHandler.Method.GET);
            var tweet_data = JObject.Parse(response.Result);

            var tweet = new TweetData(tweet_data);

            return tweet;
        }

        /// <summary>
        /// Get tweet data based of tweet_id (status_id)
        /// </summary>
        public static TweetData get_tweet_data_static(string tweet_id)
        {
            var response = api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/show.json?id=" + tweet_id, APIHandler.Method.GET);
            var tweet_data = JObject.Parse(response.Result);

            var tweet = new TweetData(tweet_data);

            return tweet;
        }

        /// <summary>
        /// Get tweet data based of tweet_id (status_id)
        /// </summary>
        public async Task<TweetData> get_tweet_data_async(string tweet_id)
        {
            var response = await api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/show.json?id=" + tweet_id, APIHandler.Method.GET);
            var tweet_data = JObject.Parse(response);

            var tweet = new TweetData(tweet_data);

            return tweet;
        }

        /// <summary>
        /// Get tweets from tl and return a list of TweetData
        /// </summary>
        public List<TweetData> get_tweets_of_timeline()
        {
            var response = api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/user_timeline.json?include_rts=false", APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response.Result).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get tweets from tl and return a list of TweetData
        /// </summary>
        public static List<TweetData> get_tweets_of_timeline_static()
        {
            var response = api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/user_timeline.json?include_rts=false", APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response.Result).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get tweets from tl and return a list of TweetData
        /// </summary>
        public async Task<List<TweetData>> get_tweets_of_timeline_async()
        {
            var response = await api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/user_timeline.json?include_rts=false", APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet passing string with text
        /// </summary>
        public TweetData post_tweet(string text)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);

            var response = api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet passing string with text
        /// </summary>
        public static TweetData post_tweet_static(string text)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);

            var response = api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet passing string with text
        /// </summary>
        public async Task<TweetData> post_tweet_async(string text)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);

            var response = await api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response));

            return tweet_data;
        }

        /// <summary>
        /// Reply a tweet passing string with text and TweetData instance
        /// </summary>
        public TweetData post_reply_tweet(string text, TweetData tweet)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);
            parameters.Add("in_reply_to_status_id", tweet.tweet_id);
            parameters.Add("auto_populate_reply_metadata", true);

            var response = api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Reply a tweet passing string with text and TweetData instance
        /// </summary>
        public static TweetData post_reply_tweet_static(string text, TweetData tweet)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);
            parameters.Add("in_reply_to_status_id", tweet.tweet_id);
            parameters.Add("auto_populate_reply_metadata", true);

            var response = api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Reply a tweet passing string with text and TweetData instance
        /// </summary>
        public async Task<TweetData> post_reply_tweet_async(string text, TweetData tweet)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);
            parameters.Add("in_reply_to_status_id", tweet.tweet_id);
            parameters.Add("auto_populate_reply_metadata", true);

            var response = await api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response));

            return tweet_data;
        }

        /// <summary>
        /// Reply a tweet passing string with text and tweet_id (status_id)
        /// </summary>
        public static TweetData post_reply_tweet(string text, string tweet_id)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);
            parameters.Add("in_reply_to_status_id", tweet_id);
            parameters.Add("auto_populate_reply_metadata", true);

            var response = api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Reply a tweet passing string with text and tweet_id (status_id)
        /// </summary>
        public static TweetData post_reply_tweet_static(string text, string tweet_id)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);
            parameters.Add("in_reply_to_status_id", tweet_id);
            parameters.Add("auto_populate_reply_metadata", true);

            var response = api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Reply a tweet passing string with text and tweet_id (status_id)
        /// </summary>
        public async Task<TweetData> post_reply_tweet_async(string text, string tweet_id)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);
            parameters.Add("in_reply_to_status_id", tweet_id);
            parameters.Add("auto_populate_reply_metadata", true);

            var response = await api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response));

            return tweet_data;
        }


        /// <summary>
        /// Get last tweets in which user was mentioned and returns a TweetReply instance
        /// </summary>
        public List<TweetData> get_mentioned_tweets()
        {
            var response = api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/mentions_timeline.json", APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response.Result).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get last tweets in which user was mentioned and returns a TweetReply instance
        /// </summary>
        public static List<TweetData> get_mentioned_tweets_static()
        {
            var response = api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/mentions_timeline.json", APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response.Result).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get last tweets in which user was mentioned and returns a TweetReply instance
        /// </summary>
        public async Task<List<TweetData>> get_mentioned_tweets_async()
        {
            var response = await api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/mentions_timeline.json", APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get last tweets in which user was mentioned with a count parameter and returns a TweetReply instance
        /// </summary>
        public List<TweetData> get_mentioned_tweets(int count)
        {
            var response = api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/mentions_timeline.json?count=" + count, APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response.Result).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get last tweets in which user was mentioned with a count parameter and returns a TweetReply instance
        /// </summary>
        public static List<TweetData> get_mentioned_tweets_static(int count)
        {
            var response = api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/mentions_timeline.json?count=" + count, APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response.Result).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get last tweets in which user was mentioned with a count parameter and returns a TweetReply instance
        /// </summary>
        public async Task<List<TweetData>> get_mentioned_tweets_async(int count)
        {
            var response = await api_handler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/mentions_timeline.json?count=" + count, APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Check if last mention to user was replied
        /// </summary>
        public Tuple<bool,TweetData> last_mention_was_replied()
        {
            var last_mention = get_mentioned_tweets(1)[0];
            var check = last_mention.replies.Count != 0;

            var result = new Tuple<bool, TweetData>(check, last_mention);

            return result;
        }

        /// <summary>
        /// Check if last mention to user was replied
        /// </summary>
        public static Tuple<bool, TweetData> last_mention_was_replied_static()
        {
            var last_mention = get_mentioned_tweets_static(1)[0];
            var check = last_mention.replies != null;

            var result = new Tuple<bool, TweetData>(check, last_mention);

            return result;
        }

        /// <summary>
        /// Check if last mention to user was replied
        /// </summary>
        public async Task<Tuple<bool, TweetData>> last_mention_was_replied_async()
        {
            var last_mention = await get_mentioned_tweets_async(1);
            var check = last_mention[0].replies != null;

            var result = new Tuple<bool, TweetData>(check, last_mention[0]);

            return result;
        }

        /// <summary>
        /// Get replies to tweet
        /// </summary>
        public List<TweetData> get_replies_of_tweet(TweetData tweet)
        {
            var tl_tweets = get_tweets_of_timeline();

            var mention_tweets = get_mentioned_tweets();

            var union_list = tl_tweets.Union(mention_tweets).ToList();

            var get_replies = union_list.Where(x => x.replying_to != null && x.replying_to.tweet_id == tweet.tweet_id).ToList();

            return get_replies;
        }

        /// <summary>
        /// Get replies to tweet
        /// </summary>
        public static List<TweetData> get_replies_of_tweet_static(TweetData tweet)
        {
            var tl_tweets = get_tweets_of_timeline_static();

            var mention_tweets = get_mentioned_tweets_static();

            var union_list = tl_tweets.Union(mention_tweets).ToList();

            var get_replies = union_list.Where(x => x.replying_to != null && x.replying_to.tweet_id == tweet.tweet_id).ToList();

            return get_replies;
        }

        /// <summary>
        /// Get replies to tweet
        /// </summary>
        public async Task<List<TweetData>> get_replies_of_tweet_async(TweetData tweet)
        {
            var tl_tweets = await get_tweets_of_timeline_async();

            var mention_tweets = await get_mentioned_tweets_async();

            var union_list = tl_tweets.Union(mention_tweets).ToList();

            var get_replies = union_list.Where(x => x.replying_to != null && x.replying_to.tweet_id == tweet.tweet_id).ToList();

            return get_replies;
        }

        /// <summary>
        /// Get replies to tweet
        /// </summary>
        public List<TweetData> get_replies_of_tweet_by_id(string tweet_id)
        {
            var tl_tweets = get_tweets_of_timeline();

            var mention_tweets = get_mentioned_tweets();

            var union_list = tl_tweets.Union(mention_tweets).ToList();

            var get_replies = union_list.Where(x => x.replying_to != null && x.replying_to.tweet_id == tweet_id).ToList();

            return get_replies;
        }

        /// <summary>
        /// Get replies to tweet
        /// </summary>
        public static List<TweetData> get_replies_of_tweet_by_id_static(string tweet_id)
        {
            var tl_tweets = get_tweets_of_timeline_static();

            var mention_tweets = get_mentioned_tweets_static();

            var union_list = tl_tweets.Union(mention_tweets).ToList();

            var get_replies = union_list.Where(x => x.replying_to != null && x.replying_to.tweet_id == tweet_id).ToList();

            return get_replies;
        }

        /// <summary>
        /// Get replies to tweet
        /// </summary>
        public async Task<List<TweetData>> get_replies_of_tweet_by_id_async(string tweet_id)
        {
            var tl_tweets = await get_tweets_of_timeline_async();

            var mention_tweets = await get_mentioned_tweets_async();

            var union_list = tl_tweets.Union(mention_tweets).ToList();

            var get_replies = union_list.Where(x => x.replying_to != null && x.replying_to.tweet_id == tweet_id).ToList();

            return get_replies;
        }
    }
}
