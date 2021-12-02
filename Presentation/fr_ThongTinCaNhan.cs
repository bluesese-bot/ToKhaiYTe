using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToKhaiYTe.Business.Component;
using ToKhaiYTe.Business.EntitiesClass;

namespace ToKhaiYTe.Presentation
{
    public partial class fr_ThongTinCaNhan : Form
    {
        private string id;
        private string gioitinh;
        private string idlop;
        E_tb_User thucthi = new E_tb_User();
        E_tb_Khoa thucthi1 = new E_tb_Khoa();
        E_tb_Lop thucthi2 = new E_tb_Lop();
        public string Id { get => id; set => id = value; }
        public fr_ThongTinCaNhan(string id)
        {
            InitializeComponent();
            Id = id;
        }
        private void LoadTT()
        {
            List<EC_tb_User> listBillinfr = thucthi.loadTTsv(id);
            foreach (EC_tb_User item in listBillinfr)
            {
                txtMSV.Text = item.Id;
                txtHoTen.Text = item.Hoten;
                dtNS.Text = item.Ngaysinh;
                txtCMT.Text = item.Socmtnd;
                txtDiachi.Text = item.Diachi;
                txtSdt.Text = item.Sdt;
                txtBHXH.Text = item.Thebhyt;
                txtGmail.Text = item.Email;
                cbLop.Text = item.Idlop;
                cbKhoa.Text = item.Khoa;
                if(item.Gioitinh == rbtNam.Text)
                {
                    rbtNam.Checked = true;
                }
                else
                {
                    if(item.Gioitinh == rbtNU.Text)
                    {
                        rbtNU.Checked = true;
                    }
                    else
                    {
                        rbtKhac.Checked = true;
                    }
                }
            }
        }
        void loadtenKhoa()
        {
            List<EC_tb_Khoa> list = thucthi1.loadkhoa();
            cbKhoa.DataSource = list;
            cbKhoa.DisplayMember = "TenKhoa";
        }
        void loadTenLop(string id)
        {
            List<EC_tb_Lop> list = thucthi2.loadTenLop(id);
            cbLop.DataSource = list;
            cbLop.DisplayMember = "TENLOP";
        }
        private void fr_ThongTinCaNhan_Load(object sender, EventArgs e)
        {
            loadtenKhoa();
            LoadTT();
            locktext();
        }
        private void locktext()
        {
            txtMSV.Enabled=false;
            txtHoTen.Enabled = false;
            dtNS.Enabled = false;
            txtCMT.Enabled = false;
            txtDiachi.Enabled = false;
            txtSdt.Enabled = false;
            txtBHXH.Enabled = false;
            txtGmail.Enabled = false;
            cbLop.Enabled = false;
            cbKhoa.Enabled = false;
        }
        private void unlocktext()
        {
            txtMSV.Enabled = false;
            txtHoTen.Enabled = true;
            dtNS.Enabled = true;
            txtCMT.Enabled = true;
            txtDiachi.Enabled = true;
            txtSdt.Enabled = true;
            txtBHXH.Enabled = true;
            txtGmail.Enabled = true;
            cbLop.Enabled = true;
            cbKhoa.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            unlocktext();
            button1.Visible = false;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text !="")
            {
                if (txtCMT.Text != "")
                {
                    if (txtDiachi.Text != "")
                    {
                        if (txtSdt.Text != "")
                        {
                            if (txtGmail.Text != "")
                             {
                                thucthi.suaND(txtMSV.Text,txtHoTen.Text,dtNS.Value.ToString(),gioitinh,txtCMT.Text,txtDiachi.Text,txtSdt.Text, txtBHXH.Text,txtGmail.Text,idlop);
                                MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadTT();
                                locktext();
                                button2.Visible = false;
                                button1.Visible = true;
                            }
                            else
                            {
                                MessageBox.Show("Gmail không được để trống", "Chú Ý", MessageBoxButtons.OK);
                                txtGmail.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Số điện thoại Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                            txtSdt.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Địa chỉ Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txtDiachi.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("CMT/TCC không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txtCMT.Focus();
                }
            }
            else
            {
                MessageBox.Show("Họ và Tên không được để trống", "Chú Ý", MessageBoxButtons.OK);
                txtHoTen.Focus();
            }
        }

        private void rbtNam_CheckedChanged(object sender, EventArgs e)
        {
            gioitinh = rbtNam.Text;
        }

        private void rbtNU_CheckedChanged(object sender, EventArgs e)
        {
            gioitinh = rbtNU.Text;
        }

        private void rbtKhac_CheckedChanged(object sender, EventArgs e)
        {
            gioitinh = rbtKhac.Text;
        }

        private void cbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id;
            ComboBox cb = sender as ComboBox;
            if(cb.SelectedItem == null)
            {
                return;
            }
            EC_tb_Khoa ec = cb.SelectedItem as EC_tb_Khoa;
            id = ec.IdKhoa;
            loadTenLop(id);
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
    }
}
