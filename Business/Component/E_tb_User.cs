using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToKhaiYTe.Business.EntitiesClass;
using ToKhaiYTe.DataAccess;

namespace ToKhaiYTe.Business.Component
{
    class E_tb_User
    {
        SQL_tb_User sql = new SQL_tb_User();
        EC_tb_User ck = new EC_tb_User();
        public void themND(EC_tb_User ec)
        {
            sql.themND(ec);
        }
        public void xoaND(EC_tb_User ec)
        {
            sql.xoaND(ec);
        }
        public void suaND(string id, string hoten, string ngaysinh, string gioitinh, string socmtnd, string diachi, string sdt, string thebhyt, string email, string idlop)
        {
            ck.Id = id;
            ck.Hoten = hoten;
            ck.Ngaysinh = ngaysinh;
            ck.Gioitinh = gioitinh;
            ck.Socmtnd = socmtnd;
            ck.Diachi = diachi;
            ck.Sdt = sdt;
            ck.Thebhyt = thebhyt;
            ck.Email = email;
            ck.Idlop = idlop;
            sql.suaND(ck);
        }
        public void themNDisHS(EC_tb_User ec)
        {
            sql.themNDisHS(ec);
        }
        public bool checkQMK(string str1,string str2)
        {
            return sql.kiemtrauserQMK(str1, str2);
        }
        public string loadid(string str1, string str2)
        {
            return sql.loadID(str1, str2);
        }
        public bool QuyenUser(string id)
        {
            ck.Id = id;
            return sql.kiemtraAdmin(ck);
        }
        public bool QuyenGV(string id)
        {
            ck.Id = id;
            return sql.kiemtraGV(ck);
        }
        public List<EC_tb_User> loadTTsv(string id)
        {
            return sql.GetTb_Menus(id);
        }

    }
}
