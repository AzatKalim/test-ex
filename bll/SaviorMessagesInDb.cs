using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using dal;

namespace bll
{
    class SaviorMessagesInDb: ISavior
    {
        DbSet<HistoryMessages> messagesContext;
        public SaviorMessagesInDb ( DbSet<HistoryMessages> messagesContext)
	    {
            this.messagesContext=messagesContext;       
	    }
        public void SaveMessage(string text)
        {
            var message = new HistoryMessages(text);
            messagesContext.Add(message);
        }
    }
}
