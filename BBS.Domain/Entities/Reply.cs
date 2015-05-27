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
    }
}
