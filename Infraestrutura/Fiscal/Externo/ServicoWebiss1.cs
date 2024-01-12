using RESTfulReference.Dominio.Taxes;
using RESTfulReference.Dominio.Taxes.Enums;

namespace RESTfulReference.Infraestrutura.Fiscal.External
{
    public class ServicoWebiss1
    {
        public string EnviarRPS(RPS rps)
        {
            var generatedNFSeID = "123456";
            Console.WriteLine("Enviando RPS para geração da NFSe");
            return generatedNFSeID;
        }

        public NFSeStatus ConsultarStatusNFSe(string documentNumber)
        {
            return NFSeStatus.Processando;
        }

        public NFSe ConsultarNFSe(string documentNumber)
        {
            return new NFSe();
        }
    }
}
