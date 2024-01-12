using RESTfulReference.Dominio.Taxes;
using RESTfulReference.Dominio.Taxes.Enums;
using RESTfulReference.Exceptions;
using RESTfulReference.Infraestrutura.Catalogo;
using RESTfulReference.Infraestrutura.Fiscal.External;

namespace RESTfulReference.Infraestrutura.Fiscal.Repositories
{
    public class DocumentRepository
    {
        private readonly ContextoDadosCatalogo _db;

        public DocumentRepository(ContextoDadosCatalogo db) { _db = db; }

        public string GenerateDocument(RPS rps)
        {
            try
            {
                rps.DocumentNumber = new WebISSService().GenerateDocument(rps);

                CreateRPS(rps);

                return rps.DocumentNumber;
            }
            catch (ConflitoEntidadeException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public NFSeStatus GetStatus(string documentNumber)
        {
            try
            {
                return new WebISSService().GetStatus(documentNumber);
            }
            catch (MalformedIdException)
            {
                throw;
            }
            catch (EntitdadeNaoEncontradaException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public NFSe GetDocument(string documentNumber)
        {
            var document = _db.Documents.FirstOrDefault(p => p.Number == documentNumber);

            if (document == null)
            {
                var documentFromSEFAZ = new WebISSService().GetDocument(documentNumber);
                if (documentFromSEFAZ == null)
                    return null;

                CreateDocument(documentFromSEFAZ);
            }
            return document;
        }

        public RPS GetRPS(string rpsID)
        {
            return _db.RPSs.FirstOrDefault(p => p.Id == rpsID);
        }

        private string CreateRPS(RPS rps)
        {

            if (rps == null) throw new ArgumentNullException("Empty RPS info");

            _db.RPSs.Add(rps);
            _db.SaveChanges();

            return rps.Id;
        }

        private void CreateDocument(NFSe document)
        {
            _db.Documents.Add(document);
            _db.SaveChanges();
        }
    }
}
