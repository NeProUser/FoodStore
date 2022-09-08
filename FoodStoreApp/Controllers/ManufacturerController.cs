using FoodStoreApp.Data;
using FoodStoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodStoreApp.Controllers
{
    public class ManufacturerController : Controller
    {
        // Переменная контекста для доступа к базе данных
        private readonly ApplicationDbContext _db;

        // Внедряем зависимость ApplicationDbContext через конструктор
        public ManufacturerController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            // Создаем список записей категорий из базы данных
            IEnumerable<Manufacturer> ManufacturerList = _db.Manufacturer;

            return View(ManufacturerList);
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category cat)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(cat);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cat);

        }


        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cat = _db.Manufacturer.Find(id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Manufacturer cat)
        {
            if (ModelState.IsValid)
            {
                _db.Manufacturer.Update(cat);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cat);

        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cat = _db.Manufacturer.Find(id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var cat = _db.Manufacturer.Find(id);
            if (cat == null)
            {
                return NotFound();
            }
            _db.Manufacturer.Remove(cat);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
