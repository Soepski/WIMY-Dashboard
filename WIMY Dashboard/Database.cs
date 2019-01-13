using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WIMY_Dashboard
{
    public class Database
    {
        public MySqlConnection Con;
        public int Userid;
        public Database()
        {
            Connect();
            Disconnect();
        }

        public void Connect()
        {
            //try
            //{
                Con = new MySqlConnection("Server=81.207.39.183;Database=wimy;Uid=WIMY;Pwd=W1MY123;");
                Con.Open();
            //
            //catch (Exception)
            //{

                //MessageBox.Show("Connectie met database niet gelukt");
            //}
            
        }

        public void Disconnect()
        {
            Con.Close();
        }

        public DataTable ExecuteStringQuery(String Query)
        {
            DataTable Result = new DataTable();

            Connect();

            if (this.Verify() == true)
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(Query, Con);
                adapter.Fill(Result);
            }
            //MySqlCommand Command = new MySqlCommand(Query, Con);

            Disconnect();

            return Result;
        }

        public bool Verify()
        {
            Console.WriteLine(this.Con.State);
            if (Con.State == ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}