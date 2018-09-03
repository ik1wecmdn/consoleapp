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
            get;
            set;
        }
        public string kelas
        {
            get;
            set;
        }
    }
}
