using RestfulReference.Domain.Entities;
using RESTfulReference.Exceptions;

namespace RestfulReference.Infrastructure.Repositories
{
    public class ProductRepository
    {
        private readonly DatabaseContext _db;

        public ProductRepository(DatabaseContext db) { this._db = db; }

        public Guid Create(Product product)
        {
            if (product == null) throw new ArgumentNullException("Empty product info");

            this._db.Products.Add(product);
            this._db.SaveChanges();

            return product.Id;
        }
        public void Update(Product product)
        {
            if (product == null) throw new ArgumentNullException("Empty product info");

            var productDb = _db.Products.FirstOrDefault(p => p.Id.ToString() == product.Id.ToString());
            if (product == null) throw new EntityNotFoundException("Product not found");

            
            productDb.Name = product.Name;
            productDb.Price = product.Price;

            this._db.SaveChanges();
        }


        public void Delete(string id)
        {
            Guid guid = new Guid();
            if (String.IsNullOrEmpty(id) || !Guid.TryParse(id, out guid))
                throw new MalformedIdException("Malformed product ID");
            
            var productDb = _db.Products.FirstOrDefault(p => p.Id.ToString() == id); 
            if (productDb == null) throw new EntityNotFoundException("Product not found");

            this._db.Products.Remove(productDb);
            this._db.SaveChanges();
        }

        public Product GetById(string id)
        {
            Guid guid = new Guid();
            if(String.IsNullOrEmpty(id) || !Guid.TryParse(id, out guid))
                throw new MalformedIdException("Malformed product ID");

            return _db.Products.FirstOrDefault(p => p.Id.ToString() == id);
        }

        public Product GetByName(string name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("Empty product name");

            return _db.Products.FirstOrDefault(p => p.Name == name);
        }
    }
}
