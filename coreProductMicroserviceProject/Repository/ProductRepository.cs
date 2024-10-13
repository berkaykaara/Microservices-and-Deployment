using coreProductMicroserviceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace coreProductMicroserviceProject.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _dbcontext;
        public ProductRepository(ProductDbContext context)
        {
            _dbcontext = context;
        }

        public void DeleteProduct(int productId)
        {
            var product = _dbcontext.Products.Find(productId);
            _dbcontext.Products.Remove(product);
            Save();
        }

        public Product GetProductById(int productId)
        {
            return _dbcontext.Products.Find(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbcontext.Products.ToList();
        }

        public void InsertProduct(Product product)
        {
            _dbcontext.Add(product);
            Save();
        }

        public void Save()
        {
            _dbcontext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _dbcontext.Entry(product).State = EntityState.Modified;
            Save();
        }
    }
}
