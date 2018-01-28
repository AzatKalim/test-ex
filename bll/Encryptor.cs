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
        
        ISavior savior;

        public Encryptor()
        {
            Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseAlways<Context>());
            context = new Context("dbContext2");
            savior = new SaviorMessagesInDb(context.Messages);
            FillReplacements();
        }
        /// <summary>
        /// функция шифрования сообщений
        /// </summary>
        /// <param name="message"> сообщение</param>
        /// <returns> зашифрованное сообщение</returns>
        public string Encrypt(string message)
        {
            var buffer = new StringBuilder();
            savior.SaveMessage(message);
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

    }
}
