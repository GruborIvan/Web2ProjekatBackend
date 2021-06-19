using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web2ProjekatBackend.Models;
using Web2ProjekatBackend.Repository;

namespace Web2ProjekatBackend.Controllers
{
    public class UserInfoController : ApiController
    {
        IUserRepository _repo;

        public UserInfoController()
        {
            _repo = new UserRepository();
        }

        public IHttpActionResult Get(string username)
        {
            UserInfo uifo = _repo.GetUserInfoByUsername(username);
            if (uifo == null)
            {
                return NotFound();
            }
            if (!uifo.IsAdminApproved)
            {
                return BadRequest("Not admin approved!");
            }
            return Ok(uifo);
        }

        public IHttpActionResult PostApproveAdmin(string username)
        {
            _repo.ApproveByAdmin(username);
            return Ok();
        }

        public IQueryable<UserInfo> GetUsersForApprove()
        {
            return _repo.GetUsersForApprove();
        }

        public IHttpActionResult Post([FromBody] UserInfo uInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            uInfo.IsAdminApproved = false;
            _repo.PostUser(uInfo);
            return CreatedAtRoute("DefaultApi", new { id = uInfo.Id }, uInfo);
        }

    }
}
