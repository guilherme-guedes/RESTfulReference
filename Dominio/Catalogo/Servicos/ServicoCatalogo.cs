using RESTfulReference.Dominio.Catalogo.Enums;
using RESTfulReference.Dominio.Catalogo.Repositorios;

namespace RESTfulReference.Dominio.Catalogo.Servicos
{
    public class ServicoCatalogo
    {
        private readonly IRepositorioServico repositorioServico;
        private readonly IRepositorioProduto repositorioProduto;

        public ServicoCatalogo(IRepositorioServico repositorioServico, IRepositorioProduto repositorioProduto)
        {
            this.repositorioServico = repositorioServico;
            this.repositorioProduto = repositorioProduto;
        }

        public void AjustarPrecos(ETipoAjuste tipo, decimal percentual)
        {
            this.repositorioProduto.AtualizarPrecos(tipo, percentual);
            this.repositorioServico.AtualizarPrecos(tipo, percentual);
        }
    }
}
