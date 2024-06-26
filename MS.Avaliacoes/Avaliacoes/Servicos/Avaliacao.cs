namespace Avaliacoes.Servicos
{
    public class Avaliacao
    {
        public int Id { get; set; }

        public decimal Nota { get; set; }

        public MateriaEnum Materia { get; set; }

        public int IdAluno { get; set; }
    }

    // não é o ideal um enum cravado, mas será feito só pra exemplificar o trabalho
    public enum MateriaEnum
    {
        TopicosEspeciais = 0,
        Seguranca = 1,
        ECC = 2
    }
}
