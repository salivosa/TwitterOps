﻿using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TwitterOps.Models;
using TwitterOps.Operation.Tweets;
using TwitterOps.Operation.Users;

namespace TwitterOps
{
    public class Operations
    {
        public static APIHandler APIHandler { get; set; }

        public static UserData LoggedUser { get; set; }

        public Operations(string consumerKey, string consumerSecret, string tokenValue, string tokenSecret)
        {
            APIHandler = new APIHandler(consumerKey, consumerSecret, tokenValue, tokenSecret);
            LoggedUser = Users.GetLoggedUser();

        }

        /// <summary>
        /// Operations related to Tweets
        /// </summary>
        public Tweets Tweets
        {
            get
            {
                return new Tweets(APIHandler, LoggedUser);
            }
        }

        /// <summary>
        /// Operations related to Users
        /// </summary>
        public Users Users
        {
            get
            {
                return new Users(APIHandler);
            }
        }



    }
}
