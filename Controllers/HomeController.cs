using BowlerFun.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlerFun.Controllers
{
    public class HomeController : Controller
    {
       
        private BowlersDbContext _context { get; set; }

        public HomeController(BowlersDbContext temp)
        {
            _context = temp;
        }


        public IActionResult Index()
        {
            var balh = _context.Bowlers.ToList();
            return View(balh);
        }

      
    }
}
