using AwesomeGym.API.Entidades;
using AwesomeGym.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AwesomeGym.API.Controllers
{
    [ApiController]
    [Route("api/alunos")]
    public class AlunosController : ControllerBase
    {
        private readonly AwesomeGymDbContext _awesomeGymDbContext;
        public AlunosController(AwesomeGymDbContext awesomeDbContext)
        {
            _awesomeGymDbContext = awesomeDbContext;
        }

        // api/alunos
        // TODO: Permitir filtro!
        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _awesomeGymDbContext.Alunos.ToList();

            return Ok(alunos);
        }

        // api/alunos/4
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _awesomeGymDbContext.Alunos.SingleOrDefault(u => u.Id == id);

            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        // api/alunos
        [HttpPost]
        public IActionResult Post([FromBody] Aluno aluno)
        {
            _awesomeGymDbContext.Alunos.Add(aluno);
            _awesomeGymDbContext.SaveChanges();

            return CreatedAtAction(nameof(GetById), aluno, new { id = aluno.Id });
        }

        // api/alunos/4
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Aluno aluno)
        {
            return Ok();
        }

        // api/alunos/4
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
