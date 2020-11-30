using System.Collections.Generic;
using System.Linq;

namespace Stein_Papier_Schere.Models
{
    public class Raw
    {
        public Raw(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public bool checkIfWinsAgainst(Raw opponent)
        {
            return winsAgainst.Any(raw => raw.id == opponent.id); //Return true/false mit LinQ, ob in der Liste winsAgainst der opponent drin steht
        }
        public string name { get; set; }
        public int id { get; set; }
        public List<Raw> winsAgainst { get; set; }
    }
}
