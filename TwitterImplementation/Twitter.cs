using DBLibrary;
using Microsoft.AspNetCore.Http;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Core.Models;
using Tweetinvi.Models;
using System.Linq;

namespace TwitterImplementation
{
    public class Twitter
    {
        private TwitterClient userClient = null;
        public Twitter()
        {
            userClient = new TwitterClient(TwitterUtil.APIKey, TwitterUtil.APISecret, TwitterUtil.APIToken, TwitterUtil.APITokenSecret);
        }

        /// <summary>
        /// Gives Only users tweets
        /// </summary>
        /// <returns></returns>
        public async Task<List<Tweet>> GetUserTweets()
        {
            try
            {
                var tweets = new List<Tweet>();
                var result = await userClient.Timelines.GetUserTimelineAsync(TwitterUtil.Username);
                foreach (var res in result)
                {
                    tweets.Add(new Tweet
                    {
                        Id = res.Id,
                        FullText = res.FullText,
                        TweetUrl = res.Url,
                        Language = res.Language.ToString(),
                        MediaCount = res.Media.Count,
                        RetweetCount = res.RetweetCount,
                        ReplyCount = res.ReplyCount,
                        CreatedByUsername = res.CreatedBy.ScreenName,
                        CreatedByName = res.CreatedBy.Name,
                        CreatedAt = res.CreatedAt
                    });
                }
                return tweets;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gives users timeline tweets
        /// </summary>
        /// <returns></returns>
        public async Task<List<Tweet>> GetUserHomeTweets()
        {
            try
            {
                var tweets = new List<Tweet>();
                var result = await userClient.Timelines.GetHomeTimelineAsync(new Tweetinvi.Parameters.GetHomeTimelineParameters() { PageSize = 100 });
                foreach (var res in result)
                {
                    tweets.Add(new Tweet
                    {
                        Id = res.Id,
                        FullText = res.FullText,
                        TweetUrl = res.Url,
                        Language = res.Language.ToString(),
                        MediaCount = res.Media.Count,
                        RetweetCount = res.RetweetCount,
                        ReplyCount = res.ReplyCount,
                        CreatedByUsername = res.CreatedBy.ScreenName,
                        CreatedByName = res.CreatedBy.Name,
                        CreatedAt = res.CreatedAt
                    });
                }
                return tweets;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task MakeTweet(string tweet, IFormFile file)
        {
            var stream = file.OpenReadStream();
            var tweetinviLogoBinary = streamToByteArray(file.OpenReadStream());
            var uploadedImage = await userClient.Upload.UploadTweetImageAsync(tweetinviLogoBinary);

            var param = new Tweetinvi.Parameters.PublishTweetParameters();
            param.Text = tweet;
            param.Medias = new List<IMedia>() { uploadedImage };

            await userClient.Tweets.PublishTweetAsync(param);
        }

        public async Task MakeTweet(string tweet)
        {
            await userClient.Tweets.PublishTweetAsync(tweet);
        }

        /// <summary>
        /// Insert Data in DB
        /// </summary>
        /// <param name="tweets"></param>
        /// <returns></returns>
        public async Task<string> SaveData(List<Tweet> tweets)
        {
            try
            {
                // Validate if table exist or not
                ValidateTable();
                using (var db = new DBManager().OrmLite.Open())
                {
                    // Insert Bulk data
                    var updateList = tweets.Where(y => db.Select<Tweet>().Select(x =>x.Id).Contains(y.Id));
                    var Ids = updateList.Select(x => x.Id);
                    var insertList = tweets.Where(x => !Ids.Contains(x.Id));
                    await db.InsertAllAsync(insertList);
                    await db.UpdateAllAsync(updateList);
                    return "SaveData";
                }
            }
            catch (Exception ex)
            {
                return ex.Message + " : " + ex.StackTrace;
            }
        }

        /// <summary>
        /// Truncate the table
        /// </summary>
        /// <returns></returns>
        public async Task<string> DeleteAll()
        {
            try
            {
                // Validate if table exist or not
                ValidateTable();
                using (var db = new DBManager().OrmLite.Open())
                {
                    // Delete All
                    db.DeleteAll<Tweet>();
                    return "DeleteAll";
                }
            }
            catch (Exception ex)
            {
                return ex.Message + " : " + ex.StackTrace;
            }
        }

        /// <summary>
        /// Get All Tweets from DB
        /// </summary>
        /// <returns></returns>
        public async Task<List<Tweet>> GetDBTweets()
        {
            try
            {
                // Validate if table exist or not
                ValidateTable();
                using (var db = new DBManager().OrmLite.Open())
                {
                    // Insert Bulk data
                    var result = await db.SelectAsync<Tweet>();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ValidateTable()
        {
            using (var db = new DBManager().OrmLite.Open())
            {
                db.CreateTableIfNotExists<Tweet>();
            }
        }

        private static byte[] streamToByteArray(Stream input)
        {
            MemoryStream ms = new MemoryStream();
            input.CopyTo(ms);
            return ms.ToArray();
        }
    }
}
