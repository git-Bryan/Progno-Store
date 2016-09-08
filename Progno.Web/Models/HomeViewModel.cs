using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Progno.Model.Model;

namespace Progno.Web.Models
{
    public class HomeViewModel
    {
        public User User { get; set; }
        public Product Product { get; set; }
    }
}