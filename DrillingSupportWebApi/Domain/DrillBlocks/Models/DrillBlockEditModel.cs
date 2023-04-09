using DrillingSupportWebApi.Abstractions;
using DrillingSupportWebApi.Domain.DrillBlocks.Entity;

namespace DrillingSupportWebApi.Domain.DrillBlocks.Models
{
    public class DrillBlockEditModel
    {
        public string Name { get; set; }

        public DateTime? UpdateDate { get; set; }

        public void ApplyToEntity(DrillBlock entity)
        {
            entity.Name = Name;
            entity.UpdateDate = UpdateDate;
        }
    }
}