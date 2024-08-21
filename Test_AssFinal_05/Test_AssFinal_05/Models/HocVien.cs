namespace Test_AssFinal_05.Models
{
    public class HocVien
    {
        public Guid Id { get; set; }
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public string ChuyenNganh { get; set; }
        public KhoaHoc? khoaHoc { get; set; }
    }
}
