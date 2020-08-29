using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TwitterOps.Models;

namespace TwitterOps
{
    public class Tasks
    {
        private static APIHandler APIHandler { get; set; }

        private static UserData LoggedUser { get; set; }

        public Tasks(string consumerKey, string consumerSecret, string tokenValue, string tokenSecret)
        {
            APIHandler = new APIHandler(consumerKey, consumerSecret, tokenValue, tokenSecret);
            LoggedUser = GetLoggedUser();

        }

        // ----------------------------------------------------------- Twitter API v1.1 calls -----------------------------------------------------------  //


        /*
          
                                                            ___________                      __          
                                                            \__    ___/_  _  __ ____   _____/  |_  ______
                                                              |    |  \ \/ \/ // __ \_/ __ \   __\/  ___/
                                                              |    |   \     /\  ___/\  ___/|  |  \___ \ 
                                                              |____|    \/\_/  \___  >\___  >__| /____  >
                                                                                   \/     \/          \/ 
         
         */



        // ---------------------------------------------------------------- ALL GET'S ---------------------------------------------------------------- //


        /// <summary>
        /// Get tweet data based of tweet_id (status_id)
        /// </summary>
        public TweetData GetTweetData(string tweet_id)
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/show.json?id=" + tweet_id, APIHandler.Method.GET);
            var tweet_data = JObject.Parse(response.Result);

            var tweet = new TweetData(tweet_data);

            return tweet;
        }

        /// <summary>
        /// Get tweet data based of tweet_id (status_id)
        /// </summary>
        public static TweetData GetTweetDataStatic(string tweet_id)
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/show.json?id=" + tweet_id, APIHandler.Method.GET);
            var tweet_data = JObject.Parse(response.Result);

            var tweet = new TweetData(tweet_data);

