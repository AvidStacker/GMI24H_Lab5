using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    internal class Person
    {
        private string name;
        private int id;
        private string profession;

        public Person(string name, int id, string profession)
        {
            this.name = name;
            this.id = id;
            this.profession = profession;
        }

        public string GetName() { return name; }

        public void SetName(string name) { this.name = name; }

        public int GetId() { return id; }

        public void SetId(int id) { this.id = id; }

        public string GetProfession() { return profession; }

        public void SetProfession(string profession) { this.profession = profession; }
    }
}
