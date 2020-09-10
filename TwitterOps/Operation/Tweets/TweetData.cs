using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TwitterOps.Operation.Tweets;
using TwitterOps.Operation.Users;

namespace TwitterOps.Operation.Tweets
{
    public class TweetData
    {
        private JObject tweet_data { get; set; }

        public TweetData(JObject tweet_data)
        {
            this.tweet_data = tweet_data;
        }

        public string url
        {
            get
            {
                return "https://twitter.com/" + user.username + "/status/" + tweet_id;
            }
        }

        public string tweet_id 
        { 
            get 
            {
                var data = tweet_data["id"];

                if (data != null)
                    return data.ToString();
                else
                    return "";
            } 
        }

        public DateTime created_at
        {
            get
            {
                return DateTime.ParseExact(tweet_data["created_at"].ToString(), "ddd MMM dd HH:mm:ss +ffff yyyy", new CultureInfo("en-US")).ToLocalTime();
            }
        }

        public UserData user
        {
            get
            {
                return new UserData(tweet_data);
            }
        }

        public string tweet_message
        {
            get
            {
                return Regex.Replace(tweet_data["text"].ToString(), @"\@\w+\b", match => "").Trim();
            }
        }

        public TweetData replying_to
        {
            get
            {
                var id = tweet_data["in_reply_to_status_id"].ToString();

                if (id != "")
                    return TweetsOperations.GetTweetByIdStatic(tweet_data["in_reply_to_status_id"].ToString());
                else
                    return null;
            }
        }

        public List<TweetData> replies
        {
            get
            {
                return TweetsOperations.GetRepliesOfTweetStatic(this);
            }
        }

        public int replies_count
        {
            get
            {
                return int.Parse(TweetsOperations.GetTweetPublicMetricsStatic(this)["reply_count"].ToString());
            }
        }

        public List<UserData> user_mentions
        {
            get
            {
                var user_mentions = tweet_data["entities"]["user_mentions"];

                if (user_mentions != null)
                    return UsersOperations.GetUserMentionsFromTweetJObjectStatic(tweet_data);
                else
                    return null;
            }
        }

        public int like_count
        {
            get
            {
                return int.Parse(tweet_data["favorite_count"].ToString());
            }
        }

        public int retweet_count
        {
            get
            {
                return int.Parse(tweet_data["retweet_count"].ToString());
            }
        }

        public int quote_count
        {
            get
            {
                return int.Parse(TweetsOperations.GetTweetPublicMetricsStatic(this)["quote_count"].ToString());
            }
        }
    }
}
