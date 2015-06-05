using BBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Service.BusinessInterfaces
{
    public interface IBoardService
    {
        IEnumerable<Board> GetRootBoards();
        IEnumerable<Board> GetChildBoards(int parentBoardID);
        Board GetBoardByID(int boardID);
    }
}
