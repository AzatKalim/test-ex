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

        IEncryptor encryptor;

        public HomeController(IEncryptor encryptor)
        {
            this.encryptor = encryptor;
        }
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
            if (ModelState.IsValid)
                ViewBag.Text = encryptor.Encrypt(guest.Text);
            //else
            //    // Обнаружена ошибка проверки достоверности
            //    return View();
        }
    }
}
