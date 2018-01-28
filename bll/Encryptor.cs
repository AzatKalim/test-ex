using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using dal;

namespace bll
{
    public class Encryptor:IEncryptor
    {
        Context context;

        public Encryptor()
        {
            Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseAlways<Context>());
            context = new Context("dbContext2");         
            FillReplacements();
        }
        public string Encrypt(string message)
        {
            var buffer = new StringBuilder();
            SaveMessageInDb(message);
            foreach (char symbol in message)
            {
                var temp = symbol.ToString();
                var replace = from replacement in context.Replacements
                              where replacement.oldSymbol==temp
                              select replacement.newSymbol;
                if (replace != null)
                    foreach (var item in replace)
                    {
                        buffer.Append(item);
                    }               
                else
                    buffer.Append(symbol);
            }          
            return buffer.ToString();
        }

        /// <summary>
        ///  заполнение таблицы замен для английских букв a-z
        /// </summary>
        public void FillReplacements()
        {
            int id=0;
            for (char i = 'a'; i < 'z'; i++)
            {
                var temp = new Replacement()
                {
                    Id=id++,
                    oldSymbol = i.ToString(),
                    newSymbol = ((char)(i + 1)).ToString()
                };
                context.Replacements.Add(temp);
            }
            var lastSymbol = new Replacement()
            {
                oldSymbol = 'z'.ToString(),
                newSymbol = 'a'.ToString()
            };
            context.Replacements.Add(lastSymbol);
            context.SaveChanges();
        }

        /// <summary>
        /// Сохранение 
        /// </summary>
        /// <param name="message"></param>
        public void SaveMessageInDb(string message)
        {
            var messageToHistory = new HistoryMessages()
            {
                Message = message,
                DateAdded = DateTime.Now
            };
            context.Messages.Add(messageToHistory);
            context.SaveChanges();
        }
    }
}
