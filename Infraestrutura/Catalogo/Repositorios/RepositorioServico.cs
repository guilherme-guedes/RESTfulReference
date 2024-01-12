using RESTfulReference.Dominio.Catalogo.Entidades;
using RESTfulReference.Dominio.Catalogo.Enums;
using RESTfulReference.Dominio.Catalogo.Repositorios;
using RESTfulReference.Exceptions;

namespace RESTfulReference.Infraestrutura.Catalogo.Repositorios
{
    public class RepositorioServico : IRepositorioServico
    {
        private readonly ContextoDadosCatalogo _db;

        public RepositorioServico(ContextoDadosCatalogo db) { _db = db; }

        public Servico Adicionar(Servico servico)
        {
            if (servico == null) throw new ArgumentNullException("Servico sem informações");

            _db.Servicos.Add(servico);
            _db.SaveChanges();

            return servico;
        }

        public void AtualizarPrecos(ETipoAjuste tipoAjuste, decimal percentual)
        {
            // TODO            
        }

        public void Remover(Servico entidade)
        {
            if (entidade == null) throw new ArgumentNullException("Servico sem informações");

            var servicoConsultado = _db.Servicos.FirstOrDefault(p => p.Id.ToString() == entidade.Id.ToString());
            if (entidade == null) throw new EntitdadeNaoEncontradaException("Servico não encontrado");

            if (entidade.Excluido) throw new ConflitoEntidadeException("Servico já excluído");

            servicoConsultado.Excluido = true;

            _db.SaveChanges();
        }

        public Servico Consultar(Guid id)
        {
            return _db.Servicos.FirstOrDefault(p => p.Id == id);
        }

        public IList<Servico> Consultar()
        {
            return _db.Servicos.AsQueryable().ToList();
        }
    }
}
