using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Domain.Entities
{
    public class Board
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageData { get; set; }
        public string ImageMimeType { get; set; }

        //一个父级板块可能会有多个子版块
        public virtual ICollection<Board> Boards { get; set; }
        //一个板块之内可能会有多个帖子
        public virtual ICollection<Post> Posts { get; set; }
    }
}
