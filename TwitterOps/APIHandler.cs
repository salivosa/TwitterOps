using Newtonsoft.Json;
using OAuth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TwitterOps
{
    public class APIHandler
    {
        //API keys of Twitter App
        private string consumerKey { get; set; }
        private string consumerSecret { get; set; }

        //Tokens of user (can be genenerated and obtained by twurl)
        private string tokenValue { get; set; }
        private string tokenSecret { get; set; }

        //Enum of Methods used in Requests
        public enum Method
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        /// <summary>
        /// Load class with API and user's keys data
        /// </summary>
        public APIHandler(string consumerKey, string consumerSecret, string tokenValue, string tokenSecret)
        {
            this.consumerKey = consumerKey;
            this.consumerSecret = consumerSecret;
            this.tokenValue = tokenValue;
            this.tokenSecret = tokenSecret;
        }

        /// <summary>
        /// Make an API request with OAuth 1.0
        /// </summary>
        public async Task<string> requestAPIOAuthAsync(string url, Method method)
        {
            //Generate OAuthRequest data (library used: OAuth.DotNetCore from Robert Hargreaves)
            OAuthRequest client = new OAuthRequest
            {
                Method = method.ToString(),
                SignatureTreatment = OAuthSignatureTreatment.Escaped,
                SignatureMethod = OAuthSignatureMethod.HmacSha1,
                ConsumerKey = consumerKey,
                ConsumerSecret = consumerSecret,
                Token = tokenValue,
                TokenSecret = tokenSecret,
                RequestUrl = url,
                Version = "1.0"
            };

            // Format authorization as header string
            string auth = client.GetAuthorizationHeader();

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod(client.Method), client.RequestUrl))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", auth);

                    var response = await httpClient.SendAsync(request);

                    return response.Content.ReadAsStringAsync().Result;
                }
            }

        }

        /// <summary>
        /// Make an API request with OAuth 1.0 and body parameters (defined key:value in dictionary)
        /// </summary>
        public async Task<string> requestAPIOAuthAsync(string url, Method method, Dictionary<string, object> body)
        {
            //Generate OAuthRequest data (library used: OAuth.DotNetCore from Robert Hargreaves)
            OAuthRequest client = new OAuthRequest
            {
                Method = method.ToString(),
                SignatureTreatment = OAuthSignatureTreatment.Escaped,
                SignatureMethod = OAuthSignatureMethod.HmacSha1,
                ConsumerKey = consumerKey,
                ConsumerSecret = consumerSecret,
                Token = tokenValue,
                TokenSecret = tokenSecret,
                RequestUrl = url,
                Version = "1.0"
            };

            // Format authorization as header string
            string auth = client.GetAuthorizationHeader();

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod(client.Method), client.RequestUrl))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", auth);

                    var multipartFormDataContent = new MultipartFormDataContent();

                    foreach (var item in body)
                        multipartFormDataContent.Add(new StringContent(item.Value.ToString()), string.Format("\"{0}\"", item.Key));

                    request.Content = multipartFormDataContent;

                    var response = await httpClient.SendAsync(request);

                    return response.Content.ReadAsStringAsync().Result;
                }
            }
        }
    }
}