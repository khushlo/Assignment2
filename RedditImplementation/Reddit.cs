using Assignment2.AuthTokenRetriever;
using Assignment2.AuthTokenRetriever.EventArgs;
using DBLibrary;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Reddit;
using Reddit.Inputs.LinksAndComments;
using Reddit.Inputs.Subreddits;
using RestSharp;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RedditImplementation
{
    public class Reddit
    {
        RedditClient reddit = null;
        public Reddit()
        {
            // this will run Only 1st time 
            if (!VerifyToken())
            {
                var temp = AuthorizeUser(RedditUtil.APP_ID, RedditUtil.SECRET);
                GetTokenFromCode();
            }
            reddit = new RedditClient(appId: RedditUtil.APP_ID, refreshToken: GetAccessToken(), appSecret: RedditUtil.SECRET);
        }

        private string GetAccessToken()
        {
            ValidateTable();
            using (var db = new DBManager().OrmLite.Open())
            {
                var res = db.Select<Utilities>();
                var tokenEntry = res.OrderByDescending(x => x.GeneratedTime)?.FirstOrDefault();
                return tokenEntry.RefreshToken;
            }
        }

        private bool VerifyToken()
        {
            ValidateTable();
            using (var db = new DBManager().OrmLite.Open())
            {
                //var res = db.Select<Utilities>();
                //var tokenEntry = res.OrderByDescending(x => x.GeneratedTime)?.FirstOrDefault();
                //return VerifyToken(tokenEntry);
                return db.Select<Utilities>()?.Count > 0;
            }
        }

        public bool VerifyToken(Utilities token)
        {
            if (token?.GeneratedTime != null)
            {
                if (token.Expires > DateTime.UtcNow)
                    return true;
            }
            return false;
        }

        public async Task<List<RedditPost>> GetMyPosts()
        {
            var listPost = new List<RedditPost>();
            try
            {
                var username = reddit.Account.Me.Name;
                var result = reddit.Account.Me.GetPostHistory();
                foreach (var post in result)
                {
                    listPost.Add(new RedditPost
                    {
                        Author = post.Author,
                        Created = post.Created,
                        DownVotes = post.DownVotes,
                        Edited = post.Edited,
                        Fullname = post.Fullname,
                        Id = post.Id,
                        Permalink = post.Permalink,
                        SelfText = post.Permalink,
                        SelfTextHTML = post.Permalink,
                        Subreddit = post.Subreddit,
                        Title = post.Title,
                        UpvoteRatio = post.UpvoteRatio,
                        UpVotes = post.UpVotes
                    });
                }
                return listPost;
            }
            catch (Exception ex)
            {
                // TODO : Manage Logs
                throw ex;
            }
        }

        public async Task<List<RedditPost>> GetHashTag(string hashTag)
        {
            var listPost = new List<RedditPost>();
            try
            {
                // Get info on another subreddit.
                var result = reddit.Subreddit(hashTag).About();

                // Get the top post from a subreddit.
                var topPost = result.Posts.Hot;
                foreach (var post in topPost)
                {
                    listPost.Add(new RedditPost
                    {
                        Author = post.Author,
                        Created = post.Created,
                        DownVotes = post.DownVotes,
                        Edited = post.Edited,
                        Fullname = post.Fullname,
                        Id = post.Id,
                        Permalink = post.Permalink,
                        SelfText = post.Permalink,
                        SelfTextHTML = post.Permalink,
                        Subreddit = post.Subreddit,
                        Title = post.Title,
                        UpvoteRatio = post.UpvoteRatio,
                        UpVotes = post.UpVotes
                    });
                }
                return listPost;
            }
            catch (Exception ex)
            {
                // TODO : Manage Logs
                throw ex;
            }
        }

        public async Task MakePost(string text, IFormFile file)
        {
            var mySub = reddit.Subreddit(name: "Jalpa96164182");
            string img ="<img src=\"https://cdn.stocksnap.io/img-thumbs/960w/macro-flower_AS7IXHU7KI.jpg\">";
            JObject obj = new JObject(file); 
            var mySelfPost = mySub.LinkPost(title: "Web Post", preview: obj).Submit();
        }

        public async Task MakePost(string text)
        {            
            // Create a new self post.
            var mySub = reddit.Subreddit(name: "Jalpa96164182");
            var mySelfPost = mySub.SelfPost(title: "Web Post", text).Submit();
        }

        /// <summary>
        /// Insert Data in DB
        /// </summary>
        /// <param name="posts"></param>
        /// <returns></returns>
        public async Task<string> SaveData(List<RedditPost> posts)
        {
            try
            {
                // Validate if table exist or not
                ValidateTable();
                using (var db = new DBManager().OrmLite.Open())
                {
                    var updateList = posts.Where(y => db.Select<RedditPost>().Select(x => x.Id).Contains(y.Id));
                    var Ids = updateList.Select(x => x.Id);
                    var insertList = posts.Where(x => !Ids.Contains(x.Id)).Select(x => x);
                    // Insert Bulk data
                    await db.InsertAllAsync(insertList);
                    await db.UpdateAllAsync(updateList);
                    return "SaveData";
                }
            }
            catch (Exception ex)
            {
                // TODO : Manage Logs
                throw ex;
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
                    db.DeleteAll<RedditPost>();
                    return "DeleteAll";
                }
            }
            catch (Exception ex)
            {
                // TODO : Manage Logs
                throw ex;
            }
        }

        /// <summary>
        /// Get All Posts from DB
        /// </summary>
        /// <returns></returns>
        public async Task<List<RedditPost>> GetDBPost()
        {
            try
            {
                // Validate if table exist or not
                ValidateTable();
                using (var db = new DBManager().OrmLite.Open())
                {
                    // Insert Bulk data
                    var result = await db.SelectAsync<RedditPost>();
                    return result;
                }
            }
            catch (Exception ex)
            {
                // TODO : Manage Logs
                throw ex;
            }
        }

        private void ValidateTable()
        {
            using (var db = new DBManager().OrmLite.Open())
            {
                db.CreateTableIfNotExists<RedditPost>();
                db.CreateTableIfNotExists<Utilities>();
            }
        }

        private static string AuthorizeUser(string appId, string appSecret = null, int port = 8080)
        {
            // Create a new instance of the auth token retrieval library.  --Kris
            AuthTokenRetrieverLib authTokenRetrieverLib = new AuthTokenRetrieverLib(appId: appId, port, redirectUri: "https://localhost:44310/", appSecret: appSecret);

            // Start the callback listener.  --Kris
            // Note - Ignore the logging exception message if you see it.  You can use Console.Clear() after this call to get rid of it if you're running a console app.
            authTokenRetrieverLib.AwaitCallback(true);
            Thread th1 = new Thread(() => { OpenBrowser(authTokenRetrieverLib.AuthURL()); });
            th1.Start();

            Thread.Sleep(5000);
            // Open the browser to the Reddit authentication page.  Once the user clicks "accept", Reddit will redirect the browser to localhost:8080, where AwaitCallback will take over.  --Kris
            //  OpenBrowser(authTokenRetrieverLib.AuthURL());

            // Cleanup.  --Kris
            authTokenRetrieverLib.StopListening();

            return authTokenRetrieverLib.RefreshToken;
        }

        private static void OpenBrowser(string authUrl, string browserPath = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe")
        {
            authUrl = authUrl.Replace("http://127.0.0.1:8080/Reddit.NET/oauthRedirect", RedditUtil.REDI_URL);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                try
                {
                    ProcessStartInfo processStartInfo = new ProcessStartInfo(authUrl);
                    Process.Start(processStartInfo);
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    ProcessStartInfo processStartInfo = new ProcessStartInfo(browserPath)
                    {
                        Arguments = authUrl
                    };
                    Process.Start(processStartInfo);
                }
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // For OSX run a separate command to open the web browser as found in https://brockallen.com/2016/09/24/process-start-for-urls-on-net-core/
                Process.Start("open", authUrl);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                // Similar to OSX, Linux can (and usually does) use xdg for this task.
                Process.Start("xdg-open", authUrl);
            }
        }

        private void GetTokenFromCode()
        {
            if (!string.IsNullOrWhiteSpace(RedditUtil.code) && !string.IsNullOrWhiteSpace(RedditUtil.state))
            {
                // Send request with code and JSON-decode the return for token retrieval.  --Kris
                RestRequest restRequest = new RestRequest("/api/v1/access_token", Method.POST);

                restRequest.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(RedditUtil.state)));
                restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                restRequest.AddParameter("grant_type", "authorization_code");
                restRequest.AddParameter("code", RedditUtil.code);
                restRequest.AddParameter("redirect_uri", RedditUtil.REDI_URL);  // This must be an EXACT match in the app settings on Reddit!  --Kris

                OAuthToken oAuthToken = JsonConvert.DeserializeObject<OAuthToken>(ExecuteRequest(restRequest));

                // Set the token properties.  --Kris
                RedditUtil.ACCESS_TOKEN = oAuthToken.AccessToken;
                RedditUtil.REFRESH_TOKEN = oAuthToken.RefreshToken;

                ValidateTable();
                using (var db = new DBManager().OrmLite.Open())
                {
                    db.Insert<Utilities>(new Utilities
                    {
                        Token = oAuthToken.AccessToken,
                        RefreshToken = oAuthToken.RefreshToken,
                        GeneratedTime = DateTime.UtcNow,
                        Expires = DateTime.UtcNow.AddSeconds(3600)
                    });
                }
            }
        }

        private string ExecuteRequest(RestRequest restRequest)
        {
            IRestResponse res = new RestClient("https://www.reddit.com").Execute(restRequest);
            if (res != null && res.IsSuccessful)
            {
                return res.Content;
            }
            else
            {
                Exception ex = new Exception("API returned non-success response.");

                ex.Data.Add("res", res);

                throw ex;
            }
        }
    }
}
