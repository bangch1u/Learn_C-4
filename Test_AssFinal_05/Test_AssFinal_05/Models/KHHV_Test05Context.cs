using Microsoft.EntityFrameworkCore;

namespace Test_AssFinal_05.Models
{
    public class KHHV_Test05Context : DbContext
    {
        public KHHV_Test05Context(DbContextOptions options) : base(options)
        {
        }
        public DbSet<HocVien> HocViens { get; set; }
        public DbSet<KhoaHoc> khoaHocs { get; set; }
    }
}
