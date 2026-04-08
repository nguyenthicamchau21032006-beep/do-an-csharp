using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace inhoadon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
        public void NhanThongTin(string tenKH, string sdt, string ngay, string gio,
                         string tensp, string trongluong, string tiencong, string dongia, string tong, string Cccd,string soluong)
        {
            textBox1.Text = tenKH;
            textBox2.Text = sdt;
            textBox3.Text = DateTime.Now.ToString("dd/MM/yyyy"); 
            textBox4.Text = DateTime.Now.ToString("HH:mm:ss");   // Tự động lấy giờ hiện tại
            textBox10.Text = Cccd;   // CCCD sẽ hiện đúng số, không bị nhảy giá tiền vào

            // Cột phải: Chi tiết giao dịch
            textBox6.Text = tensp;      // Tên sản phẩm
            textBox11.Text = trongluong;  // Trọng lượng
           
            textBox7.Text = tiencong;    // Tiền công
            textBox8.Text = dongia;     // Đơn giá - Bây giờ sẽ hiện số, không còn chữ "Thủ Đức"

            // Dưới cùng
            textBox9.Text = tong;    // Tổng tiền
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            textBox3.Text = DateTime.Now.ToString("dd/MM/yyyy"); 
            textBox4.Text = DateTime.Now.ToString("HH:mm:ss");   
        }
        

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

       

       
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

