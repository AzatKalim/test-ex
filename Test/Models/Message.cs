using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Message
    {
        [Required(ErrorMessage = "Пожалуйста, введите сообщение")]
        public string Text {get;set;}
    }
}