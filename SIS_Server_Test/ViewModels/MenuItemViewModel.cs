using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIS_Server_Test.ViewModels
{
    public class MenuItemViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Href { get; set; }
        public int MenuSize { get; set; }
        public string ImageHref { get; set; }
        public int? MenuColors { get; set; }
    }
}