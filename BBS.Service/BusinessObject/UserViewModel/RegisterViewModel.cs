using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

namespace BBS.Service.BusinessObject.UserViewModel
{
    public class RegisterViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Job { get; set; }
        public int Age { get; set; }
        public bool Sex { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string ImageData { get; set; }
        public string ImageMimeType { get; set; }


        //http://www.4byte.cn/question/579478/how-to-pass-viewmodel-from-view-to-action-use-url-action-in-mvc4.html

        //http://stackoverflow.com/questions/13085914/binding-the-model-variable-to-an-action-method-in-asp-net-mvc3
        public RouteValueDictionary RouteValues
        {
            get
            {
                var rvd = new RouteValueDictionary();
                rvd["Name"] = Name;
                rvd["Email"] = Email;
                rvd["Password"] = Password;
                rvd["ConfirmPassword"] = ConfirmPassword;
                rvd["Job"] = Job;
                rvd["Age"] = Age;
                rvd["Sex"] = Sex;
                rvd["Province"] = Province;
                rvd["City"] = City;
                //http://stackoverflow.com/questions/10680672/convert-byte-array-to-string-in-asp-net
                rvd["ImageData"] = ImageData;
                rvd["ImageMimeType"] = ImageMimeType;
                return rvd;
            }
        }
    }
}
