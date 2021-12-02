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
using ToKhaiYTe.Business.EntitiesClass;
using ToKhaiYTe.DataAccess;
using ToKhaiYTe.Business.Component;

namespace ToKhaiYTe.Presentation
{
    public partial class fr_LopKhoa : Form
    {
        public fr_LopKhoa()
        {
            InitializeComponent();
        }
        ConnectDB cn = new ConnectDB();
        E_tb_Lop thucthi2 = new E_tb_Lop();
        E_tb_Khoa thucthi1 = new E_tb_Khoa();
        string idkhoa;
        bool them;

        private void fr_LopKhoa_Load(object sender, EventArgs e)
        {
            hienthiKhoa();
            hienthiLop();
            khoitaoluoiKhoa();
            khoitaoluoiLop();
            loadtenKhoa();
            setnull();
            locktextK();
            locktextL();
        }
        private void locktextK()
        {
            txtMakhoa.Enabled = false;
            txtTenkhoa.Enabled = false;

            btnLuuKhoa.Enabled = false;
            btnXoaKhoa.Enabled = true;
            btnThemKhoa.Enabled = true;
            btnSuaKhoa.Enabled = true;
        }
        private void locktextL()
        {
            txtMalop.Enabled = false;
            txtTenlop.Enabled = false;
            cbTenkhoa.Enabled = false;

            btnLuuLop.Enabled = false;
            btnThemLop.Enabled = true;
            btnSuaLop.Enabled = true;
            btnXoaLop.Enabled = true;
        }
        private void UnlocktextK()
        {
            txtMakhoa.Enabled = true;
            txtTenkhoa.Enabled = true;

            btnLuuKhoa.Enabled = true;
            btnXoaKhoa.Enabled = false;
            btnThemKhoa.Enabled = false;
            btnSuaKhoa.Enabled = false;
        }
        private void UnlocktextL()
        {
            txtMalop.Enabled = true;
            txtTenlop.Enabled = true;
            cbTenkhoa.Enabled = true;

            btnLuuLop.Enabled = true;
            btnThemLop.Enabled = false;
            btnSuaLop.Enabled = false;
            btnXoaLop.Enabled = false;
        }
        private void setnull()
        {
            txtMakhoa.Text = "";
            txtMalop.Text = "";
            txtTenkhoa.Text = "";
            txtTenlop.Text = "";
            cbTenkhoa.SelectedIndex = -1;
        }
        private void hienthiKhoa()
        {
            msdsKhoa.DataSource = cn.taobang(@"exec loadtenkhoa");
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
        private void hienthiLop()
        {
            msdsLop.DataSource = cn.taobang(@"exec loadalllop");
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
        void loadtenKhoa()
        {
            List<EC_tb_Khoa> list = thucthi1.loadkhoa();
            cbTenkhoa.DataSource = list;
            cbTenkhoa.DisplayMember = "TenKhoa";
        }
        public void khoitaoluoiLop()
        {
            msdsLop.EnableHeadersVisualStyles = false;
            msdsLop.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msdsLop.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msdsLop.Columns[0].HeaderText = "Mã Lớp";
            msdsLop.Columns[0].Frozen = true;
            msdsLop.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msdsLop.Columns[0].Width = 150;
            msdsLop.Columns[0].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msdsLop.Columns[1].HeaderText = "Tên Lớp";
            msdsLop.Columns[1].Width = 150;
            msdsLop.Columns[1].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msdsLop.Columns[2].HeaderText = "Tên Khoa";
            msdsLop.Columns[2].Width = 150;
            msdsLop.Columns[2].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
        }
        public void khoitaoluoiKhoa()
        {
            msdsKhoa.EnableHeadersVisualStyles = false;
            msdsKhoa.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msdsKhoa.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msdsKhoa.Columns[0].HeaderText = "Mã Khoa";
            msdsKhoa.Columns[0].Frozen = true;
            msdsKhoa.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msdsKhoa.Columns[0].Width = 220;
            msdsKhoa.Columns[0].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msdsKhoa.Columns[1].HeaderText = "Tên Khoa";
            msdsKhoa.Columns[1].Width = 220;
            msdsKhoa.Columns[1].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
        }
        

        private void msdsKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            List<EC_tb_Lop> list = thucthi2.loadTenLop(msdsKhoa.Rows[dong].Cells[0].Value.ToString());
            msdsLop.DataSource = list;
            txtMakhoa.Text = msdsKhoa.Rows[dong].Cells[0].Value.ToString();
            txtTenkhoa.Text = msdsKhoa.Rows[dong].Cells[1].Value.ToString();
            khoitaoluoiLop();
        }

        private void btnThemKhoa_Click(object sender, EventArgs e)
        {
            them = true;
            UnlocktextK();
            pnThemK.Visible = true;
            setnull();
            txtMakhoa.Focus();

        }

        private void cbTenkhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
            {
                return;
            }
            EC_tb_Khoa ec = cb.SelectedItem as EC_tb_Khoa;
            idkhoa = ec.IdKhoa;
        }

