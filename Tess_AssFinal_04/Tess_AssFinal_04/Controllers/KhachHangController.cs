using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tess_AssFinal_04.Models;

namespace Tess_AssFinal_04.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly KHDH_04Context _db;
        public KhachHangController(KHDH_04Context db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var listKH = _db.KhachHangs.ToList();
            return View(listKH);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(KhachHang khachHang)
        {
            khachHang.ID = Guid.NewGuid();
            _db.KhachHangs.Add(khachHang);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(Guid id)
        {
            var kh = _db.KhachHangs.Find(id);
            return View(kh);    
        }
        public IActionResult Edit(Guid id)
        {
            var kh = _db.KhachHangs.Find(id);
            var jsonData = JsonConvert.SerializeObject(kh);
            HttpContext.Session.SetString("edited", jsonData);
            return View(kh);

        }
        [HttpPost]
        public IActionResult Edit(KhachHang khachHang)
        {
            _db.KhachHangs.Update(khachHang);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Rollback()
        {
            if (HttpContext.Session.Keys.Contains("edited"))
            {
                var jsonData = HttpContext.Session.GetString("edited");
                var khUpdate = JsonConvert.DeserializeObject<KhachHang>(jsonData);
                _db.KhachHangs.Update(khUpdate);
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
