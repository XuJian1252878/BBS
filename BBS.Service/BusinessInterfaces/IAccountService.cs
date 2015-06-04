using BBS.Domain.Entities;
using BBS.Service.BusinessObject.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Service.BusinessInterfaces
{
    public interface IAccountService
    {
        bool Register(RegisterViewModel registeInfo);
        User Login(string accountName, string password);
        User GetUserByID(int userID);
        bool UpdateUserInfo(User user);
    }
}