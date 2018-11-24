using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CG_16_2_Cheese_MVC.Models;

namespace CG_16_2_Cheese_MVC.Controllers
{
    public class HomeController : Controller
    {
        static private List<string> Cheeses = new List<string>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.cheeses = Cheeses;
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(string name)
        {
            Cheeses.Add(name);

            return Redirect("/cheese");
        }

    }
}
