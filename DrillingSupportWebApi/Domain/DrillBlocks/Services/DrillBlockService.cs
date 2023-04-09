using DrillingSupportWebApi.Abstractions;
using DrillingSupportWebApi.Domain.DrillBlocks.Entity;
using DrillingSupportWebApi.Domain.DrillBlocks.Models;

namespace DrillingSupportWebApi.Domain.DrillBlocks.Services
{
    public class DrillBlockService
    {
        private readonly IDataStore _dataStore;

        public DrillBlockService(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public DrillBlockGetModel Get(int id)
        {
            var entity = _dataStore.GetAll<DrillBlock>()
                .FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            return DrillBlockGetModel.FromEntity(entity);
        }

        public DrillBlockGetModel Update(int id, DrillBlockEditModel DrillBlockPointsEditModel)
        {
            var entity = _dataStore.GetAll<DrillBlock>()
                .FirstOrDefault(x => x.Id == id);

            if (entity == null || DrillBlockPointsEditModel == null)
            {
                return null;
            }

            DrillBlockPointsEditModel.ApplyToEntity(entity);

            _dataStore.SaveChanges();

            return DrillBlockGetModel.FromEntity(entity);
        }

        public DrillBlockGetModel Create(DrillBlockEditModel DrillBlockPointsEditModel)
        {
            var entity = new DrillBlock();

            DrillBlockPointsEditModel.ApplyToEntity(entity);

            _dataStore.Create(entity);

            return DrillBlockGetModel.FromEntity(entity);
        }

        public bool TryRemove(int id)
        {
            var entity = _dataStore.GetAll<DrillBlock>()
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