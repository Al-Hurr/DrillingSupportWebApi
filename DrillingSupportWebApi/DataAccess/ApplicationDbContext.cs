using DrillingSupportWebApi.Domain.DrillBlockPointss.Entity;
using DrillingSupportWebApi.Domain.DrillBlocks.Entity;
using DrillingSupportWebApi.Domain.HolePointss.Entity;
using DrillingSupportWebApi.Domain.Holes.Entity;
using Microsoft.EntityFrameworkCore;

namespace DrillingSupportWebApi.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<DrillBlock> DrillBlocks { get; set; }
        public DbSet<DrillBlockPoints> DrillBlockPoints { get; set; }
        public DbSet<Hole> Holes { get; set; }
        public DbSet<HolePoints> HolePoints { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
