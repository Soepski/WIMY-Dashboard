using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WIMY_Dashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database db = new Database();
        AutoStatus autostatus = new AutoStatus();
        MeldingenHandler melding = new MeldingenHandler();
        Status status = new Status();
        SerialPort serial = new SerialPort("COM4", 9600);
        List<WIMY> wimylijst = new List<WIMY>();
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                serial.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

                serial.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Arduino niet goed aangesloten");
                Debug.WriteLine(ex);
            }


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

                db.Connect();

                DataTable result = db.ExecuteStringQuery("SELECT * FROM wimy");

            foreach (DataRow row in statusresult.Rows)
            {
                lvStatus.Items.Add($"WIMY { row["WIMY_ID"]}: { row["STATUS"]}");
            }

            foreach (WIMY wimy in wimylijst)
            {
                lbAutoStatus.Items.Add(wimy.wimyid);
            }

            db.Disconnect();
        }
                foreach (DataRow item in result.Rows)
                {
                    DataRow dr = item;

                    WIMY wimy = new WIMY(

                    int.Parse(dr["WIMY_ID"].ToString()),
                    int.Parse(dr["ClusterID"].ToString()),
                    int.Parse(dr["OnderhoudID"].ToString()),
                    dr["Locatie"].ToString(),
                    int.Parse(dr["Status"].ToString())
                );
                    wimylijst.Add(wimy);
                }

                DataTable statusresult = db.ExecuteStringQuery("SELECT wimy.WIMY_ID, CASE WHEN wimy.status = 1 THEN 'Actief' ELSE 'Inactief' END AS STATUS FROM wimy");

                foreach (DataRow row in statusresult.Rows)
                {
                    lvStatus.Items.Add($"WIMY { row["WIMY_ID"]}: { row["STATUS"]}");
                }


                foreach (WIMY wimy in wimylijst)
                {
                    lbAutoStatus.Items.Add(wimy.wimyid);
                }

                db.Disconnect();
            
        }

        private void btStatusChange_Click(object sender, RoutedEventArgs e)
        {
            status.Change();
        }


        private void btnAutoOpslaan_Click(object sender, RoutedEventArgs e)
        {

            autostatus.AutoOpslaan();

        }

        private void lvAutoStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            autostatus.AutoStatusSelectie();

        }

        public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                if (serial.IsOpen)
                {
                    string SerialMelding = serial.ReadLine().ToString();
                    lvMeldingen.Items.Add($"{SerialMelding} {DateTime.Now.ToString()}");
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Public\LogFile.txt", true))
                    {
                        file.WriteLine(SerialMelding + $" {DateTime.Now.ToString()}");
                        file.WriteLine("");
                    }
                }
                else
                {
                    serial.Open();
                }
                
            });
            
        }
    }
}
