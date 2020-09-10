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
using TwitterOps.Operation.Media;
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
        public TweetsOperations Tweets
        {
            get
            {
                return new TweetsOperations(APIHandler, LoggedUser);
            }
        }

        /// <summary>
        /// Operations related to Users
        /// </summary>
        public UsersOperations Users
        {
            get
            {
                return new UsersOperations(APIHandler);
            }
        }

        /// <summary>
        /// Operations related to Media
        /// </summary>
        public MediaOperations Media
        {
            get
            {
                return new MediaOperations(APIHandler);
            }
        }



    }
}
