using System;
using System.ComponentModel.DataAnnotations;


namespace dal
{
    //класс истории собщений 
    public class HistoryMessages
    {
        public HistoryMessages (String message)
	    {
            Message = message;
            DateAdded = DateTime.Now;
	    }
        public int HistoryMessagesId { get; set; }
        //текст
        public string Message { get; set; }
        //время добавления 
        public DateTime DateAdded { get; set; }
    }
}
