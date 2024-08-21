namespace test_assfinal_3.Models
{
    public class SinhVien
    {
        public Guid ID { get; set; }
        public string Ten { get; set; }
        public int Tuoi { get; set; }
        public string Nganh { get; set; }
        public LopHoc? LopHoc { get; set; }
    }
}
