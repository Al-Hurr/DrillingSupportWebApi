using DrillingSupportWebApi.Domain.DrillBlockPointss.Entity;

namespace DrillingSupportWebApi.Domain.DrillBlockPointss.Models
{
    public class DrillBlockPointsGetModel
    {
        public int Id { get; set; }

        public int? DrillBlockId { get; set; }
        public string DrillBlock { get; set; }

        public int? Sequence { get; set; }

        public double? X { get; set; }

        public double? Y { get; set; }

        public double? Z { get; set; }

        public static DrillBlockPointsGetModel FromEntity(DrillBlockPoints entity)
        {
            return new DrillBlockPointsGetModel
            {
                Id = entity.Id,
                DrillBlockId = entity.DrillBlock?.Id,
                DrillBlock = entity.DrillBlock?.Name,
                Sequence = entity.Sequence,
                X = entity.X,
                Y = entity.Y,
                Z = entity.Z
            };
        }
    }
}
