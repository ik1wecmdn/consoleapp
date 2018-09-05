using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.OleDb;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            int pilihan;
            do
            {
                Console.Clear();
                Console.WriteLine("WEARNES EDUCATION CENTER MADIUN");
                Console.WriteLine("Informatika 1 - 2018");
                Console.WriteLine("--------------------------------");
                Console.WriteLine();
                Console.WriteLine("Menu : ");
                Console.WriteLine("1. Data Siswa");
                Console.WriteLine("2. Data Guru");
                Console.WriteLine("3. Data Nilai");
                Console.WriteLine("0. Keluar");
                Console.WriteLine("----------------");
                Console.Write("Masukkan Pilihan Anda [1-0] : ");
                pilihan = int.Parse(Console.ReadLine());
                
                if (pilihan == 1)
                {
                    int pilihanSiswa;
                    //pengolahan data siswa
                    do
                    {
                        Console.Clear();
                        Console.WriteLine(":: Pengolahan Data Siswa");
                        Console.WriteLine("------------------------");
                        Console.WriteLine("1. Tambah Data Siswa ");
                        Console.WriteLine("2. Tampil Data Siswa ");
                        Console.WriteLine("3. Edit Data Siswa ");
                        Console.WriteLine("4. Hapus Data Siswa ");
                        Console.WriteLine("5. Kembali ke Menu Awal");
                        Console.Write("Masukkan Pilihan Anda [1-5] : ");
                        pilihanSiswa = int.Parse(Console.ReadLine());
                        if (pilihanSiswa == 1)
                        {
                            
                            //proses tambah siswa menggunakan procedural
                            Console.Clear();
                            Console.WriteLine(">> Input Data Siswa");
                            Console.Write("NIS      : ");
                            string nis = Console.ReadLine();
                            Console.Write("NAMA     : ");
                            string nama = Console.ReadLine();
                            Console.Write("KELAS    : ");
                            string kelas = Console.ReadLine();

                            Console.Write("Simpan Data ? [Y/N] ");
                            string jawab = Console.ReadLine();

                            if (jawab.ToUpper() == "Y")
                            {
                                try
                                {
                                    //ciptakan query
                                    string query = "INSERT INTO siswa (nis,nama,kelas) VALUES (@nis,@nama,@kelas)";
                                    //buat koneksi / penghubung
                                    string koneksiString = "Provider=Microsoft.Ace.OleDB.12.0;Data Source=Database.accdb;";
                                    OleDbConnection koneksi = new OleDbConnection(koneksiString);
                                    koneksi.Open();
                                    //buat perintah dan eksesuksi query
                                    OleDbCommand cmd = new OleDbCommand(query, koneksi);
                                    cmd.Parameters.AddWithValue("@nis", nis);
                                    cmd.Parameters.AddWithValue("@nama", nama);
                                    cmd.Parameters.AddWithValue("@kelas", kelas);
                                    cmd.ExecuteNonQuery();

                                    Console.WriteLine("Data Berhasil Disimpan...");
                                    Console.ReadKey();
                                }
                                catch (OleDbException oleEx)
                                {
                                    Console.WriteLine("Error simpan data... " + oleEx.Message);
                                    Console.ReadKey();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Unknown Error... " + ex.Message);
                                    Console.ReadKey();
                                }
                            }
                                                        


                            //menambah data menggunakan konsep oop (lihat file siswasvc, siswamodel, accessdb
                            
                            /*
                            
                            SiswaModel data = new SiswaModel();
                            Console.Clear();
                            Console.WriteLine(">> Input Data Siswa");
                            Console.Write("NIS      : ");
                            data.nis = Console.ReadLine();
                            Console.Write("NAMA     : ");
                            data.nama = Console.ReadLine();
                            Console.Write("KELAS    : ");
                            data.kelas = Console.ReadLine();

                            Console.Write("Simpan Data ? [Y/N] ");
                            string jawab = Console.ReadLine();

                            if (jawab.ToUpper() == "Y")
                            {
                                //tambah ke database
                                SiswaSvc siswa = new SiswaSvc();
                                siswa.Add(data);
                            }
                            
                            */

                        }
                        else if (pilihanSiswa == 2)
                        {
                            //proses tampil data siswa 

                            Console.Clear();
                            Console.WriteLine(">> Tampil data Siswa : ");

                            Console.WriteLine();
                            Console.Write("Masukkan Nama Siswa atau kosongi untuk menampilkan semua : ");
                            string cari = Console.ReadLine();

                            //---- Tampil Data Procedural --

                            //buat koneksi ke access
                            string koneksiString = "Provider=Microsoft.Ace.OleDB.12.0;Data Source=Database.accdb";
                            OleDbConnection koneksi = new OleDbConnection(koneksiString);
                            koneksi.Open();

                            //buat query
                            string query;
                            if (cari == "")
                            {
                                query = "SELECT nis,nama,kelas FROM siswa ";
                            }
                            else
                            {
                                query = "SELECT nis,nama,kelas FROM siswa WHERE nama LIKE '%"+ cari +"%'";
                            }

                            OleDbCommand cmd = new OleDbCommand(query, koneksi);
                            OleDbDataReader reader = cmd.ExecuteReader();

                            //menampung dalam data tabel
                            DataTable dtSiswa = new DataTable();
                            dtSiswa.Load(reader);
                            
                            //---- End Tampil Data Procedural --

                            //Contoh penggunaan OOP cek file siswasvc dan accessdb
                            /*
                            SiswaSvc siswa = new SiswaSvc();
                            DataTable dtSiswa;
                            if (cari == "")
                                dtSiswa = siswa.GetAll();
                            else
                                dtSiswa = siswa.GetByName(cari);
                            */

                            
                            // -- menampilkan data 
                            //    lakukan perulangan dari baris 0 sampai juml baris
                            // for (int i = 0; i < dtSiswa.Rows.Count; i++)
                            // {
                            //     DataRow row = dtSiswa.Rows[i];
                            //     Console.WriteLine(" | {0} | {1,-30} | {2,-5} | ",
                            //         row["nis"], row["nama"], row["kelas"]);
                            // }
                            
                            Console.WriteLine();

                            if (dtSiswa.Rows.Count > 0)
                            {
                                //tampilkan data jika ada data
                                Console.WriteLine(" +-----+--------------------------------+-------+");
                                Console.WriteLine(" | NIS |           NAMA                 | KELAS |");
                                Console.WriteLine(" +-----+--------------------------------+-------+");
                                foreach (DataRow row in dtSiswa.Rows)
                                {
                                    Console.WriteLine(" | {0} | {1,-30} | {2,-5} | ",
                                        row["nis"], row["nama"], row["kelas"]);
                                }
                                Console.WriteLine(" +-----+--------------------------------+-------+");
                            }
                            else
                            {
                                Console.WriteLine("Data tidak ditemukan");
                            }


                            Console.ReadKey();
                        }
                        else if (pilihanSiswa == 3)
                        {
                            Console.Clear();
                            Console.WriteLine(">> Edit Data Siswa");
                            Console.WriteLine();
                            Console.Write("Masukkan Nis yang ingin di Edit : ");
                            string nisLama = Console.ReadLine();

                            // -- Contoh prosedural
                            
                            string query = "SELECT * FROM siswa WHERE nis=@nis";
                            string koneksiString = "Provider=Microsoft.Ace.OleDB.12.0;Data Source=Database.accdb";
                            OleDbConnection koneksi = new OleDbConnection(koneksiString);
                            koneksi.Open();

                            OleDbCommand cmd = new OleDbCommand(query, koneksi);
                            cmd.Parameters.AddWithValue("@nis", nisLama);
                            OleDbDataReader reader = cmd.ExecuteReader();

                            DataTable dtSiswa = new DataTable();
                            dtSiswa.Load(reader);

                            if (dtSiswa.Rows.Count == 1)
                            {
                                //tampilkan data lama
                                DataRow row = dtSiswa.Rows[0];
                                Console.WriteLine("Nis   : " + row["nis"] );
                                Console.WriteLine("Nama  : " + row["nama"]);
                                Console.WriteLine("Kelas : " + row["kelas"]);

                                //input data baru
                                Console.WriteLine();
                                Console.Write("Nis Baru   : ");
                                string nisBaru = Console.ReadLine();
                                Console.Write("Nama Baru  : ");
                                string nama = Console.ReadLine();
                                Console.Write("Kelas Baru : ");
                                string kelas = Console.ReadLine();

                                Console.Write("Update data siswa : [Y/N] ");
                                string jawab = Console.ReadLine();
                                if (jawab.ToUpper() == "Y")
                                {
                                    query = "UPDATE siswa SET nis=@nisBaru,nama=@nama,kelas=@kelas WHERE nis=@nis";
                                    cmd = new OleDbCommand(query, koneksi);

                                    cmd.Parameters.AddWithValue("@nisBaru", nisBaru);
                                    cmd.Parameters.AddWithValue("@nama", nama);
                                    cmd.Parameters.AddWithValue("@kelas", kelas);
                                    cmd.Parameters.AddWithValue("@nis", nisLama);
                                    
                                    cmd.ExecuteNonQuery();

                                }

                            }
                            else 
                            {
                                //data tidak ada
                                Console.WriteLine("Nis yang anda masukkan salah...!!");
                                Console.ReadKey();
                            }
                            

                            // -- contoh penggunaan oop
                            /*
                            SiswaSvc siswa = new SiswaSvc();
                            SiswaModel data = siswa.GetByNis(nisLama);
                            if (data != null)
                            {
                                //tampil data lama
                                Console.WriteLine("Nis   : " + data.nis);
                                Console.WriteLine("Nama  : " + data.nama);
                                Console.WriteLine("Kelas : " + data.kelas);
                                //input data baru
                                Console.WriteLine();
                                SiswaModel dataBaru = new SiswaModel();
                                Console.Write("Nis Baru   : ");
                                dataBaru.nis = Console.ReadLine();
                                Console.Write("Nama Baru  : ");
                                dataBaru.nama = Console.ReadLine();
                                Console.Write("Kelas Baru : ");
                                dataBaru.kelas = Console.ReadLine();
                                Console.Write("Update data siswa : [Y/N] ");
                                string jawab = Console.ReadLine();
                                if (jawab.ToUpper() == "Y")
                                {
                                    siswa.Edit(data.nis, dataBaru);
                                }
                            }
                            else
                            {
                                //data tidak ada
                            }
                            */

                        }
                        else if (pilihanSiswa == 4)
                        {
                            Console.Clear();
                            Console.WriteLine(">> Hapus Data Siswa");
                            Console.WriteLine();
                            Console.Write("Masukkan Nis yang ingin di Hapus : ");
                            string nis = Console.ReadLine();

                            //tampilkan dulu data siswanya

                            //-- contoh penggunaan procedural
                            
                            Console.Write("Yakin mau dihapus ? [Y/N] ");
                            string jawab = Console.ReadLine();
                            if (jawab.ToUpper() == "Y")
                            {
                                // --contoh penggunaan procedural
                                string koneksiString = "Provider=Microsoft.Ace.OleDB.12.0;Data Source=Database.accdb";
                                OleDbConnection koneksi = new OleDbConnection(koneksiString);
                                koneksi.Open();

                                string query = "DELETE FROM siswa WHERE nis=@nis";
                                OleDbCommand cmd = new OleDbCommand(query, koneksi);
                                cmd.Parameters.AddWithValue("@nis", nis);
                                cmd.ExecuteNonQuery();
                                

                                //-- contoh penggunaan oop
                                /*
                                SiswaSvc siswa = new SiswaSvc();
                                siswa.Hapus(nis);
                                */

                            }


                        }

                    } while (pilihanSiswa != 5);
                    

                }
                else if (pilihan == 2)
                {
                    //pengolahan data guru
                }
                else if (pilihan == 0)
                {

                }
            } while (pilihan != 0);


            //Console.ReadKey();
        }

    }
}
