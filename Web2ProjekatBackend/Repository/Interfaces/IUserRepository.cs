﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web2ProjekatBackend.Models;

namespace Web2ProjekatBackend.Repository
{
    public interface IUserRepository
    {
        UserInfo GetUserInfoByUsername(string username);

        IQueryable<UserInfo> GetUsersForApprove();

        void ApproveByAdmin(string username, int val);
        void PostUser(UserInfo userInfo);
    }
}