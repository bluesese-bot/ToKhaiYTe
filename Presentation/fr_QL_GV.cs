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
using COMExcel = Microsoft.Office.Interop.Excel;

namespace ToKhaiYTe.Presentation
{
    public partial class fr_QL_GV : Form
    {
        public fr_QL_GV()
        {
            InitializeComponent();
        }
        System.Data.DataView dv;
        ConnectDB cn = new ConnectDB();
        DataTable dt = new DataTable();
        private void hienthi()
        {
            dt = cn.taobang("loadALLGV");
            msds.DataSource = dt;
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
        public void khoitaoluoi()
        {
            msds.EnableHeadersVisualStyles = false;
            msds.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].HeaderText = "Mã Sinh Viên";
            msds.Columns[0].Width = 220;
            msds.Columns[0].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[1].HeaderText = "Họ Tên";
            msds.Columns[1].Width = 220;
            msds.Columns[1].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[2].HeaderText = "Ngày Sinh";
            msds.Columns[2].Width = 220;
            msds.Columns[2].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[3].HeaderText = "Giới Tính";
            msds.Columns[3].Width = 220;
            msds.Columns[3].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[4].HeaderText = "Số CMT/TCCCD";
            msds.Columns[4].Width = 220;
            msds.Columns[4].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[5].HeaderText = "Địa Chỉ";
            msds.Columns[5].Width = 220;
            msds.Columns[5].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[6].HeaderText = "Khoa";
            msds.Columns[6].Width = 220;
            msds.Columns[6].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[7].HeaderText = "SDT";
            msds.Columns[7].Width = 220;
            msds.Columns[7].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[8].HeaderText = "Thẻ BHYT";
            msds.Columns[8].Width = 220;
            msds.Columns[8].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[9].HeaderText = "Email";
            msds.Columns[9].Width = 220;
            msds.Columns[9].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[10].HeaderText = "Trạng Thái";
            msds.Columns[10].Width = 220;
            msds.Columns[10].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
        }
        private void fr_QL_GV_Load(object sender, EventArgs e)
        {
            hienthi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];

            exRange.Range["F2:H2"].Font.Size = 16;
            exRange.Range["F2:H2"].Font.Name = "Times new roman";
            exRange.Range["F2:H2"].Font.Bold = true;
            exRange.Range["F2:H2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["F2:H2"].MergeCells = true;
            exRange.Range["F2:H2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["F2:H2"].Value = "BÁO CÁO";
            //Lấy thông tin các mặt hàng
            dv = dt.DefaultView;
            tblThongtinHang = dv.ToTable();
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:AH11"].Font.Bold = true;
            exRange.Range["A11:AH11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A11:AH11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Mã Sinh Viên";
            exRange.Range["C11:C11"].Value = "Tên Sinh Viên";
            exRange.Range["D11:D11"].Value = "Ngày Sinh";
            exRange.Range["E11:E11"].Value = "Giới Tính";
            exRange.Range["F11:F11"].Value = "Số CMT/TCCCD";
            exRange.Range["G11:G11"].Value = "Địa Chỉ";
            exRange.Range["H11:H11"].Value = "Khoa";
            exRange.Range["I11:I11"].Value = "SDT";
            exRange.Range["J11:J11"].Value = "Số TBHYT";
            exRange.Range["K11:K11"].Value = "Email";
            exRange.Range["L11:L11"].Value = "Trạng Thái";

            //Set format dạng time
            exSheet.Columns["D"].NumberFormat = "dd/mm/yyyy";

            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                {
                    //Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
                }



            }
            exRange = exSheet.Cells[7][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange = exSheet.Cells[11][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = DateTime.Now;
            exRange.Range["A1:C1"].Value = "Thái Bình, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exSheet.Name = "Báo Cáo";
            exApp.Visible = true;
        }

        private void msds_SortStringChanged(object sender, EventArgs e)
        {
            dt.DefaultView.Sort = msds.SortString;
        }

        private void msds_FilterStringChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = msds.FilterString;
        }
    }
}
