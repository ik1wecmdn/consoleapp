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

        }

        public void Execute(string query, OleDbParameter[] parameters)
        {
            //untuk execute command

        }

    }
}
