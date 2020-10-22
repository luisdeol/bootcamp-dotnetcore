using AwesomeGym.API.Entidades;
using AwesomeGym.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AwesomeGym.API.Controllers
{
    [ApiController]
    [Route("api/unidades")]
    public class UnidadesController : ControllerBase
    {
        private readonly AwesomeGymDbContext _awesomeGymDbContext;
        public UnidadesController(AwesomeGymDbContext awesomeDbContext)
        {
            _awesomeGymDbContext = awesomeDbContext;
        }

        // api/unidades
        [HttpGet]
        public IActionResult Get()
        {
            var unidades = _awesomeGymDbContext.Unidades.ToList();

            return Ok(unidades);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var unidade = _awesomeGymDbContext.Unidades.SingleOrDefault(u => u.Id == id);

            if (unidade == null)
            {
                return NotFound();
            }

            return Ok(unidade);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Unidade unidade)
        {
            _awesomeGymDbContext.Unidades.Add(unidade);
            _awesomeGymDbContext.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
