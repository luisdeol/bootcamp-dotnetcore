using System;

namespace AwesomeGym.API.InputModels
{
    public class AlunoInputModel
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }
        public int IdProfessor { get; set; }
        public int IdUnidade { get; set; }
    }
}
