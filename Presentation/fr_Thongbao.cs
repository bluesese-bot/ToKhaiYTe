using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToKhaiYTe.Business.EntitiesClass;
using ToKhaiYTe.Business.Component ;

namespace ToKhaiYTe.Presentation
{
    public partial class fr_Thongbao : Form
    {
        public fr_Thongbao()
        {
            InitializeComponent();
        }
        E_tb_Thongbao thucthi = new E_tb_Thongbao();

        private void fr_Thongbao_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            List<EC_tb_Thongbao> tablist = thucthi.loadThongBao();
            foreach (EC_tb_Thongbao item in tablist)
            {
                FlowLayoutPanel fl = new FlowLayoutPanel() { Width = 1050, Height = 150 };
                fl.BorderStyle = BorderStyle.FixedSingle;
                fl.BackColor = Color.White;
                Label lb1 = new Label() { Width = 1000, Height = 30 };
                lb1.Text = item.Tieude;
                lb1.Font = new Font("Microsoft Sans Serif", 15F,FontStyle.Bold);
                lb1.BackColor = Color.White;
                lb1.BorderStyle = BorderStyle.None;
                lb1.Padding = new Padding(10, 0, 0, 0);
                fl.Controls.Add(lb1);
                TextBox txt = new TextBox { Width = 1000, Height = 70 };
                txt.Text = item.Noidung;
                txt.Font = new Font("Microsoft Sans Serif", 12F);
                txt.BackColor = Color.White;
                txt.BorderStyle = BorderStyle.None;
                txt.Margin = new Padding(50,10,3,3);
                txt.ScrollBars = ScrollBars.Both;
                txt.ReadOnly = true;
                fl.Controls.Add(txt);
                flowLayoutPanel1.Controls.Add(fl);
            }
        }
    }
}
