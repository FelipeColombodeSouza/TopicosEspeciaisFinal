using Alunos.DTO;
using Alunos;


namespace Alunos.Servicos
    {
    public interface IAlunoService
    {

        void Inserir(AlunoEntidade aluno);
        void Editar();
        List<AlunoEntidade> BuscarTodos();
        AlunoEntidade BuscarPorId(int id);
        void Remover(int id);

        /*bool VerificarPagamento(int alunoId);*/
        
    }
    public class AlunoService : IAlunoService
    {
        private readonly DataContext _dataContext;

        public AlunoService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Inserir(AlunoEntidade aluno)
        {
            _dataContext.Add(aluno);

            _dataContext.SaveChanges();
        }

        public void Editar()
        {
            _dataContext.SaveChanges();
        }

        public List<AlunoEntidade> BuscarTodos()
        {
            var listaAlunos = _dataContext.Alunos.ToList();

            return listaAlunos;

        }

        public AlunoEntidade BuscarPorId(int id)
        {
            var alunos = _dataContext.Alunos.FirstOrDefault(a => a.Id == id);

            return alunos;
        }

        public void Remover(int id)
        {
            var aluno = _dataContext.Alunos.FirstOrDefault(a => a.Id == id);

            _dataContext.Remove(aluno);
        }

        /*
        public bool VerificarPagamento(int alunoId)
        {
            // Implementação simulada de verificação de pagamento
            var pagamentos = new Dictionary<int, bool>
                {
                    { 1, true },
                    { 2, false }
                };

            return pagamentos.TryGetValue(alunoId, out bool pagou) && pagou;
        }*/
        
    }
}