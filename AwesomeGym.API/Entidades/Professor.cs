using AwesomeGym.API.Enums;
using System.Collections.Generic;

namespace AwesomeGym.API.Entidades
{
    public class Professor
    {
        protected Professor() { }
        public Professor(string nome, string endereco, int idUnidade)
        {
            Nome = nome;
            Endereco = endereco;
            Status = StatusProfessorEnum.Ativo;
            Alunos = new List<Aluno>();
            IdUnidade = idUnidade;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public StatusProfessorEnum Status { get; set; }
        public List<Aluno> Alunos { get; set; }

        public int IdUnidade { get; set; }
        public Unidade Unidade { get; set; }
    }
}
