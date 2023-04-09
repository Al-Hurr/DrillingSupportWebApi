using System.Security.Principal;

namespace DrillingSupportWebApi.Abstractions
{
    public interface IDataStore
    {
        T Get<T>(int id) where T : class, IBaseEntity;

        void Update<T>(T entity) where T : class, IBaseEntity;

        void Delete<T>(T entity) where T : class, IBaseEntity;

        void Create<T>(T entity) where T : class, IBaseEntity;

        IQueryable<T> GetAll<T>() where T : class, IBaseEntity;

        void SaveChanges();
    }
}
