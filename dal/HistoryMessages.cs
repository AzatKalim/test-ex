using System;
using System.ComponentModel.DataAnnotations;


namespace dal
{
    public class HistoryMessages
    {
        public int HistoryMessagesId { get; set; }

        public string Message { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
