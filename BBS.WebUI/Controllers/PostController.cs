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

        [Authorize, HttpGet]
        public ActionResult CreatePost()
        {
            Post post = new Post();
            int boardID = -1;
            System.Int32.TryParse(Request["boardID"], out boardID);
            post.BoardID = boardID;
            return View(post);
        }

        [HttpPost]
        public ActionResult CreatePost(Post post)
        {
            if (postService.CreatePost(post))
            {
                TempData["info"] = "您的帖子发表成功！";
                return RedirectToAction("PostsInBoard", "Post", new { boardID = post.BoardID });
            }
            else
            {
                TempData["error"] = "对不起! 您的帖子发表失败！";
                return View(post);
            }
        }

        public ActionResult PostsInBoard(int boardID)
        {
            IEnumerable<Post> targetPost = postService.GetPostsByBoard(boardID);
            ViewData["boardID"] = boardID;
            return View(targetPost);
        }

        public ActionResult PostDetail(int postID)
        {
            Post targetPost = postService.GetPostByID(postID);
            return View(targetPost);
        }

        [Authorize]
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
            return RedirectToAction("PostDetail", "Post", new { postID = reply.PostID });
        }
    }
}
