using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TwitterOps.Operation.Tweets;

namespace TwitterOps.Operation.Users
{
    public class UsersOperations
    {
        private APIHandler APIHandler { get; set; }

        public UsersOperations(APIHandler APIHandler)
        {
            this.APIHandler = APIHandler;
        }

        // ---------------------------------------------------------------- ALL GET'S ---------------------------------------------------------------- //


        // ----------------------------------------------------------- Twitter API v1.1 calls -----------------------------------------------------------  //

        /// <summary>
        /// Get UserData instance by user_id
        /// </summary>
        public UserData GetUserById(string user_id)
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/users/show.json?user_id=" + user_id, APIHandler.Method.GET);
            var user_data = JObject.Parse(response.Result);

            return new UserData(user_data);
        }

        /// <summary>
        /// Get UserData instance by user_id
        /// </summary>
        public static UserData GetUserByIdStatic(string user_id)
        {
            var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/users/show.json?user_id=" + user_id, APIHandler.Method.GET);
            var user_data = JObject.Parse(response.Result);

            return new UserData(user_data);
        }

        /// <summary>
        /// Get UserData instance by user_id
        /// </summary>
        public async Task<UserData> GetUserByIdAsync(string user_id)
        {
            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/users/show.json?user_id=" + user_id, APIHandler.Method.GET);
            var user_data = JObject.Parse(response);

            return new UserData(user_data);
        }

        /// <summary>
        /// Get UserData instance by username (screen_name)
        /// </summary>
        public UserData GetUserByScreenName(string username)
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/users/show.json?screen_name=" + username, APIHandler.Method.GET);
            var user_data = JObject.Parse(response.Result);

