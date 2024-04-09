using _001_Basics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _001_Basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        private IRandomService _randomServiceSingleton;
        private IRandomService _randomServiceScoped;
        private IRandomService _randomServiceTransient;

        private IRandomService _randomServiceSingleton2;
        private IRandomService _randomServiceScoped2;
        private IRandomService _randomServiceTransient2;

        public RandomController([FromKeyedServices("randomSingleton")] IRandomService randomSingleton,
                                [FromKeyedServices("randomSingleton")] IRandomService randomSingleton2,
                                [FromKeyedServices("randomScoped")] IRandomService randomScoped,
                                [FromKeyedServices("randomScoped")] IRandomService randomScoped2,
                                [FromKeyedServices("randomTransient")] IRandomService randomTransient,
                                [FromKeyedServices("randomTransient")] IRandomService randomTransient2)
        {
            _randomServiceSingleton = randomSingleton;
            _randomServiceSingleton2 = randomSingleton2;
            _randomServiceScoped = randomScoped;
            _randomServiceScoped2 = randomScoped2;
            _randomServiceTransient = randomTransient;
            _randomServiceTransient2 = randomTransient2;
        }

        [HttpGet]
        public ActionResult<Dictionary<string, int>> Get()
        {
            var result = new Dictionary<string, int>();

            result.Add("Singleton 1", _randomServiceSingleton.Value);
            result.Add("Singleton 2", _randomServiceSingleton2.Value);

            result.Add("Scoped 1", _randomServiceScoped.Value);
            result.Add("Scoped 2", _randomServiceScoped2.Value);

            result.Add("Transient 1", _randomServiceTransient.Value);
            result.Add("Transient 2", _randomServiceTransient2.Value);

            return result;

        }

    }
}
