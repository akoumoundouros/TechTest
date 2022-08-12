using TechTest.Data;

namespace TechTest.Repositories
{
    public interface IProductRepository
    {
        void Create(int id, string name, string desc, decimal price);
        void Delete(int id);
        List<Product> GetAll();
        Product GetById(int id);
    }
}