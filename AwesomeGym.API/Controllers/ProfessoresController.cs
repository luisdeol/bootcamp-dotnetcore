using AwesomeGym.API.Entidades;
using AwesomeGym.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AwesomeGym.API.Controllers
{
    [ApiController]
    [Route("api/professores")]
    public class ProfessoresController : ControllerBase
    {
        private readonly AwesomeGymDbContext _awesomeGymDbContext;
        public ProfessoresController(AwesomeGymDbContext awesomeGymDbContext)
        {
            _awesomeGymDbContext = awesomeGymDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var professores = _awesomeGymDbContext.Professores.ToList();

            return Ok(professores);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _awesomeGymDbContext.Professores.SingleOrDefault(p => p.Id == id);

            if (professor == null)
            {
                return NotFound();
            }

            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _awesomeGymDbContext.Professores.Add(professor);
            _awesomeGymDbContext.SaveChanges();

            return CreatedAtAction(nameof(GetById), professor, new { id = professor.Id });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Professor professor)
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
