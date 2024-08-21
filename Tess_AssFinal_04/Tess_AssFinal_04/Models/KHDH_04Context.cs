using Microsoft.EntityFrameworkCore;

namespace Tess_AssFinal_04.Models
{
    public class KHDH_04Context : DbContext
    {
        public KHDH_04Context(DbContextOptions options) : base(options)
        {
        }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
    }
}
