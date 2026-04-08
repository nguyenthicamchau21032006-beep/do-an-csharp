using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KhoHang;
using frombanhang;
using formnhanvien;
using formkhachhang;
using formluongnv;

namespace trang_chủ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KhoHang.Form1 f = new KhoHang.Form1();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            formnhanvien.Form1 f = new formnhanvien.Form1();
            f.Show();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            frombanhang.Form1 f = new frombanhang.Form1();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            formkhachhang.Form1 f = new formkhachhang.Form1();
            f.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            formluongnv.Form1 f = new formluongnv.Form1();

            // Hiển thị nó lên
            f.Show();
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Em có chắc muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                // Bí quyết ở đây: Chỉ cần ĐÓNG Trang chủ lại. Không cần gọi form đăng nhập!
                this.Close();
            }
        }
    }
}


