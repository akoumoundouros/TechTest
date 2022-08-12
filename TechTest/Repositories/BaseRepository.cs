using TechTest.Data;

namespace TechTest.Repositories
{
    public class BaseRepository
    {
        public DbContext context;

        public BaseRepository(DbContext db)
        {
            context = db;
        }

        public void Create<T>(T data)
        {
            var existing = context.Get<T>();
            if (existing == null)
                existing = new List<T>();
            existing.Add(data);
            context.SaveChanges(existing);
        }

        public List<T> GetAll<T>()
        {
            return context.Get<T>();
        }
    }
}
