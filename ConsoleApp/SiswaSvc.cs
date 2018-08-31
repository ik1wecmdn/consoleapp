using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.OleDb;

namespace ConsoleApp
{
    class SiswaSvc
    {
        public DataTable GetAll()
        {
            DataTable result = new DataTable();

            return result;
        }

        public void Add(SiswaModel data)
        {
            string query = "INSERT INTO siswa (nis,nama,kelas) VALUES (@nis,@nama,@kelas)";
            AccessDB db = new AccessDB();
            db.Execute(query,
                new OleDbParameter("nis", data.nis),
                new OleDbParameter("nama", data.nama),
                new OleDbParameter("kelas", data.kelas));
        }

        public void Edit(string nis, SiswaModel data)
        {
 
        }

        public void Hapus(string nis)
        {
 
        }


    }
}
