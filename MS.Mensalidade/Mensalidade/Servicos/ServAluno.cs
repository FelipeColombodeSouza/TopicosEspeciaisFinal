using Microsoft.AspNetCore.Http.HttpResults;

namespace Mensalidade.Servicos
{
    public interface IServAluno
    {
        Task<bool> AprovarPagamento(int id);
    }
    public class ServAluno : IServAluno
    {

        private readonly HttpClient _httpClient;
        private IServMensalidade _servMensalidade;
        public ServAluno(HttpClient httpClient, IServMensalidade servMensalidade)
        {
            _httpClient = httpClient;
            _servMensalidade = servMensalidade;
        }

        // checa a última mensalidade do aluno para ver se foi paga
        public async Task<bool> AprovarPagamento(int id)
        {
            var mensalidade = _servMensalidade.BuscarMensalidade(id);
            var pagamentoStatus = 0;

            if(mensalidade.Situacao == SituacaoEnum.Paga)
            {
                pagamentoStatus = 1;
            }
            else
            {
                pagamentoStatus = 2;
            }


            var request = new AlunoPagamentoUpdateRequest { Id = id, PagamentoStatus = pagamentoStatus };
            var response = await _httpClient.PostAsJsonAsync($"/api/Aluno/api/Aluno/AtualizarPagamento", request);
            return response.IsSuccessStatusCode;
        }

    }
    public class AlunoPagamentoUpdateRequest
    {
        public int Id { get; set; }
        public int PagamentoStatus { get; set; }
    }
}
