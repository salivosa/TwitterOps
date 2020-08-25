using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterAPI_NETCore
{
    public class TwitterReplyModel
    {
        public string reply_user { get; set; }
        public string replied_tweet_id { get; set; }
        public string replied_tweet_message { get; set; }
        public string reply_tweet_message { get; set; }

    }
}
