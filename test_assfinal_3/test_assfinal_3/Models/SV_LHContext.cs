using Microsoft.EntityFrameworkCore;

namespace test_assfinal_3.Models
{
    public class SV_LHContext : DbContext
    {
        public SV_LHContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<LopHoc> LopHocs { get; set; }
    }
}
