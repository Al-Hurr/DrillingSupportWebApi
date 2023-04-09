using DrillingSupportWebApi.Domain.DrillBlocks.Entity;

namespace DrillingSupportWebApi.Domain.DrillBlocks.Models
{
    public class DrillBlockGetModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? UpdateDate { get; set; }

        public static DrillBlockGetModel FromEntity(DrillBlock entity)
        {
            return new DrillBlockGetModel
            {
                Id = entity.Id,
                Name = entity.Name,
                UpdateDate = entity.UpdateDate
            };
        }
    }
}