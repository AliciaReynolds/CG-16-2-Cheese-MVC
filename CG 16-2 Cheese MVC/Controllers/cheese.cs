using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cheesemvc.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cheesemvc.Controllers
{
    public class cheese : Controller
    {
        static private List<Cheese> Cheeses = new List<Cheese>();

        
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
        public IActionResult NewCheese(string name, string description = "")
         {
            Cheese newCheese = new Cheese
            {
                Description = description,
                Name = name
            };

            Cheeses.Add(newCheese);
            return Redirect("/Cheese");
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheeses";
            ViewBag.cheeses = Cheeses;
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            foreach (int cheeseId in cheeseIds)
            {
                Cheeses.RemoveAll(x => x.CheeseId == cheeseId);
             }
            return Redirect("/");
        }
    }
}
