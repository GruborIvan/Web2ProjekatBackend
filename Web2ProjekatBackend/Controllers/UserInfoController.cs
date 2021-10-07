using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web2ProjekatBackend.Models;
using Web2ProjekatBackend.Models.DTO;
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
            if (uifo.IsAdminApproved == 1)
            {
                return Unauthorized();
            }
            return Ok(uifo);
        }

        public IHttpActionResult PostApproveAdmin(string username,int val)
        {
            _repo.ApproveByAdmin(username,val);
            return Ok();
        }

        public IQueryable<UserInfo> GetUsersForApprove()
        {
            return _repo.GetUsersForApprove();
        }

        public IHttpActionResult Post([FromBody] UserInfo uInfo)
        {
            if (uInfo.Username == "ivan.grubor@gmail.com")
            {
                return Ok();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
  
            _repo.PostUser(uInfo);
            return CreatedAtRoute("DefaultApi", new { id = uInfo.Id }, uInfo);
        }

        public IHttpActionResult Put([FromBody] UserDTO uInfo)
        {
            _repo.UpdateUser(uInfo);
            return Ok(_repo.GetUserInfoByUsername(uInfo.Username));
        }

    }
}
