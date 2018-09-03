using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.OleDb;


namespace ConsoleApp
{
    class AccessDB
    {
        OleDbConnection koneksi;
        
        public AccessDB()
        {
            //constructor
            string koneksiString = "Provider=Microsoft.Ace.OleDB.12.0;Data Source=Database.accdb;";
            koneksi = new OleDbConnection(koneksiString);
            koneksi.Open();
        }

        //untuk insert update dan delete
        public void Execute(string query, params OleDbParameter[] parameters)
        {
            //untuk execute command
            OleDbCommand cmd = new OleDbCommand(query, koneksi);
            cmd.Parameters.AddRange(parameters);
            cmd.ExecuteNonQuery();
        }

        //untuk select
        public DataTable GetData(string query, params OleDbParameter[] parameters)
        {
            DataTable result = new DataTable();

            OleDbCommand cmd = new OleDbCommand(query, koneksi);
            cmd.Parameters.AddRange(parameters);
            OleDbDataReader reader = cmd.ExecuteReader();

            //isi result dari reader
            result.Load(reader);

            return result;
        }

        ~AccessDB()
        {
            //destructor
            koneksi.Close();
        }

    }
}
