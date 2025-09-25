using Calculator.Model;
using Calculator.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;

        private IPersonService _personService;


        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        #region GET

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindById(id);
            
            if(person == null) 
                return NotFound();

            return Ok(person);
        }
        #endregion

        #region POST
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {

            if (person == null)
                return BadRequest();

            return Ok(_personService.Create(person));
        }
        #endregion

        #region PUT
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {

            if (person == null)
                return BadRequest();

            return Ok(_personService.Update(person));
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);

            return NoContent();
        }
        #endregion

      
    }
}
