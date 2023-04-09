using System.ComponentModel.DataAnnotations;
using DrillingSupportWebApi.Abstractions;
using DrillingSupportWebApi.Domain.DrillBlocks.Entity;

namespace DrillingSupportWebApi.Domain.Holes.Entity
{
    /// <summary>
    /// Скважина
    /// </summary>
    public class Hole : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? DrillBlockId { get; set; }
        public DrillBlock DrillBlock { get; set; }

        public double? DEPTH { get; set; }
    }
}
