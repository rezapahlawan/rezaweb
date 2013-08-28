using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RezaWeb.Mvc.Models;

namespace RezaWeb.Mvc.ViewModels
{
    public class ExamNumberVm
    {
        public UserProfile UserProfile { get; set; }
        public RegistrantInfo RegistrantInfo { get; set; }
    }
}