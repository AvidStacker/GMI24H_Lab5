using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayPerformanceTest
{
    public class Person
    {
        private string name;
        private int id;
        private string profession;

        private static HashSet<int> usedIds = new HashSet<int>();

        // Skapar en ny person och säkerställer att ID är unikt.
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

        // Tar bort personens ID från listan över använda ID:n.
        public void ReleaseId()
        {
            usedIds.Remove(this.id);
        }

        // Returnerar personens namn/ID/yrke.
        public string GetName() => name;
        public int GetId() => id;
        public string GetProfession() => profession;
    }
}
