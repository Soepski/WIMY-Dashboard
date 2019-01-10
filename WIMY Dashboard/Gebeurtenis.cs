﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIMY_Dashboard
{
    class Gebeurtenis
    {
        public int ID { get; set; }
        public int WIMY_ID { get; set; }
        public DateTime Date { get; set; }

        public Gebeurtenis(int id, int wimy_id, DateTime date)
        {
            ID = id;
            WIMY_ID = wimy_id;
            Date = date;
        }
    }
}
