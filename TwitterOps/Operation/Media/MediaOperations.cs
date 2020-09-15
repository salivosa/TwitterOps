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

        public MediaData UploadCustomMediaINIT(long file_size_bytes, MediaCategory mediaCategory)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("total_bytes", file_size_bytes);
            parameters.Add("media_category", mediaCategory);
            parameters.Add("media_type", GetMediaTypeByMediaCategory(mediaCategory));

            var response = APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json?command=INIT", APIHandler.Method.POST, parameters);

            var media_data = new MediaData(JObject.Parse(response.Result));

            return media_data;
        }

        public static MediaData UploadCustomMediaINITStatic(long file_size_bytes, MediaCategory mediaCategory)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("total_bytes", file_size_bytes);
            parameters.Add("media_category", mediaCategory);
            parameters.Add("media_type", GetMediaTypeByMediaCategoryStatic(mediaCategory));

            var response = Operations.APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json?command=INIT", APIHandler.Method.POST, parameters);

            var media_data = new MediaData(JObject.Parse(response.Result));

            return media_data;
        }

        public async Task<MediaData> UploadCustomMediaINITAsync(long file_size_bytes, MediaCategory mediaCategory)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("total_bytes", file_size_bytes);
            parameters.Add("media_category", mediaCategory);
            parameters.Add("media_type", GetMediaTypeByMediaCategory(mediaCategory));

            var response = await APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json?command=INIT", APIHandler.Method.POST, parameters);

            var media_data = new MediaData(JObject.Parse(response));

            return media_data;
        }

        public void UploadCustomMediaAPPEND(string encodedFileAsBase64, MediaData media_init)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("segment_index", 0);
            parameters.Add("media_data", encodedFileAsBase64);

            _ = APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json?command=APPEND&media_id=" + media_init.media_id, APIHandler.Method.POST, parameters);
        }

        public static void UploadCustomMediaAPPENDStatic(string encodedFileAsBase64, MediaData media_init)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("segment_index", 0);
            parameters.Add("media_data", encodedFileAsBase64);

            _ = Operations.APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json?command=APPEND&media_id=" + media_init.media_id, APIHandler.Method.POST, parameters);
        }

        public async Task UploadCustomMediaAPPENDAsync(string encodedFileAsBase64, MediaData media_init)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("segment_index", 0);
            parameters.Add("media_data", encodedFileAsBase64);

            await APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json?command=APPEND&media_id=" + media_init.media_id, APIHandler.Method.POST, parameters);
        }

        public MediaData UploadCustomMediaFINALIZE(MediaData media_append)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("segment_index", 0);

            var response = APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json?command=FINALIZE&media_id=" + media_append.media_id, APIHandler.Method.POST, parameters);

            var media_data = new MediaData(JObject.Parse(response.Result));

            return media_data;
        }

        public static MediaData UploadCustomMediaFINALIZEStatic(MediaData media_append)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("segment_index", 0);

            var response = Operations.APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json?command=FINALIZE&media_id=" + media_append.media_id, APIHandler.Method.POST, parameters);

            var media_data = new MediaData(JObject.Parse(response.Result));

            return media_data;
        }

        public async Task<MediaData> UploadCustomMediaFINALIZEAsync(MediaData media_append)
        {
            var parameters = new Dictionary<string, object> { };
            parameters.Add("segment_index", 0);

            var response = await APIHandler.requestAPIOAuthAsync("https://upload.twitter.com/1.1/media/upload.json?command=FINALIZE&media_id=" + media_append.media_id, APIHandler.Method.POST, parameters);

            var media_data = new MediaData(JObject.Parse(response));

            return media_data;
        }

        /// <summary>
        /// Upload Custom media from bytes and MediaCategory enum
        /// </summary>
        public MediaData UploadCustomMediaFromBytes(byte[] dataBytes, MediaCategory mediaCategory)
        {
            //Load File Data
            string encodedFileAsBase64 = Convert.ToBase64String(dataBytes);

            //INIT Media call
            var media_init = UploadCustomMediaINIT(dataBytes.Length, mediaCategory);

            //APPEND Media call
            UploadCustomMediaAPPEND(encodedFileAsBase64, media_init);

            //FINALIZE Media call
            var media_data = UploadCustomMediaFINALIZE(media_init);

            return media_data;
        }

        /// <summary>
        /// Upload Custom media from bytes and MediaCategory enum
        /// </summary>
        public static MediaData UploadCustomMediaFromBytesStatic(byte[] dataBytes, MediaCategory mediaCategory)
        {
            //Load File Data
            string encodedFileAsBase64 = Convert.ToBase64String(dataBytes);

            //INIT Media call
            var media_init = UploadCustomMediaINITStatic(dataBytes.Length, mediaCategory);

            //APPEND Media call
            UploadCustomMediaAPPENDStatic(encodedFileAsBase64, media_init);

            //FINALIZE Media call
            var media_data = UploadCustomMediaFINALIZEStatic(media_init);

            return media_data;
        }

        /// <summary>
        /// Upload Custom media from bytes and MediaCategory enum
        /// </summary>
        public async Task<MediaData> UploadCustomMediaFromBytesAsync(byte[] dataBytes, MediaCategory mediaCategory)
        {
            //Load File Data
            string encodedFileAsBase64 = Convert.ToBase64String(dataBytes);

            //INIT Media call
            var media_init = await UploadCustomMediaINITAsync(dataBytes.Length, mediaCategory);

            //APPEND Media call
            await UploadCustomMediaAPPENDAsync(encodedFileAsBase64, media_init);

            //FINALIZE Media call
            var media_data = await UploadCustomMediaFINALIZEAsync(media_init);

            return media_data;
        }

        /// <summary>
        /// Upload Custom media from path and MediaCategory enum
        /// </summary>
        public MediaData UploadCustomMediaFromPath(string path, MediaCategory mediaCategory)
        {
            //Load File Data
            byte[] dataBytes = File.ReadAllBytes(path);

            var media_data = UploadCustomMediaFromBytes(dataBytes, mediaCategory);

            return media_data;
        }

        /// <summary>
        /// Upload Custom media from path and MediaCategory enum
        /// </summary>
        public static MediaData UploadCustomMediaFromPathStatic(string path, MediaCategory mediaCategory)
        {
            //Load File Data
            byte[] dataBytes = File.ReadAllBytes(path);

            var media_data = UploadCustomMediaFromBytesStatic(dataBytes, mediaCategory);

            return media_data;
        }

        /// <summary>
        /// Upload Custom media from path and MediaCategory enum
        /// </summary>
        public async Task<MediaData> UploadCustomMediaFromPathAsync(string path, MediaCategory mediaCategory)
        {
            //Load File Data
            byte[] dataBytes = File.ReadAllBytes(path);

            var media_data = await UploadCustomMediaFromBytesAsync(dataBytes, mediaCategory);

            return media_data;
        }

        /// <summary>
        /// Upload Custom media from url and MediaCategory enum
        /// </summary>
        public MediaData UploadCustomMediaFromURL(string url, MediaCategory mediaCategory)
        {
            //Load File Bytes from URL
            var client = new WebClient();
            byte[] dataBytes = client.DownloadData(new Uri(url));

            var media_data = UploadCustomMediaFromBytes(dataBytes, mediaCategory);

            return media_data;
        }

        /// <summary>
        /// Upload Custom media from url and MediaCategory enum
        /// </summary>
        public static MediaData UploadCustomMediaFromURLStatic(string url, MediaCategory mediaCategory)
        {
            //Load File Bytes from URL
            var client = new WebClient();
            byte[] dataBytes = client.DownloadData(new Uri(url));

            var media_data = UploadCustomMediaFromBytesStatic(dataBytes, mediaCategory);

            return media_data;
        }

        /// <summary>
        /// Upload Custom media from url and MediaCategory enum
        /// </summary>
        public async Task<MediaData> UploadCustomMediaFromURLAsync(string url, MediaCategory mediaCategory)
        {
            //Load File Bytes from URL
            var client = new WebClient();
            byte[] dataBytes = client.DownloadData(new Uri(url));

            var media_data = await UploadCustomMediaFromBytesAsync(dataBytes, mediaCategory);

            return media_data;
        }



        // ----------------------------------------------------------- Custom Operations -----------------------------------------------------------  //

        private string GetMediaTypeByMediaCategory(MediaCategory mediaCategory)
        {
            return mediaCategory == MediaCategory.tweet_image ? "image/jpg" : mediaCategory == MediaCategory.tweet_video ? "video/mp4" : mediaCategory == MediaCategory.tweet_gif ? "image/gif" : null;
        }

        private static string GetMediaTypeByMediaCategoryStatic(MediaCategory mediaCategory)
        {
            return mediaCategory == MediaCategory.tweet_image ? "image/jpg" : mediaCategory == MediaCategory.tweet_video ? "video/mp4" : mediaCategory == MediaCategory.tweet_gif ? "image/gif" : null;
        }
    }
}
