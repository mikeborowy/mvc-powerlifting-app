using PowerLiftingApp_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowerLiftingApp_2.ViewModels
{
    public class ContenderViewModel
    {
        public ContenderViewModel()
        {
            ContendersList = new List<Contender>();
        }

        public List<Contender> ContendersList { get; set; }
    }
}