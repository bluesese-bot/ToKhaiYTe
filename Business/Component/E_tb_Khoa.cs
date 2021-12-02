using System.Collections.Generic;
using ToKhaiYTe.DataAccess;
using ToKhaiYTe.Business.EntitiesClass;
namespace ToKhaiYTe.Business.Component
{
    class E_tb_Khoa
    {
        SQL_tb_Khoa sql = new SQL_tb_Khoa();
        EC_tb_Khoa ck = new EC_tb_Khoa();

        public List<EC_tb_Khoa> loadkhoa()
        {
            return sql.loadtenkhoa();
        }
        public void themKhoa(string makhoa,string tenkhoa)
        {
            ck.IdKhoa = makhoa;
            ck.Tenkhoa = tenkhoa;
            sql.themKhoa(ck);
        }
        public void suaKhoa(string makhoa, string tenkhoa)
        {
            ck.IdKhoa = makhoa;
            ck.Tenkhoa = tenkhoa;
            sql.suaKhoa(ck);
        }
        public void xoaKhoa(string makhoa)
        {
            ck.IdKhoa = makhoa;
            sql.xoaKhoa(ck);
        }
    }
}
