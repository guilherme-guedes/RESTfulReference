using RESTfulReference.Domain.Entities.Taxes;
using RESTfulReference.Domain.Entities.Taxes.Enums;

namespace RESTfulReference.Infrastructure.External
{
    public class WebISSService
    {
        public string GenerateDocument(RPS rps)
        {
            var generatedNFSeID = "123456";
            Console.WriteLine("Sending the RPS to generate the fiscal document");
            return generatedNFSeID;
        }

        public NFSeStatus GetStatus(string documentNumber)
        {
            return NFSeStatus.Processing;
        }

        public NFSe GetDocument(string documentNumber)
        {
            return new NFSe();
        }
    }
}
