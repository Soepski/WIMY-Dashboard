using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIMY_Dashboard
{
    class WIMY
    {
        public WIMY(int wimyid, int clusterid, int onderhoudid, string locatie, int status)
        {
            this.wimyid = wimyid;
            this.clusterid = clusterid;
            this.onderhoudid = onderhoudid;
            this.locatie = locatie;
            this.status = status;
        }

        public int wimyid { get; set; }
        public int clusterid { get; set; }
        public int onderhoudid { get; set; }
        public string locatie { get; set; }
        public int status { get; set; }

    }
}
