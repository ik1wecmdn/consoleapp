using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        Console.WriteLine("---------------------");
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
                                //simpan ke database
                                
                                //ciptakan query
                                string query = "INSERT INTO siswa (nis,nama,kelas) VALUES (@nis,@nama,@kelas)";
                                //buat koneksi / penghubung
                                string koneksiString = "Provider=Microsoft.Ace.OleDB.12.0;Data Source=Database.accdb;";
                                OleDbConnection koneksi = new OleDbConnection(koneksiString);
                                koneksi.Open();
                                //buat perintah dan eksesuksi query
                                OleDbCommand cmd = new OleDbCommand(query, koneksi);
                                cmd.Parameters.AddWithValue("nis", nis);
                                cmd.Parameters.AddWithValue("nama", nama);
                                cmd.Parameters.AddWithValue("kelas", kelas);
                                cmd.ExecuteNonQuery();
                                 
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
