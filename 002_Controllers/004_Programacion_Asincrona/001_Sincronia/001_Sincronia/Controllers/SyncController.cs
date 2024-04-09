using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _001_Sincronia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SyncController : ControllerBase
    {
        [HttpGet("sync")]
        public IActionResult GetSync() 
        {

            Stopwatch sw = Stopwatch.StartNew();

            sw.Start();

            Thread.Sleep(1000);
            Console.WriteLine("Conexión terminada");

            Thread.Sleep(1000);
            Console.WriteLine("Tarea de mandar email terminada");

            Console.WriteLine("El proceso ha terminado");

            sw.Stop();

            Console.WriteLine($"Tiempo transcurrido: {sw.Elapsed}");

            return Ok();
        }

        [HttpGet("async")]
        public async Task<IActionResult> GetAsync()
        {

            Stopwatch sw = new Stopwatch();

            sw.Start();

            var task = new Task(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Conexión terminada");
            });

            task.Start();

            Console.WriteLine("Estoy haciendo otra cosa");

            await task;

            Console.WriteLine("El proceso ha terminado");

            sw.Stop();

            Console.WriteLine(sw.Elapsed);

            return Ok();
        }
    }
}
