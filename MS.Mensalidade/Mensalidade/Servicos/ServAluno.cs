using Microsoft.AspNetCore.Http.HttpResults;

namespace Mensalidade.Servicos
{
    public interface IServAluno
    {
        Task<bool> teste(int id);
    }
    public class ServAluno : IServAluno
    {

        private readonly HttpClient _httpClient;

        public ServAluno(HttpClient httpClient)
        {
            _httpClient = httpClient;
            
        }

        // essa função já ta conectando com o alunos e mudando o status da media, ai é só mudar pra lógica da mensalidade e criar uma nova função no micro de alunos
        public async Task<bool> teste(int id)
        {
            var request = new AlunoCursoUpdateRequest { Id = id, Aprovar = 0 };
            var response = await _httpClient.PostAsJsonAsync($"/api/Aluno/api/Aluno/Aprovar", request); // aqui vc vai olhar no swagger o caminho da função e trocar
            return response.IsSuccessStatusCode;
        }

    }
    public class AlunoCursoUpdateRequest
    {
        public int Id { get; set; }
        public int Aprovar { get; set; }
    }
}
