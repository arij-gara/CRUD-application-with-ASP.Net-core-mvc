using hello.Data2;
using hello.Models;
using Microsoft.AspNetCore.Mvc;

namespace hello.Controllers;

public class CategoryController : Controller
{

    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
    _db = db;
    }
    public IActionResult Index()
    {
        IEnumerable<Category> objectCategoyList =_db.Categories;
        return View(objectCategoyList);
    }
    //GET Create
    public IActionResult Create()
    {
      
        return View();
    }
    //POST CREATE
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {
        if (obj.Name == obj.Displayorder.ToString())
        {
            ModelState.AddModelError("name", "the display order cannot exactly match the name");
        }
        if (ModelState.IsValid)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }


    //GET EDIT
    public IActionResult Edit(int? id)
    {
        if (id == 0 || id == null)
        {
            return NotFound();
        }
        var Categoryfromdb = _db.Categories.Find(id);
        if(Categoryfromdb== null)
        {
            return NotFound();

        }
        return View(Categoryfromdb);

    }
    //POST Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        if (obj.Name == obj.Displayorder.ToString())
        {
            ModelState.AddModelError("name", "the display order cannot exactly match the name");
        }
        if (ModelState.IsValid)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Category  updated successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }



//GET Delete
public IActionResult Delete(int? id)
{
    if (id == 0 || id == null)
    {
        return NotFound();
    }
    var Categoryfromdb = _db.Categories.Find(id);
    if (Categoryfromdb == null)
    {
        return NotFound();

    }
    return View(Categoryfromdb);

}
//POST  Delete
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult DeletePost(int? id)
{
    var obj = _db.Categories.Find(id);
    if(obj == null)
    {
        return NotFound();
    }
    
        _db.Categories.Remove(obj);
        _db.SaveChanges();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");
    
}
}
