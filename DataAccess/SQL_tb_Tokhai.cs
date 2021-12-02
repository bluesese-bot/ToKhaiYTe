using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToKhaiYTe.Business.EntitiesClass;

namespace ToKhaiYTe.DataAccess
{
    class SQL_tb_Tokhai
    {
        ConnectDB cn = new ConnectDB();
        public void themtokhai(EC_tb_Tokhai ck)
        {
            cn.ExcuteNonQuery(@"EXEC addTk @IDNguoDung = '"+ck.IDNguoDung1+"',@Sot = N'"+ck.Sot1+ "',@dosot=N'"+ck.Dosot+"',@Ho = N'" + ck.Ho1+"',@KhoTho = N'"+ck.KhoTho1+"',@DauHong = N'"+ck.DauHong1+"', @ViempPhoi = N'"+ck.ViempPhoi1+"',@MetMoi = N'"+ck.MetMoi1+"',@trieuchungkhac = N'"+ck.Trieuchungkhac+"',@TiepXucF0 = N'"+ck.TiepXucF01+"',@TiepXucF1 = N'"+ck.TiepXucF11+"',@TiepXucNguoiCoBieuHien = N'"+ck.TiepXucNguoiCoBieuHien1+"',@TiepXucNguoiNuocNgoaiCoCV = N'"+ck.TiepXucNguoiNuocNgoaiCoCV1+"',@TuHoacQuaVungDichVe = N'"+ck.TuHoacQuaVungDichVe1+"',@TuNgay = '"+ck.TuNgay1+"',@DenNgay = '"+ck.DenNgay1+"',@DiaDiemKhoiHanh = N'"+ck.DiaDiemKhoiHanh1+"', @PhuongTienDiChuyen = N'"+ck.PhuongTienDiChuyen1+"',@Gan = N'"+ck.Gan1+"',@Mau = N'"+ck.Mau1+"', @Phoi = N'"+ck.Phoi1+"',@Than = N'"+ck.Than1+"',@TimMach = N'"+ck.TimMach1+"',@HuyetApCao = N'"+ck.HuyetApCao1+"',@TieuDuong = N'"+ck.TieuDuong1+"',@UngThu = N'"+ck.UngThu1+"',@GhepTangXuong = N'"+ck.GhepTangXuong1+"',@HIVGMD = N'"+ck.HIVGMD1+"', @CoThai = N'"+ck.CoThai1+"'");
        }
        
    }
}
