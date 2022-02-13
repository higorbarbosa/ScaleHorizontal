using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Scale_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScaleHorizontalController : ControllerBase
    {
        [HttpGet, Route("api/cpu")]
        public IActionResult ScaleHorizontal(int segundos, int porcentagem)
        {
            int percentualCPU = Math.Max(100, porcentagem);
            var fimProcesso = DateTime.Now.AddSeconds(segundos);
            var perc = percentualCPU;
            Stopwatch watch = new();
            watch.Start();
            while (DateTime.Now < fimProcesso)
            {
                if (watch.ElapsedMilliseconds > perc)
                {
                    Thread.Sleep(100 - perc);
                    watch.Reset();
                    watch.Start();
                }
            }
            
            return Ok($"Utilizado {porcentagem}% da CPU por {segundos} segundos");
        }
    }
}