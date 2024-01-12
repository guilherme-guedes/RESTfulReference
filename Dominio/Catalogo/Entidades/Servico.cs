using RESTfulReference.Dominio.Geral.Entidades;

namespace RESTfulReference.Dominio.Catalogo.Entidades
{
    public class Servico : EntidadeExcluivel
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
    }
}
