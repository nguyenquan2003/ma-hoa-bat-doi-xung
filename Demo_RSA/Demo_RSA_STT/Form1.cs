using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_RSA_STT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        FunctionRSA f = new FunctionRSA();
        List<int> lsBanSoGoc = new List<int>();
        private void btnMaHoa_Click(object sender, EventArgs e)
        {

            int p = int.Parse(txtP.Text);
            int q = int.Parse(txtQ.Text);
            int result_e = int.Parse(txtE.Text);
            int phiN = f.resultEulerN(p, q);
            int n = f.resultN(p, q);

            if (p == q)
            {
                MessageBox.Show("P và Q không được trùng");
                txtQ.Focus();
                return;
            }
            if (!f.kiemTraSoNguyenTo(int.Parse(txtP.Text)))
            {
                MessageBox.Show("Đây không phải là số nguyên tố. Mời bạn nhập lại");
                txtP.Focus();
                return;
            }


            if (result_e < 1 || result_e > f.resultEulerN(p, q))
            {
                MessageBox.Show("Số e phải lớn hơn 1 hoặc số e phải bé hơn phi N");
                txtE.Focus();
                return;
            }

            if (!f.kiemTraSoNguyenTo(int.Parse(txtQ.Text)))
            {
                MessageBox.Show("Đây không phải là số nguyên tố. Mời bạn nhập lại");
                txtQ.Focus();
                return;
            }

            if (txtE.Text == "")
            {
                MessageBox.Show("Public key không được trống");
                txtE.Focus();
                return;
            }

            if (!f.kiemTraSoNguyenTo(int.Parse(txtE.Text)))
            {
                MessageBox.Show("Số E không phải là số nguyên tố. Mời bạn nhập lại");
                txtE.Focus();
                return;
            }

            List<int> lsBanSo = new List<int>();
            List<int> lsBanMaSo = new List<int>();
            List<string> lsBanChu = new List<string>();

            foreach(char c in txtPlainText.Text)
            {
                lsBanSo.Add(f.chuyenChuSangSo(c));
            }

            lsBanSoGoc = f.maHoa(lsBanSo, result_e, f.resultN(p, q));
            foreach(int i in lsBanSoGoc)
            {
                int temp = i;
                if (i > 26)
                {
                    temp = i % 26;
                    lsBanMaSo.Add(temp);
                }
                else
                    lsBanMaSo.Add(temp);

            }

            lsBanChu = f.chuyenSoSangChu(lsBanMaSo);
            foreach(string s in lsBanChu)
            {
                txtMaHoa.AppendText(s);
            }    

        }

        private void txtP_Leave(object sender, EventArgs e)
        {

        }

        private void txtPhiN_Leave(object sender, EventArgs e)
        {

        }

        private void txtQ_Leave(object sender, EventArgs e)
        {

            int p = int.Parse(txtP.Text);
            int q = int.Parse(txtQ.Text);
            txtN.Text = f.resultN(p, q).ToString();
            txtPhiN.Text = f.resultEulerN(p, q).ToString();
        }

        private void txtN_Leave(object sender, EventArgs e)
         {

            int p = int.Parse(txtP.Text);
            int q = int.Parse(txtQ.Text);
            int phiN = f.resultEulerN(p, q);
            txtPhiN.Text = phiN.ToString();
        }

        private void txtE_Leave(object sender, EventArgs e)
        {

            int p = int.Parse(txtP.Text);
            int q = int.Parse(txtQ.Text);
            int result_e = int.Parse(txtE.Text);
            txtD.Text = f.resultD(result_e, f.resultEulerN(p, q)).ToString();
        }

        private void txtD_Leave(object sender, EventArgs e)
        {
        }

        private void btnGiaiMa_Click(object sender, EventArgs e)
            {
            int p = int.Parse(txtP.Text);
            int q = int.Parse(txtQ.Text);
            int result_e = int.Parse(txtE.Text);
            int phiN = f.resultEulerN(p, q);
            int n = f.resultN(p, q);

            List<int> lsBanSo = new List<int>();
            List<int> lsBanMaSo = new List<int>();
            List<string> lsBanChu = new List<string>();

            foreach (char c in txtMaHoa.Text)
            {
                lsBanSo.Add(f.chuyenChuSangSo(c));
            }
            int d = f.resultD(result_e, f.resultEulerN(p, q));
            for (int i = 0; i < lsBanSo.Count; i++)
            {
                while (lsBanSo[i] != lsBanSoGoc[i])
                {
                    int x = 0;
                    x++;
                    lsBanSo[i] = lsBanSo[i] + (x * 26);
                }

            }
            lsBanMaSo = f.giaiMa(lsBanSo, d, f.resultN(p, q));
           
            lsBanChu = f.chuyenSoSangChu(lsBanMaSo);
             
            foreach (string s in lsBanChu)
            {
                txtGiaiMa.AppendText(s);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtP.Text = "";
            txtQ.Text = "";
            txtPhiN.Text = "";
            txtN.Text = "";
            txtE.Text = "";
            txtD.Text = "";
            txtMaHoa.Text = "";
            txtGiaiMa.Text = "";
            txtPlainText.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát chương trình", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void chkHien_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHien.Checked == true)
            {
                txtD.PasswordChar = '\0';
            }
            else
            {
                txtD.PasswordChar = '*';
            }
        }

        private void txtD_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
