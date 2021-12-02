using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToKhaiYTe.Business.EntitiesClass
{
    class EC_tb_Chucvu
    {
        private string id;
        private string ten;

        public EC_tb_Chucvu()
        {
        }

        public EC_tb_Chucvu(DataRow row)
        {
            this.Id = row[0].ToString();
            this.Ten = row[1].ToString();
        }

        public string Id { get => id; set => id = value; }
        public string Ten { get => ten; set => ten = value; }
    }
}
