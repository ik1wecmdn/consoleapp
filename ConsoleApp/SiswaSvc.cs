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
            MySQLDB db = new MySQLDB();
            return db.GetData(query);
        }

        public SiswaModel GetByNis(string nis)
        {
            SiswaModel data = null;
            string query = "SELECT nis,nama,kelas FROM siswa WHERE nis=@kriteria";
            MySQLDB db = new MySQLDB();
            DataTable dtSiswa = db.GetData(query, new Dictionary<string, dynamic>()
            {
                {"@kriteria", nis}
            });
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
            MySQLDB db = new MySQLDB();
            return db.GetData(query, new Dictionary<string, dynamic>()
            {
               {"@kriteria", "%" + nama + "%"}
            });
        }

        public void Add(SiswaModel data)
        {
            string query = "INSERT INTO siswa (nis,nama,kelas) VALUES (@nis,@nama,@kelas)";
            MySQLDB db = new MySQLDB();
            db.Execute(query, new Dictionary<string, dynamic>()
            {
                {"@nis", data.nis},
                {"@nama", data.nama},
                {"@kelas", data.kelas}
            });
        }

        public void Edit(string nis, SiswaModel data)
        {
            string query = "UPDATE siswa SET nis=@nisBaru,nama=@namaBaru,kelas=@kelasBaru WHERE nis=@nisLama";
            MySQLDB db = new MySQLDB();
            db.Execute(query, new Dictionary<string, dynamic>()
            {
                {"@nisBaru", data.nis},
                {"@namaBaru", data.nama},
                {"@kelasBaru", data.kelas},
                {"@nisLama", nis}
            });
        }

        public void Hapus(string nis)
        {
            string query = "DELETE FROM siswa WHERE nis=@kriteria";
            MySQLDB db = new MySQLDB();
            db.Execute(query, new Dictionary<string, dynamic>()
            {
                {"@kriteria", nis}
            });

        }


    }
}
