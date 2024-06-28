namespace Alunos.Servicos
{
    public class AlunoEntidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Curso { get; set; }
        public int Idade { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public EnumStatusMensalidade StatusMensalidade { get; set; }
        public EnumStatusMedia StatusMedia { get; set; }
    }

    public enum EnumStatusMensalidade
    {
        Aguardando = 0,
        EmDia = 1,
        Atrasada = 2
    }

    public enum EnumStatusMedia
    {
        EmAguardo = 0,
        Aprovado = 1,
        Reprovado = 2
    }
}
