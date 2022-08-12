using TechTest.Data;

namespace TechTest.Repositories
{
    public class ProductRepository : IProductRepository
    {
        TTContext _db;
        public ProductRepository(TTContext db)
        {
            _db = db;
        }

        public void Create(int id, string name, string desc, decimal price)
        {
            var product = new Product
            {
                Id = id,
                Name = name,
                Description = desc,
                Price = price
            };
            _db.Add(product);
            _db.SaveChanges();
        }

        public Product GetById(int id)
        {
            return _db.Products.Find(id);
        }

        public List<Product> GetAll()
        {
            return _db.Products.ToList();
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            _db.Products.Remove(product);
            _db.SaveChanges();
        }
    }
}
