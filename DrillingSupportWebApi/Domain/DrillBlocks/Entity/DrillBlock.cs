using System.ComponentModel.DataAnnotations;
using DrillingSupportWebApi.Abstractions;

namespace DrillingSupportWebApi.Domain.DrillBlocks.Entity
{
    /// <summary>
    /// Блок обуривания
    /// </summary>
    public class DrillBlock : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
