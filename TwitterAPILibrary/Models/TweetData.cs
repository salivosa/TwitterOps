using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace TwitterAPI_NETCore.Models
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
                return tweet_data["id"].ToString();
            } 
        }

        public DateTime created_at
        {
            get
            {
                return DateTime.ParseExact(tweet_data["created_at"].ToString(), "ddd MMM dd HH:mm:ss +ffff yyyy", new CultureInfo("en-US"));
            }
        }

        public string username
        {
            get
            {
                return Regex.Replace(tweet_data["user"]["screen_name"].ToString(), @"\@\w+\b", match => "").Trim();
            }
        }

        public string tweet_message
        {
            get
            {
                return tweet_data["text"].ToString();
            }
        }
    }
}
