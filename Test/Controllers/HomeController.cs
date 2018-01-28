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
        IEncryptor encryptor;

        public HomeController()
            : this(new Encryptor())
        {
        }
        public HomeController(IEncryptor encryptor)
        {
            this.encryptor = encryptor;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult EncryptForm()
        {
            return View();
        }

        // выполнение ajax 
        public ActionResult EncryptedMessage(string text)
        {
            var encryptedText = "";
            if (ModelState.IsValid)
            {
                encryptedText = encryptor.Encrypt(text);
                return PartialView(new Message(encryptedText));
            }
            else
                return PartialView();
        }
    }
}
