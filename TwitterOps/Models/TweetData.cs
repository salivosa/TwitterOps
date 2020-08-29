using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace TwitterOps.Models
{
    public class TweetData
    {
        private JObject tweet_data { get; set; }

        public TweetData(JObject tweet_data)
        {
            this.tweet_data = tweet_data;
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
                return DateTime.ParseExact(tweet_data["created_at"].ToString(), "ddd MMM dd HH:mm:ss +ffff yyyy", new CultureInfo("en-US"));
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
                    return Tasks.GetTweetDataStatic(tweet_data["in_reply_to_status_id"].ToString());
                else
                    return null;
            }
        }

        public List<TweetData> replies
        {
            get
            {
                return Tasks.GetRepliesOfTweetStatic(this);
            }
        }
    }
}
