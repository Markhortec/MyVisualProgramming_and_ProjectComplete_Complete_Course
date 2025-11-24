namespace NetWebAPI.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity dbentity, TEntity entity);
    }
}
