using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Podium.Core;
using Podium.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUser _users;

        public UserController(IUser users)
        {
            this._users = users;
        }

        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            var result = _users.AddUser(user);
            return Ok(result);

        }
    }
}
