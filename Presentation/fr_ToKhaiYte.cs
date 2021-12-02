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

namespace ToKhaiYTe.Presentation
{
    public partial class fr_ToKhaiYte : Form
    {
        private string IDNguoDung;
        private string Sot;
        private string dosot;
        private string Ho;
        private string KhoTho;
        private string DauHong;
        private string ViempPhoi;
        private string MetMoi;
        private string trieuchungkhac;
        private string TiepXucF0;
        private string TiepXucF1;
        private string TiepXucNguoiCoBieuHien;
        private string TiepXucNguoiNuocNgoaiCoCV;
        private string TuHoacQuaVungDichVe;
        private string TuNgay;
        private string DenNgay;
        private string DiaDiemKhoiHanh;
        private string PhuongTienDiChuyen;
        private string Gan = "Không";
        private string Mau = "Không";
        private string Phoi = "Không";
        private string Than = "Không";
        private string TimMach = "Không";
        private string HuyetApCao = "Không";
        private string TieuDuong = "Không";
        private string UngThu = "Không";
        private string GhepTangXuong = "Không";
        private string HIVGMD = "Không";
        private string CoThai = "Không";
        E_tb_ToKhai thucthi = new E_tb_ToKhai();
        public fr_ToKhaiYte()
        {
            InitializeComponent();
        }
        public fr_ToKhaiYte(string id)
        {
            InitializeComponent();
            this.IDNguoDung = id;
        }


        private void rbtCosot_CheckedChanged(object sender, EventArgs e)
        {
            txtDosot.Enabled = true;
            Sot = rbtCosot.Text;
        }

        private void rbtKhongSot_CheckedChanged(object sender, EventArgs e)
        {
            txtDosot.Enabled = false;
            Sot = rbtKhongSot.Text;
        }

        private void rbtCoKhotho_CheckedChanged(object sender, EventArgs e)
        {
            KhoTho = rbtCoKhotho.Text;
        }

        private void rbtKhongKhotho_CheckedChanged(object sender, EventArgs e)
        {
            KhoTho = rbtKhongKhotho.Text;
        }

        private void rbtCoMetmoi_CheckedChanged(object sender, EventArgs e)
        {
            MetMoi = rbtCoMetmoi.Text;
        }

        private void rbtKhongmetMoi_CheckedChanged(object sender, EventArgs e)
        {
            MetMoi = rbtKhongmetMoi.Text;
        }

        private void rbtCoDauHong_CheckedChanged(object sender, EventArgs e)
        {
            DauHong = rbtCoDauHong.Text;
        }

        private void rbtKhongDauHong_CheckedChanged(object sender, EventArgs e)
        {
            DauHong = rbtKhongDauHong.Text;
        }

        private void rbtCoTrieuChungKhac_CheckedChanged(object sender, EventArgs e)
        {
            txtTrieuChungKhac.Enabled = true;
        }

        private void rbtKhongTrieuchungkhac_CheckedChanged(object sender, EventArgs e)
        {
            trieuchungkhac = rbtKhongTrieuchungkhac.Text;
            txtTrieuChungKhac.Enabled = false;
        }

        private void rbtCoHo_CheckedChanged(object sender, EventArgs e)
        {
            Ho = rbtCoHo.Text;
        }

        private void rbtKhongHo_CheckedChanged(object sender, EventArgs e)
        {
            Ho = rbtKhongHo.Text;
        }

        private void rbtCoViemPhoi_CheckedChanged(object sender, EventArgs e)
        {
            ViempPhoi = rbtCoViemPhoi.Text;
        }

        private void rbtKhongViemPhoi_CheckedChanged(object sender, EventArgs e)
        {
            ViempPhoi = rbtKhongViemPhoi.Text;
        }

        private void rbtCoTSF1_CheckedChanged(object sender, EventArgs e)
        {
            TiepXucF1 = rbtCoTSF1.Text;
        }

        private void rbtKhongTsF1_CheckedChanged(object sender, EventArgs e)
        {
            TiepXucF1 = rbtKhongTsF1.Text;
        }

