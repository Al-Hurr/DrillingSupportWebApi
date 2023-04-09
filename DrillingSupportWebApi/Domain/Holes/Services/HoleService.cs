using DrillingSupportWebApi.Abstractions;
using DrillingSupportWebApi.Domain.Holes.Entity;
using DrillingSupportWebApi.Domain.Holes.Models;
using Microsoft.EntityFrameworkCore;

namespace DrillingSupportWebApi.Domain.Holes.Services
{
    public class HoleService
    {
        private readonly IDataStore _dataStore;

        public HoleService(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public HoleGetModel Get(int id)
        {
            var entity = _dataStore.GetAll<Hole>()
                .Include(x => x.DrillBlock)
                .FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            return HoleGetModel.FromEntity(entity);
        }

        public HoleGetModel Update(int id, HoleEditModel HolePointsEditModel)
        {
            var entity = _dataStore.GetAll<Hole>()
                .Include(x => x.DrillBlock)
                .FirstOrDefault(x => x.Id == id);

            if (entity == null || HolePointsEditModel == null)
            {
                return null;
            }

            HolePointsEditModel.ApplyToEntity(entity, _dataStore);

            _dataStore.SaveChanges();

            return HoleGetModel.FromEntity(entity);
        }

        public HoleGetModel Create(HoleEditModel HolePointsEditModel)
        {
            var entity = new Hole();

            HolePointsEditModel.ApplyToEntity(entity, _dataStore);

            _dataStore.Create(entity);

            return HoleGetModel.FromEntity(entity);
        }

        public bool TryRemove(int id)
        {
            var entity = _dataStore.GetAll<Hole>()
                .FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return false;
            }

            _dataStore.Delete(entity);

            return true;
        }
    }
}
