using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            int pilihan;
            do
            {
                Console.WriteLine();
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
                        Console.WriteLine();
                        Console.WriteLine("Pengolahan Data Siswa");
                        Console.WriteLine("---------------------");
                        Console.WriteLine("1. Tambah Data Siswa ");
                        Console.WriteLine("2. Tampil Data Siswa ");
                        Console.WriteLine("3. Edit Data Siswa ");
                        Console.WriteLine("4. Hapus Data Siswa ");
                        Console.WriteLine("5. Kembali ke Menu Awal");
                        Console.Write("Masukkan Pilihan Anda [1-5]");
                        pilihanSiswa = int.Parse(Console.ReadLine());
                        if (pilihanSiswa == 1)
                        {
                            //proses tambah siswa
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
