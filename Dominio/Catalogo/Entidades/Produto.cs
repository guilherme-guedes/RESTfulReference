using RESTfulReference.Dominio.Geral.Entidades;

namespace RESTfulReference.Dominio.Catalog
{
    public class Produto : EntidadeExcluivel
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
    }
}
