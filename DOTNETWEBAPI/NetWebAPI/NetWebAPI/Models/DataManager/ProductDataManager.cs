using NetWebAPI.Models.Entities;
using NetWebAPI.Repository;

namespace NetWebAPI.Models.DataManager
{
    public class ProductDataManager : IDataRepository<Product>
    {
        private readonly ApplicationDbContext Db;
        public ProductDataManager(ApplicationDbContext applicationDbContext)
        {
                this.Db = applicationDbContext;
        }
        public void Add(Product entity)
        {

            Db.Products.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(Product entity)
        {
            Db.Products.Remove(entity);
            Db.SaveChanges();
        }

        public Product Get(int id)
        {
            return Db.Products.SingleOrDefault(product => product.ID == id);

        }

        public IEnumerable<Product> GetAll()
        {
            return Db.Products.ToList();
        }

        public void Update(Product dbEntity,Product entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.Description = entity.Description;
            dbEntity.Price = entity.Price;
            Db.SaveChanges();
        }

  
    }
}
