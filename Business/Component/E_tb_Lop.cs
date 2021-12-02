using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToKhaiYTe.DataAccess;
using System.Windows.Forms;
using ToKhaiYTe.Business.EntitiesClass;

namespace ToKhaiYTe.Business.Component
{
    class E_tb_Lop
    {
        SQL_tb_Lop sql = new SQL_tb_Lop();
        EC_tb_Lop ck = new EC_tb_Lop();
        public List<EC_tb_Lop> loadTenLop(string str)
        {
           return sql.loadTenLop(str);
        }
        public void themLop(string malop,string tenlop,string makhoa)
        {
            ck.Idlop = malop;
            ck.Tenlop = tenlop;
            ck.Makhoa = makhoa;
            sql.themLop(ck);
        }
        public void suaLop(string malop, string tenlop, string makhoa)
        {
            ck.Idlop = malop;
            ck.Tenlop = tenlop;
            ck.Makhoa = makhoa;
            sql.suaLop(ck);
        }
        public void xoaLop(string malop)
        {
            ck.Idlop = malop;
            sql.xoaLop(ck);
        }
    }
}