            return tweet;
        }

        /// <summary>
        /// Get tweet data based of tweet_id (status_id)
        /// </summary>
        public async Task<TweetData> GetTweetDataAsync(string tweet_id)
        {
            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/show.json?id=" + tweet_id, APIHandler.Method.GET);
            var tweet_data = JObject.Parse(response);

            var tweet = new TweetData(tweet_data);

            return tweet;
        }

        /// <summary>
        /// Get tweets from tl and return a list of TweetData
        /// </summary>
        public List<TweetData> GetTweetsOfTimeline()
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/user_timeline.json?include_rts=false", APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response.Result).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get tweets from tl and return a list of TweetData
        /// </summary>
        public static List<TweetData> GetTweetsOfTimelineStatic()
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/user_timeline.json?include_rts=false", APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response.Result).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get tweets from tl and return a list of TweetData
        /// </summary>
        public async Task<List<TweetData>> GetTweetsOfTimelineAsync()
        {
            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/user_timeline.json?include_rts=false", APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get last tweets in which user was mentioned and returns a TweetReply instance
        /// </summary>
        public List<TweetData> GetMentionedTweets()
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/mentions_timeline.json", APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response.Result).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get last tweets in which user was mentioned and returns a TweetReply instance
        /// </summary>
        public static List<TweetData> GetMentionedTweetsStatic()
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/mentions_timeline.json", APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response.Result).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get last tweets in which user was mentioned and returns a TweetReply instance
        /// </summary>
        public async Task<List<TweetData>> GetMentionedTweetsAsync()
        {
            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/mentions_timeline.json", APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get last tweets in which user was mentioned with a count parameter and returns a TweetReply instance
        /// </summary>
        public List<TweetData> GetMentionedTweets(int count)
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/mentions_timeline.json?count=" + count, APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response.Result).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get last tweets in which user was mentioned with a count parameter and returns a TweetReply instance
        /// </summary>
        public static List<TweetData> GetMentionedTweetsStatic(int count)
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/mentions_timeline.json?count=" + count, APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response.Result).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get last tweets in which user was mentioned with a count parameter and returns a TweetReply instance
        /// </summary>
        public async Task<List<TweetData>> GetMentionedTweetsAsync(int count)
        {
            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/mentions_timeline.json?count=" + count, APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Check if last mention to user was replied
        /// </summary>
        public Tuple<bool, TweetData> IsLastMentionReplied()
        {
            var last_mention = GetMentionedTweets(1)[0];
            var check = last_mention.replies.Count != 0;

            var result = new Tuple<bool, TweetData>(check, last_mention);

            return result;
        }

        /// <summary>
        /// Check if last mention to user was replied
        /// </summary>
        public static Tuple<bool, TweetData> IsLastMentionRepliedStatic()
        {
            var last_mention = GetMentionedTweetsStatic(1)[0];
            var check = last_mention.replies != null;

            var result = new Tuple<bool, TweetData>(check, last_mention);

            return result;
        }

        /// <summary>
        /// Check if last mention to user was replied
        /// </summary>
        public async Task<Tuple<bool, TweetData>> IsLastMentionRepliedAsync()
        {
            var last_mention = await GetMentionedTweetsAsync(1);
            var check = last_mention[0].replies != null;

            var result = new Tuple<bool, TweetData>(check, last_mention[0]);

            return result;
        }

        /// <summary>
        /// Check if last mention to user was replied by logged user in API credentials
        /// </summary>
        public Tuple<bool, TweetData> IsLastMentionRepliedByLoggedUser()
        {
            var last_mention = GetMentionedTweets(1)[0];

            var data = last_mention.replies;

            var check = data.Count != 0;

            if (check)
                check = data.Where(w => w.user.user_id == LoggedUser.user_id).Count() > 0;

            var result = new Tuple<bool, TweetData>(check, last_mention);

            return result;
        }

        /// <summary>
        /// Check if last mention to user was replied by logged user in API credentials
        /// </summary>
        public static Tuple<bool, TweetData> IsLastMentionRepliedByLoggedUserStatic()
        {
            var last_mention = GetMentionedTweetsStatic(1)[0];

            var data = last_mention.replies;

            var check = data.Count != 0;

            if (check)
                check = data.Where(w => w.user.user_id == LoggedUser.user_id).Count() > 0;

            var result = new Tuple<bool, TweetData>(check, last_mention);

            return result;
        }

        /// <summary>
        /// Check if last mention to user was replied by logged user in API credentials
        /// </summary>
        public async Task<Tuple<bool, TweetData>> IsLastMentionRepliedByLoggedUserAsync(string user_id)
        {
            var last_mention = await GetMentionedTweetsAsync(1);

            var data = last_mention[0].replies;

            var check = data != null;

            if (check)
                check = data.Where(w => w.user.user_id == LoggedUser.user_id).Count() > 0;

            var result = new Tuple<bool, TweetData>(check, last_mention[0]);

            return result;
        }

        /// <summary>
        /// Check if last mention to user was replied by user using user_id parameter
        /// </summary>
        public Tuple<bool, TweetData> IsLastMentionRepliedByUser(string user_id)
        {
            var last_mention = GetMentionedTweets(1)[0];

            var data = last_mention.replies;

            var check = data.Count != 0;

            if (check)
                check = data.Where(w => w.user.user_id == user_id).Count() > 0;

            var result = new Tuple<bool, TweetData>(check, last_mention);

            return result;
        }

        /// <summary>
        /// Check if last mention to user was replied by user using user_id parameter
        /// </summary>
        public static Tuple<bool, TweetData> IsLastMentionRepliedByUserStatic(string user_id)
        {
            var last_mention = GetMentionedTweetsStatic(1)[0];

            var data = last_mention.replies;

            var check = data.Count != 0;

            if (check)
                check = data.Where(w => w.user.user_id == user_id).Count() > 0;

            var result = new Tuple<bool, TweetData>(check, last_mention);

            return result;
        }

        /// <summary>
        /// Check if last mention to user was replied by user using user_id parameter
        /// </summary>
        public async Task<Tuple<bool, TweetData>> IsLastMentionRepliedByUserAsync(string user_id)
        {
            var last_mention = await GetMentionedTweetsAsync(1);

            var data = last_mention[0].replies;

            var check = data != null;

            if (check)
                check = data.Where(w => w.user.user_id == user_id).Count() > 0;

            var result = new Tuple<bool, TweetData>(check, last_mention[0]);

            return result;
        }

        /// <summary>
        /// Check if last mention to user was replied by user using UserData instance
        /// </summary>
        public Tuple<bool, TweetData> IsLastMentionRepliedByUser(UserData user)
        {
            var last_mention = GetMentionedTweets(1)[0];

            var data = last_mention.replies;

            var check = data.Count != 0;

            if (check)
                check = data.Where(w => w.user.user_id == user.user_id).Count() > 0;

            var result = new Tuple<bool, TweetData>(check, last_mention);

            return result;
        }

        /// <summary>
        /// Check if last mention to user was replied by user using UserData instance
        /// </summary>
        public static Tuple<bool, TweetData> IsLastMentionRepliedByUserStatic(UserData user)
        {
            var last_mention = GetMentionedTweetsStatic(1)[0];

            var data = last_mention.replies;

            var check = data.Count != 0;

            if (check)
                check = data.Where(w => w.user.user_id == user.user_id).Count() > 0;

            var result = new Tuple<bool, TweetData>(check, last_mention);

            return result;
        }

        /// <summary>
        /// Check if last mention to user was replied by user using UserData instance
        /// </summary>
        public async Task<Tuple<bool, TweetData>> IsLastMentionRepliedByUserAsync(UserData user)
        {
            var last_mention = await GetMentionedTweetsAsync(1);

            var data = last_mention[0].replies;

            var check = data != null;

            if (check)
                check = data.Where(w => w.user.user_id == user.user_id).Count() > 0;

            var result = new Tuple<bool, TweetData>(check, last_mention[0]);

            return result;
        }

        /// <summary>
        /// Get replies to tweet
        /// </summary>
        public List<TweetData> GetRepliesOfTweet(TweetData tweet)
        {
            var tl_tweets = GetTweetsOfTimeline();

            var mention_tweets = GetMentionedTweets();

            var union_list = tl_tweets.Union(mention_tweets).ToList();

            var get_replies = union_list.Where(x => x.replying_to != null && x.replying_to.tweet_id == tweet.tweet_id).ToList();

            return get_replies;
        }

        /// <summary>
        /// Get replies to tweet
        /// </summary>
        public static List<TweetData> GetRepliesOfTweetStatic(TweetData tweet)
        {
            var tl_tweets = GetTweetsOfTimelineStatic();

            var mention_tweets = GetMentionedTweetsStatic();

            var union_list = tl_tweets.Union(mention_tweets).GroupBy(x => x.tweet_id).Select(w => w.First()).ToList();

            var get_replies = union_list.Where(x => x.replying_to != null && x.replying_to.tweet_id == tweet.tweet_id).ToList();

            return get_replies;
        }

        /// <summary>
        /// Get replies to tweet
        /// </summary>
        public async Task<List<TweetData>> GetRepliesOfTweetAsync(TweetData tweet)
        {
            var tl_tweets = await GetTweetsOfTimelineAsync();

            var mention_tweets = await GetMentionedTweetsAsync();

            var union_list = tl_tweets.Union(mention_tweets).GroupBy(x => x.tweet_id).Select(w => w.First()).ToList();

            var get_replies = union_list.Where(x => x.replying_to != null && x.replying_to.tweet_id == tweet.tweet_id).ToList();

            return get_replies;
        }

        /// <summary>
        /// Get replies to tweet
        /// </summary>
        public List<TweetData> GetRepliesOfTweetByID(string tweet_id)
        {
            var tl_tweets = GetTweetsOfTimeline();

            var mention_tweets = GetMentionedTweets();

            var union_list = tl_tweets.Union(mention_tweets).GroupBy(x => x.tweet_id).Select(w => w.First()).ToList();

            var get_replies = union_list.Where(x => x.replying_to != null && x.replying_to.tweet_id == tweet_id).ToList();

            return get_replies;
        }

        /// <summary>
        /// Get replies to tweet
        /// </summary>
        public static List<TweetData> GetRepliesOfTweetByIDStatic(string tweet_id)
        {
            var tl_tweets = GetTweetsOfTimelineStatic();

            var mention_tweets = GetMentionedTweetsStatic();

            var union_list = tl_tweets.Union(mention_tweets).GroupBy(x => x.tweet_id).Select(w => w.First()).ToList();

            var get_replies = union_list.Where(x => x.replying_to != null && x.replying_to.tweet_id == tweet_id).ToList();

            return get_replies;
        }

        /// <summary>
        /// Get replies to tweet
        /// </summary>
        public async Task<List<TweetData>> GetRepliesOfTweetByIDAsync(string tweet_id)
        {
            var tl_tweets = await GetTweetsOfTimelineAsync();

            var mention_tweets = await GetMentionedTweetsAsync();

            var union_list = tl_tweets.Union(mention_tweets).GroupBy(x => x.tweet_id).Select(w => w.First()).ToList();

            var get_replies = union_list.Where(x => x.replying_to != null && x.replying_to.tweet_id == tweet_id).ToList();

            return get_replies;
        }



        // ---------------------------------------------------------------- ALL POST'S ---------------------------------------------------------------- //


        /// <summary>
        /// Post a tweet passing string with text
        /// </summary>
        public TweetData PostTweet(string text)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);

            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet passing string with text
        /// </summary>
        public static TweetData PostTweetStatic(string text)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);

            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet passing string with text
        /// </summary>
        public async Task<TweetData> PostTweetAsync(string text)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);

            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response));

            return tweet_data;
        }

        /// <summary>
        /// Reply a tweet passing string with text and TweetData instance
        /// </summary>
        public TweetData PostReplyTweet(string text, TweetData tweet)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);
            parameters.Add("in_reply_to_status_id", tweet.tweet_id);
            parameters.Add("auto_populate_reply_metadata", true);

            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Reply a tweet passing string with text and TweetData instance
        /// </summary>
        public static TweetData PostReplyTweetStatic(string text, TweetData tweet)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);
            parameters.Add("in_reply_to_status_id", tweet.tweet_id);
            parameters.Add("auto_populate_reply_metadata", true);

            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Reply a tweet passing string with text and TweetData instance
        /// </summary>
        public async Task<TweetData> PostReplyTweetAsync(string text, TweetData tweet)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);
            parameters.Add("in_reply_to_status_id", tweet.tweet_id);
            parameters.Add("auto_populate_reply_metadata", true);

            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response));

            return tweet_data;
        }

        /// <summary>
        /// Reply a tweet passing string with text and tweet_id (status_id)
        /// </summary>
        public static TweetData PostReplyTweet(string text, string tweet_id)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);
            parameters.Add("in_reply_to_status_id", tweet_id);
            parameters.Add("auto_populate_reply_metadata", true);

            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Reply a tweet passing string with text and tweet_id (status_id)
        /// </summary>
        public static TweetData PostReplyTweetStatic(string text, string tweet_id)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);
            parameters.Add("in_reply_to_status_id", tweet_id);
            parameters.Add("auto_populate_reply_metadata", true);

            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Reply a tweet passing string with text and tweet_id (status_id)
        /// </summary>
        public async Task<TweetData> PostReplyTweetAsync(string text, string tweet_id)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);
            parameters.Add("in_reply_to_status_id", tweet_id);
            parameters.Add("auto_populate_reply_metadata", true);

            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response));

            return tweet_data;
        }


        /*
                                                                 ____ ___                           
                                                                |    |   \______ ___________  ______
                                                                |    |   /  ___// __ \_  __ \/  ___/
                                                                |    |  /\___ \\  ___/|  | \/\___ \ 
                                                                |______//____  >\___  >__|  /____  >
                                                                             \/     \/           \/ 
         */



        // ---------------------------------------------------------------- ALL GET'S ---------------------------------------------------------------- //

        /// <summary>
        /// Get UserData instance by user_id
        /// </summary>
        public UserData GetUserById(string user_id)
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/users/show.json?user_id=" + user_id, APIHandler.Method.GET);
            var user_data = JObject.Parse(response.Result);

            return new UserData(user_data);
        }

        /// <summary>
        /// Get UserData instance by user_id
        /// </summary>
        public static UserData GetUserByIdStatic(string user_id)
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/users/show.json?user_id=" + user_id, APIHandler.Method.GET);
            var user_data = JObject.Parse(response.Result);

            return new UserData(user_data);
        }

        /// <summary>
        /// Get UserData instance by user_id
        /// </summary>
        public async Task<UserData> GetUserByIdAsync(string user_id)
        {
            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/users/show.json?user_id=" + user_id, APIHandler.Method.GET);
            var user_data = JObject.Parse(response);

            return new UserData(user_data);
        }

        /// <summary>
        /// Get UserData instance by username (screen_name)
        /// </summary>
        public UserData GetUserByScreenName(string username)
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/users/show.json?screen_name=" + username, APIHandler.Method.GET);
            var user_data = JObject.Parse(response.Result);

            return new UserData(user_data);
        }

        /// <summary>
        /// Get UserData instance by username (screen_name)
        /// </summary>
        public static UserData GetUserByScreenNameStatic(string username)
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/users/show.json?screen_name=" + username, APIHandler.Method.GET);
            var user_data = JObject.Parse(response.Result);

            return new UserData(user_data);
        }

        /// <summary>
        /// Get UserData instance by username (screen_name)
        /// </summary>
        public async Task<UserData> GetUserByScreenNameAsync(string username)
        {
            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/users/show.json?screen_name=" + username, APIHandler.Method.GET);
            var user_data = JObject.Parse(response);

            return new UserData(user_data);
        }
        /// <summary>
        /// Get UserData of Logged User in API credentials
        /// </summary>
        public UserData GetLoggedUser()
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/account/verify_credentials.json", APIHandler.Method.GET);
            var user_data = JObject.Parse(response.Result);

            return new UserData(user_data);
        }

        /// <summary>
        /// Get UserData of Logged User in API credentials
        /// </summary>
        public static UserData GetLoggedUserStatic()
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/account/verify_credentials.json", APIHandler.Method.GET);
            var user_data = JObject.Parse(response.Result);

            return new UserData(user_data);
        }

        /// <summary>
        /// Get UserData of Logged User in API credentials
        /// </summary>
        public async Task<UserData> GetLoggedUserAsync()
        {
            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/account/verify_credentials.json", APIHandler.Method.GET);
            var user_data = JObject.Parse(response);

            return new UserData(user_data);
        }

        /// <summary>
        /// Check if User is shadowbanned by UserData instance
        /// </summary>
        public bool IsUserShadowbanned(UserData user)
        {
            string url = "https://twitter.com/search?q=" + user.username + "&src=typed_query";
            var Webget = new HtmlWeb();
            var doc = Webget.Load(url);

            bool check = false;

            if (doc.DocumentNode.SelectSingleNode("//div[@class='noresults']") != null)
                check = true;

            return check;
        }

        /// <summary>
        /// Check if User is shadowbanned by UserData instance
        /// </summary>
        public static bool IsUserShadowbannedStatic(UserData user)
        {
            string url = "https://twitter.com/search?q=" + user.username + "&src=typed_query";
            var Webget = new HtmlWeb();
            var doc = Webget.Load(url);

            bool check = false;

            if (doc.DocumentNode.SelectSingleNode("//div[@class='noresults']") != null)
                check = true;

            return check;
        }

        /// <summary>
        /// Check if User is shadowbanned by username
        /// </summary>
        public bool IsUserShadowbanned(string username)
        {
            string url = "https://twitter.com/search?q=" + username + "&src=typed_query";
            var Webget = new HtmlWeb();
            var doc = Webget.Load(url);

            bool check = false;

            if (doc.DocumentNode.SelectSingleNode("//div[@class='noresults']") != null)
                check = true;

            return check;
        }


        /// <summary>
        /// Get List of Followers of User
        /// </summary>
        public List<UserData> GetUserFollowers(UserData user)
        {
            var list_users = new List<UserData>();

            //it's the max number of count by request according to documention
            int max_entries = 200;

            string page = string.Empty;

            while (true)
            {
                var next_cursor = page == "" ? "" : "&cursor=" + page;
                var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/followers/list.json?count=" + max_entries + "&user_id=" + user.user_id + next_cursor, APIHandler.Method.GET);

                var result_data = JObject.Parse(response.Result);

                page = result_data["next_cursor"].ToString();

                var result_users = result_data["users"].Children<JObject>().Select(x => new UserData(x)).ToList();

                list_users.AddRange(result_users);

                if (page == "0")
                    break;
            }

            return list_users;
        }

        /// <summary>
        /// Get List of Followers of User
        /// </summary>
        public static List<UserData> GetUserFollowersStatic(UserData user)
        {
            var list_users = new List<UserData>();

            int max_entries = 200;
            string page = string.Empty;

            while (true)
            {
                var next_cursor = page == "" ? "" : "&cursor=" + page;
                var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/followers/list.json?count=" + max_entries + "&user_id=" + user.user_id + next_cursor, APIHandler.Method.GET);

                var result_data = JObject.Parse(response.Result);

                page = result_data["next_cursor"].ToString();

                var result_users = result_data["users"].Children<JObject>().Select(x => new UserData(x)).ToList();

                list_users.AddRange(result_users);

                if (page == "0")
                    break;
            }

            return list_users;
        }

        /// <summary>
        /// Get List of Followers of User
        /// </summary>
        public async Task<List<UserData>> GetUserFollowersAsync(UserData user)
        {
            var list_users = new List<UserData>();

            int max_entries = 200;
            string page = string.Empty;

            while (true)
            {
                var next_cursor = page == "" ? "" : "&cursor=" + page;
                var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/followers/list.json?count=" + max_entries + "&user_id=" + user.user_id + next_cursor, APIHandler.Method.GET);

                var result_data = JObject.Parse(response);

                page = result_data["next_cursor"].ToString();

                var result_users = result_data["users"].Children<JObject>().Select(x => new UserData(x)).ToList();

                list_users.AddRange(result_users);

                if (page == "0")
                    break;
            }

            return list_users;
        }

        /// <summary>
        /// Get List of User's Followings
        /// </summary>
        public List<UserData> GetUserFollowings(UserData user)
        {
            var list_users = new List<UserData>();

            //it's the max number of count by request according to documention
            int max_entries = 200;

            string page = string.Empty;

            while (true)
            {
                var next_cursor = page == "" ? "" : "&cursor=" + page;
                var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/friends/list.json?count=" + max_entries + "&user_id=" + user.user_id + next_cursor, APIHandler.Method.GET);

                var result_data = JObject.Parse(response.Result);

                page = result_data["next_cursor"].ToString();

                var result_users = result_data["users"].Children<JObject>().Select(x => new UserData(x)).ToList();

                list_users.AddRange(result_users);

                if (page == "0")
                    break;
            }

            return list_users;
        }

        /// <summary>
        /// Get List of User's Followings
        /// </summary>
        public static List<UserData> GetUserFollowingsStatic(UserData user)
        {
            var list_users = new List<UserData>();

            //it's the max number of count by request according to documention
            int max_entries = 200;

            string page = string.Empty;

            while (true)
            {
                var next_cursor = page == "" ? "" : "&cursor=" + page;
                var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/friends/list.json?count=" + max_entries + "&user_id=" + user.user_id + next_cursor, APIHandler.Method.GET);

                var result_data = JObject.Parse(response.Result);

                page = result_data["next_cursor"].ToString();

                var result_users = result_data["users"].Children<JObject>().Select(x => new UserData(x)).ToList();

                list_users.AddRange(result_users);

                if (page == "0")
                    break;
            }

            return list_users;
        }

        /// <summary>
        /// Get List of User's Followings
        /// </summary>
        public async Task<List<UserData>> GetUserFollowingsAsync(UserData user)
        {
            var list_users = new List<UserData>();

            //it's the max number of count by request according to documention
            int max_entries = 200;

            string page = string.Empty;

            while (true)
            {
                var next_cursor = page == "" ? "" : "&cursor=" + page;
                var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/friends/list.json?count=" + max_entries + "&user_id=" + user.user_id + next_cursor, APIHandler.Method.GET);

                var result_data = JObject.Parse(response);

                page = result_data["next_cursor"].ToString();

                var result_users = result_data["users"].Children<JObject>().Select(x => new UserData(x)).ToList();

                list_users.AddRange(result_users);

                if (page == "0")
                    break;
            }

            return list_users;
        }
    }
}
