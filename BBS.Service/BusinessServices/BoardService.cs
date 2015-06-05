using BBS.Domain.Abstract;
using BBS.Domain.Entities;
using BBS.Service.BusinessInterfaces;
using BBS.Service.BusinessServices.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Service.BusinessServices
{
    public class BoardService: BaseService, IBoardService
    {
        private IBoardRepository boardRepository;

        public BoardService()
        {
            boardRepository = LoadRepository<IBoardRepository>();
        }

        public IEnumerable<Board> GetRootBoards()
        {
            IEnumerable<Board> rootBoards = boardRepository.Find(board => board.ParentBoardID == null);
            return rootBoards;
        }

        public IEnumerable<Board> GetChildBoards(int parentBoardID)
        {
            IEnumerable<Board> childBoards = boardRepository.Find(board => board.ParentBoardID == parentBoardID);
            return childBoards;
        }

        public Board GetBoardByID(int boardID)
        {
            Board targetBoard = boardRepository.Find(board => board.ID == boardID).FirstOrDefault();
            return targetBoard;
        }
    }
}
