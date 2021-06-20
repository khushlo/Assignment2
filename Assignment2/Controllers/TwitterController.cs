using Assignment2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TwitterImplementation;

namespace Assignment2.Controllers
{
    public class TwitterController : Controller
    {
        private readonly ILogger<TwitterController> _logger;

        public TwitterController(ILogger<TwitterController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                Twitter tweet = new Twitter();
                var res = await tweet.GetDBTweets();
                return View(res.OrderByDescending(x => x.CreatedAt));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message + " : " + ex.StackTrace;
                return View(new List<Tweet>());
            }
        }

        public async Task<IActionResult> GetMyTweet()
        {
            Twitter objTwitter = new Twitter();
            var res = await objTwitter.GetUserTweets();
            var msg2 = objTwitter.SaveData(res);
            if (string.Compare(msg2.Result, "SaveData", true) == 0)
                ViewBag.Message = "DB updated successfully";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetMyTimeline()
        {
            Twitter objTwitter = new Twitter();
            var res = await objTwitter.GetUserHomeTweets();
            var msg2 = objTwitter.SaveData(res);
            if (string.Compare(msg2.Result, "SaveData", true) == 0)
                ViewBag.Message = "DB updated successfully";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Truncate()
        {
            Twitter objTwitter = new Twitter();
            var msg = objTwitter.DeleteAll();
            if (string.Compare(msg.Result, "DeleteAll", true) == 0)
                ViewBag.Message = "Deleted Successfully";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> MakeTweet(string tweet, IFormFile file)
        {
            Twitter objTwitter = new Twitter();
            if (file != null)
                await objTwitter.MakeTweet(tweet, file);
            else if (!string.IsNullOrWhiteSpace(tweet))
                await objTwitter.MakeTweet(tweet);
            return RedirectToAction("Index");
        }

        public IActionResult OpenModelPopup()
        {
            return View("TweetPopUp");
        }
    }
}
