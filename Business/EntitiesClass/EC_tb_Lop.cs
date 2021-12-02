using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToKhaiYTe.Business.EntitiesClass
{
    class EC_tb_Lop
    {
        private string idlop;
        private string tenlop;
        private string makhoa;

        public EC_tb_Lop()
        {
        }

        public EC_tb_Lop(DataRow row)
        {
            this.Idlop = row[0].ToString();
            this.Tenlop = row[1].ToString();
            this.Makhoa = row[2].ToString();
        }

        public string Idlop { get => idlop; set => idlop = value; }
        public string Tenlop { get => tenlop; set => tenlop = value; }
        public string Makhoa { get => makhoa; set => makhoa = value; }
    }
}
