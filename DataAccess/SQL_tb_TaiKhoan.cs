using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ToKhaiYTe.Business.EntitiesClass;
using System.Data;

namespace ToKhaiYTe.DataAccess
{
    class SQL_tb_TaiKhoan
    {
        ConnectDB cn = new ConnectDB();
        public void xoatk(EC_tb_TaiKhoan ec)
        {
            cn.ExcuteNonQuery(@"exec delete_taikhoan @ID=N'"+ec.Id+"'");
        }
        public bool kiemtraUserName(EC_tb_TaiKhoan ec)
        {
           return cn.KiemtraUsername(@"exec kiemtrauser @ID='"+ec.Id+"',@password=N'"+ec.Pass+"'");
        }
        public void themtk(EC_tb_TaiKhoan ec)
        {
            cn.ExcuteNonQuery(@"exec addtaikhoan @id=N'"+ec.Id+"',@pass=N'"+ec.Pass+"'");
        }
        public void suamk(EC_tb_TaiKhoan ec)
        {
            cn.ExcuteNonQuery(@"exec suaMK @id = N'"+ec.Id+"',@pass = N'"+ec.Pass+"'");
        }
    }
}
