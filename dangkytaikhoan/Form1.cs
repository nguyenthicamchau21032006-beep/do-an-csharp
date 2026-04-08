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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dangkytaikhoan
{
    public partial class Form1 : Form
    {
        string strCon = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyVangBac;Integrated Security=True";
        SqlConnection sqlCon = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

       
        private void label6_Click(object sender, EventArgs e)
        {

        }


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon == null) sqlCon = new SqlConnection(strCon);
                if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();

                // 1. KIỂM TRA MẬT KHẨU (textBox7: MK, textBox8: Xác nhận)
                if (string.IsNullOrEmpty(textBox3.Text) || textBox3.Text != textBox4.Text)
                {
                    MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp hoặc đang trống!");
                    textBox8.Focus();
                    return;
                }

                
                string query = "INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, Quyen, SDT, Email) " +
                               "VALUES (@User, @Pass, @HoTen, @Quyen, @Sdt, @Email)";

                SqlCommand cmd = new SqlCommand(query, sqlCon);

                // Gán đúng các TextBox vào tham số
                cmd.Parameters.AddWithValue("@User", textBox2.Text);     // Tên đăng nhập
                cmd.Parameters.AddWithValue("@Pass", textBox3.Text);     // Mật khẩu
                cmd.Parameters.AddWithValue("@HoTen", textBox1.Text);    // Họ tên
                cmd.Parameters.AddWithValue("@Quyen", textBox7.Text);    // Quyền (Admin/NhanVien)
                cmd.Parameters.AddWithValue("@Sdt", textBox5.Text);      // Số điện thoại
                cmd.Parameters.AddWithValue("@Email", textBox6.Text);    // Email
                cmd.Parameters.AddWithValue("@Xacnhanmk", textBox4.Text);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Đăng ký thành công tài khoản cho " + textBox1.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }

}