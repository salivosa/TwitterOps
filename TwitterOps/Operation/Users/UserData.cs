﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using TwitterOps.Operation.Tweets;
using TwitterOps.Operation.Users;

namespace TwitterOps.Operation.Users
{
    public class UserData
    {
        private JToken user_data { get; set; }
        public UserData(JObject user_data)
        {
            if(user_data.ContainsKey("user"))
                this.user_data = user_data["user"];
            else
                this.user_data = user_data;
        }

        public string user_id
        {
            get
            {
                return user_data["id"].ToString();
            }
        }

        public string username
        {
            get
            {
                return user_data["screen_name"].ToString();
            }
        }

        public string name
        {
            get
            {
                return user_data["name"].ToString();
            }
        }

        public string location
        {
            get
            {
                return user_data["location"].ToString();
            }
        }

        public string bio
        {
            get
            {
                return user_data["description"].ToString();
            }
        }

        public string profile_image_url
        {
            get
            {
                return user_data["profile_image_url"].ToString().Replace("normal", "200x200");
            }
        }

        public List<UserData> follows
        {
            get
            {
                return UsersOperations.GetUserFollowingsStatic(this);
            }
        }

        public int follows_count
        {
            get
            {
                return int.Parse(user_data["friends_count"].ToString());
            }
        }

        public List<UserData> followers
        {
            get
            {
                return UsersOperations.GetUserFollowersStatic(this);
            }
        }

        public int followers_count
        {
            get
            {
                return int.Parse(user_data["followers_count"].ToString());
            }
        }

        public bool is_protected
        {
            get
            {
                return user_data["protected"].ToString().ToLower() == "true";
            }
        }

        public bool? is_shadowbanned
        {
            get
            {
                return UsersOperations.IsUserShadowbannedStatic(this);
            }
        }

        public DateTime created_at
        {
            get
            {
                return DateTime.ParseExact(user_data["created_at"].ToString(), "ddd MMM dd HH:mm:ss +ffff yyyy", new CultureInfo("en-US")).ToLocalTime();
            }
        }
    }
}
