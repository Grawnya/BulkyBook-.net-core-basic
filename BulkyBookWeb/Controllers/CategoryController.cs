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
    
    #region Create Methods
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
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            // dictionary holds the state of the model binding process, including any validation errors, 
            // and is used to provide feedback to the user if there are issues with their input.
            ModelState.AddModelError("CustomError", "The DisplayOrder cannot match the name.");
            // "CustomError": This is the key for the error message, which could be any string that you choose, 
            // though it's generally good to use something descriptive.
            // "": This is an empty string as the error message, meaning no visible feedback will be provided 
            // to the user. Usually, this would be a descriptive message, such as "Please provide a valid value."
        }
        if (ModelState.IsValid)
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
    #endregion
    
    #region Edit Methods    
    // GET
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        //FirstOrDefault selected, because single will throw and error if there is none,
        //SingleOrDefault will return null if there is null but will throw an error if there is more than 1
        //FirstOrDefault will return the first one and will return null if there is no value,
        //but will need to pass an expression with a generic object

        //Find is good for primary keys like id
        var categoryFromDb = _db.Categories.Find(id);

        if (categoryFromDb == null) 
        {
            return NotFound();
        }

        return View(categoryFromDb);
    }
    
    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            // dictionary holds the state of the model binding process, including any validation errors, 
            // and is used to provide feedback to the user if there are issues with their input.
            ModelState.AddModelError("CustomError", "The DisplayOrder cannot match the name.");
            // "CustomError": This is the key for the error message, which could be any string that you choose, 
            // though it's generally good to use something descriptive.
            // "": This is an empty string as the error message, meaning no visible feedback will be provided 
            // to the user. Usually, this would be a descriptive message, such as "Please provide a valid value."
        }
        if (ModelState.IsValid)
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
    #endregion
}