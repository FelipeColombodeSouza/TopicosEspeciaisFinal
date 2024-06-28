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

        /** só vou comentar aq pra n mexer em nada q vc tava fazendo aisuhdijkh (シ_ _)シ

        [Route("api/[controller]/Inserir")]
        [HttpPost]
        public IActionResult Inserir(AdicionarMensalidadeDTO mensalidadeDTO)
        {
            try
            {
                var mensalidade = new Mensalidade();

                mensalidade.Valor = mensalidadeDTO.Valor;
                mensalidade.Situacao = mensalidadeDTO.Situacao;
                mensalidade.Mes = mensalidadeDTO.Nota;
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
        public IActionResult Editar(EditarMensalidadeDTO mensalidadeDTO)
        {
            try
            {
                var mensalidade = new Mensalidade();

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
        } **/

        [Route("api/[controller]/teste")]
        [HttpPost]
        public async Task<IActionResult> teste(int idAluno)
        {
            var sucesso = await _servAluno.teste(idAluno);
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
