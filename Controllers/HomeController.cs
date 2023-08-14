using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDicious.Models;

namespace CRUDicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    // Add a private variable of type MyContext (or whatever you named your context file)
    private MyContext _context;
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        // When our HomeController is instantiated, it will fill in _context with context
        // Remember that when context is initialized, it brings in everything we need from DbContext
        // which comes from Entity Framework Core
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        List<Dish> AllDishes = _context.Dishes.OrderByDescending(d => d.CreatedAt).ToList();
        return View("Index", AllDishes);
    }

    [HttpGet("Dishes/New")]
    public IActionResult DisplayNewDish()
    {
        return View("New"); //<--- HTML page to see our new, displayed dish
    }

    [HttpPost("Dishes/Create")]
    public IActionResult Create(Dish newDish)
    {
        if (ModelState.IsValid) //<--- validation 
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            // call the method to render the new page
            return DisplayNewDish();
        }
    }

    [HttpGet("Dishes/{id}")]
    public IActionResult Read(int id)
    {
        Dish? OneDish = _context.Dishes.FirstOrDefault(d => d.DishID == id);
        return View("Read", OneDish);
    }


    [HttpGet("Dishes/{id}/edit")]
    public IActionResult Edit(int id)
    {
        Dish? DishToEdit = _context.Dishes.FirstOrDefault(i => i.DishID == id);
        return View("Edit", DishToEdit);
    }

    [HttpPost("Dishes/{id}/update")]
    public IActionResult Update(Dish newDish, int id)
    {
        Dish? OldDish = _context.Dishes.FirstOrDefault(i => i.DishID == id);
        if (ModelState.IsValid)
        {
            OldDish.Name = newDish.Name;
            OldDish.Chef = newDish.Chef;
            OldDish.Tastiness = newDish.Tastiness;
            OldDish.Calories = newDish.Calories;
            OldDish.Description = newDish.Description;
            OldDish.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("Edit", OldDish);
        }
    }

    [HttpPost("Dishes/{id}/Destroy")]
    public IActionResult Destroy(int id)
    {
        Dish? DishToDelete = _context.Dishes.SingleOrDefault(i => i.DishID == id);
        _context.Dishes.Remove(DishToDelete);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
