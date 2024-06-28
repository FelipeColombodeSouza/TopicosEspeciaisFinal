using Mensalidade.DTO;
using Mensalidade;


namespace Mensalidade.Servicos
{
    public interface IServMensalidade
    {
        void Inserir(MensalidadeEntidade mensalidade);
        void Editar();
        MensalidadeEntidade BuscarMensalidade(int id);
        MensalidadeEntidade BuscarPorAluno(int alunoId);
        List<MensalidadeEntidade> BuscarTodos();
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

        public MensalidadeEntidade BuscarMensalidade(int id)
        {
            var mensalidade = _dataContext.Mensalidade.FirstOrDefault(a => a.Id == id);

            return mensalidade;
        }

        public List<MensalidadeEntidade> BuscarTodos()
        {
            var listaMensalidade = _dataContext.Mensalidade.ToList();

            return listaMensalidade;
        }


        public MensalidadeEntidade BuscarPorAluno(int alunoId)
        {
            var ultimaMensalidade = _dataContext.Mensalidade.FirstOrDefault(a => a.IdAluno == alunoId);

            return ultimaMensalidade;
        }

        public void Remover(int id)
        {
            var mensalidade = _dataContext.Mensalidade.FirstOrDefault(a => a.Id == id);

            _dataContext.Remove(mensalidade);
        }
    }
}
