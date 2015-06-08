using BBS.Domain.Entities;
using BBS.Service.BusinessInterfaces;
using BBS.Service.BusinessObject.UserViewModel;
using BBS.WebUI.Models.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace BBS.WebUI.Controllers
{
    public class UserController : Controller
    {
        private IAccountService accountService;
        private IPostService postService;

        public UserController(IAccountService accountService, IPostService postService)
        {
            this.accountService = accountService;
            this.postService = postService;
        }

        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            User user = accountService.Login(loginViewModel.UserAccount, loginViewModel.Password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(loginViewModel.UserAccount, false);
                Session["User"] = user;
                TempData["info"] = user.Name + " login success!";
                if (loginViewModel.ReturnUrl != null && Url.IsLocalUrl(loginViewModel.ReturnUrl))
                {
                    return Redirect(loginViewModel.ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                TempData["error"] = "The account or the password error!";
                return View(loginViewModel);
            }
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            RegisterViewModel ruser = new RegisterViewModel();
            return View(ruser);
        }

        [HttpPost]
        public ActionResult SignUp(RegisterViewModel ruser, HttpPostedFileBase image)//存储上传的文件信息
        {
            if (image != null)
            {
                ruser.ImageMimeType = image.ContentType;
                byte[] imagebyte = new byte[image.ContentLength];
                image.InputStream.Read(imagebyte, 0, image.ContentLength);
                ruser.ImageData = Convert.ToBase64String(imagebyte);
            }
            if(!accountService.Register(ruser))
            {
                TempData["error"] = "The user name or email you input have already registered!";
                return View(ruser);
            }
            TempData["info"] = "Register success!";
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            Session.Abandon();//取消Session会话。
            FormsAuthentication.SignOut();//删除Forms验证票证。
            return RedirectToAction("Index", "Home");
        }

        public FileContentResult GetTempHeadPortrait()
        {
            byte[] imageData = Convert.FromBase64String(Request.QueryString["ImageData"]);
            string imageMimeType = Request.QueryString["ImageMimeType"];
            if(imageData != null && imageMimeType != null)
            {
                return File(imageData, imageMimeType);
            }
            else
            {
                return null;
            }
        }


        public FileContentResult GetHeadPortrait(int id)//通过登录用户的ID获取用户的头像
        {
            User user = null;
            if (id == -1 && Session["User"] != null)//网页标题头部的用户头像。
            {
                user = (User)Session["User"];
            }
            else
            {
                user = accountService.GetUserByID(id);
                if (user == null)
                {
                    return null;
                }
            }
            byte[] imageData = Convert.FromBase64String(user.ImageData);
            string imageMimeType = user.ImageMimeType;
            if(imageData != null && imageMimeType != null)
            {
                return File(imageData, imageMimeType);
            }
            return null;
        }

        //导航进入用户进入用户管理中心。
        [Authorize]
        public ActionResult Management()
        {
            ViewData["UserPost"] = postService.GetPostByUser(((User)Session["User"]).ID);
            return View((User)Session["User"]);
        }

        //更新用户信息
        [Authorize]
        public ActionResult UpdateInfo(User user, HttpPostedFileBase image)
        {
            if(image != null)
            {
                byte[] imageData = new byte[image.ContentLength];
                image.InputStream.Read(imageData, 0, image.ContentLength);
                user.ImageData = Convert.ToBase64String(imageData);
                user.ImageMimeType = image.ContentType;
            }
            if (!accountService.UpdateUserInfo(user))
            {
                TempData["Error"] = "Fail to update user info!";
            }
            TempData["info"] = "Update user info success!";
            Session["User"] = accountService.GetUserByID(user.ID);
            return View("Management", (User)Session["User"]);
        }

        [Authorize]
        public ActionResult AdminIndex()
        {
            return View();
        }
    }
}
