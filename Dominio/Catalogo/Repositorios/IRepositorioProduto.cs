using RESTfulReference.Dominio.Catalog;
using RESTfulReference.Dominio.Geral.Repositorios;

namespace RESTfulReference.Dominio.Catalogo.Repositorios
{
    public interface IRepositorioProduto : IRepositorioGeral<Produto>,
        IRepositorioAtualizadorPreco,
        IRepositorioExclusor<Produto>
    {
        Produto Adicionar(Produto produto);
    }
}
