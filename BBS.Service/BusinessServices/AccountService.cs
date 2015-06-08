using BBS.Domain.Abstract;
using BBS.Domain.Entities;
using BBS.Service.BusinessInterfaces;
using BBS.Service.BusinessObject.UserViewModel;
using BBS.Service.BusinessServices.Base;
using BBS.Service.Module;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Service.BusinessServices
{
    public class AccountService : BaseService, IAccountService
    {
        private IUserRepository userRepository;

        public AccountService()
        {
            userRepository = LoadRepository<IUserRepository>();
        }

        public bool Register(RegisterViewModel registerViewModel)
        {

            //首先寻找是否已有相同用户名或者邮箱的用户已注册。
            int dbUsers = userRepository.Find(user => (user.Name == registerViewModel.Name) 
                || (user.Email == registerViewModel.Email)).Count();
            if (dbUsers > 0)
            {
                return false;
            }
            //存储用户信息。
            User ruser = GetUserFromRegisterInfo(registerViewModel);
            userRepository.Create(ruser);
            return true;
        }

        public User Login(string accountName, string password)
        {
            //检查用户的用户名密码是否匹配。
            User loginUser = userRepository.Find(
                user => ((user.Name == accountName) || (user.Email == accountName)) && (user.Password == password) )
                .FirstOrDefault();
            return loginUser;
        }
        

        //根据用户的ID获取user实例。
        public User GetUserByID(int userID)
        {
            User targetUser = userRepository.Find(user => user.ID == userID).FirstOrDefault();
            return targetUser;
        }

        //更新用户的个人信息。
        public bool UpdateUserInfo(User user)
        {
            if (user == null)
            {
                return false;
            }
            return userRepository.UpdateUserInfo(user);
        }

        public User GetUserByAccount(string accountName)
        {
            return userRepository.Find(user => user.Name == accountName || user.Email == accountName).FirstOrDefault();
        }

        internal User GetUserFromRegisterInfo(RegisterViewModel registerInfo)
        {
            User user = new User();
            user.Age = registerInfo.Age;
            user.City = registerInfo.City;
            user.Email = registerInfo.Email;
            user.ImageData = registerInfo.ImageData;
            user.ImageMimeType = registerInfo.ImageMimeType;
            user.Job = registerInfo.Job;
            user.Name = registerInfo.Name;
            user.Password = registerInfo.Password;
            user.Province = registerInfo.Province;
            user.Sex = registerInfo.Sex;
            return user;
        }
    }
}
