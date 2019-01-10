using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIMY_Dashboard
{
    class Monteur
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public string Adres { get; set; }
        public string Woonplaats { get; set; }
        public bool Spoedonderhoud { get; set; }

        public Monteur(int id, string naam, string adres, string woonplaats, bool spoed)
        {
            ID = id;
            Naam = naam;
            Adres = adres;
            Woonplaats = woonplaats;
            Spoedonderhoud = spoed;
        }
    }
}
