using RESTfulReference.Dominio.Catalog;
using RESTfulReference.Dominio.Catalogo.Enums;
using RESTfulReference.Dominio.Catalogo.Repositorios;
using RESTfulReference.Exceptions;

namespace RESTfulReference.Infraestrutura.Catalogo.Repositorios
{
    public class RepositorioProduto : IRepositorioProduto
    {
        private readonly ContextoDadosCatalogo _db;

        public RepositorioProduto(ContextoDadosCatalogo db) { _db = db; }

        public Produto Adicionar(Produto produto)
        {
            if (produto == null) throw new ArgumentNullException("Produto sem informações");

            _db.Produtos.Add(produto);
            _db.SaveChanges();

            return produto;
        }

        public void Remover(Produto entidade)
        {
            if (entidade == null) throw new ArgumentNullException("Produto sem informações");

            var produtoConsultado = _db.Produtos.FirstOrDefault(p => p.Id.ToString() == entidade.Id.ToString());
            if (entidade == null) throw new EntitdadeNaoEncontradaException("Produto não encontrado");

            if (entidade.Excluido) throw new ConflitoEntidadeException("Produto já excluído");

            produtoConsultado.Excluido = true;

            _db.SaveChanges();
        }

        public Produto Consultar(Guid id)
        {
            return _db.Produtos.FirstOrDefault(p => p.Id == id);
        }

        public IList<Produto> Consultar()
        {
            return _db.Produtos.AsQueryable().ToList();
        }

        public void AtualizarPrecos(ETipoAjuste tipoAjuste, decimal percentual)
        {
            // TODO            
        }
    }
}
