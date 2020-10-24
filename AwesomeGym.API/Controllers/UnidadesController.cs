using AwesomeGym.API.Entidades;
using AwesomeGym.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

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
        public IActionResult GetById(int id)
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

            return CreatedAtAction(nameof(GetById), unidade, new { id = unidade.Id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Unidade unidade)
        {
            if (!await _awesomeGymDbContext.Unidades.AnyAsync(u => u.Id == id))
            {
                return NotFound();
            }

            // _awesomeGymDbContext.Unidades.Update(unidade);
            _awesomeGymDbContext.Entry(unidade).State = EntityState.Modified;
            await _awesomeGymDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
