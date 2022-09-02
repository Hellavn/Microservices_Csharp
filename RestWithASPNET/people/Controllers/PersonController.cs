using Microsoft.AspNetCore.Mvc;
using projeto2.Model;
using projeto2.Services;

namespace projeto2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private iPersonServices _personservice;
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        
    };

        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger, iPersonServices personServices)
        {
            _logger = logger;
            _personservice = personServices;    
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personservice.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personservice.FindByID(id);
            if(person == null)
                return NotFound();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            
            if (person == null)
                return BadRequest();
            return Ok(_personservice.Create(person);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {

            if (person == null)
                return BadRequest();
            return Ok(_personservice.Update(person);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personservice.Delete(id); 
            return NoContent();
        }
    }
}