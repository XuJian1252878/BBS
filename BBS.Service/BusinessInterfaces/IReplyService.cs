using BBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Service.BusinessInterfaces
{
    public interface IReplyService
    {
        bool PostReply(Reply reply);
    }
}
