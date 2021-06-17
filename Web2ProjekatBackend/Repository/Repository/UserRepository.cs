using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web2ProjekatBackend.Models;

namespace Web2ProjekatBackend.Repository
{
    public class UserRepository : IUserRepository
    {
        ApplicationDbContext db;

        public UserRepository()
        {
            db = new ApplicationDbContext();
        }

        public UserInfo GetUserInfoByUsername(string username)
        {
            return db.UserInfos.Where(x => x.Username == username).FirstOrDefault();
        }

        public void PostUser(UserInfo userInfo)
        {
            db.UserInfos.Add(userInfo);
            db.SaveChanges();
        }
    }
}