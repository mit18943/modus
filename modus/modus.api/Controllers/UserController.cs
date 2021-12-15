using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using modus.Core.Repositories;
using modus.Model.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace modus.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repo;

        public UserController(IUserRepository repo)
        {
            this.repo = repo;
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<User>> Get()
        {
            return await repo.LoadRecordsAsnyc("User");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<User> GetById(string id)
        {
            var x = await repo.LoadRecordByIdAsync("User", id);
            return x;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            var result = await repo.InsertRecordAsnyc("User", user);
            return result;
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<User>> DeleteUser(string id)
        {
            var result = await repo.DeleteRecordAsync("User", id);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<User>> UpdateUser(User user, string id)
        {
            var result = await repo.UpsertRecordAsync("User", id, user);
            return Ok(result);
        }

    }
}
