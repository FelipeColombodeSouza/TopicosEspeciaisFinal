using Microsoft.AspNetCore.Mvc;
using Avaliacoes.Servicos;
using Avaliacoes.DTO;
using System.Diagnostics;

namespace Avaliacoes
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacoesController : Controller
    {

        private IServAvaliacoes _servAvaliacoes;
        private IServAluno _servAluno;

        public AvaliacoesController(IServAvaliacoes servAvaliacoes, IServAluno servAluno)
        {
            _servAvaliacoes = servAvaliacoes;
            _servAluno = servAluno;
        }

        [Route("api/[controller]/Inserir")]
        [HttpPost]
        public IActionResult Inserir(AdicionarAvaliacoesDTO avaliacoesDTO)
        {
            try
            {
                var avaliacao = new Avaliacao();

                avaliacao.Materia = avaliacoesDTO.Materia;
                avaliacao.Nota = avaliacoesDTO.Nota;
                avaliacao.IdAluno = avaliacoesDTO.IdAluno;

                _servAvaliacoes.Inserir(avaliacao);

                var retornoInsercao = new { CodigoAvaliacao = avaliacao.Id };


                return Ok(retornoInsercao);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Route("api/[controller]/Editar/{id}")]
        [HttpPost]
        public IActionResult Editar(EditarAvaliacoesDTO avaliacoesDTO)
        {
            try
            {
                var avaliacao = new Avaliacao();

                avaliacao.Materia = avaliacoesDTO.Materia;
                avaliacao.Nota = avaliacoesDTO.Nota;

                _servAvaliacoes.Editar();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Route("api/[controller]/Buscar/{id}")]
        [HttpGet]
        public IActionResult BuscarAvaliacao(int id)
        {
            try
            {
                var avaliacao = _servAvaliacoes.BuscarAvaliacao(id);

                return Ok(avaliacao);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/[controller]/BuscarTodos")]
        [HttpGet]
        public IActionResult BuscarAvaliacaoLista()
        {
            try
            {
                var avaliacoes = _servAvaliacoes.BuscarTodos();

                return Ok(avaliacoes);
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
                var avaliacoes = _servAvaliacoes.BuscarPorAluno(id);

                return Ok(avaliacoes);
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
                _servAvaliacoes.Remover(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/[controller]/AprovarMedia")]
        [HttpPost]
        public async Task<IActionResult> CalculoMedia(int idAluno)
        {
            var sucesso = await _servAluno.CalculoMedia(idAluno);
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
