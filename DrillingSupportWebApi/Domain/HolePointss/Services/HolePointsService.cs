using DrillingSupportWebApi.Abstractions;
using DrillingSupportWebApi.Domain.HolePointss.Entity;
using DrillingSupportWebApi.Domain.HolePointss.Models;
using Microsoft.EntityFrameworkCore;

namespace DrillingSupportWebApi.Domain.HolePointsss.Services
{
    public class HolePointsService
    {
        private readonly IDataStore _dataStore;

        public HolePointsService(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public HolePointsGetModel Get(int id)
        {
            var entity = _dataStore.GetAll<HolePoints>()
                .Include(x => x.Hole)
                .FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            return HolePointsGetModel.FromEntity(entity);
        }

        public HolePointsGetModel Update(int id, HolePointsEditModel HolePointsPointsEditModel)
        {
            var entity = _dataStore.GetAll<HolePoints>()
                .Include(x => x.Hole)
                .FirstOrDefault(x => x.Id == id);

            if (entity == null || HolePointsPointsEditModel == null)
            {
                return null;
            }

            HolePointsPointsEditModel.ApplyToEntity(entity, _dataStore);

            _dataStore.SaveChanges();

            return HolePointsGetModel.FromEntity(entity);
        }

        public HolePointsGetModel Create(HolePointsEditModel HolePointsPointsEditModel)
        {
            var entity = new HolePoints();

            HolePointsPointsEditModel.ApplyToEntity(entity, _dataStore);

            _dataStore.Create(entity);

            return HolePointsGetModel.FromEntity(entity);
        }

        public bool TryRemove(int id)
        {
            var entity = _dataStore.GetAll<HolePoints>()
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
