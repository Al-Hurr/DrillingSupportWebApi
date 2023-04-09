using DrillingSupportWebApi.Abstractions;
using DrillingSupportWebApi.Domain.DrillBlocks.Entity;
using DrillingSupportWebApi.Domain.Holes.Entity;
using System.ComponentModel.DataAnnotations;

namespace DrillingSupportWebApi.Domain.Holes.Models
{
    public class HoleEditModel
    {
        public string Name { get; set; }

        public int? DrillBlockId { get; set; }

        public double? DEPTH { get; set; }

        public void ApplyToEntity(Hole entity, IDataStore dataStore)
        {
            entity.Name = Name;
            entity.DrillBlockId = DrillBlockId;
            entity.DrillBlock = dataStore.GetAll<DrillBlock>().FirstOrDefault(x => x.Id == DrillBlockId);
            entity.DEPTH = DEPTH;
        }
    }
}
