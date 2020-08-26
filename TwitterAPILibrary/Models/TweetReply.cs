using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterAPI_NETCore.Models
{
    public class TweetReply
    {
        public string in_reply_to_status_id { get; set; }
        public TweetData tweet_model { get; set; }
    }
}
