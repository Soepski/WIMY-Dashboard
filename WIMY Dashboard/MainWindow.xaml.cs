using System;
using System.Collections.Generic;
using System.Data;
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

namespace WIMY_Dashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database db = new Database();
        SerialPort serial = new SerialPort("COM3", 9600);
        List<WIMY> wimylijst = new List<WIMY>();
        public MainWindow()
        {
            InitializeComponent();
            serial.Open();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Connect();

            DataTable result = db.ExecuteStringQuery("SELECT * FROM wimy");

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

            db.Disconnect();
        }

        private void btStatusChange_Click(object sender, RoutedEventArgs e)
        {
            if (lvStatus.SelectedItem != null)
            {
                int Index = lvStatus.SelectedIndex;
                string Status = lvStatus.SelectedItem.ToString();

                if (cbStatus.Text == "Actief")
                {
                    Status = Status.Replace("Inactief", "Actief");
                }
                else
                {
                    Status = Status.Replace("Actief", "Inactief");
                }

                lvStatus.Items.RemoveAt(Index);
                lvStatus.Items.Insert(Index, Status);
            }
        }
    }
}
