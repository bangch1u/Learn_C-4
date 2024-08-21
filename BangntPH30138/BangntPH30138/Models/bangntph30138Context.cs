using Microsoft.EntityFrameworkCore;

namespace BangntPH30138.Models
{
    public class bangntph30138Context : DbContext
    {
        public bangntph30138Context(DbContextOptions options) : base(options)
        {
        }
        public DbSet<CanHo> CanHos { get; set; }
        public DbSet<ToaNha> ToaNhas { get; set; }
    }
}
