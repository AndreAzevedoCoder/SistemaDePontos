namespace PontoMVC.Database
{
    public interface IFuncionarioRepository
    {
        public void Cadastrar(Funcionario funcionario);
        public void Logar(Funcionario funcionario);
    }
}