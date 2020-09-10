using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

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

        public MediaData UploadImageFromURL(string image_url)
        {
            var parameters = new Dictionary<string, object> { };

            using (var client = new WebClient())
            {
                byte[] dataBytes = client.DownloadData(new Uri(image_url));
                string encodedFileAsBase64 = Convert.ToBase64String(dataBytes);
                parameters.Add("media_data", encodedFileAsBase64);
            }

            parameters.Add("media_category", MediaData.MediaCategory.tweet_image);

            var response = APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json", APIHandler.Method.POST, parameters);

            var media_data = new MediaData(JObject.Parse(response.Result));

            return media_data;
        }

        public static MediaData UploadImageFromURLStatic(string image_url)
        {
            var parameters = new Dictionary<string, object> { };

            using (var client = new WebClient())
            {
                byte[] dataBytes = client.DownloadData(new Uri(image_url));
                string encodedFileAsBase64 = Convert.ToBase64String(dataBytes);
                parameters.Add("media_data", encodedFileAsBase64);
            }

            parameters.Add("media_category", MediaData.MediaCategory.tweet_image);

            var response = Operations.APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json", APIHandler.Method.POST, parameters);

            var media_data = new MediaData(JObject.Parse(response.Result));

            return media_data;
        }

        public async Task<MediaData> UploadImageFromURLAsync(string image_url)
        {
            var parameters = new Dictionary<string, object> { };

            using (var client = new WebClient())
            {
                byte[] dataBytes = client.DownloadData(new Uri(image_url));
                string encodedFileAsBase64 = Convert.ToBase64String(dataBytes);
                parameters.Add("media_data", encodedFileAsBase64);
            }

            parameters.Add("media_category", MediaData.MediaCategory.tweet_image);

            var response = await APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json", APIHandler.Method.POST, parameters);

            var media_data = new MediaData(JObject.Parse(response));

            return media_data;
        }
    }
}
