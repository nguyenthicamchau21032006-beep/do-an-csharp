using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formluongnv
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double luongCoBan = 0;
                double thuongPhat = 0;

                
                double.TryParse(textBox4.Text, out luongCoBan);
                double.TryParse(textBox5.Text, out thuongPhat);

                
                DateTime gioVao = DateTime.Parse(textBox7.Text);
                DateTime gioRa = DateTime.Parse(textBox8.Text);
                DateTime gioChuan = DateTime.Parse("08:00");

                TimeSpan duration = gioRa - gioVao;
                double tongGioLam = duration.TotalHours;

                // Trừ 1 tiếng nghỉ trưa nếu làm hơn 5 tiếng
                if (tongGioLam > 5) tongGioLam -= 1;

                // 3. TÍNH TIỀN PHẠT ĐI TRỄ (Nếu có)
                double tienPhatTre = 0;
                if (gioVao > gioChuan)
                {
                    int phutTre = (int)(gioVao - gioChuan).TotalMinutes;
                    tienPhatTre = phutTre * 5000; 
                    MessageBox.Show($"Cảnh báo: Nhân viên đi trễ {phutTre} phút! Phạt: {tienPhatTre:N0}đ", "Kỷ luật");
                }

                
                double tongLuong = luongCoBan + thuongPhat - tienPhatTre;

                
                textBox9.Text = tongLuong.ToString("N0"); 
                if (tienPhatTre > 0)
                {
                    double hienThiThuongPhat = thuongPhat - tienPhatTre;
                    textBox5.Text = hienThiThuongPhat.ToString("N0");
                }

                MessageBox.Show($"Đã tính xong! Tổng giờ làm: {tongGioLam:0.0}h", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng kiểm tra lại! Đảm bảo Giờ gõ chuẩn (HH:mm) và Tiền chỉ gõ số.", "Lỗi nhập liệu");
            }
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            string tenNV = textBox1.Text;
            string maNV = textBox2.Text;
            string tongTien = textBox9.Text;

            if (string.IsNullOrEmpty(tenNV) || string.IsNullOrEmpty(tongTien))
            {
                MessageBox.Show("Vui lòng tính lương trước khi lưu!");
                return;
            }

            
            string thongTin = $"Nhân viên: {tenNV} ({maNV}) - Thực nhận: {tongTien} VNĐ";
            MessageBox.Show("Đã lưu thành công dữ liệu: \n" + thongTin, "Lưu dữ liệu");
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Ông chắc chắn muốn thoát chứ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
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

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
