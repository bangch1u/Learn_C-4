using System.ComponentModel.DataAnnotations;

namespace BangntPH30138.Models
{
    public class ToaNha
    {
        [Key]
        public string ID { get; set; }
        public string DiaChi { get; set; }
        public List<CanHo>? CanHos { get; set; }
    }
}
