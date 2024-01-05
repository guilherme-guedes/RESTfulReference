using RestfulReference.Infrastructure;
using RESTfulReference.Domain.Entities.Catalog;
using RESTfulReference.Domain.Entities.Taxes;
using RESTfulReference.Domain.Entities.Taxes.Enums;
using RESTfulReference.Exceptions;
using RESTfulReference.Infrastructure.External;

namespace RESTfulReference.Infrastructure.Repositories
{
    public class DocumentRepository
    {
        private readonly DatabaseContext _db;

        public DocumentRepository(DatabaseContext db) { this._db = db; }

        public string GenerateDocument(RPS rps)
        {
            try
            {
                rps.DocumentNumber =  new WebISSService().GenerateDocument(rps);

                CreateRPS(rps);

                return rps.DocumentNumber;
            }
            catch (EntityConflictedException)
            {
                throw;
            }
            catch(Exception)
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
            catch (EntityNotFoundException)
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

            if(document == null)
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

            this._db.RPSs.Add(rps);
            this._db.SaveChanges();

            return rps.Id;
        }

        private void CreateDocument(NFSe document)
        {
            this._db.Documents.Add(document);
            this._db.SaveChanges();
        }
    }
}
