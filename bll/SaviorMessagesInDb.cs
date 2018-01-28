using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using dal;

namespace bll
{
    /// <summary>
    /// класс сохраняющий сообщения в бд
    /// </summary>
    class SaviorMessagesInDb: ISavior
    {
        //место хранения 
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
