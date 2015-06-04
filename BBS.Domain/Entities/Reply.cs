using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Domain.Entities
{
    public class Reply
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime PublishTime { get; set; }

        //一条回复仅对应一个用户
        public int UserID { get; set; }
        public virtual User User { get; set; }
        //一条回复仅对应于一个帖子
        public int PostID { get; set; }
        public virtual Post Post { get; set; }
    }
}