        private void rbtCoTSF0_CheckedChanged(object sender, EventArgs e)
        {
            TiepXucF0 = rbtCoTSF0.Text;
        }

        private void rbtKhongTSF0_CheckedChanged(object sender, EventArgs e)
        {
            TiepXucF0 = rbtKhongTSF0.Text;
        }

        private void rbtCoTSNbhien_CheckedChanged(object sender, EventArgs e)
        {
            TiepXucNguoiCoBieuHien = rbtCoTSNbhien.Text;
        }

        private void rbtKhongNBHIen_CheckedChanged(object sender, EventArgs e)
        {
            TiepXucNguoiCoBieuHien = rbtKhongNBHIen.Text;
        }

        private void rbtCoNNN_CheckedChanged(object sender, EventArgs e)
        {
            TiepXucNguoiNuocNgoaiCoCV = rbtCoNNN.Text;
        }

        private void rbtKhongNNN_CheckedChanged(object sender, EventArgs e)
        {
            TiepXucNguoiNuocNgoaiCoCV = rbtKhongNNN.Text;
        }

        private void rbtCoDiquavungdich_CheckedChanged(object sender, EventArgs e)
        {
            TuHoacQuaVungDichVe = rbtCoDiquavungdich.Text;
        }

        private void rbtKhongDiquaVung_CheckedChanged(object sender, EventArgs e)
        {
            TuHoacQuaVungDichVe = rbtKhongDiquaVung.Text;
        }

        private void btnGuiKB_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkCamKet.Checked)
                {
                    dosot = txtDosot.Text;
                    if (rbtCoTrieuChungKhac.Checked == true)
                    {
                        trieuchungkhac = txtTrieuChungKhac.Text;
                    }
                    TuNgay = dtTuNgay.Value.ToString();
                    DenNgay = dtDenngay.Value.ToString();
                    DiaDiemKhoiHanh = txtDiaDiemKH.Text;
                    PhuongTienDiChuyen = txtPhuongTien.Text;
                    if (checkGan.CheckState == CheckState.Checked)
                    {
                        Gan = "Có";
                    }
                    if (checkMau.CheckState == CheckState.Checked)
                    {
                        Mau = "Có";
                    }
                    if (checkphoi.CheckState == CheckState.Checked)
                    {
                        Phoi = "Có";
                    }
                    if (checkthan.CheckState == CheckState.Checked)
                    {
                        Than = "Có";
                    }
                    if (checkTimMach.CheckState == CheckState.Checked)
                    {
                        TimMach = "Có";
                    }
                    if (checkHuyetap.CheckState == CheckState.Checked)
                    {
                        HuyetApCao = "Có";
                    }
                    if (checkTieuduong.CheckState == CheckState.Checked)
                    {
                        TieuDuong = "Có";
                    }
                    if (checkUngthu.CheckState == CheckState.Checked)
                    {
                        UngThu = "Có";
                    }
                    if (checkGheptang.CheckState == CheckState.Checked)
                    {
                        GhepTangXuong = "Có";
                    }
                    if (checkHIV.CheckState == CheckState.Checked)
                    {
                        HIVGMD = "Có";
                    }
                    if (checkCothai.CheckState == CheckState.Checked)
                    {
                        CoThai = "Có";
                    }
                    thucthi.themTokhai(IDNguoDung, Sot, dosot, Ho, KhoTho, DauHong, ViempPhoi, MetMoi, trieuchungkhac, TiepXucF0, TiepXucF1, TiepXucNguoiCoBieuHien, TiepXucNguoiNuocNgoaiCoCV, TuHoacQuaVungDichVe, TuNgay, DenNgay, DiaDiemKhoiHanh, PhuongTienDiChuyen, Gan, Mau, Phoi, Than, TimMach, HuyetApCao, TieuDuong, UngThu, GhepTangXuong, HIVGMD, CoThai);
                    MessageBox.Show("Gửi Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Bạn Chưa Chấp Nhận Cam Kết", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }
        public void loadnull()
        {

        }
    }
}
    