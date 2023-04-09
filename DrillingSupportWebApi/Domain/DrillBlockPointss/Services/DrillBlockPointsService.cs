using DrillingSupportWebApi.Abstractions;
using DrillingSupportWebApi.Domain.DrillBlockPointss.Entity;
using DrillingSupportWebApi.Domain.DrillBlockPointss.Models;
using Microsoft.EntityFrameworkCore;

namespace DrillingSupportWebApi.Domain.DrillBlockPointsPointss.Services
{
    public class DrillBlockPointsService
    {
        private readonly IDataStore _dataStore;

        public DrillBlockPointsService(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public DrillBlockPointsGetModel Get(int id)
        {
            var entity = _dataStore.GetAll<DrillBlockPoints>()
                .Include(x => x.DrillBlock)
                .FirstOrDefault(x => x.Id == id);

            if(entity == null)
            {
                return null;
            }

            return DrillBlockPointsGetModel.FromEntity(entity);
        }

        public DrillBlockPointsGetModel Update(int id, DrillBlockPointsEditModel DrillBlockPointsEditModel)
        {
            var entity = _dataStore.GetAll<DrillBlockPoints>()
                .Include(x => x.DrillBlock)
                .FirstOrDefault(x => x.Id == id);

            if (entity == null || DrillBlockPointsEditModel == null)
            {
                return null;
            }

            DrillBlockPointsEditModel.ApplyToEntity(entity, _dataStore);

            _dataStore.SaveChanges();

            return DrillBlockPointsGetModel.FromEntity(entity);
        }

        public DrillBlockPointsGetModel Create(DrillBlockPointsEditModel DrillBlockPointsEditModel)
        {
            var entity = new DrillBlockPoints();

            DrillBlockPointsEditModel.ApplyToEntity(entity, _dataStore);

            _dataStore.Create(entity);

            return DrillBlockPointsGetModel.FromEntity(entity);
        }

        public bool TryRemove(int id)
        {
            var entity = _dataStore.GetAll<DrillBlockPoints>()
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