using AwesomeGym.API.Enums;
using System;

namespace AwesomeGym.API.Entidades
{
    public class Aluno
    {
        protected Aluno() { }
        public Aluno(string nome, string endereco, DateTime dataNascimento)
        {
            Nome = nome;
            Endereco = endereco;
            DataNascimento = dataNascimento;
            Status = StatusAlunoEnum.Ativo;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }
        public StatusAlunoEnum Status { get; set; }

        public int IdUnidade { get; set; }
        public Unidade Unidade { get; private set; }

        public int IdProfessor { get; set; }
        public Professor Professor { get; private set; }
    }
}
