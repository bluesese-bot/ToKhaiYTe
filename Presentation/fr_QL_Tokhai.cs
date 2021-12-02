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
    public partial class fr_QL_Tokhai : Form
    {
        public fr_QL_Tokhai()
        {
            InitializeComponent();
        }
        System.Data.DataView dv;
        ConnectDB cn = new ConnectDB();
        DataTable dt = new DataTable();
        private void fr_QL_Tokhai_Load(object sender, EventArgs e)
        {
            hienthi();
            khoitaoluoi();
        }
        private void hienthi()
        {
            dt = cn.taobang("loadTTtokhaicoban");
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
            msds.Columns[0].Frozen = true;
            msds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].Width = 200;
            msds.Columns[0].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[1].HeaderText = "Tên Sinh Viên";
            msds.Columns[1].Width = 200;
            msds.Columns[1].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[2].HeaderText = "Lớp";
            msds.Columns[2].Width = 150;
            msds.Columns[2].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[3].HeaderText = "Khoa";
            msds.Columns[3].Width = 200;
            msds.Columns[3].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[4].HeaderText = "Ngày Khai Báo";
            msds.Columns[4].Width = 150;
            msds.Columns[4].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[5].HeaderText = "Sốt";
            msds.Columns[5].Width = 100;
            msds.Columns[5].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[6].HeaderText = "Độ Sốt";
            msds.Columns[6].Width = 100;
            msds.Columns[6].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[7].HeaderText = "Ho";
            msds.Columns[7].Width = 100;
            msds.Columns[7].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[8].HeaderText = "Khó Thở";
            msds.Columns[8].Width = 100;
            msds.Columns[8].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[9].HeaderText = "Đau Họng";
            msds.Columns[9].Width = 100;
            msds.Columns[9].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[10].HeaderText = "Viêm Phổi";
            msds.Columns[10].Width = 100;
            msds.Columns[10].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[11].HeaderText = "Mệt Mỏi";
            msds.Columns[11].Width = 100;
            msds.Columns[11].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[12].HeaderText = "Triệu Chứng Khác";
            msds.Columns[12].Width = 200;
            msds.Columns[12].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[13].HeaderText = "Tiếp Xúc Với F0";
            msds.Columns[13].Width = 200;
            msds.Columns[13].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[14].HeaderText = "Tiếp Xúc Với F1";
            msds.Columns[14].Width = 300;
            msds.Columns[14].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[15].HeaderText = "Tiếp xúc với người có biểu hiện";
            msds.Columns[15].Width = 200;
            msds.Columns[15].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[16].HeaderText = "Tiếp xúc với người từ nước có bệnh COVID 19";
            msds.Columns[16].Width = 200;
            msds.Columns[16].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[17].HeaderText = "Đi về hoặc từng qua vùng có dịch";
            msds.Columns[17].Width = 200;
            msds.Columns[17].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[18].HeaderText = "Từ Ngày";
            msds.Columns[18].Width = 150;
            msds.Columns[18].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[19].HeaderText = "Đến Ngày";
            msds.Columns[19].Width = 150;
            msds.Columns[19].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[20].HeaderText = "Địa điểm khởi hành";
            msds.Columns[20].Width = 200;
            msds.Columns[20].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[21].HeaderText = "Phương tiện di chuyển";
            msds.Columns[21].Width = 200;
            msds.Columns[21].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[22].HeaderText = "Bệnh gan mãn tính";
            msds.Columns[22].Width = 200;
            msds.Columns[22].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[23].HeaderText = "Bệnh máu mãn tính";
            msds.Columns[23].Width = 200;
            msds.Columns[23].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[24].HeaderText = "Bệnh phổi mãn tính";
            msds.Columns[24].Width = 200;
            msds.Columns[24].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[25].HeaderText = "Bệnh thận mạn tính";
            msds.Columns[25].Width = 200;
            msds.Columns[25].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[26].HeaderText = "Bệnh tim mạch";
            msds.Columns[26].Width = 200;
            msds.Columns[26].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[27].HeaderText = "Huyết áp cao";
            msds.Columns[27].Width = 200;
            msds.Columns[27].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[28].HeaderText = "Tiểu đường";
            msds.Columns[28].Width = 200;
            msds.Columns[28].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[29].HeaderText = "Ung thư";
            msds.Columns[29].Width = 150;
            msds.Columns[29].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[30].HeaderText = "Người nhận ghép tạng, tủy xương";
            msds.Columns[30].Width = 200;
            msds.Columns[30].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[31].HeaderText = "HIV hoặc suy giảm miễn dịch";
            msds.Columns[31].Width = 200;
            msds.Columns[31].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            msds.Columns[32].HeaderText = "Có thai";
            msds.Columns[32].Width = 150;
            msds.Columns[32].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
        }

        private void msds_SortStringChanged(object sender, EventArgs e)
        {
            dt.DefaultView.Sort = msds.SortString;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
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

            exRange.Range["O2:Q2"].Font.Size = 16;
            exRange.Range["O2:Q2"].Font.Name = "Times new roman";
            exRange.Range["O2:Q2"].Font.Bold = true;
            exRange.Range["O2:Q2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["O2:Q2"].MergeCells = true;
            exRange.Range["O2:Q2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["O2:Q2"].Value = "BÁO CÁO";
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
            exRange.Range["D11:D11"].Value = "Lớp";
            exRange.Range["E11:E11"].Value = "Khoa";
            exRange.Range["F11:F11"].Value = "Ngày Khai Báo";
            exRange.Range["G11:G11"].Value = "Sốt";
            exRange.Range["H11:H11"].Value = "Độ Sốt";
            exRange.Range["I11:I11"].Value = "Ho";
            exRange.Range["J11:J11"].Value = "Khó Thở";
            exRange.Range["K11:K11"].Value = "Đau Họng";
            exRange.Range["L11:L11"].Value = "Viêm Phổi";
            exRange.Range["M11:M11"].Value = "Mệt Mỏi";
            exRange.Range["N11:N11"].Value = "Triệu Chứng Khác";
            exRange.Range["O11:O11"].Value = "Tiếp Xúc Với F0";
            exRange.Range["P11:P11"].Value = "Tiếp Xúc Với F1";
            exRange.Range["Q11:Q11"].Value = "Tiếp xúc với người có biểu hiện";
            exRange.Range["R11:R11"].Value = "Tiếp xúc với người từ nước có bệnh COVID 19";
            exRange.Range["S11:S11"].Value = "Đi về hoặc từng qua vùng có dịch của quốc gia, vùng lãnh thổ có dịch COVID19";
            exRange.Range["T11:T11"].Value = "Từ Ngày";
            exRange.Range["U11:U11"].Value = "Đến Ngày";
            exRange.Range["V11:V11"].Value = "Địa điểm khởi hành";
            exRange.Range["W11:W11"].Value = "Phương tiện di chuyển";
            exRange.Range["X11:X11"].Value = "Bệnh gan mãn tính";
            exRange.Range["Y11:Y11"].Value = "Bệnh máu mãn tính";
            exRange.Range["Z11:Z11"].Value = "Bệnh phổi mãn tính";
            exRange.Range["AA11:AA11"].Value = "Bệnh thận mạn tính";
            exRange.Range["AB11:AB11"].Value = "Bệnh tim mạch";
            exRange.Range["AC11:AC11"].Value = "Huyết áp cao";
            exRange.Range["AD11:AD11"].Value = "Tiểu đường";
            exRange.Range["AE11:AE11"].Value = "Ung thư";
            exRange.Range["AF11:AF11"].Value = "Người nhận ghép tạng, tủy xương";
            exRange.Range["AG11:AG11"].Value = "HIV hoặc suy giảm miễn dịch";
            exRange.Range["AH11:AH11"].Value = "Có thai";

            exSheet.Columns["F"].NumberFormat = "dd/mm/yyyy";
            exSheet.Columns["T"].NumberFormat = "dd/mm/yyyy";
            exSheet.Columns["U"].NumberFormat = "dd/mm/yyyy";
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++) {
                    //Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
                }
                    
                   
                    
            }
            exRange = exSheet.Cells[28][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange = exSheet.Cells[31][hang + 17]; //Ô A1 
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

        private void msds_FilterStringChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = msds.FilterString;
        }
    }
}
