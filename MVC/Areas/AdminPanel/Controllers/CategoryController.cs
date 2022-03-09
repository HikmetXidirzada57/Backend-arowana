using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;

namespace MVC.Areas.AdminPanel.Controllers
{

    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        private readonly CategoryManager _categoryManager;

        public CategoryController(CategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public IActionResult Create()
        {
            return View();
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CategoryName","IsDeleted","CategoryIcon")]Categories category)
        {
            if (ModelState.IsValid)
            {
                _categoryManager.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        public IActionResult Index()
        {
            return View(_categoryManager.GetAll());
        }
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var category = _categoryManager.GetById(id);
            if(category == null) return NotFound();
            return View(category);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var categoriEdit=_categoryManager.GetById(id);
            if(categoriEdit == null) return NotFound();
            return View(categoriEdit);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id,Categories category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _categoryManager.Update(category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_categoryManager.CategorytExists(category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                 
                }
                return RedirectToAction(nameof(Index));
            }
          
          return View(category);
        }
        public IActionResult Delete(int? id)
        {
            if(id == null) return NotFound();   
            var deletedCat= _categoryManager.GetById(id);
            if(deletedCat == null) return NotFound();
            return View();
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var deletedCat = _categoryManager.GetById(id);
            _categoryManager.Delete(deletedCat);
            return RedirectToAction(nameof(Index));
        }
    }
}
