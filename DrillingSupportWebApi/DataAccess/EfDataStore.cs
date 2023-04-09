using DrillingSupportWebApi.Abstractions;

namespace DrillingSupportWebApi.DataAccess
{
    public class EfDataStore : IDataStore
    {
        internal readonly ApplicationDbContext _dbContext;

        public EfDataStore(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        void IDataStore.Create<T>(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            SaveChanges();
        }

        void IDataStore.Delete<T>(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            SaveChanges();
        }

        T IDataStore.Get<T>(int id)
        {
            return _dbContext.Set<T>().First(x => x.Id.Equals(id));
        }

        IQueryable<T> IDataStore.GetAll<T>()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        void IDataStore.Update<T>(T entity)
        {
            _dbContext.Update(entity);
            SaveChanges();
        }
    }
}
