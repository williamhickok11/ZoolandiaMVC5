using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZoolandiaMVC.Models;
using ZoolandiaMVC5.Models;
using ZoolandiaMVC5.ViewModels;

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
            // Get access to the employees that work at the habittat that this animal live in
            var employeeList = (from a in _context.Animal
                             where a.ID == animalId

                             join h in _context.Habitat
                             on a.IdHabitat equals h.ID

                             join ht in _context.HabitatType
                             on h.IdHabitatType equals ht.ID

                             join m in _context.Maintenance
                             on h.ID equals m.IdHabitat

                             join e in _context.Employee
                             on m.IdEmployee equals e.ID
                             select new HabitatEmployeeViewModel
                             {
                                 Name = e.Name,
                                 Salary = e.Salary,
                                 Age = e.Age
                             }).ToList();

            //Get all the details about this animal, add the list of employees as well
            var animalDetails = (from a in _context.Animal
                                 where a.ID == animalId

                                 join s in _context.Species
                                 on a.IdSpecies equals s.ID

                                 join g in _context.Genus
                                 on s.IdGenus equals g.ID

                                 join h in _context.Habitat
                                 on a.IdHabitat equals h.ID

                                 join ht in _context.HabitatType
                                 on h.IdHabitatType equals ht.ID

                                 select new AnimalViewModel
                                 {
                                     Name = a.Name,
                                     Species = s.CommonName,
                                     Genus = g.CommonName,
                                     Habitat = h.Name,
                                     HabitatType = ht.Name,
                                     //Employees = employeeList
                                 }).FirstOrDefault();

            return View(animalDetails);
        }
        
    }
}