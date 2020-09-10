using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterOps.Operation.Users;

namespace TwitterOps.Operation.Media
{
    public class MediaData
    {
        public enum MediaCategory
        {
            tweet_image,
            amplify_video,
            tweet_gif,
            tweet_video
        }

        private JObject media_data { get; set; }

        public MediaData(JObject media_data)
        {
            this.media_data = media_data;
        }

        public string media_id
        {
            get
            {
                return media_data["media_id"].ToString();
            }
        }
        public string media_key
        {
            get
            {
                var data = media_data["media_key"];

                if (data != null)
                    return data.ToString();
                else
                    return "";
            }
        }

        public float size_mb
        {
            get
            {
                return (int.Parse(media_data["size"].ToString()) / 1024f) / 1024f;
            }
        }
    }
}
