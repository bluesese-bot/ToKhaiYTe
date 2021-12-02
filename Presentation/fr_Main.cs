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
    public partial class fr_Main : Form
    {
        private string id;
        private Form activeForm;
        private Button currentButton;
        E_tb_User thucthi = new E_tb_User();
        public string Id { get => id; set => id = value; }

        private void Admin()
        {
            if(thucthi.QuyenUser(Id))
            {
                button6.Visible = false;
            }
        }
        public fr_Main()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = ColorTranslator.FromHtml("Navy");
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btnCloseChildForm.Visible = true;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in pnMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.DarkTurquoise;
                    previousBtn.ForeColor = Color.White;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnMain.Controls.Add(childForm);
            this.pnMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }
        private void bntMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            
            Reset();
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME";
            pnCenter.BackColor = Color.DarkTurquoise;
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fr_ThongTinCaNhan(id), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fr_ToKhaiYte(Id), sender);
        }
        public static void ThreadProc()
        {
            Application.Run(new fr_DangNhap());
        }
        private void button7_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
            t.Start();
            this.Close();
        }
        public  void ThreadProc1()
        {
            fr_Quanly fr = new fr_Quanly();
            fr.Id = Id;
            Application.Run(fr);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc1));
            t.Start();
            this.Close();
        }

        private void fr_Main_Load(object sender, EventArgs e)
        {
            Admin();
            fr_Thongbao tb = new fr_Thongbao();
            tb.TopLevel = false;
            tb.FormBorderStyle = FormBorderStyle.None;
            tb.Dock = DockStyle.Fill;
            this.pnMain.Controls.Add(tb);
            this.pnMain.Tag = tb;
            tb.BringToFront();
            tb.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fr_HD(), sender);
        }
    }
}
