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

        public SiswaModel GetByNis(string nis)
        {
            SiswaModel data = null;
            string query = "SELECT nis,nama,kelas FROM siswa WHERE nis=@kriteria";
            AccessDB db = new AccessDB();
            DataTable dtSiswa = db.GetData(query,
                new OleDbParameter("@kriteria", nis));
            if (dtSiswa.Rows.Count == 1)
            {
                //ambil satu baris saja
                DataRow row = dtSiswa.Rows[0];
                //masukkan ke model siswa
                data = new SiswaModel();
                data.nis = row["nis"].ToString();
                data.nama = row["nama"].ToString();
                data.kelas = row["kelas"].ToString();
            }
            
            return data;
        }

        public DataTable GetByName(string nama)
        {
            string query = "SELECT nis,nama,kelas FROM siswa WHERE nama LIKE @kriteria";
            AccessDB db = new AccessDB();
            return db.GetData(query, 
                new OleDbParameter("@kriteria", "%" + nama + "%"));
        }

        public void Add(SiswaModel data)
        {
            string query = "INSERT INTO siswa (nis,nama,kelas) VALUES (@nis,@nama,@kelas)";
            AccessDB db = new AccessDB();
            db.Execute(query,
                new OleDbParameter("@nis", data.nis),
                new OleDbParameter("@nama", data.nama),
                new OleDbParameter("@kelas", data.kelas));
        }

        public void Edit(string nis, SiswaModel data)
        {
            string query = "UPDATE siswa SET nis=@nisBaru,nama=@namaBaru,kelas=@kelasBaru WHERE nis=@nisLama";
            AccessDB db = new AccessDB();
            db.Execute(query,
                new OleDbParameter("@nisBaru", data.nis),
                new OleDbParameter("@namaBaru", data.nama),
                new OleDbParameter("@kelasBaru", data.kelas),
                new OleDbParameter("@nisLama", nis));
        }

        public void Hapus(string nis)
        {
            string query = "DELETE FROM siswa WHERE nis=@kriteria";
            AccessDB db = new AccessDB();
            db.Execute(query, 
                new OleDbParameter("@kriteria", nis));

        }


    }
}
