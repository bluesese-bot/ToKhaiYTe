using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToKhaiYTe.DataAccess;
using ToKhaiYTe.Business.Component;
using ToKhaiYTe.Business.EntitiesClass;

namespace ToKhaiYTe.Presentation
{
    public partial class fr_QL_Taikhoan : Form
    {
        public fr_QL_Taikhoan()
        {
            InitializeComponent();
        }
        int dong;
        string gioitinh;
        ConnectDB cn = new ConnectDB();
        E_tb_TaiKhoan thucthi = new E_tb_TaiKhoan();
        EC_tb_TaiKhoan ck = new EC_tb_TaiKhoan();
        EC_tb_User ck1 = new EC_tb_User();
        E_tb_User thucthi1 = new E_tb_User();
        E_tb_Khoa thucthi2 = new E_tb_Khoa();
        E_tb_Lop thucthi3 = new E_tb_Lop();
        E_tb_Chucvu thucthi4 = new E_tb_Chucvu();
        string idlop;
        string idcv;
        private void setnull()
        {
            txtHoTen.Text = "";
            dtNS.Value = DateTime.Now;
            txtGmail.Text = "";
            cbcv.SelectedIndex = -1;
            txtSDT.Text = "";
            txtTK.Text = "";
            txtMK.Text = "";
            txtMK2.Text = "";
            rbtnKhac.Checked = false;
            rbtnNam.Checked = false;
            rbtnNu.Checked = false;
        }
        public void khoitaoluoi()
        {
            msds.EnableHeadersVisualStyles = false;
            msds.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].HeaderText = "Mã Đăng Nhập";
            msds.Columns[0].Frozen = true;
            msds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].Width = 300;
            msds.Columns[0].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[1].HeaderText = "Họ Tên";
            msds.Columns[1].Width = 300;
            msds.Columns[1].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[2].HeaderText = "Chức Vụ";
            msds.Columns[2].Width = 300;
            msds.Columns[2].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
        }
        private void hienthi()
        {
            msds.DataSource = cn.taobang("select_taikhoanAll");
            SqlConnection con = cn.getcon();
            con.Open();
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (panel1.Visible==false)
            {
                panel1.Visible = true;
                btnThem.Visible = false;
            }
        }

        private void fr_QL_Taikhoan_Load(object sender, EventArgs e)
        {
            hienthi();
            khoitaoluoi();
            loadtenKhoa();
            loadcv();
        }

        private void msds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.Id = ck1.Id =msds.Rows[dong].Cells[0].Value.ToString();

                    thucthi.xoatk(ck);
                    thucthi1.xoaND(ck1);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienthi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.Compare(txtMK.Text, txtMK2.Text, true) == 0)
                {
                    if (thucthi.kiemtrauser(txtTK.Text, txtMK.Text))
                    {
                        ck.Id = ck1.Id = txtTK.Text; ;
                        ck.Pass = txtMK.Text;
                        ck1.Hoten = txtHoTen.Text;
                        ck1.Ngaysinh = dtNS.Value.ToString();
                        ck1.Gioitinh = gioitinh;
                        ck1.Sdt = txtSDT.Text;
                        ck1.Email = txtGmail.Text;
                        ck1.Chucvu = idcv;
                        ck1.Idlop = idlop;
                        thucthi1.themND(ck1);
                        thucthi.themtk(ck);
                        hienthi();
                        MessageBox.Show("Tạo Thành Công", "Chúc Mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Tài Khoản Đã Tồn Tại", "Chúc Mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTK.Focus();
                    }
                    setnull();
                }
                else
                {
                    MessageBox.Show("Hai Mật Khẩu Không Trùng Khớp", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMK.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                panel1.Visible = false;
                btnThem.Visible = true;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            btnThem.Visible = true;
            setnull();
        }

        private void rbtnNam_CheckedChanged(object sender, EventArgs e)
        {
            gioitinh = rbtnNam.Text;
        }

        private void rbtnNu_CheckedChanged(object sender, EventArgs e)
        {
            gioitinh = rbtnNu.Text;
        }

        private void rbtnKhac_CheckedChanged(object sender, EventArgs e)
        {
            gioitinh = rbtnKhac.Text;
        }

        private void cbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
            {
                return;
            }
            EC_tb_Khoa ec = cb.SelectedItem as EC_tb_Khoa;
            id = ec.IdKhoa;
            loadTenLop(id);
        }
        void loadtenKhoa()
        {
            List<EC_tb_Khoa> list = thucthi2.loadkhoa();
            cbKhoa.DataSource = list;
            cbKhoa.DisplayMember = "TenKhoa";
        }
        void loadTenLop(string id)
        {
            List<EC_tb_Lop> list = thucthi3.loadTenLop(id);
            cbLop.DataSource = list;
            cbLop.DisplayMember = "TENLOP";
        }
        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
            {
                return;
            }
            EC_tb_Lop ec = cb.SelectedItem as EC_tb_Lop;
            idlop = ec.Idlop;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
            {
                return;
            }
            EC_tb_Chucvu ec = cb.SelectedItem as EC_tb_Chucvu;
            idcv = ec.Id;
        }
        void loadcv()
        {
            List<EC_tb_Chucvu> list = thucthi4.loadcv();
            cbcv.DataSource = list;
            cbcv.DisplayMember = "Ten";
        }
    }
}
