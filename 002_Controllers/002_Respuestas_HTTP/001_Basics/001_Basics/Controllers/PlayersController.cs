using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _001_Basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {

        [HttpGet("AllPlayers")]
        public ActionResult<List<SoccerPlayers>> GetPlayers([FromHeader] string Host, [FromHeader(Name = "Content-Length")] string ContentLength) {
            Console.WriteLine($"Host: {Host}\nContentLength: {ContentLength}");
            return Ok(PlayersRepository.Players);
        }

        [HttpGet("FindAPlayer/{id}")]
        public ActionResult<SoccerPlayers> GetPlayerById(Guid id, [FromHeader] string Host, [FromHeader(Name="Content-Length")] string ContentLength) 
        {
            Console.WriteLine($"Host: {Host}\nContentLength: {ContentLength}");

            var player = PlayersRepository.Players.FirstOrDefault(player => player.Id == id);

            if (player == null) NotFound();
            return Ok(player);
        }


        [HttpGet("FindAPlayerByName/{name}")]
        public ActionResult<List<SoccerPlayers>> GetPlayerByName(string name, [FromHeader] string Host, [FromHeader(Name = "Content-Length")] string ContentLength)
        {
            Console.WriteLine($"Host: {Host}\nContentLength: {ContentLength}");

            var player = PlayersRepository.Players.Where(player => player.Name.ToUpper().Contains(name.ToUpper()));

            if(player == null) NotFound();

            return Ok(player);
        }


        [HttpPost("AddPlayer")]
        public IActionResult AddPlayer(SoccerPlayers player, [FromHeader] string Host, [FromHeader (Name="Content-Length")] string ContentLength)
        {
            Console.WriteLine($"Host: {Host}\nContentLength: {ContentLength}");
            PlayersRepository.Players.Add(player);
            return NoContent();
        }

    }


    public class SoccerPlayers
    {
        public Guid Id { get {return _id; } }
        public string Name { get { return _name; } set { _name = value;} }
        public string Position { get {return _position; } set { _position = value; } }
        public string Team { get {return _team; } set { _team = value; } }

        private Guid _id = Guid.NewGuid();
        private string _name;
        private string _position;
        private string _team;
    }

    public class PlayersRepository
    {

        public static List<SoccerPlayers> Players = new List<SoccerPlayers>
        {

            new SoccerPlayers()
            {
                Name = "Ronaldo Nazario De Lima",
                Position = "Forward",
                Team = "Real Madrid"
            },

            new SoccerPlayers()
            {
                Name = "Cristiano Ronaldo",
                Position = "Forward",
                Team = "Real Madrid"
            },

            new SoccerPlayers()
            {
                Name = "Mo Salah",
                Position = "Forward",
                Team = "Liverpool"
            },

            new SoccerPlayers()
            {
                Name = "Pelé",
                Position = "Forward",
                Team = "Santos"
            }
        };
    }

}
