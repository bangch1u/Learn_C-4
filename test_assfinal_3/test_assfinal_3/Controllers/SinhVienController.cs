using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using test_assfinal_3.Models;

namespace test_assfinal_3.Controllers
{
    public class SinhVienController : Controller
    {
        private readonly SV_LHContext _db;
        public SinhVienController(SV_LHContext db)
        {
            _db = db;
        }
    
        public IActionResult Index()
        {
            var listSV = _db.SinhViens.ToList();
            return View(listSV);
        }
        public IActionResult Create()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult Create(SinhVien sinhVien)
        {
            sinhVien.ID = Guid.NewGuid();
            _db.SinhViens.Add(sinhVien);
            _db.SaveChanges();
            return RedirectToAction("Index");   
        }
        public IActionResult Details(Guid id)
        {
            var listSV = _db.SinhViens.FirstOrDefault(sv => sv.ID == id);
            return View(listSV);
        }
        public IActionResult Edit(Guid id)
        {
            var listSV = _db.SinhViens.FirstOrDefault(sv => sv.ID == id);
            var jsonData = JsonConvert.SerializeObject(listSV);
            HttpContext.Session.SetString("edited", jsonData);
            return View(listSV);
        }
        [HttpPost]
        public IActionResult Edit(SinhVien sinhVien)
        {
            _db.SinhViens.Update(sinhVien);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Rollback()
        {
            if (HttpContext.Session.Keys.Contains("edited"))
            {
                var jsonData = HttpContext.Session.GetString("edited");
                var editeSV = JsonConvert.DeserializeObject<SinhVien>(jsonData);
                _db.SinhViens.Update(editeSV);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (HttpContext.Session.Keys.Contains("deleted"))
            {
                var jsonData = HttpContext.Session.GetString("deleted");
                var svDeleted = JsonConvert.DeserializeObject<SinhVien>(jsonData);
                _db.SinhViens.Add(svDeleted);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return Content("Error");
            }
            
        }
        
        public IActionResult Delete(Guid id)
        {
            var svDelete = _db.SinhViens.FirstOrDefault(sv => sv.ID == id);
            var JsonData = JsonConvert.SerializeObject(svDelete);
            HttpContext.Session.SetString("deleted", JsonData);
            _db.SinhViens.Remove(svDelete);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
