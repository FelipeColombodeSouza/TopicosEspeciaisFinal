using Mensalidade.Servicos;

namespace Mensalidade.DTO
{
    public class AdicionarMensalidadeDTO
    {

        public string Mes { get; set; }

        public decimal Valor { get; set; }

        public SituacaoEnum Situacao { get; set; }

        public int IdAluno { get; set; }
    }
}
