using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharProject.Models
{

    public class Drug
    {     
        public string Name { get; }
        public DrugType Type { get; }
        public double Price { get; }
        public string Description { get; }
        public int Count { get; set; }
        public DateTime Expiredate { get; }
        private static int _counter = 0;
        public int ID { get; }
        public Drug()
        {
            _counter++;
            ID = _counter;
        }
        public Drug(DrugType type, string name, string description, int count, double price, DateTime expiredate) : this()
        {
            Type = type;
            Name = name;            
            Description = description;
            Count = count;
            Price = price;
            Expiredate = expiredate;
        }
        public override string ToString()
        {
            return $" ID-{ID} - Name-{Name} - Price-{Price} AZN - #{Count}";
        }

        
    }
}