using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin;
using Photocopier.Data;
using Photocopier.Models;

namespace Photocopier.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var repo = new ProductsRepo("~/App_Data/Copiers.xml");

            return View(repo.All());
        }
        
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Copier(int id)
        {
            var repo = new ProductsRepo("~/App_Data/Copiers.xml");
            
            return View(repo.Find(x => x.Id == id));
        }
    }
}