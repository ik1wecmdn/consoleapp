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
                MyIO.Tulis("WEARNES EDUCATION CENTER MADIUN");
                MyIO.Tulis("Informatika 1 - 2018");
                MyIO.Tulis("--------------------------------");
                MyIO.Tulis("");
                MyIO.Tulis("Menu : ");
                MyIO.Tulis("1. Data Siswa");
                MyIO.Tulis("2. Data Guru");
                MyIO.Tulis("3. Data Nilai");
                MyIO.Tulis("0. Keluar");
                MyIO.Tulis("----------------");
                MyIO.Label("Masukkan Pilihan Anda [1-0] : ");
                pilihan = MyIO.InputInt();
                
                if (pilihan == 1)
                {
                    int pilihanSiswa;
                    //pengolahan data siswa
                    do
                    {
                        Console.Clear();
                        MyIO.Tulis(":: Pengolahan Data Siswa");
                        MyIO.Tulis("------------------------");
                        MyIO.Tulis("1. Tambah Data Siswa ");
                        MyIO.Tulis("2. Tampil Data Siswa ");
                        MyIO.Tulis("3. Edit Data Siswa ");
                        MyIO.Tulis("4. Hapus Data Siswa ");
                        MyIO.Tulis("5. Kembali ke Menu Awal");
                        MyIO.Label("Masukkan Pilihan Anda [1-5] : ");
                        pilihanSiswa = MyIO.InputInt();
                        if (pilihanSiswa == 1)
                        {
                            
                            //proses tambah siswa menggunakan procedural
                            /*
                            Console.Clear();
                            MyIO.Tulis(">> Input Data Siswa");
                            MyIO.Label("NIS      : ");
                            string nis = MyIO.InputString();
                            MyIO.Label("NAMA     : ");
                            string nama = MyIO.InputString();
                            MyIO.Label("KELAS    : ");
                            string kelas = MyIO.InputString();

                            MyIO.Label("Simpan Data ? [Y/N] ");
                            string jawab = MyIO.InputString();

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

                                    MyIO.Tulis("Data Berhasil Disimpan...");
                                    Console.ReadKey();
                                }
                                catch (OleDbException oleEx)
                                {
                                    MyIO.Tulis("Error simpan data... " + oleEx.Message);
                                    Console.ReadKey();
                                }
                                catch (Exception ex)
                                {
                                    MyIO.Tulis("Unknown Error... " + ex.Message);
                                    Console.ReadKey();
                                }
                            }
                            */                            


                            //menambah data menggunakan konsep oop (lihat file siswasvc, siswamodel, accessdb
                            
                            
                            
                            SiswaModel data = new SiswaModel();
                            Console.Clear();
                            MyIO.Tulis(">> Input Data Siswa");
                            MyIO.Label("NIS      : ");
                            data.nis = MyIO.InputString();
                            MyIO.Label("NAMA     : ");
                            data.nama = MyIO.InputString();
                            MyIO.Label("KELAS    : ");
                            data.kelas = MyIO.InputString();

                            MyIO.Label("Simpan Data ? [Y/N] ");
                            string jawab = MyIO.InputString();

                            if (jawab.ToUpper() == "Y")
                            {
                                //tambah ke database
                                SiswaSvc siswa = new SiswaSvc();
                                siswa.Add(data);
                            }
                            
                            

                        }
                        else if (pilihanSiswa == 2)
                        {
                            //proses tampil data siswa 

                            Console.Clear();
                            MyIO.Tulis(">> Tampil data Siswa : ");

                            MyIO.Tulis("");
                            MyIO.Label("Masukkan Nama Siswa atau kosongi untuk menampilkan semua : ");
                            string cari = Console.ReadLine();

                            //---- Tampil Data Procedural --
                            /*
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
                            */
                            //---- End Tampil Data Procedural --

                            //Contoh penggunaan OOP cek file siswasvc dan accessdb
                            
                            SiswaSvc siswa = new SiswaSvc();
                            DataTable dtSiswa;
                            if (cari == "")
                                dtSiswa = siswa.GetAll();
                            else
                                dtSiswa = siswa.GetByName(cari);
                            

                            
                            // -- menampilkan data 
                            //    lakukan perulangan dari baris 0 sampai juml baris
                            // for (int i = 0; i < dtSiswa.Rows.Count; i++)
                            // {
                            //     DataRow row = dtSiswa.Rows[i];
                            //     MyIO.Tulis(" | {0} | {1,-30} | {2,-5} | ",
                            //         row["nis"], row["nama"], row["kelas"]);
                            // }
                            
                            MyIO.Tulis("");

                            if (dtSiswa.Rows.Count > 0)
                            {

                                //tampilkan data jika ada data
                                /*
                                MyIO.Tulis(" +-----+--------------------------------+-------+");
                                MyIO.Tulis(" | NIS |           NAMA                 | KELAS |");
                                MyIO.Tulis(" +-----+--------------------------------+-------+");
                                foreach (DataRow row in dtSiswa.Rows)
                                {
                                    MyIO.Tulis(" | {0} | {1,-30} | {2,-5} | ",
                                        row["nis"], row["nama"], row["kelas"]);
                                }
                                MyIO.Tulis(" +-----+--------------------------------+-------+");
                                */

                                string judul = "NIS            NAMA                                      KELAS";
                                MyIO.Tulis(8, 6, judul, ConsoleColor.Green, ConsoleColor.Black);
                                MyIO.BuatKotak(5, 5, 15, 7);
                                MyIO.BuatKotak(15, 5, 60, 7);
                                MyIO.BuatKotak(60, 5, 80, 7);
                                MyIO.BuatKotak(5, 7, 15, 15);
                                MyIO.BuatKotak(15, 7, 60, 15);
                                MyIO.BuatKotak(60, 7, 80, 15);
                                MyIO.Tulis(15, 5, "┬", ConsoleColor.Green, ConsoleColor.Black);
                                MyIO.Tulis(60, 5, "┬", ConsoleColor.Green, ConsoleColor.Black);
                                MyIO.Tulis(5, 7, "├", ConsoleColor.Green, ConsoleColor.Black);
                                MyIO.Tulis(15, 7, "┼", ConsoleColor.Green, ConsoleColor.Black);
                                MyIO.Tulis(60, 7, "┼", ConsoleColor.Green, ConsoleColor.Black);
                                MyIO.Tulis(80, 7, "┤", ConsoleColor.Green, ConsoleColor.Black);
                                MyIO.Tulis(15, 15, "┴", ConsoleColor.Green, ConsoleColor.Black);
                                MyIO.Tulis(60, 15, "┴", ConsoleColor.Green, ConsoleColor.Black);
                                int baris = 8;
                                foreach(DataRow row in dtSiswa.Rows)
                                {
                                    MyIO.Tulis(7, baris, row["nis"].ToString());
                                    MyIO.Tulis(17, baris, row["nama"].ToString());
                                    MyIO.Tulis(62, baris, row["kelas"].ToString());
                                    baris++;
                                    if (baris == 15)
                                    {
                                        MyIO.Tulis(5, 16, "Tekan sembarang tombol untuk melanjutkan...!", ConsoleColor.Yellow);
                                        Console.ReadKey();
                                        for (int i = 8; i < 15; i++)
                                        {
                                            MyIO.Tulis(6, i, "      ");
                                            MyIO.Tulis(17, i, "                          ");
                                            MyIO.Tulis(62, i, "          ");
                                        }
                                        baris = 8;
                                    }
                                }


                            }
                            else
                            {
                                MyIO.Tulis("Data tidak ditemukan");
                            }


                            Console.ReadKey();
                        }
                        else if (pilihanSiswa == 3)
                        {
                            Console.Clear();
                            MyIO.Tulis(">> Edit Data Siswa");
                            MyIO.Tulis("");
                            MyIO.Label("Masukkan Nis yang ingin di Edit : ");
                            string nisLama = MyIO.InputString();

                            // -- Contoh prosedural
                            /*
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
                                MyIO.Tulis("Nis   : " + row["nis"] );
                                MyIO.Tulis("Nama  : " + row["nama"]);
                                MyIO.Tulis("Kelas : " + row["kelas"]);

                                //input data baru
                                MyIO.Tulis();
                                MyIO.Label("Nis Baru   : ");
                                string nisBaru = MyIO.InputString();
                                MyIO.Label("Nama Baru  : ");
                                string nama = MyIO.InputString();
                                MyIO.Label("Kelas Baru : ");
                                string kelas = MyIO.InputString();

                                MyIO.Label("Update data siswa : [Y/N] ");
                                string jawab = MyIO.InputString();
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
                                MyIO.Tulis("Nis yang anda masukkan salah...!!");
                                Console.ReadKey();
                            }
                            */
                            // -- end procdural

                            // -- contoh penggunaan oop
                            
                            SiswaSvc siswa = new SiswaSvc();
                            SiswaModel data = siswa.GetByNis(nisLama);
                            if (data != null)
                            {
                                //tampil data lama
                                MyIO.Tulis("Nis   : " + data.nis);
                                MyIO.Tulis("Nama  : " + data.nama);
                                MyIO.Tulis("Kelas : " + data.kelas);
                                //input data baru
                                MyIO.Tulis("");
                                SiswaModel dataBaru = new SiswaModel();
                                MyIO.Label("Nis Baru   : ");
                                dataBaru.nis = MyIO.InputString();
                                MyIO.Label("Nama Baru  : ");
                                dataBaru.nama = MyIO.InputString();
                                MyIO.Label("Kelas Baru : ");
                                dataBaru.kelas = MyIO.InputString();
                                MyIO.Label("Update data siswa : [Y/N] ");
                                string jawab = MyIO.InputString();
                                if (jawab.ToUpper() == "Y")
                                {
                                    siswa.Edit(data.nis, dataBaru);
                                }
                            }
                            else
                            {
                                //data tidak ada
                            }
                            

                        }
                        else if (pilihanSiswa == 4)
                        {
                            Console.Clear();
                            MyIO.Tulis(">> Hapus Data Siswa");
                            MyIO.Tulis("");
                            MyIO.Label("Masukkan Nis yang ingin di Hapus : ");
                            string nis = MyIO.InputString();

                            //tampilkan dulu data siswanya
                            
                            MyIO.Label("Yakin mau dihapus ? [Y/N] ");
                            string jawab = MyIO.InputString();
                            if (jawab.ToUpper() == "Y")
                            {
                                // --contoh penggunaan procedural\
                                /*
                                string koneksiString = "Provider=Microsoft.Ace.OleDB.12.0;Data Source=Database.accdb";
                                OleDbConnection koneksi = new OleDbConnection(koneksiString);
                                koneksi.Open();

                                string query = "DELETE FROM siswa WHERE nis=@nis";
                                OleDbCommand cmd = new OleDbCommand(query, koneksi);
                                cmd.Parameters.AddWithValue("@nis", nis);
                                cmd.ExecuteNonQuery();
                                */

                                //-- contoh penggunaan oop
                                
                                SiswaSvc siswa = new SiswaSvc();
                                siswa.Hapus(nis);
                                

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
