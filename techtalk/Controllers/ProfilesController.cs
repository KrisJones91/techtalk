using System;
using Microsoft.AspNetCore.Mvc;
using techtalk.Models;
using techtalk.Services;

namespace techtalk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesService _service;

        public ProfilesController(ProfilesService service)
        {
            _service = service;
        }

        //get profile
        [HttpGet("{id}")]

        public ActionResult<Profile> Get(string id)
        {
            try
            {
                Profile profile = _service.GetProfileById(id);
                return Ok(profile);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //get users Posts

        //get users Comments
    }
}