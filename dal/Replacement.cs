using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dal
{
    // таблица замен
    public class Replacement
    {
        public int Id { get; set; }

        public string oldSymbol { get; set; }
        
        public string newSymbol { get; set; }
    }
}
