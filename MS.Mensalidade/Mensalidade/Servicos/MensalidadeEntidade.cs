namespace Mensalidade.Servicos
{
    public class MensalidadeEntidade
    {
        public int Id { get; set; }

        public string Mes { get; set; }

        public decimal Valor { get; set; }

        public SituacaoEnum Situacao { get; set; }

        public int IdAluno { get; set; }
    }

    public enum SituacaoEnum
    {
        EmAberto = 0,
        Paga = 1
    }
}
