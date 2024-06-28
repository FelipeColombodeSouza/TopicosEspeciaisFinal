using Avaliacoes.Servicos;

namespace Avaliacoes.DTO
{
    public class AdicionarAvaliacoesDTO
    {
        public decimal Nota { get; set; }

        public MateriaEnum Materia { get; set; }

        public int IdAluno { get; set; }
    }
}
