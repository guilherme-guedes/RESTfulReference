using RESTfulReference.Dominio.Geral.Entidades;

namespace RESTfulReference.Dominio.Taxes
{
    public class NFSe : EntidadeAbstrata
    {
        public string Numero { get; set; }
        public RPS RPS { get; set; }
        public object Informacoes { get; set; }
    }
}
