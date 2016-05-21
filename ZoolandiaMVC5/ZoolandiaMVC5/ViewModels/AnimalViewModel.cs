using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZoolandiaMVC.Models;

namespace ZoolandiaMVC5.ViewModels
{
    public class AnimalViewModel
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public string Genus { get; set; }
        public string Habitat { get; set; }
        public string HabitatType { get; set; }
        public List<HabitatEmployeeViewModel> Employees { get; set; }
    }
}