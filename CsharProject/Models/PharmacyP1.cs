using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharProject.Models
{
     public partial class Pharmacy
    {
        public string Name { get; }
        private static int _counter = 0;
        public int ID { get; }
        private List<Drug> Drugs;
        public Pharmacy(string name)
        {
            Name = name;
            _counter++;
            ID = _counter;
            Drugs = new List<Drug>();
        }
    }
}
