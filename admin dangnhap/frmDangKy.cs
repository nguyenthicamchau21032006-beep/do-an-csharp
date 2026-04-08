using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon == null) sqlCon = new SqlConnection(strCon);
                if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();

                // 1. KIỂM TRA MẬT KHẨU (textBox7: MK, textBox8: Xác nhận)
                if (string.IsNullOrEmpty(textBox7.Text) || textBox7.Text != textBox8.Text)
                {
                    MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp hoặc đang trống!");
                    textBox8.Focus();
                    return;
                }

                // 2. CHỈNH QUERY CHO KHỚP SQL (Bảng NguoiDung, Cột Quyen)
                // Theo SQL của ông: INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, Quyen)
                string query = "INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, Quyen, SDT, Email) " +
                               "VALUES (@User, @Pass, @HoTen, @Quyen, @Sdt, @Email)";

                SqlCommand cmd = new SqlCommand(query, sqlCon);

                // Gán đúng các TextBox vào tham số
                cmd.Parameters.AddWithValue("@User", textBox6.Text);     // Tên đăng nhập
                cmd.Parameters.AddWithValue("@Pass", textBox7.Text);     // Mật khẩu
                cmd.Parameters.AddWithValue("@HoTen", textBox1.Text);    // Họ tên
                cmd.Parameters.AddWithValue("@Quyen", textBox3.Text);    // Quyền (Admin/NhanVien)
                cmd.Parameters.AddWithValue("@Sdt", textBox2.Text);      // Số điện thoại
                cmd.Parameters.AddWithValue("@Email", textBox4.Text);    // Email

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Đăng ký thành công tài khoản cho " + textBox1.Text);
                }
            }
            catch (Exception ex)
            {
                // Nếu lỗi "Invalid object name 'NhanVien'" thì là do query cũ. 
                // Tui đã đổi thành 'NguoiDung' ở trên rồi nhé.
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
        }

        
private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