            return new UserData(user_data);
        }

        /// <summary>
        /// Get UserData instance by username (screen_name)
        /// </summary>
        public static UserData GetUserByScreenNameStatic(string username)
        {
            var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/users/show.json?screen_name=" + username, APIHandler.Method.GET);
            var user_data = JObject.Parse(response.Result);

            return new UserData(user_data);
        }

        /// <summary>
        /// Get UserData instance by username (screen_name)
        /// </summary>
        public async Task<UserData> GetUserByScreenNameAsync(string username)
        {
            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/users/show.json?screen_name=" + username, APIHandler.Method.GET);
            var user_data = JObject.Parse(response);

            return new UserData(user_data);
        }
        /// <summary>
        /// Get UserData of Logged User in API credentials
        /// </summary>
        public UserData GetLoggedUser()
        {
            var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/account/verify_credentials.json", APIHandler.Method.GET);
            var user_data = JObject.Parse(response.Result);

            return new UserData(user_data);
        }

        /// <summary>
        /// Get UserData of Logged User in API credentials
        /// </summary>
        public static UserData GetLoggedUserStatic()
        {
            var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/account/verify_credentials.json", APIHandler.Method.GET);
            var user_data = JObject.Parse(response.Result);

            return new UserData(user_data);
        }

        /// <summary>
        /// Get UserData of Logged User in API credentials
        /// </summary>
        public async Task<UserData> GetLoggedUserAsync()
        {
            var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/account/verify_credentials.json", APIHandler.Method.GET);
            var user_data = JObject.Parse(response);

            return new UserData(user_data);
        }

        /// <summary>
        /// Get mentions of users from tweet in JObject instance
        /// </summary>
        public List<UserData> GetUserMentionsFromTweetJObject(JObject json)
        {
            return json["entities"]["user_mentions"].Children<JObject>().Select(x => GetUserById(x["id"].ToString())).ToList();
        }

        /// <summary>
        /// Get mentions of users from tweet in JObject instance
        /// </summary>
        public static List<UserData> GetUserMentionsFromTweetJObjectStatic(JObject json)
        {
            return json["entities"]["user_mentions"].Children<JObject>().Select(x => GetUserByIdStatic(x["id"].ToString())).ToList();
        }

        /// <summary>
        /// Check if user is shadowbanned
        /// </summary>
        public bool? IsUserShadowbanned(UserData user)
        {
            //If user is protected then check if logged user can see user tweets so i validate that here and if its not then it will return null
            if (user.is_protected && user.followers.Count() == 0)
                return null;

            string url = "https://twitter.com/search?q=" + user.username + "&src=typed_query";
            var Webget = new HtmlWeb();
            var doc = Webget.Load(url);

            bool check = false;

            //Check if 
            if (doc.DocumentNode.SelectSingleNode("//div[@class='noresults']") != null)
                check = true;

            return check;
        }

        /// <summary>
        /// Check if user is shadowbanned
        /// </summary>
        public static bool? IsUserShadowbannedStatic(UserData user)
        {
            //If user is protected then check if logged user can see user tweets so i validate that here and if its not then it will return null
            if (user.is_protected && user.followers.Count() == 0)
                return null;

            string url = "https://twitter.com/search?q=" + user.username + "&src=typed_query";
            var Webget = new HtmlWeb();
            var doc = Webget.Load(url);

            bool check = false;

            //Check if 
            if (doc.DocumentNode.SelectSingleNode("//div[@class='noresults']") != null)
                check = true;

            return check;
        }

        /// <summary>
        /// Get List of Followers of User
        /// </summary>
        public List<UserData> GetUserFollowers(UserData user)
        {
            var list_users = new List<UserData>();

            //it's the max number of count by request according to documention
            int max_entries = 200;

            string page = string.Empty;

            while (true)
            {
                var next_cursor = page == "" ? "" : "&cursor=" + page;
                var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/followers/list.json?count=" + max_entries + "&user_id=" + user.user_id + next_cursor, APIHandler.Method.GET);

                var result_data = JObject.Parse(response.Result);

                if (result_data["next_cursor"] == null)
                    break;

                page = result_data["next_cursor"].ToString();

                var result_users = result_data["users"].Children<JObject>().Select(x => new UserData(x)).ToList();

                list_users.AddRange(result_users);

                if (page == "0")
                    break;

            }

            return list_users;
        }

        /// <summary>
        /// Get List of Followers of User
        /// </summary>
        public static List<UserData> GetUserFollowersStatic(UserData user)
        {
            var list_users = new List<UserData>();

            int max_entries = 200;
            string page = string.Empty;

            while (true)
            {
                var next_cursor = page == "" ? "" : "&cursor=" + page;
                var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/followers/list.json?count=" + max_entries + "&user_id=" + user.user_id + next_cursor, APIHandler.Method.GET);

                var result_data = JObject.Parse(response.Result);

                if (result_data["next_cursor"] == null)
                    break;

                page = result_data["next_cursor"].ToString();

                var result_users = result_data["users"].Children<JObject>().Select(x => new UserData(x)).ToList();

                list_users.AddRange(result_users);

                if (page == "0")
                    break;
            }

            return list_users;
        }

        /// <summary>
        /// Get List of Followers of User
        /// </summary>
        public async Task<List<UserData>> GetUserFollowersAsync(UserData user)
        {
            var list_users = new List<UserData>();

            int max_entries = 200;
            string page = string.Empty;

            while (true)
            {
                var next_cursor = page == "" ? "" : "&cursor=" + page;
                var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/followers/list.json?count=" + max_entries + "&user_id=" + user.user_id + next_cursor, APIHandler.Method.GET);

                var result_data = JObject.Parse(response);

                if (result_data["next_cursor"] == null)
                    break;

                page = result_data["next_cursor"].ToString();

                var result_users = result_data["users"].Children<JObject>().Select(x => new UserData(x)).ToList();

                list_users.AddRange(result_users);

                if (page == "0")
                    break;
            }

            return list_users;
        }

        /// <summary>
        /// Get List of User's Followings
        /// </summary>
        public List<UserData> GetUserFollowings(UserData user)
        {
            var list_users = new List<UserData>();

            //it's the max number of count by request according to documention
            int max_entries = 200;

            string page = string.Empty;

            while (true)
            {
                var next_cursor = page == "" ? "" : "&cursor=" + page;
                var response = APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/friends/list.json?count=" + max_entries + "&user_id=" + user.user_id + next_cursor, APIHandler.Method.GET);

                var result_data = JObject.Parse(response.Result);

                if (result_data["next_cursor"] == null)
                    break;

                page = result_data["next_cursor"].ToString();

                var result_users = result_data["users"].Children<JObject>().Select(x => new UserData(x)).ToList();

                list_users.AddRange(result_users);

                if (page == "0")
                    break;
            }

            return list_users;
        }

        /// <summary>
        /// Get List of User's Followings
        /// </summary>
        public static List<UserData> GetUserFollowingsStatic(UserData user)
        {
            var list_users = new List<UserData>();

            //it's the max number of count by request according to documention
            int max_entries = 200;

            string page = string.Empty;

            while (true)
            {
                var next_cursor = page == "" ? "" : "&cursor=" + page;
                var response = Operations.APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/friends/list.json?count=" + max_entries + "&user_id=" + user.user_id + next_cursor, APIHandler.Method.GET);

                var result_data = JObject.Parse(response.Result);

                if (result_data["next_cursor"] == null)
                    break;

                page = result_data["next_cursor"].ToString();

                var result_users = result_data["users"].Children<JObject>().Select(x => new UserData(x)).ToList();

                list_users.AddRange(result_users);

                if (page == "0")
                    break;
            }

            return list_users;
        }

        /// <summary>
        /// Get List of User's Followings
        /// </summary>
        public async Task<List<UserData>> GetUserFollowingsAsync(UserData user)
        {
            var list_users = new List<UserData>();

            //it's the max number of count by request according to documention
            int max_entries = 200;

            string page = string.Empty;

            while (true)
            {
                var next_cursor = page == "" ? "" : "&cursor=" + page;
                var response = await APIHandler.requestAPIOAuthAsync("https://api.twitter.com/1.1/friends/list.json?count=" + max_entries + "&user_id=" + user.user_id + next_cursor, APIHandler.Method.GET);

                var result_data = JObject.Parse(response);

                if (result_data["next_cursor"] == null)
                    break;

                page = result_data["next_cursor"].ToString();

                var result_users = result_data["users"].Children<JObject>().Select(x => new UserData(x)).ToList();

                list_users.AddRange(result_users);

                if (page == "0")
                    break;
            }

            return list_users;
        }
    }
}
