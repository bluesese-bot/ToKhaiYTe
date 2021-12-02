using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToKhaiYTe.Business.EntitiesClass
{
    class EC_tb_Khoa
    {
        private string idKhoa;
        private string tenkhoa;

        public EC_tb_Khoa()
        {
        }

        public EC_tb_Khoa(DataRow row)
        {
            this.IdKhoa = row[0].ToString();
            this.Tenkhoa = row[1].ToString();
        }

        public string IdKhoa { get => idKhoa; set => idKhoa = value; }
        public string Tenkhoa { get => tenkhoa; set => tenkhoa = value; }

    }
}
