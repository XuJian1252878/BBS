using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.WebUI.Models.UserViewModel
{
    public class LoginViewModel
    {
        //可能是用户名，或者是电子邮件。
        public string UserAccount { get; set; }

        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
