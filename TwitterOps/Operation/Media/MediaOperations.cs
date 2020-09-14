using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static TwitterOps.Operation.Media.MediaData;

namespace TwitterOps.Operation.Media
{
    public class MediaOperations
    {
        private APIHandler APIHandler { get; set; }

        public MediaOperations(APIHandler APIHandler)
        {
            this.APIHandler = APIHandler;
        }

        // ----------------------------------------------------------- Twitter API v1.1 calls -----------------------------------------------------------  //




        // ---------------------------------------------------------------- ALL POST'S ---------------------------------------------------------------- //

        /// <summary>
        /// Upload Image from url
        /// </summary>
        public MediaData UploadImageFromURL(string image_url)
        {
            var parameters = new Dictionary<string, object> { };

            using (var client = new WebClient())
            {
                byte[] dataBytes = client.DownloadData(new Uri(image_url));
                string encodedFileAsBase64 = Convert.ToBase64String(dataBytes);
                parameters.Add("media_data", encodedFileAsBase64);
            }

            parameters.Add("media_category", MediaCategory.tweet_image);

            var response = APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json", APIHandler.Method.POST, parameters);

            var media_data = new MediaData(JObject.Parse(response.Result));

            return media_data;
        }

        /// <summary>
        /// Upload Image from url
        /// </summary>
        public static MediaData UploadImageFromURLStatic(string image_url)
        {
            var parameters = new Dictionary<string, object> { };

            using (var client = new WebClient())
            {
                byte[] dataBytes = client.DownloadData(new Uri(image_url));
                string encodedFileAsBase64 = Convert.ToBase64String(dataBytes);
                parameters.Add("media_data", encodedFileAsBase64);
            }

            parameters.Add("media_category", MediaCategory.tweet_image);

            var response = Operations.APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json", APIHandler.Method.POST, parameters);

            var media_data = new MediaData(JObject.Parse(response.Result));

            return media_data;
        }

        /// <summary>
        /// Upload Image from url
        /// </summary>
        public async Task<MediaData> UploadImageFromURLAsync(string image_url)
        {
            var parameters = new Dictionary<string, object> { };

            using (var client = new WebClient())
            {
                byte[] dataBytes = client.DownloadData(new Uri(image_url));
                string encodedFileAsBase64 = Convert.ToBase64String(dataBytes);
                parameters.Add("media_data", encodedFileAsBase64);
            }

            parameters.Add("media_category", MediaCategory.tweet_image);

            var response = await APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json", APIHandler.Method.POST, parameters);

            var media_data = new MediaData(JObject.Parse(response));

            return media_data;
        }

        /// <summary>
        /// Upload Image from path
        /// </summary>
        public MediaData UploadImageFromPath(string path)
        {
            byte[] dataBytes = File.ReadAllBytes(path);
            string encodedFileAsBase64 = Convert.ToBase64String(dataBytes);

            var parameters = new Dictionary<string, object> { };
            parameters.Add("media_data", encodedFileAsBase64);

            parameters.Add("media_category", MediaCategory.tweet_image);

            var response = APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json", APIHandler.Method.POST, parameters);

            var media_data = new MediaData(JObject.Parse(response.Result));

            return media_data;
        }

        /// <summary>
        /// Upload Image from path
        /// </summary>
        public static MediaData UploadImageFromPathStatic(string path)
        {
            byte[] dataBytes = File.ReadAllBytes(path);
            string encodedFileAsBase64 = Convert.ToBase64String(dataBytes);

            var parameters = new Dictionary<string, object> { };
            parameters.Add("media_data", encodedFileAsBase64);

            parameters.Add("media_category", MediaCategory.tweet_image);

            var response = Operations.APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json", APIHandler.Method.POST, parameters);

            var media_data = new MediaData(JObject.Parse(response.Result));

            return media_data;
        }

        /// <summary>
        /// Upload Image from path
        /// </summary>
        public async Task<MediaData> UploadImageFromPathAsync(string path)
        {
            byte[] dataBytes = File.ReadAllBytes(path);
            string encodedFileAsBase64 = Convert.ToBase64String(dataBytes);

            var parameters = new Dictionary<string, object> { };
            parameters.Add("media_data", encodedFileAsBase64);

            parameters.Add("media_category", MediaCategory.tweet_image);

            var response = await APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json", APIHandler.Method.POST, parameters);

            var media_data = new MediaData(JObject.Parse(response));

            return media_data;
        }

        /// <summary>
        /// Upload Custom media from url and MediaCategory enum
        /// </summary>
        public MediaData UploadCustomMediaFromURL(string url, MediaCategory mediaCategory)
        {
            var parameters = new Dictionary<string, object> { };

            using (var client = new WebClient())
            {
                byte[] dataBytes = client.DownloadData(new Uri(url));
                string encodedFileAsBase64 = Convert.ToBase64String(dataBytes);
                parameters.Add("media_data", encodedFileAsBase64);
            }

            parameters.Add("media_category", mediaCategory);

            var response = APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json", APIHandler.Method.POST, parameters);

            var media_data = new MediaData(JObject.Parse(response.Result));

            return media_data;
        }

