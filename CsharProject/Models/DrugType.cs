using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharProject.Models
{
    public class DrugType
    {
        public string TypeName { get; }
        public int ID { get; }
        private static int _counter=0;
        public DrugType()
        {           
            _counter++;
            ID = _counter;
        }
        public DrugType(string typeName) : this()
        {
            TypeName = typeName;         
        }
        public override string ToString()
        {
            return TypeName;
        }
    }
}
