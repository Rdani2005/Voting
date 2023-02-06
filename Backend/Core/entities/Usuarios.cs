using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.entities
{
    class Usuarios
    {

        //Attributes
        private int id;
        private string identification;
        private string name;
        private string lastName;
        private string secondLastName;
        private string email;
        private string pictureUrl;
        private int section;

        //Constructor method
        public Usuarios(int pid, string piden, string pname, string plastname, string pSlastname,
                        string pemail, string pUrl, int psection)
        {

            //Assign the attributes
            this.id = pid;
            this.identification = piden;
            this.name = pname;
            this.lastName = plastname;
            this.secondLastName = pSlastname;
            this.email = pemail;
            this.pictureUrl = pUrl;
            this.section = psection;
        }

        //Properties
        public int ID { get { return id; } set { id = value; } }

        public string Iden { get { return identification; } set { identification = value; } }

        public string Name { get { return name; } set { name = value; } }

        public string LastName { get { return lastName;} set { lastName = value; } }

        public string SecondLastName { get { return secondLastName;} set { secondLastName = value; } }

        public string Email { get { return email; } set { email = value; } }

        public string PictureUrl { get { return pictureUrl; } set { pictureUrl = value; } }

        public int Section { get { return section; } set { section = value; } }
    }
}
