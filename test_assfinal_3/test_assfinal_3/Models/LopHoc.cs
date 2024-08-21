using System.ComponentModel.DataAnnotations;

namespace test_assfinal_3.Models
{
    public class LopHoc
    {
        [Key]
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public int Khoa { get; set; }
        public List<SinhVien>? SinhViens { get; set; }
    }
}
