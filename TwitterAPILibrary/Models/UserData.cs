using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TwitterAPI_NETCore.Models
{
    public class UserData
    {
        private JToken user_data { get; set; }
        public UserData(JObject user_data)
        {
            this.user_data = user_data["user"];
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

        public bool is_protected
        {
            get
            {
                return user_data["protected"].ToString().ToLower() == "true";
            }
        }

        public DateTime created_at
        {
            get
            {
                return DateTime.ParseExact(user_data["created_at"].ToString(), "ddd MMM dd HH:mm:ss +ffff yyyy", new CultureInfo("en-US"));
            }
        }
    }
}
