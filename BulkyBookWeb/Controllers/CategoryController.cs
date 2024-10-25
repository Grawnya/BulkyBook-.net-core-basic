using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers;

public class CategoryController : Controller
{
    // will store the database context for the controller
    private readonly ApplicationDBContext _db;
    // to tell the application that we need an implementation of the ApplicationDBContext, where the connection to the context is already made
    public CategoryController(ApplicationDBContext db)
    {
        // this db will have all the implementation of the connection strings and tables that are needed to retrieve the data
        _db = db; // to populate local _db object
    }

    // Controllers always have an index action method
    public IActionResult Index()
    {
        // to retrieve categories- go to DB set, get all the categories records from the suitable table and convert them to a list
        IEnumerable<Category> objCategoryList = _db.Categories;
        return View(objCategoryList);
    }
    
    // GET
    public IActionResult Create()
    {
        return View();
    }
    
    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {
        if(ModelState.IsValid)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return null;
        }
    }
}