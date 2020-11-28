# TwitterOps
A congruent way to use Twitter API.

Powered by .NET Core 3.1

## Description
Right now capable of getting Tweets, Replies, Post Tweets... can be used for whatever automation needed.

(dropped project because Twitter permabanned me for no reason, haha)

## Usage

### Load Main Class

```C#
using System;
using TwitterOps;
using System.Configuration;
using System.Linq;
using System.Collections.Generic;

namespace testConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Example

            //Load key data
            string consumerKey = ConfigurationManager.AppSettings["consumerKey"];
            string consumerSecret = ConfigurationManager.AppSettings["consumerSecret"];
            string tokenValue = ConfigurationManager.AppSettings["tokenValue"];
            string tokenSecret = ConfigurationManager.AppSettings["tokenSecret"];

            //Load module
            var ops = new Operations(consumerKey, consumerSecret, tokenValue, tokenSecret);
        }
    }
}
```

As you can see, you must declare the class **Operations** with your tokens. **consumerKey** and **consumerSecret** are your app tokens. **tokenValue** and **tokenSecret** are the tokens of a linked twitter account.

This class can reach to other classes which represents modules for the different forms of operations. At this moment it only contains:
- Tweets
- Users
- Media

Depending of the module, each operation will return a class model. These classes has every metadata needed for any complex scripting.

The declared **ops** variable can be used for any of the following operations. I will categorize it by module for consistency:

### Tweets

- #### Post a Tweet

```C#
//Execute a task
var tweet = ops.Tweets.PostTweet("This is a automated tweet!");
```

- #### Post a Tweet with image

```C#
//Post tweet with URL of image
var tweet = ops.Tweets.PostTweetWithImageURL("kimika is cute!", "https://pbs.twimg.com/media/EnyWXkFWEAETjMA?format=jpg&name=small");

//Also can be a List<string>. 4 max
var tweet2 = ops.Tweets.PostTweetWithImagesURL("aoi is cute!", new List<string> { "https://pbs.twimg.com/media/DpUq61zUUAEv16G?format=jpg&name=small", "https://pbs.twimg.com/media/D7LPDN1VUAE0cx2?format=jpg&name=small", "https://pbs.twimg.com/media/Drtz9kiU4AA_MbM?format=jpg&name=small", "https://pbs.twimg.com/media/DpuEzHXU8AAy4AQ?format=jpg&name=small" });

//Of course can be loaded locally
var tweet3 = ops.Tweets.PostTweetWithImagePath(@"D:\STUFF\Waiff\2d waifus\2020\aikatsu!\hikami sumire\geshumaro\(danbooru.donmai.us-posts-4089209)-30166199557befbd8c6a931830222060.jpg");
```

- #### Post a Tweet with media

```C#
//Load media
var media = ops.Media.UploadCustomMediaFromPath(@"C:\Users\salivosa\Downloads\testo1.mp4", TwitterOps.Operation.Media.MediaData.MediaCategory.tweet_video);

//Post Tweet with uploaded media
var tweet = ops.Tweets.PostTweetWithMedia("lol", media);
```

The enum **Media.MediaData.MediaCategory** can select any of these values:
  - tweet_image
  - tweet_gif
  - tweet_video
  - amplify_video

I'd recommend only using it with videos or gifs, with images **PostTweetWithImageURL** is more convinient.

- #### Post a Thread

```C#
//Execute a task
var thread = ops.Tweets.PostThread(@"Once upon a time there was a lovely princess. But she had an enchantment upon her of a fearful sort which could only be broken by love's first kiss. She was locked away in a castle guarded by a terrible fire-breathing dragon. Many brave knights had attempted to free her from this dreadful prison, but non prevailed. She waited in the dragon's keep in the highest room of the tallest tower for her true love and true love's first kiss. (laughs) Like that's ever gonna happen. What a load of - (toilet flush)", false);
```

Second argument is a boolean which determines if the string can be splitted by dot. If is false then it will split every 280 characters.

- #### Get a Tweet

```C#
//Execute a task
var tweet = ops.Tweets.GetTweetById("1332104924184850432");
```

- #### Get Replies of a Tweet

```C#
//Get Tweet
var tweet = ops.Tweets.GetTweetById("1332104924184850432");

//Get Replies of obtained Tweet
var replies = tweet.replies;
```

- #### Reply a Tweet

```C#
//Get Tweet
var tweet = ops.Tweets.GetTweetById("1332104924184850432");

//Reply to obtained Tweet
var reply = ops.Tweets.PostReplyTweet("agreed!", tweet);
```

- #### Quote a Tweet

```C#
//Get Tweet
var tweet = ops.Tweets.GetTweetById("1332104924184850432");

//Reply to obtained Tweet
var quoted_tweet = ops.Tweets.PostTweetQuote("humillado!", tweet);
```

### Users

- #### Get User information

```C#
//Get User by Username
var user = ops.Users.GetUserByScreenName("realDonaldTrump");

//Get User by ID
user = ops.Users.GetUserById("25073877");

//Get User Follows
var follows = user.follows;

//Get User Followers
var followers = user.followers;
```

**user** variable has information such as creation datetime, follows, followers, profile image url and more.
