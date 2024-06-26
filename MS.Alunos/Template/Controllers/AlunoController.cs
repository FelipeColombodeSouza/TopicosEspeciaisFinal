using Microsoft.AspNetCore.Mvc;
using Alunos.DTO;
using Alunos.Servicos;

namespace Alunos.Controller
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [Route("api/[controller]/Inserir")]
        [HttpPost]
        public IActionResult Inserir(InserirAlunoDTO alunoDTO)
        {
            try
            {
                var aluno = new AlunoEntidade();

                aluno.Nome = alunoDTO.Nome;
                aluno.Telefone = alunoDTO.Telefone;
                aluno.Curso = alunoDTO.Curso;
                aluno.Idade = alunoDTO.Idade;
                aluno.Endereco = alunoDTO.Endereco;
                aluno.StatusMensalidade = 0;
                aluno.StatusMedia = 0;

                _alunoService.Inserir(aluno);

                var retornoInsercao = new { CodigoAluno = aluno.Id };

                return Ok("Adicionado aluno com ID: " + retornoInsercao);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/[controller]/Editar")]
        [HttpPost]
        public IActionResult Editar(int id, InserirAlunoDTO alunoDTO)
        {
            try
            {
                var aluno = _alunoService.BuscarPorId(id);

                aluno.Nome = alunoDTO.Nome;
                aluno.Telefone = alunoDTO.Telefone;
                aluno.Idade = alunoDTO.Idade;
                aluno.Curso = alunoDTO.Curso;
                aluno.Endereco = alunoDTO.Endereco;

                _alunoService.Editar();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/[controller]/BuscarTodos")]
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            try
            {
                var alunos = _alunoService.BuscarTodos();
                return Ok(alunos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/[controller]/Buscar/{id}")]
        [HttpGet]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var aluno = _alunoService.BuscarPorId(id);
                return Ok(aluno);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/[controller]/Remover/{id}")]
        [HttpDelete]
        public IActionResult Remover(int id)
        {
            try
            {
                _alunoService.Remover(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Route("api/[controller]/Aprovar")]
        [HttpPost]
        public IActionResult AprovarMedia([FromBody] AlunoCursoUpdateRequest request)
        {
            try
            {
                var aluno = _alunoService.BuscarPorId(request.Id);

                if (Enum.IsDefined(typeof(EnumStatusMedia), request.Aprovar))
                {
                    aluno.StatusMedia = (EnumStatusMedia)request.Aprovar;
                }
                else
                {
                    return BadRequest("Status inválido.");
                }

                _alunoService.Editar();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /*
        [Route("verificar-pagamento/{id}")]
        [HttpGet]
        public IActionResult VerificarPagamento(int id)
        {
            try
            {
                var pagamentoOk = _alunoService.VerificarPagamento(id);
                return Ok(new { PagamentoOk = pagamentoOk });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }*/
    }

    public class AlunoCursoUpdateRequest
    {
        public int Id { get; set; }
        public int Aprovar { get; set; }
    }
}