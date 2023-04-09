using System.ComponentModel.DataAnnotations;
using DrillingSupportWebApi.Abstractions;
using DrillingSupportWebApi.Domain.Holes.Entity;

namespace DrillingSupportWebApi.Domain.HolePointss.Entity
{
    public class HolePoints : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        public int? HoleId { get; set; }
        public Hole Hole { get; set; }

        public double? X { get; set; }

        public double? Y { get; set; }

        public double? Z { get; set; }
    }
}