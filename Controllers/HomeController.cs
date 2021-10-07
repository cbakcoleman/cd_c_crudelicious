using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;

namespace cd_c_crudelicious
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
            List<Dish> AllDishes = _context.Dishes.ToList();

            return View();
        }
    }
}