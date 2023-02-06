using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.entities
{
    class Secciones {

        //Attributes
        private int id;
        private string name;
        private string description;
        private int idGen;

        //Constructor method
        public Secciones(int pid, string pname, string pdesc, int pidgen)
        {

            //Assign the attributes
            this.id = pid;
            this.name = pname;
            this.description = pdesc;
            this.idGen = pidgen;
        }

        //Properties
        public int ID { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Desc { get { return description; } set { name = description; } }
        public int IDGen { get { return idGen; } set { idGen = value; } }
    }
}
