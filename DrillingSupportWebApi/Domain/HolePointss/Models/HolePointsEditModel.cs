using DrillingSupportWebApi.Abstractions;
using DrillingSupportWebApi.Domain.HolePointss.Entity;
using DrillingSupportWebApi.Domain.Holes.Entity;

namespace DrillingSupportWebApi.Domain.HolePointss.Models
{
    public class HolePointsEditModel
    {
        public int? HoleId { get; set; }

        public double? X { get; set; }

        public double? Y { get; set; }

        public double? Z { get; set; }

        public void ApplyToEntity(HolePoints entity, IDataStore dataStore)
        {
            entity.HoleId = HoleId;
            entity.Hole = dataStore.GetAll<Hole>().FirstOrDefault(x => x.Id == HoleId);
            entity.X = X;
            entity.Y = Y;
            entity.Z = Z;
        }
    }
}
