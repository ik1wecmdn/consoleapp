using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace ConsoleApp
{
    class MySQLDB
    {
        MySqlConnection koneksi;
        
        public MySQLDB()
        {
            string koneksiString = "Server=davidnakoko.com;user=davidnakoko_ik12018;password=wearnesik1;database=davidnakoko_ik12018";
            koneksi = new MySqlConnection(koneksiString);
            koneksi.Open();
        }

        //untuk insert update dan delete
        public void Execute(string query, Dictionary<string, dynamic> data = null)
        {
            MySqlCommand cmd = new MySqlCommand(query, koneksi);
            if (data != null)
            {
                foreach (string key in data.Keys)
                {
                    cmd.Parameters.AddWithValue(key, data[key]);
                }
            }
            cmd.ExecuteNonQuery();
        }

        

        //untuk select
        public DataTable GetData(string query, Dictionary<string, dynamic> data = null)
        {
            MySqlCommand cmd = new MySqlCommand(query, koneksi);
            if (data != null)
            {
                foreach (string key in data.Keys)
                {
                    cmd.Parameters.AddWithValue(key, data[key]);
                }
            }
            MySqlDataReader reader = cmd.ExecuteReader();
            
            DataTable result = new DataTable();
            result.Load(reader);

            return result;
        }

        ~MySQLDB()
        {
            //destructor
            koneksi.Close();
        }

    }
}
