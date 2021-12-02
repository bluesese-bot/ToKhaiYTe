using System.Collections.Generic;
using ToKhaiYTe.DataAccess;
using ToKhaiYTe.Business.EntitiesClass;

namespace ToKhaiYTe.Business.Component
{
    class E_tb_Chucvu
    {
        SQL_tb_Chucvu sql = new SQL_tb_Chucvu();

        public List<EC_tb_Chucvu> loadcv()
        {
            return sql.loadcv();
        }
    }
}
