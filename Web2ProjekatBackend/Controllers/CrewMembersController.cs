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
    public class CrewMembersController : ApiController
    {
        IUserRepository _repo;
           
        public CrewMembersController()
        {
            _repo = new UserRepository();
        }

        public IQueryable Get()
        {
            return _repo.GetCrewMembers();
        }

        public IHttpActionResult Post([FromBody] CrewPostDTO dto)
        {
            _repo.AssignUserToCrew(dto);
            return Ok();
        }

    }
}
