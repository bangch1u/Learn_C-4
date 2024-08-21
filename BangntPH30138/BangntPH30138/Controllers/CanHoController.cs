using BangntPH30138.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BangntPH30138.Controllers
{
    public class CanHoController : Controller
    {
        private readonly bangntph30138Context _db;
        public CanHoController(bangntph30138Context db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var listCH = _db.CanHos.ToList();
            return View(listCH);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CanHo canHo)
        {
            _db.CanHos.Add(canHo);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(string id)
        {
            var canHo = _db.CanHos.Find(id);
            return View(canHo); 
        }
        public IActionResult Delete(string id)
        {
            var CHDelete = _db.CanHos.FirstOrDefault(ch => ch.ID == id);
            var jsonData = JsonConvert.SerializeObject(CHDelete);
            HttpContext.Session.SetString("deleted", jsonData);
            _db.CanHos.Remove(CHDelete);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Rollback()
        {
            if (HttpContext.Session.Keys.Contains("deleted"))
            {
                var jsonData = HttpContext.Session.GetString("deleted");
                var CHDelete = JsonConvert.DeserializeObject<CanHo>(jsonData);
                _db.CanHos.Add(CHDelete);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return Content("Error");
            }
        }
        public IActionResult Edit(string id)
        {
            var chEdit = _db.CanHos.FirstOrDefault(ch => ch.ID == id);
            return View(chEdit);
        }
        [HttpPost]
        public IActionResult Edit(CanHo canHo)
        {
            _db.CanHos.Update(canHo);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
