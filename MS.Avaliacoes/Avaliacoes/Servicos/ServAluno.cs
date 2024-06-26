using Microsoft.AspNetCore.Http.HttpResults;

namespace Avaliacoes.Servicos
{
    public interface IServAluno
    {
        Task<bool> CalculoMedia(int id);
    }
    public class ServAluno : IServAluno
    {

        private readonly HttpClient _httpClient;
        private IServAvaliacoes _servAvaliacoes;

        public ServAluno(HttpClient httpClient, IServAvaliacoes servAvaliacoes)
        {
            _httpClient = httpClient;
            _servAvaliacoes = servAvaliacoes;
        }

        public async Task<bool> CalculoMedia(int id)
        {
            var aprovar = 0;

            decimal media = _servAvaliacoes.calculoMedia(id);

            if (media >= 6)
            {
                aprovar = 1;
            }
            else
            {
                aprovar = 2;
            }

            var request = new AlunoCursoUpdateRequest { Id = id, Aprovar = aprovar };
            var response = await _httpClient.PostAsJsonAsync($"/api/Aluno/api/Aluno/Aprovar", request);
            return response.IsSuccessStatusCode;
        }

    }
    public class AlunoCursoUpdateRequest
    {
        public int Id { get; set; }
        public int Aprovar { get; set; }
    }
}
