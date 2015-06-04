using BBS.Domain.Abstract;
using BBS.Domain.Concrete.Base;
using BBS.Domain.Concrete.DBContext;
using BBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Domain.Concrete
{
    public class EFUserRepository : EFTypeRepository<User>, IUserRepository
    {
        public bool UpdateUserInfo(User user)
        {
            if(user == null)
            {
                return false;
            }
            User dbEntity = context.User.Find(user.ID);
            if (dbEntity == null)
            {
                return false;
            }
            dbEntity.Age = user.Age;
            dbEntity.City = user.City;
            dbEntity.Email = user.Email;
            dbEntity.ImageData = user.ImageData;
            dbEntity.ImageMimeType = user.ImageMimeType;
            dbEntity.Job = user.Job;
            dbEntity.Name = user.Name;
            dbEntity.Password = user.Password;
            dbEntity.Province = user.Province;
            dbEntity.Sex = user.Sex;
            context.SaveChanges();
            return true;
        }
    }
}