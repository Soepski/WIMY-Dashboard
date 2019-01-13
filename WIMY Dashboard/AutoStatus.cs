using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIMY_Dashboard
{
    class AutoStatus
    {
        Database db = new Database();
        MainWindow mainwindow = new MainWindow();
        public void AutoOpslaan()
        {
            db.Connect();

            string geselecteerdeWimy = mainwindow.lbAutoStatus.SelectedValue.ToString();

            string vantijd = mainwindow.tbAutoVan.Text;
            string tottijd = mainwindow.tbAutoTot.Text;

            db.ExecuteStringQuery($"UPDATE wimy SET VanTijd='{vantijd}', TotTijd='{tottijd}' WHERE  WIMY_ID= {geselecteerdeWimy};");

            db.Disconnect();
        }

        public void AutoStatusSelectie()
        {
            db.Connect();

            string geselecteerdeWimy = mainwindow.lbAutoStatus.SelectedValue.ToString();

            DataTable autoResult = db.ExecuteStringQuery($"SELECT VanTijd, TotTijd FROM wimy WHERE WIMY_ID = {geselecteerdeWimy}");

            foreach (DataRow row in autoResult.Rows)
            {
                mainwindow.tbAutoVan.Text = row["VanTijd"].ToString();
                mainwindow.tbAutoTot.Text = row["TotTijd"].ToString();
            }

            db.Disconnect();
        }
    }
}
