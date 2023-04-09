using System.ComponentModel.DataAnnotations;
using DrillingSupportWebApi.Abstractions;
using DrillingSupportWebApi.Domain.DrillBlocks.Entity;

namespace DrillingSupportWebApi.Domain.DrillBlockPointss.Entity
{
    /// <summary>
    /// Точки блока
    /// </summary>
    public class DrillBlockPoints : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        public int? DrillBlockId { get; set; }
        public DrillBlock DrillBlock { get; set; }

        // не понял, как использовать это поле
        public int? Sequence { get; set; }

        public double? X { get; set; }

        public double? Y { get; set; }

        public double? Z { get; set; }
    }
}