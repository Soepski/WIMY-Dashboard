using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIMY_Dashboard
{
    class Gebruiker
    {
        public int ID { get; set; }
        public int Cluster_ID { get; set; }
        public string Naam { get; set; }
        public string Adres { get; set; }
        public string Woonplaats { get; set; }
        public string GebruikersNaam { get; set; }
        public string Wachtwoord { get; set; }
    }
}
