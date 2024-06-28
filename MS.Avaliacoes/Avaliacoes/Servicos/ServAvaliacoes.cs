using Avaliacoes.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Net.Http;
using System.Threading.Tasks;

namespace Avaliacoes.Servicos
{
    public interface IServAvaliacoes
    {
        void Inserir(Avaliacao avaliacao);
        void Editar();
        Avaliacao BuscarAvaliacao(int id);
        List<Avaliacao> BuscarTodos();
        List<Avaliacao> BuscarPorAluno(int alunoId);
        decimal calculoMedia(int alunoId);
        void Remover(int id);
    }

    public class ServAvaliacoes : IServAvaliacoes
    {
        private readonly DataContext _dataContext;

        public ServAvaliacoes(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Inserir(Avaliacao avaliacao)
        {
            _dataContext.Add(avaliacao);

            _dataContext.SaveChanges();
        }

        public void Editar()
        {

            _dataContext.SaveChanges();
        }

        public Avaliacao BuscarAvaliacao(int id)
        {
            var avaliacao = _dataContext.Avaliacoes.FirstOrDefault(a => a.Id == id);

            return avaliacao;
        }

        public List<Avaliacao> BuscarPorAluno(int alunoId)
        {
            var listaAvaliacoes = _dataContext.Avaliacoes.Where(a => a.IdAluno == alunoId).ToList();

            return listaAvaliacoes;
        }

        public decimal calculoMedia(int alunoId)
        {
            var listaAvaliacoes = BuscarPorAluno(alunoId);

            decimal mediaNota = listaAvaliacoes.Average(a => a.Nota);

            return mediaNota;
        }

        /* Buscar por aluno e matéria, não será feito por matéria para manter a simplicidade do projeto
         * 
         * 
        public List<Avaliacao> BuscarPorAluno(int alunoId, int materiaId)
        {
            var listaAvaliacoes = _dataContext.Avaliacoes.Where(a => a.IdAluno == alunoId && a.Materia == (MateriaEnum)materiaId).ToList();

            return listaAvaliacoes;
        }

        public decimal calculoMedia(int alunoId, int materiaId)
        {
            var listaAvaliacoes = BuscarPorAluno(alunoId, materiaId);

            decimal mediaNota = listaAvaliacoes.Average(a => a.Nota);

            return mediaNota;
        }
        */
        public List<Avaliacao> BuscarTodos()
        {
            var listaAvaliacoes = _dataContext.Avaliacoes.ToList();

            return listaAvaliacoes;
        }

        public void Remover(int id)
        {
            var avaliacao = _dataContext.Avaliacoes.FirstOrDefault(a => a.Id == id);

            _dataContext.Remove(avaliacao); 
        }


    }
}
