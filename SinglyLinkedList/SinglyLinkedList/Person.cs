using System;
using System.Collections.Generic;

namespace SinglyLinkedList
{
    public class Person
    {
        private string name;
        private int id;
        private string profession;

        private static HashSet<int> usedIds = new HashSet<int>();

        public Person(string name, int id, string profession)
        {
            if (usedIds.Contains(id))
            {
                throw new ArgumentException("ID är redan taget.");
            }

            this.name = name;
            this.id = id;
            this.profession = profession;
            usedIds.Add(id);
        }

        public void ReleaseId()
        {
            usedIds.Remove(this.id);
        }

        public string GetName() => name;
        public int GetId() => id;
        public string GetProfession() => profession;
    }
}
