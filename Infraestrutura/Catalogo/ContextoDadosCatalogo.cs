using Microsoft.EntityFrameworkCore;
using RESTfulReference.Dominio.Catalog;
using RESTfulReference.Dominio.Catalogo.Entidades;

namespace RESTfulReference.Infraestrutura.Catalogo
{
    public class ContextoDadosCatalogo : DbContext
    {
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public ContextoDadosCatalogo(DbContextOptions<ContextoDadosCatalogo> options) : base(options) { }
    }
}
