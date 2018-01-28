using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using dal;

namespace bll
{
    public class Encriptor:IEncriptor
    {
        Context context;

        public Encriptor()
        {
            Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseAlways<Context>());
            context = new Context();         
            FillReplacements();
        }
        public string Encript(string message)
        {
            var buffer = new StringBuilder();
            foreach (char symbol in message)
            {
                var temp = symbol.ToString();
                var replace = from replacement in context.Replacements
                              where replacement.oldSymbol==temp
                              select replacement.newSymbol;
                if (replace != null)
                {
                    foreach (var item in replace)
                    {
                        buffer.Append(item);
                    }
                    
                }
                else
                {
                    buffer.Append(symbol);
                }

            }

            return buffer.ToString();
        }

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
