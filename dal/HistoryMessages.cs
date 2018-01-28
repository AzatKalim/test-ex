using System;
using System.ComponentModel.DataAnnotations;


namespace dal
{
    public class HistoryMessages
    {
        public HistoryMessages (String message)
	    {
            Message = message;
            DateAdded = DateTime.Now;
	    }
        public int HistoryMessagesId { get; set; }

        public string Message { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
