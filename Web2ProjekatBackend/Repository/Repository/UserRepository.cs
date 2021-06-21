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

        public void ApproveByAdmin(string username)
        {
            UserInfo uinfo = db.UserInfos.Where(x => x.Username == username).FirstOrDefault();
            uinfo.IsAdminApproved = true;
            db.Entry<UserInfo>(uinfo).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public UserInfo GetUserInfoByUsername(string username)
        {
            return db.UserInfos.Where(x => x.Username == username).FirstOrDefault();
        }

        public IQueryable<UserInfo> GetUsersForApprove()
        {
            return db.UserInfos.Where(x => x.IsAdminApproved == false);
        }

        public void PostUser(UserInfo userInfo)
        {
            if (userInfo.VrsteKorisnika == VrsteKorisnika.ADMINISTRATOR)
            {
                userInfo.IsAdminApproved = true;
            }
            else
            {
                userInfo.IsAdminApproved = false;
            }
            db.UserInfos.Add(userInfo);
            db.SaveChanges();
        }
    }
}