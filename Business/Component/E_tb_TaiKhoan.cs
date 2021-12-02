using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToKhaiYTe.DataAccess;
using ToKhaiYTe.Business.EntitiesClass;

namespace ToKhaiYTe.Business.Component
{
    class E_tb_TaiKhoan
    {
        SQL_tb_TaiKhoan sqltk = new SQL_tb_TaiKhoan();
        EC_tb_TaiKhoan ck = new EC_tb_TaiKhoan();
        public bool kiemtrauser(string user, string pass)
        {
            ck.Id = user;
            ck.Pass = pass;
            return sqltk.kiemtraUserName(ck);
        }
        public void xoatk(EC_tb_TaiKhoan tk)
        {
            sqltk.xoatk(tk);
        }
        public void themtk(EC_tb_TaiKhoan tk)
        {
            sqltk.themtk(tk);
        }
        public void suamk(string user, string pass)
        {
            ck.Id = user;
            ck.Pass = pass;
            sqltk.suamk(ck);
        }
    }
}
