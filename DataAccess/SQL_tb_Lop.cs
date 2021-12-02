using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToKhaiYTe.Business.EntitiesClass;
namespace ToKhaiYTe.DataAccess
{
    class SQL_tb_Lop
    {
        ConnectDB cn = new ConnectDB();
        public List<EC_tb_Lop> loadTenLop(string id)
        {
            List<EC_tb_Lop> list = new List<EC_tb_Lop>();
            DataTable data = cn.taobang(@"exec loadTenLop @makhoa=N'" + id + "'");
            foreach (DataRow item in data.Rows)
            {
                EC_tb_Lop ck = new EC_tb_Lop(item);
                list.Add(ck);
            }

            return list;
        }
        public void themLop(EC_tb_Lop ck)
        {
            cn.ExcuteNonQuery(@"exec themlop @makhoa='"+ck.Makhoa+"',@malop='"+ck.Idlop+"',@tenlop=N'"+ck.Tenlop+"'");
        }
        public void suaLop(EC_tb_Lop ck)
        {
            cn.ExcuteNonQuery(@"exec sualop @makhoa='"+ck.Makhoa+"',@malop='"+ck.Idlop+"',@tenlop=N'"+ck.Tenlop+"'");
        }
        public void xoaLop(EC_tb_Lop ck)
        {
            cn.ExcuteNonQuery(@"exec xoalop@malop='"+ck.Idlop+"'");
        }
    }
}
