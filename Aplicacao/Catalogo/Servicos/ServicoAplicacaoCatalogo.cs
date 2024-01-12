using RESTfulReference.Dominio.Catalogo.Entidades;
using RESTfulReference.Dominio.Catalogo.Repositorios;

namespace RESTfulReference.Aplicacao.Catalogo.Servicos
{
    public class ServicoAplicacaoCatalogo
    {

        private readonly IRepositorioServico repositorio;

        public ServicoAplicacaoCatalogo(IRepositorioServico repositorio) { this.repositorio = repositorio; }
    }
}
