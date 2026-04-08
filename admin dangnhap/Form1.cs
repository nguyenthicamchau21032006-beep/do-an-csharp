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

namespace admin_dangnhap
{
    public partial class Form1 : Form
    {
        string strCon = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyVangBac;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.NhoMatKhau)
            {
                textBox3.Text = Properties.Settings.Default.TaiKhoan;
                textBox4.Text = Properties.Settings.Default.MatKhau;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        
            
        {
            // Kiểm tra để trống
            if (string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ tài khoản và mật khẩu!");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_kiemtralogin", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Truyền tham số
                    cmd.Parameters.AddWithValue("@User", textBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@Pass", textBox4.Text.Trim());

                    
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        // KHAI BÁO resultCode NẰM Ở ĐÂY NÈ:
                        int resultCode = Convert.ToInt32(dt.Rows[0]["Code"]);
                        string thongBao = dt.Rows[0]["ThongBao"].ToString();

                        if (resultCode == 2)
                        {
                            
                            string tenTaiKhoan = textBox3.Text;

                            
                            DialogResult hoiLuu = MessageBox.Show(
                                "Chào " + tenTaiKhoan + "! Đăng nhập thành công.Bạn có muốn lưu mật khẩu cho lần đăng nhập sau không?",
                                "Lưu mật khẩu",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            );

                            
                            if (hoiLuu == DialogResult.Yes)
                            {
                                Properties.Settings.Default.TaiKhoan = textBox3.Text;
                                Properties.Settings.Default.MatKhau = textBox4.Text;
                                Properties.Settings.Default.NhoMatKhau = true;
                            }
                            else
                            {
                                Properties.Settings.Default.TaiKhoan = "";
                                Properties.Settings.Default.MatKhau = "";
                                Properties.Settings.Default.NhoMatKhau = false;
                            }
                            Properties.Settings.Default.Save();

                         
                            this.Hide(); 

                            trang_chủ.Form1 frmTrangChu = new trang_chủ.Form1();
                            frmTrangChu.ShowDialog(); 

                            this.Show(); 

                           
                            if (Properties.Settings.Default.NhoMatKhau == false)
                            {
                                textBox3.Clear();
                                textBox4.Clear();
                            }
                            textBox3.Focus();
                        }
                        else
                        {
                            MessageBox.Show(thongBao, "Lỗi đăng nhập");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
   
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            quenmatkhau.Form1 frmQuen = new quenmatkhau.Form1();
            this.Hide();
            frmQuen.ShowDialog();
            this.Show();
        }



        private void button4_Click(object sender, EventArgs e)
        {
            dangkytaikhoan.Form1 frm = new dangkytaikhoan.Form1();

            this.Hide(); 
            frm.ShowDialog(); 
            this.Show();

        }

        
    }
}
    

