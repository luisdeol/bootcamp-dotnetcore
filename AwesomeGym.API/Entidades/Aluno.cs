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

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; private set; }
        public StatusAlunoEnum Status { get; private set; }

        public int IdUnidade { get; private set; }
        public Unidade Unidade { get; private set; }

        public int IdProfessor { get; private set; }
        public Professor Professor { get; private set; }

        public void MudarStatusParaInativo()
        {
            if (Status != StatusAlunoEnum.Ativo)
            {
                throw new Exception("Estado invalido.");
            }

            Status = StatusAlunoEnum.Inativo;
        }
    }
}
