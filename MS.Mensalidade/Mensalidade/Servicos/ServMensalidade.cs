using Mensalidade.DTO;
using Mensalidade;


namespace Mensalidade.Servicos
{
    public interface IServMensalidade
    {
        void Inserir(MensalidadeEntidade mensalidade);
        void Editar();
        List<MensalidadeEntidade> BuscarPorAluno(int alunoId);
        void Remover(int id);
    }

    public class ServMensalidade : IServMensalidade
    {
        private readonly DataContext _dataContext;

        public ServMensalidade(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Inserir(MensalidadeEntidade mensalidade)
        {
            _dataContext.Add(mensalidade);

            _dataContext.SaveChanges();
        }

        public void Editar()
        {
            _dataContext.SaveChanges();
        }

        public List<MensalidadeEntidade> BuscarPorAluno(int alunoId)
        {
            var listaMensalidade = _dataContext.Mensalidade.Where(a => a.IdAluno == alunoId).ToList();

            return listaMensalidade;
        }

        public void Remover(int id)
        {
            var mensalidade = _dataContext.Mensalidade.FirstOrDefault(a => a.Id == id);

            _dataContext.Remove(mensalidade);
        }
    }
}
