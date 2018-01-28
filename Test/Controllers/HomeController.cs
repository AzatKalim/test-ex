using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;
using bll;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        IEncriptor encriptor;

        public ActionResult Index()
        {
            //ViewBag.Greeting =hour.ToString();
           
            return View();
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public void  RsvpForm(Message guest)
        {
            encriptor = new Encriptor();
            if (ModelState.IsValid)
                ViewBag.Text = encriptor.Encript(guest.Text);
            //else
            //    // Обнаружена ошибка проверки достоверности
            //    return View();
        }
    }
}
