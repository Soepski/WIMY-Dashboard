using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIMY_Dashboard
{
    class Status
    {
        Database db = new Database();
        MainWindow mainwindow = new MainWindow();
        SerialPort serial = new SerialPort("COM4", 9600);

        public void Change()
        {

            if (mainwindow.lvStatus.SelectedItem != null)
            {
                int Index = mainwindow.lvStatus.SelectedIndex;
                string Status = mainwindow.lvStatus.SelectedItem.ToString();

                if (mainwindow.cbStatus.Text == "Actief")
                {
                    Status = Status.Replace("Inactief", "Actief");
                    serial.WriteLine("A");

                }
                else
                {
                    Status = Status.Replace("Actief", "Inactief");
                    serial.WriteLine("U");
                }

                mainwindow.lvStatus.Items.RemoveAt(Index);
                mainwindow.lvStatus.Items.Insert(Index, Status);


                db.Connect();

                List<int> IDList = new List<int>();
                List<int> StatusList = new List<int>();
                int lvStatusCount = mainwindow.lvStatus.Items.Count;
                for (int count = 0; count < lvStatusCount; count++)
                {
                    string wimyinfo = Convert.ToString(mainwindow.lvStatus.Items[count]);
                    string wimyinfoID = wimyinfo.Remove(0, 5);
                    int wimyID = Convert.ToInt32(wimyinfoID.Remove(1, wimyinfoID.Length - 1));
                    string wimyinfoStatus = wimyinfo.Remove(0, 8);
                    int wimyStatus = 0;
                    if (wimyinfoStatus == "Actief")
                    {
                        wimyStatus = 1;
                    }
                    IDList.Add(wimyID);
                    StatusList.Add(wimyStatus);
                }
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Public\StatusLog.txt", true))
                {
                    file.WriteLine($"You have edited the states of the WIMY's on {System.DateTime.Now}");
                    foreach (int ID in IDList)
                    {
                        db.ExecuteStringQuery($"UPDATE wimy SET status = {StatusList[IDList.IndexOf(ID)]} WHERE WIMY_ID = {IDList[IDList.IndexOf(ID)]}");
                        file.WriteLine($"The status of WIMY {ID} was set to {LogStatusWrite(StatusList[IDList.IndexOf(ID)])}");
                    }
                    file.WriteLine("");
                }

                db.Disconnect();

            }
        }

        public string LogStatusWrite(int state)
        {
            if (state == 1) { return "Actief"; }
            else { return "Inactief"; }
        }
    }
}
