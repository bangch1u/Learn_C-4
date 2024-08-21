using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Test_AssFinal_05.Models;

namespace Test_AssFinal_05.Controllers
{
    public class HocVienController : Controller
    {
        private readonly KHHV_Test05Context _db;
        public HocVienController(KHHV_Test05Context db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var listHV = _db.HocViens.ToList();
            return View(listHV);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(HocVien hocVien)
        {
            hocVien.Id = Guid.NewGuid();
            _db.HocViens.Add(hocVien);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(Guid id)
        {
            var listHV = _db.HocViens.Find(id);
            return View(listHV);
        }
        public IActionResult Delete(Guid id)
        {
            var hvDelete = _db.HocViens.FirstOrDefault(hv => hv.Id == id);
            var jsonData = JsonConvert.SerializeObject(hvDelete);
            HttpContext.Session.SetString("deleted", jsonData);
            _db.HocViens.Remove(hvDelete);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(Guid id)
        {
            var hvEdit = _db.HocViens.FirstOrDefault(hv => hv.Id == id);
            return View(hvEdit);
        }
        [HttpPost]
        public IActionResult Edit(HocVien hocVien)
        {
            _db.HocViens.Update(hocVien);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Rollback()
        {
            if (HttpContext.Session.Keys.Contains("deleted"))
            {
                var jsonData = HttpContext.Session.GetString("deleted");
                var hvDeleted = JsonConvert.DeserializeObject<HocVien>(jsonData);
                _db.HocViens.Add(hvDeleted);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return Content("Error");
            }
        }
    }
}
