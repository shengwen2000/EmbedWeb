using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmbedWeb.Models;
using MyForm2;

namespace EmbedWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            var model = new HomeViewModel();
            model.Names = new List<string>(new[] { "1", "2", "3" });
            model.Names = Process.GetProcesses().Select(x => x.ProcessName).ToList();


            return View(model);
        }

        public IActionResult About()
        {
            Form1.AppForm.UiCtx.Post(s => {
                Form1.AppForm.HelloWorld();
            }, null);

            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public IActionResult HelloWorld()
        //{
        //    ViewData["Message"] = "HelloWorld";

        //    return View("Index");
        //}
    }
}
