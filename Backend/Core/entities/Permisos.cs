using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.entities
{
    class Permisos {

        //Attributes
        private int id;
        private string name;
        private string description;

        //Constructor method
        public Permisos(int pid, string pname, string pdesc) { 
        
            //Assign the attributes
            this.id = pid;
            this.name = pname;
            this.description = pdesc;
        }

        //Properties
        public int ID { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Desc { get { return description; } set { name = description; } }
    }
}
