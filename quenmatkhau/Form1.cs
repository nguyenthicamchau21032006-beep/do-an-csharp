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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
namespace quenmatkhau
{
    public partial class Form1 : Form
    {
        string strCon = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyVangBac;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string sdt = textBox2.Text.Trim();
            string passMoi = textBox3.Text.Trim();
            string xacNhan = textBox4.Text.Trim();

            // 1. Kiểm tra nhập liệu
            if (email == "" || sdt == "" || passMoi == "")
            {
                MessageBox.Show("Nhân viên vui lòng nhập đủ thông tin xác minh!");
                return;
            }

            if (passMoi != xacNhan)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    con.Open();
                    // Sử dụng bảng NguoiDung theo đúng file SQL của Bảo
                    string sql = "UPDATE NguoiDung SET MatKhau = @pass WHERE Email = @email AND SDT = @sdt";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@sdt", sdt);
                    cmd.Parameters.AddWithValue("@pass", passMoi);

                    int kq = cmd.ExecuteNonQuery();

                    if (kq > 0)
                    {
                        // Thông báo thân thiện cho nhân viên
                        MessageBox.Show("Nhân viên đã đổi mật khẩu thành công! Hãy dùng mật khẩu mới để đăng nhập.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Thông tin Email hoặc Số điện thoại không khớp. Vui lòng kiểm tra lại hoặc liên hệ Admin Bảo!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối hệ thống: " + ex.Message);
            }
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}