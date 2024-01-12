using RESTfulReference.Dominio.Catalogo.Entidades;
using RESTfulReference.Dominio.Geral.Repositorios;

namespace RESTfulReference.Dominio.Catalogo.Repositorios
{
    public interface IRepositorioServico : IRepositorioGeral<Servico>,
        IRepositorioAtualizadorPreco,
        IRepositorioExclusor<Servico>
    {
        public Servico Adicionar(Servico servico);
    }
}
