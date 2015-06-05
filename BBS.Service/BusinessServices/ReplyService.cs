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
    public class ReplyService: BaseService, IReplyService
    {
        private IReplyRepository replyRepository = null;
        public ReplyService()
        {
            this.replyRepository = LoadRepository<IReplyRepository>();
        }

        public bool PostReply(Reply reply)
        {
            return replyRepository.Create(reply);
        }
    }
}
