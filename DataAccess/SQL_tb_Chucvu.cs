using System.Collections.Generic;
using System.Data;
using ToKhaiYTe.Business.EntitiesClass;

namespace ToKhaiYTe.DataAccess
{
    class SQL_tb_Chucvu
    {
        ConnectDB cn = new ConnectDB();
        public List<EC_tb_Chucvu> loadcv()
        {
            List<EC_tb_Chucvu> list = new List<EC_tb_Chucvu>();
            DataTable data = cn.taobang(@"exec loadchucvu");
            foreach (DataRow item in data.Rows)
            {
                EC_tb_Chucvu ck = new EC_tb_Chucvu(item);
                list.Add(ck);
            }
            return list;
        }
    }
}
