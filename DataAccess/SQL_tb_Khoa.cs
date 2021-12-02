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
    class SQL_tb_Khoa
    {
        ConnectDB cn = new ConnectDB();
        public List<EC_tb_Khoa> loadtenkhoa()
        {
            List<EC_tb_Khoa> list = new List<EC_tb_Khoa>();
            DataTable data = cn.taobang(@"exec loadtenkhoa");
            foreach (DataRow item in data.Rows)
            {
                EC_tb_Khoa ck = new EC_tb_Khoa(item);
                list.Add(ck);
            }
            return list;
        }

        public void themKhoa(EC_tb_Khoa ck)
        {
            cn.ExcuteNonQuery(@"exec themKhoa @makhoa=N'"+ck.IdKhoa+ "',@tenkhoa = N'"+ck.Tenkhoa+"'");
        }
        public void suaKhoa(EC_tb_Khoa ck)
        {
            cn.ExcuteNonQuery(@"exec suaKhoa @makhoa=N'" + ck.IdKhoa + "',@tenkhoa = N'" + ck.Tenkhoa + "'");
        }
        public void xoaKhoa(EC_tb_Khoa ck)
        {
            cn.ExcuteNonQuery(@"exec xoaKhoa @makhoa=N'" + ck.IdKhoa + "'");
        }
    }
}
