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
    class SQL_tb_User
    {
        ConnectDB cn = new ConnectDB();
        public void themND(EC_tb_User ec)
        {
            cn.ExcuteNonQuery(@"exec Themnguoidung @ID =N'"+ec.Id+"',@hoten=N'"+ec.Hoten+"',@ngaysinh = N'"+ec.Ngaysinh+"',@gioitinh = N'"+ec.Gioitinh+"',@sdt=N'"+ec.Sdt+"',@email=N'"+ec.Email+"',@chucvu=N'"+ec.Chucvu+ "',@idlop=N'"+ec.Idlop+"'");
        }
        public void themNDisHS(EC_tb_User ec)
        {
            cn.ExcuteNonQuery(@"exec Themnguoidunghs @ID =N'"+ec.Id+"',@hoten=N'"+ec.Hoten+"',@ngaysinh = N'"+ec.Ngaysinh+"',@gioitinh = N'"+ec.Gioitinh+"',@sdt=N'"+ec.Sdt+"',@email=N'"+ec.Email+ "',@idlop='"+ec.Idlop+"'");
        }
        public void suaND(EC_tb_User ec)
        {
            cn.ExcuteNonQuery(@"exec suathongtinnguoidung @ID=N'"+ec.Id+"',@hoten =N'"+ec.Hoten+"',@ngaysinh = N'"+ec.Ngaysinh+"',@gioitinh =N'"+ec.Gioitinh+"',@sdt = N'"+ec.Sdt+"',@email =N'"+ec.Email+"',@socmt = N'"+ec.Socmtnd+"',@tbhyt = N'"+ec.Thebhyt+"',@diachi = N'"+ec.Diachi+"',@idlop=N'"+ec.Idlop+"'");
        }
        public void xoaND(EC_tb_User ec)
        {
            cn.ExcuteNonQuery(@"exec xoanguoidung @id='"+ec.Id+"'");
        }
        public bool kiemtrauserQMK(string DK1 , string dk2)
        {
           return cn.KiemtraUsername(@"exec KiemtrauserQMK @id = N'"+DK1+"',@ten=N'"+dk2+"'");
        }
        public string loadID(string DK1, string dk2)
        {
            return cn.returnscalarnumberString(@"exec LoadIDngdung @id = N'" + DK1+"',@ten=N'"+dk2+"'");
        }
        public bool kiemtraAdmin(EC_tb_User ec)
        {
            return cn.KiemtraAdmin(@"exec KiemtraChucVu @id='" + ec.Id + "'");
        }
        public bool kiemtraGV(EC_tb_User ec)
        {
            return cn.KiemtraGv(@"exec KiemtraChucVu @id='" + ec.Id + "'");
        }
        public List<EC_tb_User> GetTb_Menus(string id)
        {
            List<EC_tb_User> listmenu = new List<EC_tb_User>();
            DataTable data = cn.taobang(@"exec loadTTsv @id='" + id + "'");
            foreach (DataRow item in data.Rows)
            {
                EC_tb_User menu = new EC_tb_User(item);
                listmenu.Add(menu);
            }
            return listmenu;
        }

    }
}
