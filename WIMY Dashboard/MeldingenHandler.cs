using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIMY_Dashboard
{
    class MeldingenHandler
    {
        Database db = new Database();
        MainWindow mainwindow = new MainWindow();
        SerialPort serial = new SerialPort("COM4", 9600);
        public void Verwerk()
        {
            if (serial.IsOpen)
            {
                string SerialMelding = serial.ReadLine().ToString();
                mainwindow.lvMeldingen.Items.Add($"{SerialMelding} {DateTime.Now.ToString()}");
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Public\LogFile.txt", true))
                {
                    file.WriteLine(SerialMelding + $" {DateTime.Now.ToString()}");
                    file.WriteLine("");
                }

                //Melding moet nog naar database
            }
            else
            {
                serial.Open();
            }
        }
    }
}
