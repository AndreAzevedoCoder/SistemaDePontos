namespace PontoMVC.Database.Interfaces
{
    public interface IDiaDeTrabalhoRepository
    {
        public void Cadastrar(DiaDeTrabalho dia);
        public void Excluir(DiaDeTrabalho dia);
        public void Editar(DiaDeTrabalho dia);
    }
}