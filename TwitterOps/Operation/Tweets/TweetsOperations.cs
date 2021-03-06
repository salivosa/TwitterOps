﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterOps.Operation.Media;
using TwitterOps.Operation.Users;

namespace TwitterOps.Operation.Tweets
{
    public class TweetsOperations
    {
        private APIHandler APIHandler { get; set; }

        private UserData LoggedUser { get; set; }
        public TweetsOperations(APIHandler APIHandler, UserData LoggedUser)
        {
            this.APIHandler = APIHandler;
            this.LoggedUser = LoggedUser;
        }

        // ---------------------------------------------------------------- ALL GET'S ---------------------------------------------------------------- //


        // ----------------------------------------------------------- Twitter API v1.1 calls -----------------------------------------------------------  //

        /// <summary>
        /// Get tweet data based of tweet_id (status_id)
        /// </summary>
        public TweetData GetTweetById(string tweet_id)
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/show.json?id=" + tweet_id, APIHandler.Method.GET);
            var tweet_data = JObject.Parse(response.Result);

            var tweet = new TweetData(tweet_data);

            return tweet;
        }

        /// <summary>
        /// Get tweet data based of tweet_id (status_id)
        /// </summary>
        public static TweetData GetTweetByIdStatic(string tweet_id)
        {
            var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/show.json?id=" + tweet_id, APIHandler.Method.GET);
            var tweet_data = JObject.Parse(response.Result);

            var tweet = new TweetData(tweet_data);

            return tweet;
        }

        /// <summary>
        /// Get tweet data based of tweet_id (status_id)
        /// </summary>
        public async Task<TweetData> GetTweetByIdAsync(string tweet_id)
        {
            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/show.json?id=" + tweet_id, APIHandler.Method.GET);
            var tweet_data = JObject.Parse(response);

            var tweet = new TweetData(tweet_data);

            return tweet;
        }

