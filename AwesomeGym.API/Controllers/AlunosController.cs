using AwesomeGym.API.Entidades;
using AwesomeGym.API.Enums;
using AwesomeGym.API.InputModels;
using AwesomeGym.API.Persistence;
using AwesomeGym.API.ViewModels;
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
        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _awesomeGymDbContext
                .Alunos
                .ToList();

            var alunosViewModel = alunos
                .Select(a => new AlunoViewModel(a.Nome, a.Status))
                .ToList();

            return Ok(alunosViewModel);
        }

        // api/alunos/4
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // TODO: Trazer unidade e professor
            var aluno = _awesomeGymDbContext
                .Alunos
                .SingleOrDefault(u => u.Id == id);

            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        // api/alunos
        [HttpPost]
        public IActionResult Post([FromBody] AlunoInputModel alunoInputModel)
        {
            var aluno = new Aluno(
                alunoInputModel.Nome,
                alunoInputModel.Endereco,
                alunoInputModel.DataNascimento
                );

            _awesomeGymDbContext.Alunos.Add(aluno);
            _awesomeGymDbContext.SaveChanges();

            return CreatedAtAction(nameof(GetById), alunoInputModel, new { id = alunoInputModel.Id });
        }

        // api/alunos/4
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AlunoUpdateInputModel alunoInputModel)
        {
            var aluno = _awesomeGymDbContext.Alunos.SingleOrDefault(a => a.Id == id);

            if (aluno == null)
            {
                return NotFound();
            }

            aluno.Endereco = alunoInputModel.Endereco;

            _awesomeGymDbContext.SaveChanges();

            return NoContent();
        }

        // api/alunos/4
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _awesomeGymDbContext.Alunos.SingleOrDefault(a => a.Id == id);

            if (aluno == null)
            {
                return NotFound();
            }

            aluno.MudarStatusParaInativo();
            _awesomeGymDbContext.SaveChanges();

            return NoContent();
        }
    }
}
