using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Domain.Entities
{
    public class Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishTime { get; set; }

        //一个帖子与唯一的发帖人相关联
        public int UserID { get; set; }
        public virtual User User { get; set; }
        //一个帖子与唯一的板块相对应
        public int BoardID { get; set; }
        public virtual Board Board { get; set; }
        //一个帖子下有多条回复
        public virtual ICollection<Reply> Replies { get; set; }
        //一个帖子可以有多个话题标签
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
