using AwesomeGym.API.Enums;

namespace AwesomeGym.API.ViewModels
{
    public class AlunoViewModel
    {
        public AlunoViewModel(string nome, StatusAlunoEnum status)
        {
            Nome = nome;
            Status = status;
        }

        public string Nome { get; private set; }
        public StatusAlunoEnum Status { get; private set; }
    }
}
