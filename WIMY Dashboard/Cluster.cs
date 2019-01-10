using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIMY_Dashboard
{
    class Cluster
    {
        public int ID { get; set; }
        public int WIMY_ID { get; set; }
        public int Gebruiker_ID { get; set; }

        public Cluster(int id, int wimy_id, int gebruiker_id)
        {
            ID = id;
            WIMY_ID = wimy_id;
            Gebruiker_ID = gebruiker_id;
        }
    }
}
