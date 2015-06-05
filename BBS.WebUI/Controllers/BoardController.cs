using BBS.Domain.Entities;
using BBS.Service.BusinessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBS.WebUI.Controllers
{
    public class BoardController : Controller
    {

        private IBoardService boardService = null;
        //
        // GET: /Board/

        public BoardController(IBoardService boardService)
        {
            this.boardService = boardService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChildBoards(int boardID)
        {
            IEnumerable<Board> childBoards = boardService.GetChildBoards(boardID);
            return View(childBoards);
        }

    }
}
