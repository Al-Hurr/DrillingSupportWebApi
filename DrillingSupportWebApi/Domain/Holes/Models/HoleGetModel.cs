using DrillingSupportWebApi.Domain.Holes.Entity;

namespace DrillingSupportWebApi.Domain.Holes.Models
{
    public class HoleGetModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? DrillBlockId { get; set; }
        public string DrillBlock { get; set; }

        public double? DEPTH { get; set; }

        public static HoleGetModel FromEntity(Hole entity)
        {
            return new HoleGetModel
            {
                Id = entity.Id,
                Name = entity.Name,
                DrillBlockId = entity.DrillBlock?.Id,
                DrillBlock = entity.DrillBlock?.Name,
                DEPTH = entity.DEPTH
            };
        }
    }
}
