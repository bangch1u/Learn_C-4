using System.ComponentModel.DataAnnotations;

namespace Tess_AssFinal_04.Models
{
    public class DonHang
    {
        [Key]
        public string MaDonHang { get; set; }
        public string TenDonHang { get; set; }
        public DateTime NgayDatHang { get; set; }
        public KhachHang? KhachHang { get; set; }   
    }
}
