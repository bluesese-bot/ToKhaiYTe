using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToKhaiYTe.Business.EntitiesClass
{
    class EC_tb_User
    {
        private string id;
        private string hoten;
        private string ngaysinh;
        private string gioitinh;
        private string socmtnd;
        private string diachi;
        private string sdt;
        private string thebhyt;
        private string email;
        private string chucvu;
        private string idlop;
        private string trangthai;
        private string khoa;
        public EC_tb_User(DataRow row)
        {
            this.id = row[0].ToString();
            this.hoten = row[1].ToString();
            this.ngaysinh = row[2].ToString();
            this.gioitinh = row[3].ToString();
            this.socmtnd = row[4].ToString();
            this.diachi = row[5].ToString();
            this.sdt = row[6].ToString();
            this.thebhyt = row[7].ToString();
            this.email = row[8].ToString();
            this.chucvu = row[9].ToString();
            this.idlop = row[10].ToString();
            this.khoa = row[11].ToString();
        }

        public EC_tb_User()
        {

        }

        public string Id { get => id; set => id = value; }
        public string Hoten { get => hoten; set => hoten = value; }
        public string Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public string Socmtnd { get => socmtnd; set => socmtnd = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Thebhyt { get => thebhyt; set => thebhyt = value; }
        public string Email { get => email; set => email = value; }
        public string Chucvu { get => chucvu; set => chucvu = value; }
        public string Idlop { get => idlop; set => idlop = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
        public string Khoa { get => khoa; set => khoa = value; }
    }
}
