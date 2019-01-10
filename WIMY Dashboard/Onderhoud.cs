using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIMY_Dashboard
{
    class Onderhoud
    {
        public int ID { get; set; }
        public int WIMY_ID { get; set; }
        public int Monteur_ID { get; set; }
        public DateTime Date { get; set; }

        public Onderhoud(int id, int wimy_id, int monteur_id, DateTime date)
        {
            ID = id;
            WIMY_ID = wimy_id;
            Monteur_ID = monteur_id;
            Date = date;
        }
    }
}
