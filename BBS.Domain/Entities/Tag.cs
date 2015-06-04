using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Domain.Entities
{
    public class Tag
    {
        public int ID { get; set; }
        public string Content { get; set; }

        //一个用户可以有多个话题标签
        public virtual ICollection<User> Users { get; set; }
        //一个帖子可以有多个话题标签
        public virtual ICollection<Post> Posts { get; set; }
    }
}
