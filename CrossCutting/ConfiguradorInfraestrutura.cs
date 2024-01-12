using RESTfulReference.Dominio.Catalogo.Repositorios;
using RESTfulReference.Infraestrutura.Catalogo;
using RESTfulReference.Infraestrutura.Catalogo.Repositorios;

namespace RESTfulReference.CrossCutting
{
    public class ConfiguradorInfraestrutura
    {
        public static void ConfigurarInfraestrutura(IServiceCollection serviceCollection)
        {
            // Contexto
            serviceCollection.AddScoped<ContextoDadosCatalogo, ContextoDadosCatalogo>();

            // Repositorios
            serviceCollection.AddScoped<IRepositorioProduto, RepositorioProduto>();
            serviceCollection.AddScoped<IRepositorioServico, RepositorioServico>();
        }
    }
}
