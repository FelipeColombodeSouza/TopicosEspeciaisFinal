using Microsoft.AspNetCore.Mvc;
using Mensalidade.Servicos;
using Mensalidade.DTO;

namespace Mensalidade
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensalidadeController : Controller
    {
        private IServMensalidade _servMensalidade;
        private IServAluno _servAluno;

        public MensalidadeController(IServMensalidade servMensalidade, IServAluno servAluno)
        {
            _servMensalidade = servMensalidade;
            _servAluno = servAluno;
        }

        [Route("api/[controller]/Inserir")]
        [HttpPost]
        public IActionResult Inserir(AdicionarMensalidadeDTO mensalidadeDTO)
        {
            try
            {
                var mensalidade = new MensalidadeEntidade();

                mensalidade.Valor = mensalidadeDTO.Valor;
                mensalidade.Situacao = mensalidadeDTO.Situacao;
                mensalidade.Mes = mensalidadeDTO.Mes;
                mensalidade.IdAluno = mensalidadeDTO.IdAluno;

                _servMensalidade.Inserir(mensalidade);

                var retornoInsercao = new { CodigoMensalidade = mensalidade.Id };


                return Ok(retornoInsercao);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/[controller]/Editar/{id}")]
        [HttpPost]
        public IActionResult Editar(int id, EditarMensalidadeDTO mensalidadeDTO)
        {
            try
            {
                var mensalidade = _servMensalidade.BuscarMensalidade(id);

                mensalidade.Situacao = mensalidadeDTO.Situacao;
                mensalidade.Valor = mensalidadeDTO.Valor;
                mensalidade.Mes = mensalidadeDTO.Mes;

                _servMensalidade.Editar();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/[controller]/BuscarTodos")]
        [HttpGet]
        public IActionResult BuscarMensalidadeLista()
        {
            try
            {
                var mensalidades = _servMensalidade.BuscarTodos();

                return Ok(mensalidades);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/[controller]/BuscarMensalidade")]
        [HttpGet]
        public IActionResult BuscarMensalidade(int id)
        {
            try
            {
                var mensalidades = _servMensalidade.BuscarMensalidade(id);

                return Ok(mensalidades);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/[controller]/BuscarPorAluno")]
        [HttpGet]
        public IActionResult BuscarPorAluno(int id)
        {
            try
            {
                var avaliacoes = _servMensalidade.BuscarPorAluno(id);

                return Ok(avaliacoes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/[controller]/Remover")]
        [HttpDelete]
        public IActionResult RemoverMensalidade(int id)
        {
            try
            {
                _servMensalidade.Remover(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/[controller]/VerificarPagamento")]
        [HttpPost]
        public async Task<IActionResult> VerificarPagamento(int idAluno)
        {
            var sucesso = await _servAluno.AprovarPagamento(idAluno);
            if (sucesso)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
