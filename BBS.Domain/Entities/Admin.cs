using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Domain.Entities
{
    public class Admin
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Permission { get; set; }//管理员权限等级
        public string ImageData { get; set; }//管理员头像图片
        public string ImageMimeType { get; set; }//管理员头像图片格式
    }
}
