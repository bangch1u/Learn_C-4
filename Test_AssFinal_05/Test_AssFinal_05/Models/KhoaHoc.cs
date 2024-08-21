using System.ComponentModel.DataAnnotations;

namespace Test_AssFinal_05.Models
{
    public class KhoaHoc
    {
        [Key]
        public string  MaKhoaHoc { get; set; }
        public string  TenKhoaHoc { get; set; }
        public int  NamHoc { get; set; }
        public List<HocVien>? HocViens { get; set; }
    }
}