        /// <summary>
        /// Upload Custom media from url and MediaCategory enum
        /// </summary>
        public static MediaData UploadCustomMediaFromURLStatic(string url, MediaCategory mediaCategory)
        {
            var parameters = new Dictionary<string, object> { };

            using (var client = new WebClient())
            {
                byte[] dataBytes = client.DownloadData(new Uri(url));
                string encodedFileAsBase64 = Convert.ToBase64String(dataBytes);
                parameters.Add("media_data", encodedFileAsBase64);
            }

            parameters.Add("media_category", mediaCategory);

            var response = Operations.APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json", APIHandler.Method.POST, parameters);

            var media_data = new MediaData(JObject.Parse(response.Result));

            return media_data;
        }

        /// <summary>
        /// Upload Custom media from url and MediaCategory enum
        /// </summary>
        public async Task<MediaData> UploadCustomMediaFromURLAsync(string url, MediaCategory mediaCategory)
        {
            var parameters = new Dictionary<string, object> { };

            using (var client = new WebClient())
            {
                byte[] dataBytes = client.DownloadData(new Uri(url));
                string encodedFileAsBase64 = Convert.ToBase64String(dataBytes);
                parameters.Add("media_data", encodedFileAsBase64);
            }

            parameters.Add("media_category", mediaCategory);

            var response = await APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json", APIHandler.Method.POST, parameters);

            var media_data = new MediaData(JObject.Parse(response));

            return media_data;
        }

        /// <summary>
        /// Upload Custom media from path and MediaCategory enum
        /// </summary>
        public MediaData UploadCustomMediaFromPath(string path, MediaCategory mediaCategory)
        {
            byte[] dataBytes = File.ReadAllBytes(path);
            string encodedFileAsBase64 = Convert.ToBase64String(dataBytes);

            var parameters = new Dictionary<string, object> { };
            parameters.Add("media_data", encodedFileAsBase64);

            parameters.Add("media_category", mediaCategory);

            var response = APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json", APIHandler.Method.POST, parameters);

            var media_data = new MediaData(JObject.Parse(response.Result));

            return media_data;
        }

        /// <summary>
        /// Upload Custom media from path and MediaCategory enum
        /// </summary>
        public static MediaData UploadCustomMediaFromPathStatic(string path, MediaCategory mediaCategory)
        {
            byte[] dataBytes = File.ReadAllBytes(path);
            string encodedFileAsBase64 = Convert.ToBase64String(dataBytes);

            var parameters = new Dictionary<string, object> { };
            parameters.Add("media_data", encodedFileAsBase64);

            parameters.Add("media_category", mediaCategory);

            var response = Operations.APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json", APIHandler.Method.POST, parameters);

            var media_data = new MediaData(JObject.Parse(response.Result));

            return media_data;
        }

        /// <summary>
        /// Upload Custom media from path and MediaCategory enum
        /// </summary>
        public async Task<MediaData> UploadCustomMediaFromPathAsync(string path, MediaCategory mediaCategory)
        {
            byte[] dataBytes = File.ReadAllBytes(path);
            string encodedFileAsBase64 = Convert.ToBase64String(dataBytes);

            var parameters = new Dictionary<string, object> { };
            parameters.Add("media_data", encodedFileAsBase64);

            parameters.Add("media_category", mediaCategory);

            var response = await APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json", APIHandler.Method.POST, parameters);

            var media_data = new MediaData(JObject.Parse(response));

            return media_data;
        }

        /// <summary>
        /// Upload Custom media bytes of file and MediaCategory enum
        /// </summary>
        public MediaData UploadCustomMediaFromBytes(byte[] dataBytes, MediaCategory mediaCategory)
        {
            string encodedFileAsBase64 = Convert.ToBase64String(dataBytes);

            var parameters = new Dictionary<string, object> { };
            parameters.Add("media_data", encodedFileAsBase64);

            parameters.Add("media_category", mediaCategory);

            var response = APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json", APIHandler.Method.POST, parameters);

            var media_data = new MediaData(JObject.Parse(response.Result));

            return media_data;
        }

        /// <summary>
        /// Upload Custom media bytes of file and MediaCategory enum
        /// </summary>
        public static MediaData UploadCustomMediaFromBytesStatic(byte[] dataBytes, MediaCategory mediaCategory)
        {
            string encodedFileAsBase64 = Convert.ToBase64String(dataBytes);

            var parameters = new Dictionary<string, object> { };
            parameters.Add("media_data", encodedFileAsBase64);

            parameters.Add("media_category", mediaCategory);

            var response = Operations.APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json", APIHandler.Method.POST, parameters);

            var media_data = new MediaData(JObject.Parse(response.Result));

            return media_data;
        }

        /// <summary>
        /// Upload Custom media bytes of file and MediaCategory enum
        /// </summary>
        public async Task<MediaData> UploadCustomMediaFromBytesAsync(byte[] dataBytes, MediaCategory mediaCategory)
        {
            string encodedFileAsBase64 = Convert.ToBase64String(dataBytes);

            var parameters = new Dictionary<string, object> { };
            parameters.Add("media_data", encodedFileAsBase64);

            parameters.Add("media_category", mediaCategory);

            var response = await APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json", APIHandler.Method.POST, parameters);

            var media_data = new MediaData(JObject.Parse(response));

            return media_data;
        }
    }
}
