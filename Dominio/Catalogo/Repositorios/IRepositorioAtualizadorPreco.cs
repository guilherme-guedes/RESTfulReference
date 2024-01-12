using RESTfulReference.Dominio.Catalogo.Enums;

namespace RESTfulReference.Dominio.Catalogo.Repositorios
{
    public interface IRepositorioAtualizadorPreco
    {
        public void AtualizarPrecos(ETipoAjuste tipoAjuste, decimal percentual);
    }
}
