using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TwitterAPI_NETCore;

namespace serviceTest
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private Tasks task { get; set; }

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;

            //Example

            //Load key data
            string consumerKey = ConfigurationManager.AppSettings["consumerKey"];
            string consumerSecret = ConfigurationManager.AppSettings["consumerSecret"];
            string tokenValue = ConfigurationManager.AppSettings["tokenValue"];
            string tokenSecret = ConfigurationManager.AppSettings["tokenSecret"];

            //Load module
            task = new Tasks(consumerKey, consumerSecret, tokenValue, tokenSecret);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //Execute a task

                var response = task.IsLastMentionRepliedByLoggedUser();

                if (!response.Item1)
                {
                    var tweet = task.PostReplyTweet(response.Item2.tweet_message, response.Item2);
                    _logger.LogInformation(DateTimeOffset.Now + " - Respuesta hecha a usuario @" + tweet.user.username + ": " + tweet.tweet_message);
                }
                    
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}