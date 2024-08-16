using ContentNegotiation.Data;
using ContentNegotiation.Models.Items;
using Microsoft.AspNetCore.Mvc;

namespace ContentNegotiation.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ItemController(ApplicationDbContext db)
        {
            _db = db;
            
        }
        public IActionResult Index()
        {
            IEnumerable<Item>  objlist = _db.Items;
            return View(objlist);
        }

        // Get Create
        public IActionResult Create()
        {
            return View();
        }

        // post Craeet
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);
        }

        public IActionResult Update(int? Id)
        {
            if (Id == null)
            {
                return NoContent();
            }
            var item = _db.Items.Find(Id);
            if (item == null)
            {
                return NoContent();
            }
            return View(item);
        }


        // post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Item obj)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }


        // Get Delete
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Items.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _db.Items.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }       
             _db.Items.Remove(obj);
             _db.SaveChanges();
             return RedirectToAction("Index");
            
        }

    }
}
