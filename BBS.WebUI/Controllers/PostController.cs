using BBS.Domain.Entities;
using BBS.Service.BusinessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBS.WebUI.Controllers
{
    public class PostController : Controller
    {
        private IPostService postService = null;
        private IReplyService replyService = null;

        public PostController(IPostService postService, IReplyService replyService)
        {
            this.postService = postService;
            this.replyService = replyService;
        }
        //
        // GET: /Post/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult PostsInBoard(int boardID)
        {
            IEnumerable<Post> targetPost = postService.GetPostsByBoard(boardID);
            return View(targetPost);
        }

        public ActionResult PostDetail(int postID)
        {
            Post targetPost = postService.GetPostByID(postID);
            return View(targetPost);
        }

        public ActionResult PostReply(Reply reply)
        {
            bool bResult = replyService.PostReply(reply);
            if(bResult)
            {
                TempData["info"] = "评论发表成功！";
            }
            else
            {
                TempData["error"] = "评论发表失败！";
            }
            return RedirectToAction()
        }
    }
}
