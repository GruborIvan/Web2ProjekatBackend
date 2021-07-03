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

        public void ApproveByAdmin(string username, int val)
        {
            UserInfo uinfo = db.UserInfos.Where(x => x.Username == username).FirstOrDefault();
            uinfo.IsAdminApproved = val;
            db.Entry<UserInfo>(uinfo).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public UserInfo GetUserInfoByUsername(string username)
        {
            return db.UserInfos.Where(x => x.Username == username).FirstOrDefault();
        }

        public IQueryable<UserInfo> GetUsersForApprove()
        {
            return db.UserInfos.Where(x => x.IsAdminApproved == 1);
        }

        public void PostUser(UserInfo userInfo)
        {
            if (userInfo.VrsteKorisnika == VrsteKorisnika.ADMINISTRATOR)
            {
                userInfo.IsAdminApproved = 0;
            }
            else
            {
                userInfo.IsAdminApproved = 1;
            }
            db.UserInfos.Add(userInfo);
            db.SaveChanges();
        }
    }
}