using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToKhaiYTe.DataAccess;
using ToKhaiYTe.Business.EntitiesClass;

namespace ToKhaiYTe.Business.Component
{
    class E_tb_Thongbao
    {
        SQL_tb_Thongbao sql = new SQL_tb_Thongbao();
        EC_tb_Thongbao ck = new EC_tb_Thongbao();
        public List<EC_tb_Thongbao> loadThongBao()
        {
            return sql.loadThongBao();
        }
        public void themtb(string id,string tieude,string noidung)
        {
            ck.Id = id;
            ck.Tieude = tieude;
            ck.Noidung = noidung;
            sql.themtb(ck);
        }
        public void suatb(string id, string tieude, string noidung)
        {
            ck.Id = id;
            ck.Tieude = tieude;
            ck.Noidung = noidung;
            sql.suatb(ck);
        }
        public void xoatb(string id)
        {
            ck.Id = id;
            sql.xoatb(ck);
        }
    }
}
