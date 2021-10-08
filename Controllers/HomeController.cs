using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using cd_c_crudelicious.Models;

namespace cd_c_crudelicious.Controllers
{
    public class HomeController : Controller
    {
        private DishContext _context;

        public HomeController(DishContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.AllDishes = _context.Dishes.
                OrderByDescending(d => d.CreatedAt).ToList();
            
            return View();
        }


        [HttpGet("new")]
        public IActionResult NewDish()
        {
            return View("NewDish");
        }


        [HttpPost("dish/new")]
        public IActionResult AddDish(Dish dish)
        {
            if(ModelState.IsValid)
            {
                _context.Add(dish);
                _context.SaveChanges();
                return RedirectToAction("ThisDish", new { dishId = dish.DishId});
            }
            else
            {
                return View("newdish", dish);
            }
        }

        [HttpGet("{dishId}")]
        public IActionResult ThisDish(int dishId)
        {
            Dish ToDisplay = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
            if(ToDisplay == null)
            {
                return RedirectToAction("Index");
            }
            return View(ToDisplay);
        }

        [HttpGet("edit/{dishId}")]
        public IActionResult EditDish(int dishId)
        {
            Dish EditDish = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
            if(EditDish == null)
            {
                return RedirectToAction("ThisDish");
            }
            return View(EditDish);
        }

        [HttpPost("update/{dishId}")]
        public IActionResult UpdateDish(Dish newdish, int dishId)
        {
            if(ModelState.IsValid)
            {
                Dish RetrievedDish = _context.Dishes
                    .FirstOrDefault(dish => dish.DishId == dishId);
                RetrievedDish.DishName = newdish.DishName;
                RetrievedDish.ChefName = newdish.ChefName;
                RetrievedDish.Calories = newdish.Calories;
                RetrievedDish.Tastiness = newdish.Tastiness;
                RetrievedDish.Description = newdish.Description;
                RetrievedDish.UpdatedAt = DateTime.Now;

                _context.SaveChanges();

                return RedirectToAction("ThisDish");
            }
            return View("editdish", newdish);
        }

        [HttpGet("delete/{dishId}")]
        public IActionResult DeleteDish(int dishId)
        {
            Dish RetrievedDish = _context.Dishes
                .SingleOrDefault(d => d.DishId == dishId);
            _context.Dishes.Remove(RetrievedDish);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}