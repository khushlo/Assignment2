using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedditImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using R = RedditImplementation;

namespace Assignment2.Controllers
{
    public class RedditController : Controller
    {

        // GET: RedditController
        public async Task<IActionResult> Index()
        {
            R.Reddit objReddit = new R.Reddit();
            var lstPost = await objReddit.GetDBPost();
            return View(lstPost.OrderByDescending(x => x.Created));
        }

        public async Task<IActionResult> GetMyPosts()
        {
            R.Reddit objReddit = new R.Reddit();
            var lstPost = await objReddit.GetMyPosts();
            if (lstPost.Any())
            {
                await objReddit.SaveData(lstPost);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Reddit/GetTaggedPost/{hashTag?}")]
        public async Task<IActionResult> GetTaggedPost(string hashTag)
        {
            hashTag ??= "AskReddit";
            R.Reddit objReddit = new R.Reddit();
            var lstPost = await objReddit.GetHashTag(hashTag);
            if (lstPost.Any())
            {
                await objReddit.SaveData(lstPost);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Truncate()
        {
            R.Reddit objReddit = new R.Reddit();
            var msg = await objReddit.DeleteAll();
            if (string.Compare(msg, "DeleteAll", true) == 0)
                ViewBag.Message = "Deleted Successfully";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(string text, IFormFile file)
        {
            R.Reddit objTwitter = new R.Reddit();
            if (file != null)
                await objTwitter.MakePost(text, file);
            else if (!string.IsNullOrWhiteSpace(text))
                await objTwitter.MakePost(text);
            return RedirectToAction("Index");
        }

        public ActionResult GetToken(string state, string code)
        {
            RedditUtil.code = code;
            RedditUtil.state = state;
            return View();
        }

        public IActionResult OpenModelPopup()
        {
            return View();
        }
    }
}
