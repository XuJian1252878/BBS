using BBS.Domain.Abstract;
using BBS.Domain.Concrete.Base;
using BBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Domain.Concrete
{
    public class EFBoardRepository: EFTypeRepository<Board>, IBoardRepository
    {

    }
}