        /// <summary>
        /// Get tweets from tl of logged user
        /// </summary>
        public List<TweetData> GetTweetsOfTimeline()
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/user_timeline.json?include_rts=false", APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response.Result).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get tweets from tl of logged user
        /// </summary>
        public static List<TweetData> GetTweetsOfTimelineStatic()
        {
            var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/user_timeline.json?include_rts=false", APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response.Result).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get tweets from tl of logged user
        /// </summary>
        public async Task<List<TweetData>> GetTweetsOfTimelineAsync()
        {
            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/user_timeline.json?include_rts=false", APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get tweets from tl of UserData
        /// </summary>
        public List<TweetData> GetTweetsOfTimeline(UserData user)
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/user_timeline.json?include_rts=false&count=200&user_id=" + user.user_id, APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response.Result).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get tweets from tl of UserData
        /// </summary>
        public static List<TweetData> GetTweetsOfTimelineStatic(UserData user)
        {
            var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/user_timeline.json?include_rts=false&count=200&user_id=" + user.user_id, APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response.Result).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get tweets from tl of UserData
        /// </summary>
        public async Task<List<TweetData>> GetTweetsOfTimelineAsync(UserData user)
        {
            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/user_timeline.json?include_rts=false&count=200&user_id=" + user.user_id, APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get tweets from tl of UserData
        /// </summary>
        public List<TweetData> GetTweetsOfTimelineSinceTweet(TweetData tweet)
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/user_timeline.json?include_rts=false&count=200&since_id=" + tweet.tweet_id + "&user_id=" + tweet.user.user_id, APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response.Result).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get tweets from tl of UserData
        /// </summary>
        public static List<TweetData> GetTweetsOfTimelineSinceTweetStatic(TweetData tweet)
        {
            var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/user_timeline.json?include_rts=false&count=200&since_id=" + tweet.tweet_id + "&user_id=" + tweet.user.user_id, APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response.Result).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get tweets from tl of UserData
        /// </summary>
        public async Task<List<TweetData>> GetTweetsOfTimelineSinceTweetAsync(TweetData tweet)
        {
            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/user_timeline.json?include_rts=false&count=200&since_id=" + tweet.tweet_id + "&user_id=" + tweet.user.user_id, APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get last tweets in which user was mentioned and returns a TweetData instance
        /// </summary>
        public List<TweetData> GetMentionedTweets()
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/mentions_timeline.json", APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response.Result).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get last tweets in which user was mentioned and returns a TweetData instance
        /// </summary>
        public static List<TweetData> GetMentionedTweetsStatic()
        {
            var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/mentions_timeline.json", APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response.Result).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get last tweets in which user was mentioned and returns a TweetData instance
        /// </summary>
        public async Task<List<TweetData>> GetMentionedTweetsAsync()
        {
            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/mentions_timeline.json", APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get last tweets in which user was mentioned with a count parameter and returns a TweetData instance
        /// </summary>
        public List<TweetData> GetMentionedTweets(int count)
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/mentions_timeline.json?count=" + count, APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response.Result).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get last tweets in which user was mentioned with a count parameter and returns a TweetData instance
        /// </summary>
        public static List<TweetData> GetMentionedTweetsStatic(int count)
        {
            var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/mentions_timeline.json?count=" + count, APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response.Result).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get last tweets in which user was mentioned with a count parameter and returns a TweetData instance
        /// </summary>
        public async Task<List<TweetData>> GetMentionedTweetsAsync(int count)
        {
            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/mentions_timeline.json?count=" + count, APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get last tweets in which user was mentioned and returns a TweetData instance
        /// </summary>
        public List<TweetData> GetMentionedTweetsByUser(UserData user)
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/mentions_timeline.json?user_id=" + user.user_id, APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response.Result).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get last tweets in which user was mentioned and returns a TweetData instance
        /// </summary>
        public static List<TweetData> GetMentionedTweetsByUserStatic(UserData user)
        {
            var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/mentions_timeline.json?user_id=" + user.user_id, APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response.Result).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get last tweets in which user was mentioned and returns a TweetData instance
        /// </summary>
        public async Task<List<TweetData>> GetMentionedTweetsByUserAsync(UserData user)
        {
            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/mentions_timeline.json?user_id=" + user.user_id, APIHandler.Method.GET);

            var tweet_data = JArray.Parse(response).Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get last tweets in which user was mentioned since Tweet
        /// </summary>
        public List<TweetData> GetMentionedTweetsSinceTweet(TweetData tweet)
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/search/tweets.json?q=" + tweet.user.username + "&count=100&since_id=" + tweet.tweet_id, APIHandler.Method.GET);

            var tweet_data = JObject.Parse(response.Result)["statuses"].Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get last tweets in which user was mentioned since Tweet
        /// </summary>
        public static List<TweetData> GetMentionedTweetsSinceTweetStatic(TweetData tweet)
        {
            var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/search/tweets.json?q=" + tweet.user.username + "&count=100&since_id=" + tweet.tweet_id, APIHandler.Method.GET);

            var tweet_data = JObject.Parse(response.Result)["statuses"].Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get last tweets in which user was mentioned since Tweet
        /// </summary>
        public async Task<List<TweetData>> GetMentionedTweetsSinceTweetAsync(TweetData tweet)
        {
            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/search/tweets.json?q=" + tweet.user.username + "&count=100&since_id=" + tweet.tweet_id, APIHandler.Method.GET);

            var tweet_data = JObject.Parse(response)["statuses"].Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get last tweets in which user was mentioned since Tweet
        /// </summary>
        public List<TweetData> GetMentionedTweetsSinceTweetByUser(TweetData tweet, UserData user)
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/search/tweets.json?q=" + user.username + "&count=100&result_type=recent&max_id=" + tweet.tweet_id, APIHandler.Method.GET);

            var tweet_data = JObject.Parse(response.Result)["statuses"].Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get last tweets in which user was mentioned since Tweet
        /// </summary>
        public static List<TweetData> GetMentionedTweetsSinceTweetByUserStatic(TweetData tweet, UserData user)
        {
            var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/search/tweets.json?q=" + user.username + "&count=100&result_type=recent&max_id=" + tweet.tweet_id, APIHandler.Method.GET);

            var tweet_data = JObject.Parse(response.Result)["statuses"].Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get last tweets in which user was mentioned since Tweet
        /// </summary>
        public async Task<List<TweetData>> GetMentionedTweetsSinceTweetByUserAsync(TweetData tweet, UserData user)
        {
            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/search/tweets.json?q=" + user.username + "&count=100&result_type=recent&max_id=" + tweet.tweet_id, APIHandler.Method.GET);

            var tweet_data = JObject.Parse(response)["statuses"].Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get Tweets Mentioning User
        /// </summary>
        public List<TweetData> GetMentionedTweets(UserData user)
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/search/tweets.json?q=" + user.username + "&count=100", APIHandler.Method.GET);

            var tweet_data = JObject.Parse(response.Result)["statuses"].Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }

        /// <summary>
        /// Get Tweets Mentioning User
        /// </summary>
        public static List<TweetData> GetMentionedTweetsStatic(UserData user)
        {
            var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/search/tweets.json?q=" + user.username + "&count=100", APIHandler.Method.GET);

            var tweet_data = JObject.Parse(response.Result)["statuses"].Children<JObject>().Select(x => new TweetData(x)).ToList();

            return tweet_data;
        }


        // ----------------------------------------------------------- Twitter API v2 calls -----------------------------------------------------------  //

        /// <summary>
        /// Get Replies Count From Twitter API v2
        /// </summary>
        public JToken GetTweetPublicMetrics(TweetData tweet)
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/2/tweets/" + tweet.tweet_id + "?tweet.fields=public_metrics", APIHandler.Method.GET);

            var tweet_data = JObject.Parse(response.Result)["data"]["public_metrics"];

            return tweet_data;
        }

        /// <summary>
        /// Get Replies Count From Twitter API v2
        /// </summary>
        public static JToken GetTweetPublicMetricsStatic(TweetData tweet)
        {
            var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/2/tweets/" + tweet.tweet_id + "?tweet.fields=public_metrics", APIHandler.Method.GET);

            var tweet_data = JObject.Parse(response.Result)["data"]["public_metrics"];

            return tweet_data;
        }

        /// <summary>
        /// Get Replies Count From Twitter API v2
        /// </summary>
        public async Task<JToken> GetTweetPublicMetricsAsync(TweetData tweet)
        {
            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/2/tweets/" + tweet.tweet_id + "?tweet.fields=public_metrics", APIHandler.Method.GET);

            var tweet_data = JObject.Parse(response)["data"]["public_metrics"];

            return tweet_data;
        }


        // ----------------------------------------------------------- Custom Operations -----------------------------------------------------------  //

        /// <summary>
        /// Get linear thread of tweet
        /// </summary>
        public List<TweetData> GetThreadFromTweet(TweetData tweet)
        {
            var tweet_replies = tweet.replies;

            var tweets_replying_to = new List<TweetData>();

            var tweet_replying_to = tweet.replying_to;

            while (true)
            {
                if (tweet_replying_to == null)
                    break;

                tweets_replying_to.Add(tweet_replying_to);

                tweet_replying_to = tweet_replying_to.replying_to;
            }

            var thread = tweets_replying_to.Union(tweet_replies).ToList();
            thread.Add(tweet);
            thread = thread.OrderBy(w => w.created_at).ToList();

            return thread;
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
            var last_mention = GetMentionedTweets().OrderBy(z => z.created_at).Last();

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
                check = data.Where(w => w.user.user_id == Operations.LoggedUser.user_id).Count() > 0;

            var result = new Tuple<bool, TweetData>(check, last_mention);

            return result;
        }

        /// <summary>
        /// Check if last mention to user was replied by logged user in API credentials
        /// </summary>
        public async Task<Tuple<bool, TweetData>> IsLastMentionRepliedByLoggedUserAsync()
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
        /// Get replies to tweet. Still with some problems
        /// </summary>
        public List<TweetData> GetRepliesOfTweet(TweetData tweet)
        {
            var tl_tweets = GetTweetsOfTimelineSinceTweet(tweet).OrderByDescending(w => w.created_at).ToList();

            var mention_tweets = GetMentionedTweetsSinceTweet(tweet);

            var captured_tweets = tl_tweets.Union(mention_tweets).ToList();

            var replies = new List<TweetData>();

            int replies_count = tweet.replies_count;
            int last_iteration_count = 0;

            while (true)
            {
                foreach (var captured_tweet in captured_tweets)
                {
                    var data = captured_tweet.replying_to;

                    if (data != null)
                        if (captured_tweet.replying_to.tweet_id == tweet.tweet_id)
                            replies.Add(captured_tweet);
                }

                if ((replies.Count < replies_count) && (replies.Count != last_iteration_count))
                {
                    if (replies_count == 1)
                        captured_tweets = GetMentionedTweetsSinceTweetByUser(replies.OrderByDescending(w => w.created_at).Last(), tweet.user);
                    else
                        captured_tweets = GetMentionedTweetsSinceTweetByUser(replies.Where(x => x.user.user_id != tweet.user.user_id).OrderByDescending(w => w.created_at).Last(), tweet.user);

                    captured_tweets = captured_tweets.Where(p => !replies.Any(z => z.tweet_id == p.tweet_id)).ToList();
                    last_iteration_count = replies.Count;
                }
                else
                    break;
            }

            replies = replies.GroupBy(x => x.tweet_id).Select(w => w.First()).ToList();

            return replies;
        }

        /// <summary>
        /// Get replies to tweet. Still with some problems
        /// </summary>
        public static List<TweetData> GetRepliesOfTweetStatic(TweetData tweet)
        {
            var tl_tweets = GetTweetsOfTimelineSinceTweetStatic(tweet).OrderByDescending(w => w.created_at).ToList();

            var mention_tweets = GetMentionedTweetsSinceTweetStatic(tweet);

            var captured_tweets = tl_tweets.Union(mention_tweets).ToList();

            var replies = new List<TweetData>();

            int replies_count = tweet.replies_count;
            int last_iteration_count = 0;

            while (replies.Count < replies_count)
            {
                foreach (var captured_tweet in captured_tweets)
                {
                    var data = captured_tweet.replying_to;

                    if (data != null)
                        if (captured_tweet.replying_to.tweet_id == tweet.tweet_id)
                            replies.Add(captured_tweet);
                }

                if ((replies.Count < replies_count) && replies.Count != last_iteration_count)
                {
                    if (replies_count == 1)
                        captured_tweets = GetMentionedTweetsSinceTweetByUserStatic(replies.OrderByDescending(w => w.created_at).Last(), tweet.user);
                    else
                        captured_tweets = GetMentionedTweetsSinceTweetByUserStatic(replies.Where(x => x.user.user_id != tweet.user.user_id).OrderByDescending(w => w.created_at).Last(), tweet.user);

                    captured_tweets = captured_tweets.Where(p => !replies.Any(z => z.tweet_id == p.tweet_id)).ToList();
                    last_iteration_count = replies.Count;
                }
                else
                    break;
            }

            replies = replies.GroupBy(x => x.tweet_id).Select(w => w.First()).ToList();

            return replies;
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

        // ----------------------------------------------------------- Twitter API v1.1 calls -----------------------------------------------------------  //

        //Limit of characters of a tweet atm
        static readonly int tweet_limit = 280;

        /// <summary>
        /// Post a tweet passing string with text
        /// </summary>
        public TweetData PostTweet(string text)
        {
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

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
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);

            var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet passing string with text
        /// </summary>
        public async Task<TweetData> PostTweetAsync(string text)
        {
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);

            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet with image from url
        /// </summary>
        public TweetData PostTweetWithImageURL(string img_url)
        {
            var image_data = MediaOperations.UploadImageFromURLStatic(img_url);

            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json?media_ids=" + image_data.media_id, APIHandler.Method.POST);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet with image from url
        /// </summary>
        public static TweetData PostTweetWithImageURLStatic(string img_url)
        {
            var image_data = MediaOperations.UploadImageFromURLStatic(img_url);

            var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json?media_ids=" + image_data.media_id, APIHandler.Method.POST);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet with image from url
        /// </summary>
        public async Task<TweetData> PostTweetWithImageURLAsync(string img_url)
        {
            var image_data = MediaOperations.UploadImageFromURLStatic(img_url);

            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json?media_ids=" + image_data.media_id, APIHandler.Method.POST);

            var tweet_data = new TweetData(JObject.Parse(response));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet with images from list of urls
        /// </summary>
        public TweetData PostTweetWithImagesURL(List<string> img_url)
        {
            var list_media = new List<MediaData>();

            foreach (var url in img_url)
                list_media.Add(MediaOperations.UploadImageFromURLStatic(url));

            //Only can post 4 images max in a tweet
            var list_media_ids = string.Join(",", list_media.Select(w => w.media_id).Take(4).ToList());

            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json?media_ids=" + list_media_ids, APIHandler.Method.POST);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet with images from list of urls
        /// </summary>
        public static TweetData PostTweetWithImagesURLStatic(List<string> img_url)
        {
            var list_media = new List<MediaData>();

            foreach (var url in img_url)
                list_media.Add(MediaOperations.UploadImageFromURLStatic(url));

            //Only can post 4 images max in a tweet
            var list_media_ids = string.Join(",", list_media.Select(w => w.media_id).Take(4).ToList());

            var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json?media_ids=" + list_media_ids, APIHandler.Method.POST);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet with images from list of urls
        /// </summary>
        public async Task<TweetData> PostTweetWithImagesURLAsync(List<string> img_url)
        {
            var list_media = new List<MediaData>();

            foreach (var url in img_url)
                list_media.Add(MediaOperations.UploadImageFromURLStatic(url));

            //Only can post 4 images max in a tweet
            var list_media_ids = string.Join(",", list_media.Select(w => w.media_id).Take(4).ToList());

            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json?media_ids=" + list_media_ids, APIHandler.Method.POST);

            var tweet_data = new TweetData(JObject.Parse(response));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet with text and images from list of urls
        /// </summary>
        public TweetData PostTweetWithImagesURL(string text, List<string> img_url)
        {
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

            var list_media = new List<MediaData>();

            foreach (var url in img_url)
                list_media.Add(MediaOperations.UploadImageFromURLStatic(url));

            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);

            //Only can post 4 images max in a tweet
            var list_media_ids = string.Join(",", list_media.Select(w => w.media_id).Take(4).ToList());

            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json?media_ids=" + list_media_ids, APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet with text and images from list of urls
        /// </summary>
        public static TweetData PostTweetWithImagesURLStatic(string text, List<string> img_url)
        {
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

            var list_media = new List<MediaData>();

            foreach (var url in img_url)
                list_media.Add(MediaOperations.UploadImageFromURLStatic(url));

            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);

            //Only can post 4 images max in a tweet
            var list_media_ids = string.Join(",", list_media.Select(w => w.media_id).Take(4).ToList());

            var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json?media_ids=" + list_media_ids, APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet with text and images from list of urls
        /// </summary>
        public async Task<TweetData> PostTweetWithImagesURLAsync(string text, List<string> img_url)
        {
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

            var list_media = new List<MediaData>();

            foreach (var url in img_url)
                list_media.Add(MediaOperations.UploadImageFromURLStatic(url));

            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);

            //Only can post 4 images max in a tweet
            var list_media_ids = string.Join(",", list_media.Select(w => w.media_id).Take(4).ToList());

            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json?media_ids=" + list_media_ids, APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet with text and image from url
        /// </summary>
        public TweetData PostTweetWithImageURL(string text, string img_url)
        {
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

            var image_data = MediaOperations.UploadImageFromURLStatic(img_url);

            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);

            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json?media_ids=" + image_data.media_id, APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet with text and image from url
        /// </summary>
        public static TweetData PostTweetWithImageURLStatic(string text, string img_url)
        {
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

            var image_data = MediaOperations.UploadImageFromURLStatic(img_url);

            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);

            var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json?media_ids=" + image_data.media_id, APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet with text and image from url
        /// </summary>
        public async Task<TweetData> PostTweetWithImageURLAsync(string text, string img_url)
        {
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

            var image_data = MediaOperations.UploadImageFromURLStatic(img_url);

            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);

            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json?media_ids=" + image_data.media_id, APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet with image from path
        /// </summary>
        public TweetData PostTweetWithImagePath(string path)
        {
            var image_data = MediaOperations.UploadImageFromPathStatic(path);

            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json?media_ids=" + image_data.media_id, APIHandler.Method.POST);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet with MediaData instance
        /// </summary>
        public TweetData PostTweetWithMedia(MediaData media)
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json?media_ids=" + media.media_id, APIHandler.Method.POST);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet with MediaData instance
        /// </summary>
        public static TweetData PostTweetWithMediaStatic(MediaData media)
        {
            var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json?media_ids=" + media.media_id, APIHandler.Method.POST);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet with MediaData instance
        /// </summary>
        public async Task<TweetData> PostTweetWithMediaAsync(MediaData media)
        {
            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json?media_ids=" + media.media_id, APIHandler.Method.POST);

            var tweet_data = new TweetData(JObject.Parse(response));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet with a list of MediaData instance
        /// </summary>
        public TweetData PostTweetWithMedia(List<MediaData> media)
        {
            var list_media_ids = string.Join(",", media.Select(w => w.media_id).Take(4).ToList());

            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json?media_ids=" + list_media_ids, APIHandler.Method.POST);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet with a list of MediaData instance
        /// </summary>
        public static TweetData PostTweetWithMediaStatic(List<MediaData> media)
        {
            var list_media_ids = string.Join(",", media.Select(w => w.media_id).Take(4).ToList());

            var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json?media_ids=" + list_media_ids, APIHandler.Method.POST);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet with a list of MediaData instance
        /// </summary>
        public async Task<TweetData> PostTweetWithMediaAsync(List<MediaData> media)
        {
            var list_media_ids = string.Join(",", media.Select(w => w.media_id).Take(4).ToList());

            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json?media_ids=" + list_media_ids, APIHandler.Method.POST);

            var tweet_data = new TweetData(JObject.Parse(response));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet with text and MediaData instance
        /// </summary>
        public TweetData PostTweetWithMedia(string text, MediaData media)
        {
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);

            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json?media_ids=" + media.media_id, APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet with text and MediaData instance
        /// </summary>
        public static TweetData PostTweetWithMediaStatic(string text, MediaData media)
        {
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);

            var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json?media_ids=" + media.media_id, APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet with text and MediaData instance
        /// </summary>
        public async Task<TweetData> PostTweetWithMediaAsync(string text, MediaData media)
        {
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);

            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json?media_ids=" + media.media_id, APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet with text and a list of MediaData instance
        /// </summary>
        public TweetData PostTweetWithMedia(string text, List<MediaData> media)
        {
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

            var list_media_ids = string.Join(",", media.Select(w => w.media_id).Take(4).ToList());

            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);

            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json?media_ids=" + list_media_ids, APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet with text and a list of MediaData instance
        /// </summary>
        public static TweetData PostTweetWithMediaStatic(string text, List<MediaData> media)
        {
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

            var list_media_ids = string.Join(",", media.Select(w => w.media_id).Take(4).ToList());

            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);

            var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json?media_ids=" + list_media_ids, APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Post a tweet with text and a list of MediaData instance
        /// </summary>
        public async Task<TweetData> PostTweetWithMediaAsync(string text, List<MediaData> media)
        {
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

            var list_media_ids = string.Join(",", media.Select(w => w.media_id).Take(4).ToList());

            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);

            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json?media_ids=" + list_media_ids, APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response));

            return tweet_data;
        }

        /// <summary>
        /// Reply a tweet passing string with text and TweetData instance
        /// </summary>
        public TweetData PostReplyTweet(string text, TweetData tweet)
        {
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

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
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);
            parameters.Add("in_reply_to_status_id", tweet.tweet_id);
            parameters.Add("auto_populate_reply_metadata", true);

            var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Reply a tweet passing string with text and TweetData instance
        /// </summary>
        public async Task<TweetData> PostReplyTweetAsync(string text, TweetData tweet)
        {
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

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
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);
            parameters.Add("in_reply_to_status_id", tweet_id);
            parameters.Add("auto_populate_reply_metadata", true);

            var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Reply a tweet passing string with text and tweet_id (status_id)
        /// </summary>
        public static TweetData PostReplyTweetStatic(string text, string tweet_id)
        {
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);
            parameters.Add("in_reply_to_status_id", tweet_id);
            parameters.Add("auto_populate_reply_metadata", true);

            var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response.Result));

            return tweet_data;
        }

        /// <summary>
        /// Reply a tweet passing string with text and tweet_id (status_id)
        /// </summary>
        public async Task<TweetData> PostReplyTweetAsync(string text, string tweet_id)
        {
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

            var parameters = new Dictionary<string, object> { };
            parameters.Add("status", text);
            parameters.Add("in_reply_to_status_id", tweet_id);
            parameters.Add("auto_populate_reply_metadata", true);

            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/statuses/update.json", APIHandler.Method.POST, parameters);

            var tweet_data = new TweetData(JObject.Parse(response));

            return tweet_data;
        }



        // ----------------------------------------------------------- Custom Operations -----------------------------------------------------------  //

        /// <summary>
        /// Post a tweet quoting other tweet with text and tweet_id
        /// </summary>
        public TweetData PostTweetQuote(string text, string tweet_id)
        {
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

            text = text + " " + GetTweetById(tweet_id).url;

            return PostTweet(text);
        }

        /// <summary>
        /// Post a tweet quoting other tweet with text and tweet_id
        /// </summary>
        public static TweetData PostTweetQuoteStatic(string text, string tweet_id)
        {
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

            text = text + " " + GetTweetByIdStatic(tweet_id).url;

            return PostTweetStatic(text);
        }

        /// <summary>
        /// Post a tweet quoting other tweet with text and tweet_id
        /// </summary>
        public async Task<TweetData> PostTweetQuoteAsync(string text, string tweet_id)
        {
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

            var tweet_data = await GetTweetByIdAsync(tweet_id);

            text = text + " " + tweet_data.url;

            return await PostTweetAsync(text);
        }

        /// <summary>
        /// Post a tweet quoting other tweet with text and TweetData instance
        /// </summary>
        public TweetData PostTweetQuote(string text, TweetData tweet)
        {
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

            text = text + " " + tweet.url;

            return PostTweet(text);
        }

        /// <summary>
        /// Post a tweet quoting other tweet with text and TweetData instance
        /// </summary>
        public static TweetData PostTweetQuoteStatic(string text, TweetData tweet)
        {
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

            text = text + " " + tweet.url;

            return PostTweetStatic(text);
        }

        /// <summary>
        /// Post a tweet quoting other tweet with text and TweetData instance
        /// </summary>
        public async Task<TweetData> PostTweetQuoteAsync(string text, TweetData tweet)
        {
            text = string.Join("", text.ToCharArray().Take(tweet_limit));

            text = text + " " + tweet.url;

            return await PostTweetAsync(text);
        }

        /// <summary>
        /// Post a thread of tweets with text paragraph
        /// </summary>
        public List<TweetData> PostThread(string text)
        {
            var thread = new List<TweetData>();

            var paragraphs = text.Split('.').Select(w => w.Trim() + ".").ToList();

            TweetData last_tweet = null;

            foreach (var paragraph in paragraphs)
            {
                int k = 0;
                var tweet_content = paragraph.ToLookup(c => (k++ / tweet_limit)).Select(e => new string(e.ToArray())).ToList();

                foreach (var tweet_text in tweet_content)
                {
                    if (last_tweet == null)
                    {
                        last_tweet = PostTweet(tweet_text);
                        thread.Add(last_tweet);
                    }
                    else
                    {
                        last_tweet = PostReplyTweet(tweet_text, last_tweet);
                        thread.Add(last_tweet);
                    }

                }
            }

            return thread;
        }

        /// <summary>
        /// Post a thread of tweets with text paragraph
        /// </summary>
        public static List<TweetData> PostThreadStatic(string text)
        {
            var thread = new List<TweetData>();

            var paragraphs = text.Split('.').Select(w => w.Trim() + ".").ToList();

            TweetData last_tweet = null;

            foreach (var paragraph in paragraphs)
            {
                int k = 0;
                var tweet_content = paragraph.ToLookup(c => (k++ / tweet_limit)).Select(e => new string(e.ToArray())).ToList();

                foreach (var tweet_text in tweet_content)
                {
                    if (last_tweet == null)
                    {
                        last_tweet = PostTweetStatic(tweet_text);
                        thread.Add(last_tweet);
                    }
                    else
                    {
                        last_tweet = PostReplyTweetStatic(tweet_text, last_tweet);
                        thread.Add(last_tweet);
                    }

                }
            }

            return thread;
        }

        /// <summary>
        /// Post a thread of tweets with text paragraph
        /// </summary>
        public async Task<List<TweetData>> PostThreadAsync(string text)
        {
            var thread = new List<TweetData>();

            var paragraphs = text.Split('.').Select(w => w.Trim() + ".").ToList();

            TweetData last_tweet = null;

            foreach (var paragraph in paragraphs)
            {
                int k = 0;
                var tweet_content = paragraph.ToLookup(c => (k++ / tweet_limit)).Select(e => new string(e.ToArray())).ToList();

                foreach (var tweet_text in tweet_content)
                {
                    if (last_tweet == null)
                    {
                        last_tweet = await PostTweetAsync(tweet_text);
                        thread.Add(last_tweet);
                    }
                    else
                    {
                        last_tweet = await PostReplyTweetAsync(tweet_text, last_tweet);
                        thread.Add(last_tweet);
                    }

                }
            }

            return thread;
        }

        /// <summary>
        /// Post a thread of tweets with text paragraph (if split_by_dot set to false it won't split by '.')
        /// </summary>
        public List<TweetData> PostThread(string text, bool split_by_dot)
        {
            var thread = new List<TweetData>();

            var paragraphs = new List<string>();

            if (split_by_dot)
                paragraphs = text.Split('.').Select(w => w.Trim() + ".").ToList();
            else
                paragraphs.Add(text);

            TweetData last_tweet = null;

            foreach (var paragraph in paragraphs)
            {
                int k = 0;
                var tweet_content = paragraph.ToLookup(c => (k++ / tweet_limit)).Select(e => new string(e.ToArray())).ToList();

                foreach (var tweet_text in tweet_content)
                {
                    if (last_tweet == null)
                    {
                        last_tweet = PostTweet(tweet_text);
                        thread.Add(last_tweet);
                    }
                    else
                    {
                        last_tweet = PostReplyTweet(tweet_text, last_tweet);
                        thread.Add(last_tweet);
                    }

                }
            }

            return thread;
        }

        /// <summary>
        /// Post a thread of tweets with text paragraph (if split_by_dot set to false it won't split by '.')
        /// </summary>
        public static List<TweetData> PostThreadStatic(string text, bool split_by_dot)
        {
            var thread = new List<TweetData>();

            var paragraphs = new List<string>();

            if (split_by_dot)
                paragraphs = text.Split('.').Select(w => w.Trim() + ".").ToList();
            else
                paragraphs.Add(text);

            TweetData last_tweet = null;

            foreach (var paragraph in paragraphs)
            {
                int k = 0;
                var tweet_content = paragraph.ToLookup(c => (k++ / tweet_limit)).Select(e => new string(e.ToArray())).ToList();

                foreach (var tweet_text in tweet_content)
                {
                    if (last_tweet == null)
                    {
                        last_tweet = PostTweetStatic(tweet_text);
                        thread.Add(last_tweet);
                    }
                    else
                    {
                        last_tweet = PostReplyTweetStatic(tweet_text, last_tweet);
                        thread.Add(last_tweet);
                    }

                }
            }

            return thread;
        }

        /// <summary>
        /// Post a thread of tweets with text paragraph (if split_by_dot set to false it won't split by '.')
        /// </summary>
        public async Task<List<TweetData>> PostThreadAsync(string text, bool split_by_dot)
        {
            var thread = new List<TweetData>();

            var paragraphs = new List<string>();

            if (split_by_dot)
                paragraphs = text.Split('.').Select(w => w.Trim() + ".").ToList();
            else
                paragraphs.Add(text);

            TweetData last_tweet = null;

            foreach (var paragraph in paragraphs)
            {
                int k = 0;
                var tweet_content = paragraph.ToLookup(c => (k++ / tweet_limit)).Select(e => new string(e.ToArray())).ToList();

                foreach (var tweet_text in tweet_content)
                {
                    if (last_tweet == null)
                    {
                        last_tweet = await PostTweetAsync(tweet_text);
                        thread.Add(last_tweet);
                    }
                    else
                    {
                        last_tweet = await PostReplyTweetAsync(tweet_text, last_tweet);
                        thread.Add(last_tweet);
                    }

                }
            }

            return thread;
        }

        /// <summary>
        /// Post a thread of tweets with list of paragraphs
        /// </summary>
        public List<TweetData> PostThread(List<string> paragraphs)
        {
            var thread = new List<TweetData>();

            TweetData last_tweet = null;

            foreach (var paragraph in paragraphs)
            {
                int k = 0;
                var tweet_content = paragraph.ToLookup(c => (k++ / tweet_limit)).Select(e => new string(e.ToArray())).ToList();

                foreach (var tweet_text in tweet_content)
                {
                    if (last_tweet == null)
                    {
                        last_tweet = PostTweet(tweet_text);
                        thread.Add(last_tweet);
                    }
                    else
                    {
                        last_tweet = PostReplyTweet(tweet_text, last_tweet);
                        thread.Add(last_tweet);
                    }

                }
            }

            return thread;
        }

        /// <summary>
        /// Post a thread of tweets with list of paragraphs
        /// </summary>
        public static List<TweetData> PostThreadStatic(List<string> paragraphs)
        {
            var thread = new List<TweetData>();

            TweetData last_tweet = null;

            foreach (var paragraph in paragraphs)
            {
                int k = 0;
                var tweet_content = paragraph.ToLookup(c => (k++ / tweet_limit)).Select(e => new string(e.ToArray())).ToList();

                foreach (var tweet_text in tweet_content)
                {
                    if (last_tweet == null)
                    {
                        last_tweet = PostTweetStatic(tweet_text);
                        thread.Add(last_tweet);
                    }
                    else
                    {
                        last_tweet = PostReplyTweetStatic(tweet_text, last_tweet);
                        thread.Add(last_tweet);
                    }

                }
            }

            return thread;
        }

        /// <summary>
        /// Post a thread of tweets with list of paragraphs
        /// </summary>
        public async Task<List<TweetData>> PostThreadAsync(List<string> paragraphs)
        {
            var thread = new List<TweetData>();

            TweetData last_tweet = null;

            foreach (var paragraph in paragraphs)
            {
                int k = 0;
                var tweet_content = paragraph.ToLookup(c => (k++ / tweet_limit)).Select(e => new string(e.ToArray())).ToList();

                foreach (var tweet_text in tweet_content)
                {
                    if (last_tweet == null)
                    {
                        last_tweet = await PostTweetAsync(tweet_text);
                        thread.Add(last_tweet);
                    }
                    else
                    {
                        last_tweet = await PostReplyTweetAsync(tweet_text, last_tweet);
                        thread.Add(last_tweet);
                    }

                }
            }

            return thread;
        }
    }
}
