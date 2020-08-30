using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TwitterOps;

namespace serviceTest
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private Operations ops { get; set; }

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
            ops = new Operations(consumerKey, consumerSecret, tokenValue, tokenSecret);

            _logger.LogInformation(DateTimeOffset.Now + " - Worker Inicializado!");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var response = ops.Tweets.IsLastMentionRepliedByLoggedUser();

                    if (!response.Item1)
                    {
                        var tweet = await ops.Tweets.PostReplyTweetAsync(response.Item2.tweet_message, response.Item2);
                        _logger.LogInformation(DateTimeOffset.Now + " - Respuesta hecha a usuario @" + tweet.user.username + ": " + tweet.tweet_message);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(DateTimeOffset.Now + " - Ocurrió un error:\n\n" + ex.ToString());
                }
                    
                await Task.Delay(1500, stoppingToken);
            }
        }
    }
}