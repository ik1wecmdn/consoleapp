using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class SiswaModel
    {
        private string _nis;
        private string _nama;
        private string _kelas;
        public string nis
        {
            get 
            {
                return _nis;
            }
            set
            {
                _nis = value;
            }
        }
        public string nama
        {
            get
            {
                return _nama;
            }
            set
            {
                _nama = value;
            }
        }
        public string kelas
        {
            get
            {
                return _kelas;
            }
            set
            {
                _kelas = value;
            }
        }
    }
}
