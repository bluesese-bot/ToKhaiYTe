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

namespace ToKhaiYTe.Presentation
{
    public partial class fr_DoiMatKhau : Form
    {
        E_tb_User thucthi = new E_tb_User();
        E_tb_TaiKhoan thucthi1 = new E_tb_TaiKhoan();
        string str1;
        string id;
        public fr_DoiMatKhau()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void button1_Click(object sender, EventArgs e)
        {
            if (raSDT.Checked)
            {
                str1 = txtSDT.Text;
            } else
            {
                str1 = txtGMT.Text;
            }    
            try
            {
                if (!thucthi.checkQMK(str1, txtTen.Text))
                {
                    id=thucthi.loadid(str1, txtTen.Text);
                    grb_Xacminh.Visible = false;
                    grb_Nhapmk.Visible = true;
                    lbimg2.Image = Image.FromFile(@"E:\To_Khai_Y_Te\ToKhaiYTe\Resources\2-filled-64.png");
                    lbcenter_12.ForeColor = Color.FromArgb(84, 255, 159);
                }
                else
                {
                    MessageBox.Show("Tài Khoản không tồn tại", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTen.Text = null;
                    txtGMT.Text = null;
                    txtSDT.Text = null;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.Compare(txtPass.Text, txtPass2.Text, true) == 0)
                {
                    thucthi1.suamk(str1,txtPass.Text);
                    grb_Nhapmk.Visible = false;
                    grb_Hoanthanh.Visible = true;
                    lbimg3.Image = Image.FromFile(@"E:\To_Khai_Y_Te\ToKhaiYTe\Resources\3-filled-64.png");
                    lbcenter_23.ForeColor = Color.FromArgb(84, 255, 159);
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

        private void fr_DoiMK_Load(object sender, EventArgs e)
        {
            grb_Xacminh.Visible = true;
            grb_Nhapmk.Visible = false;
            grb_Hoanthanh.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (txtTen.Text == "Tên người dùng")
            {
                txtTen.Text = "";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (txtTen.Text == "")
            {
                txtTen.Text = "Tên người dùng";
            }
        }

        private void fr_DoiMatKhau_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void rdGMT_CheckedChanged(object sender, EventArgs e)
        {
            txtGMT.Enabled = true;
            txtSDT.Enabled = false;
            txtSDT.Text = null;
        }

        private void raSDT_CheckedChanged(object sender, EventArgs e)
        {
            txtSDT.Enabled = true;
            txtGMT.Enabled = false;
            txtGMT.Text = null;
        }
    }
}
