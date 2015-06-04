using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Domain.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Job { get; set; }
        public int Age { get; set; }
        public bool Sex { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string ImageData { get; set; }
        public string ImageMimeType { get; set; }

        //一个用户可能包含多个帖子
        public virtual ICollection<Post> Posts { get; set; }
        //一个用户可能发表过多次评论
        public virtual ICollection<Reply> Replies { get; set; }
        //一个用户可能有多个标签
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
