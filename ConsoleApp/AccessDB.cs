﻿using System;
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
        public void Execute(string query, Dictionary<string, dynamic> data = null)
        {
            //untuk execute command
            OleDbCommand cmd = new OleDbCommand(query, koneksi);
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
            OleDbCommand cmd = new OleDbCommand(query, koneksi);
            if (data != null)
            {
                foreach (string key in data.Keys)
                {
                    cmd.Parameters.AddWithValue(key, data[key]);
                }
            }
            OleDbDataReader reader = cmd.ExecuteReader();

            DataTable result = new DataTable();
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
