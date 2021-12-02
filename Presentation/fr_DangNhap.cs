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
    public partial class fr_DangNhap : Form
    {
        E_tb_TaiKhoan thucthi = new E_tb_TaiKhoan();
        EC_tb_TaiKhoan ck = new EC_tb_TaiKhoan();
        public fr_DangNhap()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            button1.Focus();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void txtTaiKhoan_Enter(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "Tên Đăng Nhập")
            {
                txtTaiKhoan.Text = "";
                txtTaiKhoan.ForeColor = Color.Black;
                label2.BackColor = Color.MediumAquamarine;
            }
        }

        private void txtTaiKhoan_Leave(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "")
            {
                txtTaiKhoan.Text = "Tên Đăng Nhập";
                label2.BackColor = Color.Black;
            }
        }

        private void txtMK_Enter(object sender, EventArgs e)
        {
            if (txtMK.Text == "Mật Khẩu")
            {
                txtMK.Text = "";
                txtMK.ForeColor = Color.Black;
                label1.BackColor = Color.MediumAquamarine;
                txtMK.UseSystemPasswordChar = true;
            }
        }

        private void txtMK_Leave(object sender, EventArgs e)
        {
            if (txtMK.Text == "")
            {
                txtMK.Text = "Mật Khẩu";
                label1.BackColor = Color.Black;
                txtMK.UseSystemPasswordChar = false;
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            fr_DoiMatKhau fr = new fr_DoiMatKhau();
            fr.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            fr_DangKy fr = new fr_DangKy();
            fr.ShowDialog();
        }
        public  void ThreadProc()
        {
            fr_Main fr = new fr_Main();
            fr.Id = ck.Id;
            Application.Run(fr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text!= "" || string.Compare(txtTaiKhoan.Text,"Tên Đăng Nhập",true)!=0)
            {
                if (txtMK.Text!="" || string.Compare(txtMK.Text,"Mật Khẩu", true) != 0 )
                {
                    try
                    {
                        ck.Id = txtTaiKhoan.Text;
                        ck.Pass = txtMK.Text;
                        if (!thucthi.kiemtrauser(ck.Id, ck.Pass))
                        {

                            MessageBox.Show("Đăng Nhập Thành Công", "Chúc Mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
                            t.Start();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản đăng nhập chưa đúng. Vui lòng kiểm tra lại.", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtTaiKhoan.Text = "Tên Đăng Nhập";
                            txtMK.Text = "Mật Khẩu";
                            txtTaiKhoan.Focus();
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu không Được để trống", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMK.Focus();
                }
            }
            else
            {
                MessageBox.Show("Tài khoản không Được để trống", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTaiKhoan.Focus();
            }
        }

        private void fr_DangNhap_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtMK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                button1.Enabled = false;
                button1_Click(sender, e);
            }
        }

        private void txtTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                SendKeys.Send("{TAB}");
        }



        private void button2_Click(object sender, EventArgs e)
        {
            txtMK.UseSystemPasswordChar = true;
            button3.Visible = true;
            button2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtMK.UseSystemPasswordChar = false;
            button2.Visible = true;
            button3.Visible = false;
        }
    }
}
