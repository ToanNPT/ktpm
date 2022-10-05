using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi07_TinhToan3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSo1.Text = txtSo2.Text = "0";
            radCong.Checked = true;             //đầu tiên chọn phép cộng
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có thực sự muốn thoát không?",
                                 "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Close();
            }
        }


        private string remove_nev(string a)
        {
            a = a.Replace(",", ".");
            int n = a.Length, i = 0, dem = 0;
            while (i < n && a[i] == '-')
            {
                dem++;
                i++;
            }

            if (dem % 2 == 0)
            {
                return a.Substring(dem);
            }
            else
            {
                return a.Substring(dem - 1);
            }
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            //lấy giá trị của 2 ô số
            double so1, so2, kq = 0;
            try
            {
                // Reset kết quả
                txtKq.Text = ""; 
                so1 = double.Parse(remove_nev(txtSo1.Text));
                so2 = double.Parse(remove_nev(txtSo2.Text));
                if (radChia.Checked && so2 == 0)
                {
                    MessageBox.Show("Cannot divide by 0!", "Warning", MessageBoxButtons.OK);
                    txtSo2.Focus();
                }
                else
                {
                    if (radCong.Checked)
                    {
                        kq = so1 + so2;
                    }
                    else if (radTru.Checked)
                    {
                        kq = so1 - so2;
                    }
                    else if (radNhan.Checked)
                    {
                        kq = so1 * so2;
                    }
                    else if (radChia.Checked && so2 != 0)
                    {
                        kq = so1 / so2;
                    }
                    //Hiển thị kết quả lên trên ô kết quả
                    txtKq.Text = kq.ToString();
                }
            }
            catch (FormatException)
            {
                DialogResult dr = MessageBox.Show("You just filled out wrong format number", "Warning", MessageBoxButtons.OK);
                txtSo2.Text = "";
                txtSo1.Text = "";
                txtSo1.Focus();
            }
            //Thực hiện phép tính dựa vào phép toán được chọn

        }

        private void txtSo1_Click(object sender, EventArgs e)
        {
            txtSo1.Text = "";
        }

        private void txtSo2_TextChanged(object sender, EventArgs e)
        {
            txtSo2.Text = "";
        }
    }
}