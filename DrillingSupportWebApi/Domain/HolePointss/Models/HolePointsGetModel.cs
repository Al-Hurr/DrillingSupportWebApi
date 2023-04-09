using DrillingSupportWebApi.Domain.HolePointss.Entity;

namespace DrillingSupportWebApi.Domain.HolePointss.Models
{
    public class HolePointsGetModel
    {
        public int Id { get; set; }

        public int? HoleId { get; set; }
        public string Hole { get; set; }

        public double? X { get; set; }

        public double? Y { get; set; }

        public double? Z { get; set; }

        public static HolePointsGetModel FromEntity(HolePoints entity)
        {
            return new HolePointsGetModel
            {
                Id = entity.Id,
                HoleId = entity.Hole?.Id,
                Hole = entity.Hole?.Name,
                X = entity.X,
                Y = entity.Y,
                Z = entity.Z
            };
        }
    }
}
