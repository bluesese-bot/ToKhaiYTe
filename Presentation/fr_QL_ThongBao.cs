using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToKhaiYTe.DataAccess;
using ToKhaiYTe.Business.Component;

namespace ToKhaiYTe.Presentation
{
    public partial class fr_QL_ThongBao : Form
    {
        public fr_QL_ThongBao()
        {
            InitializeComponent();
        }
        E_tb_Thongbao thucthi = new E_tb_Thongbao();
        bool them;
        private void hienthiTB()
        {
            msds.DataSource = thucthi.loadThongBao();
        }

        private void fr_QL_ThongBao_Load(object sender, EventArgs e)
        {
            hienthiTB();
            khoitaoluoi();
            setnull();
            locktext();
        }
        public void khoitaoluoi()
        {
            msds.EnableHeadersVisualStyles = false;
            msds.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].HeaderText = "Mã Thông Báo";
            msds.Columns[0].Frozen = true;
            msds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].Width = 200;
            msds.Columns[0].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[1].HeaderText = "Tiêu Đề";
            msds.Columns[1].Width = 150;
            msds.Columns[1].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[2].HeaderText = "Nội Dung";
            msds.Columns[2].Width = 480;
            msds.Columns[2].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
        }
        public void setnull()
        {
            txtMatb.Text = "";
            txtTieuDe.Text = "";
            txtNoiDung.Text = "";
        }
        private void locktext()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            pnTB.Visible = false;
        }
        private void Unlocktext()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            pnTB.Visible = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            setnull();
            Unlocktext();
            txtMatb.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMatb.Text!="")
            {
                if (txtTieuDe.Text !="")
                {
                    if (them==true)
                    {
                        try
                        {
                            thucthi.themtb(txtMatb.Text, txtTieuDe.Text, txtNoiDung.Text);
                            MessageBox.Show("Đã Thêm Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        try
                        {
                            thucthi.suatb(txtMatb.Text, txtTieuDe.Text, txtNoiDung.Text);
                            MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    locktext();
                    hienthiTB();
                    khoitaoluoi();
                }
                else
                {
                    MessageBox.Show("Tiêu đề Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txtTieuDe.Focus();
                }
            }
            else
            {
                MessageBox.Show("Mã thông báo Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                txtTieuDe.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            setnull();
            locktext();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;
            Unlocktext();
            txtMatb.ReadOnly = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {


                    thucthi.xoatb(txtMatb.Text);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienthiTB();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
        }

        private void msds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            txtMatb.Text = msds.Rows[dong].Cells[0].Value.ToString();
            txtTieuDe.Text = msds.Rows[dong].Cells[1].Value.ToString();
            txtNoiDung.Text = msds.Rows[dong].Cells[2].Value.ToString();
        }
    }
}
