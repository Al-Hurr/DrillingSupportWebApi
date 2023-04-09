using DrillingSupportWebApi.Abstractions;
using DrillingSupportWebApi.Domain.DrillBlockPointss.Entity;
using DrillingSupportWebApi.Domain.DrillBlocks.Entity;

namespace DrillingSupportWebApi.Domain.DrillBlockPointss.Models
{
    public class DrillBlockPointsEditModel
    {
        public int? DrillBlockId { get; set; }

        public int? Sequence { get; set; }

        public double? X { get; set; }

        public double? Y { get; set; }

        public double? Z { get; set; }

        public void ApplyToEntity(DrillBlockPoints entity, IDataStore dataStore)
        {
            entity.DrillBlock = dataStore.GetAll<DrillBlock>().FirstOrDefault(x => x.Id == DrillBlockId);
            entity.DrillBlockId = DrillBlockId;
            entity.Sequence = Sequence;
            entity.X = X;
            entity.Y = Y;
            entity.Z = Z;
        }
    }
}