        private void btnLuuKhoa_Click(object sender, EventArgs e)
        {
            if (txtMakhoa.Text != "")
            {
                if (txtTenkhoa.Text != "")
                {
                    if(them == true)
                    {
                        try
                        {

                            thucthi1.themKhoa(txtMakhoa.Text,txtTenkhoa.Text);
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

                            thucthi1.suaKhoa(txtMakhoa.Text,txtTenkhoa.Text);
                            MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    locktextK();
                    pnThemK.Visible = false;
                    hienthiKhoa();
                    khoitaoluoiKhoa();
                    hienthiLop();
                    khoitaoluoiLop();
                }
                else
                {
                    MessageBox.Show("Tên Khoa Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txtTenkhoa.Focus();
                }
            }
            else
            {
                MessageBox.Show("Mã Khoa Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                txtMakhoa.Focus();
            }
        }

        private void btnSuaKhoa_Click(object sender, EventArgs e)
        {
            them = false;
            UnlocktextK();
            txtMakhoa.ReadOnly = true;
            pnThemK.Visible = true;
        }

        private void btnXoaKhoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                   

                    thucthi1.xoaKhoa(txtMakhoa.Text);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienthiKhoa();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
        }

        private void btnThemLop_Click(object sender, EventArgs e)
        {
            them = true;
            UnlocktextL();
            setnull();
            pnThemL.Visible = true;
            txtMalop.Focus();
        }

        private void btnLuuLop_Click(object sender, EventArgs e)
        {
            if (txtMalop.Text!="")
            {
                if (txtTenlop.Text!="")
                {
                    if (cbTenkhoa.SelectedIndex!=-1)
                    {
                        if (them == true)
                        {
                            try
                            {
                                thucthi2.themLop(txtMalop.Text, txtTenlop.Text,idkhoa);
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
                                thucthi2.suaLop(txtMalop.Text, txtTenlop.Text, idkhoa);
                                MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        locktextL();
                        hienthiLop();
                        khoitaoluoiLop();
                        pnThemL.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Tên Khoa Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        cbTenkhoa.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Tên Lớp Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txtTenlop.Focus();
                }
            }
            else
            {
                MessageBox.Show("Mã Lớp Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                txtMalop.Focus();
            }
        }

        private void btnSuaLop_Click(object sender, EventArgs e)
        {
            them = false;
            UnlocktextL();
            txtMalop.ReadOnly = true;
            pnThemL.Visible = true;
        }

        private void btnXoaLop_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {


                    thucthi2.xoaLop(txtMalop.Text);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienthiKhoa();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            setnull();
            pnThemK.Visible = false;
            locktextK();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setnull();
            pnThemL.Visible = false;
            locktextL();
        }

        private void msdsLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            txtMalop.Text = msdsLop.Rows[dong].Cells[0].Value.ToString();
            txtTenlop.Text = msdsLop.Rows[dong].Cells[1].Value.ToString();
            cbTenkhoa.Text = msdsLop.Rows[dong].Cells[2].Value.ToString();
        }
    }
}
