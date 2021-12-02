using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToKhaiYTe.Business.EntitiesClass;
using ToKhaiYTe.DataAccess;

namespace ToKhaiYTe.Business.Component
{
    class E_tb_ToKhai
    {
        SQL_tb_Tokhai sql = new SQL_tb_Tokhai();
        EC_tb_Tokhai ck = new EC_tb_Tokhai();
        public void themTokhai(string IDNguoDung, string Sot, string dosot, string Ho, string KhoTho, string DauHong, string ViempPhoi, string MetMoi, string trieuchungkhac, string TiepXucF0, string TiepXucF1, string TiepXucNguoiCoBieuHien, string TiepXucNguoiNuocNgoaiCoCV, string TuHoacQuaVungDichVe, string TuNgay, string DenNgay, string DiaDiemKhoiHanh, string PhuongTienDiChuyen, string Gan, string Mau, string Phoi, string Than, string TimMach, string HuyetApCao, string TieuDuong, string UngThu, string GhepTangXuong, string HIVGMD, string CoThai)
        {
            ck.IDNguoDung1 = IDNguoDung;
            ck.Sot1 = Sot;
            ck.Dosot = dosot;
            ck.Ho1 = Ho;
            ck.KhoTho1 = KhoTho;
            ck.DauHong1 = DauHong;
            ck.ViempPhoi1 = ViempPhoi;
            ck.MetMoi1 = MetMoi;
            ck.Trieuchungkhac = trieuchungkhac;
            ck.TiepXucF01 = TiepXucF0;
            ck.TiepXucF11 = TiepXucF1;
            ck.TiepXucNguoiCoBieuHien1 = TiepXucNguoiCoBieuHien;
            ck.TiepXucNguoiNuocNgoaiCoCV1 = TiepXucNguoiNuocNgoaiCoCV;
            ck.TuHoacQuaVungDichVe1 = TuHoacQuaVungDichVe;
            ck.TuNgay1 = TuNgay;
            ck.DenNgay1 = DenNgay;
            ck.DiaDiemKhoiHanh1 = DiaDiemKhoiHanh;
            ck.PhuongTienDiChuyen1 = PhuongTienDiChuyen;
            ck.Gan1 = Gan;
            ck.Mau1 = Mau;
            ck.Phoi1 = Phoi;
            ck.Than1 = Than;
            ck.TimMach1 = TimMach;
            ck.HuyetApCao1 = HuyetApCao;
            ck.TieuDuong1 = TieuDuong;
            ck.UngThu1 = UngThu;
            ck.GhepTangXuong1 = GhepTangXuong;
            ck.HIVGMD1 = HIVGMD;
            ck.CoThai1 = CoThai;
            sql.themtokhai(ck);   
        }
    }
}
