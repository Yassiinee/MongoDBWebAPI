using Microsoft.AspNetCore.Mvc;
using MongoDBWebAPI.Models;
using MongoDBWebAPI.Services;

namespace MongoDBWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly MongoDBService _mongoDBService;
        public PeopleController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        [HttpPost("connect")]
        public async Task<IActionResult> Connect()
        {
            await _mongoDBService.ConnectAsync();
            return Ok("Connected and key retrieved.");
        }
        [HttpGet]
        public async Task<ActionResult<List<Person>>> Get()
        {
            var people = await _mongoDBService.GetPeopleAsync();
            return Ok(people);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Person person)
        {
            await _mongoDBService.CreatePersonAsync(person);
            return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
        }
    }
}
