using TechTest.Data;

namespace TechTest.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(DbContext db) : base(db)
        {

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
            Create<Product>(product);
        }

        public Product GetById(int id)
        {
            return GetAll<Product>()
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Product> GetAll()
        {
            return base.GetAll<Product>();
        }

        public void Delete(int id)
        {
            var allProducts = context.Get<Product>();
            allProducts.RemoveAll(x => x.Id == id);
            context.SaveChanges<Product>(allProducts);
        }
    }
}
