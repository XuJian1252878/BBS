using BBS.Domain.Abstract.Base;
using BBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Domain.Abstract
{
    public interface IBoardRepository: ITypeRepository<Board>
    {
    }
}
