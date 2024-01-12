using RESTfulReference.Dominio.Geral.Entidades;

namespace RESTfulReference.Dominio.Geral.Repositorios
{
    public interface IRepositorioExclusor<T> where T : EntidadeExcluivel
    {
        public void Remover(T entidade);
    }
}
