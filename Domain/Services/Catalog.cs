using Newtonsoft.Json;
using RestfulReference.Domain.Entities;
using RestfulReference.Infrastructure.Repositories;
using RESTfulReference.Exceptions;
using System.Security.Cryptography;
using System.Text;
using System.Text.Unicode;

namespace RESTfulReference.Services
{
    public class Catalog
    {
        private readonly ProductRepository repository;

        public Catalog(ProductRepository repository) { this.repository = repository; }

        public void CheckIntegrity(Product product)
        {
            if (product == null) throw new ArgumentNullException("Empty product info");

            var productSameName = repository.GetByName(product.Name);
            if (productSameName != null)
                throw new ConflictedProductException("There is already a product with this name");
        }

        public bool CheckIfModified(Product product)
        {

            if (product == null) throw new ArgumentNullException("Empty product info");

            var productDb = repository.GetById(product.Id.ToString());
            if (productDb == null) return true;
            
            var mapProductDb = GenerateHash(productDb);
            var mapProduct = GenerateHash(product);

            return (mapProductDb != mapProduct);
        }

        private string GenerateHash(Product product) 
        {
            if (product == null) return "";

            var json = JsonConvert.SerializeObject(product);
            return Encoding.UTF8.GetString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(json)));
        }
    }
}
