using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToKhaiYTe.Business.EntitiesClass;

namespace ToKhaiYTe.DataAccess
{
    class SQL_tb_Thongbao
    {
        ConnectDB cn = new ConnectDB();
        
        public List<EC_tb_Thongbao> loadThongBao()
        {
            List<EC_tb_Thongbao> tableTB = new List<EC_tb_Thongbao>();
            DataTable data = cn.taobang("loadThongBao");
            foreach (DataRow item in data.Rows)
            {
                EC_tb_Thongbao table = new EC_tb_Thongbao(item);
                tableTB.Add(table);
            }
            return tableTB;
        }
        public void themtb(EC_tb_Thongbao ck)
        {
            cn.ExcuteNonQuery(@"exec themthongbao @id='"+ck.Id+ "',@tieude=N'"+ck.Tieude+"',@noidung=N'"+ck.Noidung+"'");
        }
        public void suatb(EC_tb_Thongbao ck)
        {
            cn.ExcuteNonQuery(@"exec suaThongbao @id='" + ck.Id + "',@tieude=N'" + ck.Tieude + "',@noidung=N'" + ck.Noidung + "'");
        }
        public void xoatb(EC_tb_Thongbao ck)
        {
            cn.ExcuteNonQuery(@"exec xoathongbao @id='" + ck.Id + "'");
        }
    }
}
