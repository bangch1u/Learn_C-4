using System.ComponentModel.DataAnnotations;

namespace BangntPH30138.Models
{
    public class CanHo
    {
        [Key]
        public string ID { get; set; }
        public string Ten { get; set; }
        public double DienTich { get; set; }
        public string So { get; set; }
        public ToaNha? ToaNha { get; set; }
    }
}
