using Mensalidade.Servicos;

namespace Mensalidade.DTO
{
    public class EditarMensalidadeDTO
    {
        public decimal Valor { get; set; }

        public SituacaoEnum Situacao { get; set; }

        public string Mes { get; set; }
    }
}
