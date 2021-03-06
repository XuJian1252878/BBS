﻿using BBS.Domain.Entities;
using BBS.Service.BusinessInterfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBS.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IBoardService boardService = null;
        //
        // GET: /Home/

        public HomeController(IBoardService boardService)
        {
            this.boardService = boardService;
        }

        public ActionResult Index()
        {
            IEnumerable<Board> rootBoards = boardService.GetRootBoards();
            ViewBag.RootBaords = rootBoards;
            return View();
        }
    }
}
