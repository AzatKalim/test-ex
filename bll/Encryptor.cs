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
        //контекст для работы с бд
        Context context;
        // класс, сохраняющий сообщения в бд
        ISavior savior;

        public Encryptor()
        {
            Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseAlways<Context>());
            context = new Context("dbContext");
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
            //буффер результата
            var buffer = new StringBuilder();
            //сохраняем сообщение
            savior.SaveMessage(message);
            foreach (char symbol in message)
            {
                // linq отказывается работать с char
                var symbolToString = symbol.ToString();
                //linq запрос 
                var replace = from replacement in context.Replacements
                              where replacement.oldSymbol == symbolToString
                              select replacement.newSymbol;
                string newSymbol = null;
                try
                {
                    newSymbol = replace.First();
                }
                catch (System.ArgumentNullException)
                {
                    newSymbol = symbolToString;
                }
                finally
                {
                    buffer.Append(newSymbol);
                }               
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
