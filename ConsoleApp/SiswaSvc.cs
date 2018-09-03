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
            string query = "SELECT nis,nama,kelas FROM siswa";
            AccessDB db = new AccessDB();
            return db.GetData(query);
        }

        public DataTable GetByName(string nama)
        {
            string query = "SELECT nis,nama,kelas FROM siswa WHERE nama LIKE @kriteria";
            AccessDB db = new AccessDB();
            return db.GetData(query, 
                new OleDbParameter("kriteria", "%" + nama + "%"));
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
