using RESTfulReference.Dominio.Geral.Entidades;

namespace RESTfulReference.Dominio.Geral.Repositorios
{
    public interface IRepositorioGeral<T> where T : EntidadeAbstrata
    {
        public T Consultar(Guid id);

        public IList<T> Consultar();
    }
}
