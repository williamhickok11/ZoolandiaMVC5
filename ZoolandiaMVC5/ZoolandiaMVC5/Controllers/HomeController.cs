using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZoolandiaMVC5.Models;

namespace ZoolandiaMVC5.Controllers
{
    public class HomeController : Controller
    {
        ZoolandiaDbContext _context = new ZoolandiaDbContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: All Animals from the database
        public ActionResult ViewAnimals()
        {
            // Access the database
            var animals = (from a in _context.Animal
                           select a);

            return View(animals.ToList());
        }

        // GET: The details of each animal
        public ActionResult Details(int animalId)
        {


            return View();
        }
        
    }
}