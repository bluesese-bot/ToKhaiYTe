using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToKhaiYTe.Business.Component;
using ToKhaiYTe.Business.EntitiesClass;

namespace ToKhaiYTe.Presentation
{
    public partial class fr_DangKy : Form
    {
        E_tb_TaiKhoan thucthi = new E_tb_TaiKhoan();
        E_tb_User thucthi1 = new E_tb_User();
        EC_tb_TaiKhoan ck = new EC_tb_TaiKhoan();
        EC_tb_User ck1 = new EC_tb_User();
        E_tb_Khoa thucthi2 = new E_tb_Khoa();
        E_tb_Lop thucthi3 = new E_tb_Lop();
        string gioiTinh;
        string idlop;
        public fr_DangKy()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fr_DangKy_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.Compare(txtPass.Text, txtPass2.Text, true) == 0)
                {
                    if (thucthi.kiemtrauser(txtTK.Text, txtPass.Text))
                    {
                        try
                        {
                            ck.Id = ck1.Id = txtTK.Text; ;
                            ck.Pass = txtPass.Text;
                            ck1.Hoten = txtTen.Text;
                            ck1.Ngaysinh = dtNS.Value.ToString();
                            ck1.Gioitinh = gioiTinh;
                            ck1.Sdt = txtSDT.Text;
                            ck1.Email = txtGmail.Text;
                            ck1.Idlop = idlop;
                            thucthi1.themNDisHS(ck1);
                            thucthi.themtk(ck);
                            MessageBox.Show("Tạo Thành Công", "Chúc Mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Tài Khoản Đã Tồn Tại", "Chúc Mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTK.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Hai Mật Khẩu Không Trùng Khớp", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPass.Text = null;
                    txtPass2.Text = null;
                    txtPass.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtNam_CheckedChanged(object sender, EventArgs e)
        {
            gioiTinh = txtNam.Text;
        }

        private void txtNu_CheckedChanged(object sender, EventArgs e)
        {
            gioiTinh = txtNu.Text;
        }

        private void txtKhac_CheckedChanged(object sender, EventArgs e)
        {
            gioiTinh = txtKhac.Text;
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
        void loadTenLop(string id)
        {
            List<EC_tb_Lop> list = thucthi3.loadTenLop(id);
            cbLop.DataSource = list;
            cbLop.DisplayMember = "TENLOP";
        }
        void loadtenKhoa()
        {
            List<EC_tb_Khoa> list = thucthi2.loadkhoa();
            cbKhoa.DataSource = list;
            cbKhoa.DisplayMember = "TenKhoa";
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

        private void fr_DangKy_Load(object sender, EventArgs e)
        {
            loadtenKhoa();
            cbKhoa.SelectedIndex = -1;
            cbLop.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPass2.UseSystemPasswordChar = true;
            button3.Visible = true;
            button2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtPass2.UseSystemPasswordChar = false;
            button2.Visible = true;
            button3.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
            button4.Visible = true;
            button5.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = false;
            button5.Visible = true;
            button4.Visible = false;
        }
    }
}
