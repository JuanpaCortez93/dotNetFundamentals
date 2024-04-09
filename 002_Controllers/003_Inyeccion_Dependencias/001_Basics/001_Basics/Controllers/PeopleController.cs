using _001_Basics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _001_Basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {

        private IPeopleService _peopleService;

        public PeopleController([FromKeyedServices("PeopleService2")]IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet("all")]
        public ActionResult<List<People>> GetPeople() => Ok(PeopleRepository.PeopleList);

        [HttpGet("id/{id}")]
        public ActionResult<People> GetPerson(int id)
        {
            var person = PeopleRepository.PeopleList.FirstOrDefault(person => person.Id == id);

            if(person == null) return BadRequest();

            return Ok(person);
        }

        [HttpGet("name/{name}")]
        public ActionResult<List<People>> GetPeopleByName(string name) 
        {

            var people = PeopleRepository.PeopleList.Where(people => people.Name.ToUpper().Contains(name.ToUpper()));
            if (people == null) return NotFound();
            return Ok(people);
        }

        [HttpPost]
        public IActionResult AddPeople(People people)
        {
            if(people == null) return BadRequest();
            if(!_peopleService.Validate(people)) return BadRequest();

            PeopleRepository.PeopleList.Add(people);

            return NoContent();
        } 


    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Name";
        public DateTime Birthday { get; set; } = DateTime.Now;
    }

    public class PeopleRepository
    {
        public static List<People> PeopleList = new List<People>
        {
            new People()
            {
                Id = 1,
                Name = "Felipe",
                Birthday = new DateTime(1990,11,16)
            },

            new People()
            {
                Id = 2,
                Name = "Ximenita",
                Birthday = new DateTime(1969,12,26)
            },

            new People()
            {
                Id = 3,
                Name = "Pablito",
                Birthday = new DateTime(1961,7,29)
            },

            new People()
            {
                Id = 4,
                Name = "Juanpa",
                Birthday = new DateTime(1993,2,26)
            }

        };

    }
}
