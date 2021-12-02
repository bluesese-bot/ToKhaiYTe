using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToKhaiYTe.Business.EntitiesClass
{
    class EC_tb_Thongbao
    {
        private string id;
        private string tieude;
        private string noidung;

        public EC_tb_Thongbao()
        {
        }

        public EC_tb_Thongbao(DataRow row)
        {
            this.Id = row["ID Thông Báo"].ToString();
            this.Tieude = row["Tiêu Đề"].ToString();
            this.Noidung = row["Nội Dung"].ToString();
        }
        public string Id { get => id; set => id = value; }
        public string Tieude { get => tieude; set => tieude = value; }
        public string Noidung { get => noidung; set => noidung = value; }
    }
}
