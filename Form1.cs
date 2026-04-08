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
                         string tensp, string trongluong, string tiencong, string dongia, string tongtien, string Cccd, string soluong)
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
            textBox9.Text = tongtien;    // Tổng tiền
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.Enabled = false;
            string strCon = @"Data Source=DESKTOP-CCJUSV8\SQLEXPRESS;Initial Catalog=QuanLyVangBac;Integrated Security=True";

            try
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    con.Open();

                    // 1. CHỈ LẤY THÔNG TIN TỪ CÁC Ô TRÊN FORM
                    string tenKhach = textBox1.Text.Trim();
                    string tenNhanVien = textBox12.Text.Trim();

                   
                    // 2. TÍNH TOÁN (Sửa lại cách parse để không mất số lẻ)
                    decimal d_tienCong = ParseDecimal(textBox7.Text);
                    decimal d_donGiaVang = ParseDecimal(textBox8.Text);

                    // Trọng lượng dùng decimal để chính xác (ví dụ 2.9)
                    decimal d_trongLuong = 0;
                    decimal.TryParse(textBox11.Text.Trim().Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out d_trongLuong);

                    decimal d_soLuong = 0;
                    decimal.TryParse(textBox5.Text.Trim(), out d_soLuong);

                    // Công thức: ((Đơn giá * Trọng lượng) + Tiền công) * Số lượng
                    decimal d_tongTien = ((d_donGiaVang * d_trongLuong) + d_tienCong) * d_soLuong;

                    
                    textBox9.Text = d_tongTien.ToString("N0");
                   
                    string tenSP = textBox6.Text.Trim();
                    string sqlSP = "SELECT TOP 1 MaSP FROM SanPham WHERE TenSP = @ten";
                    SqlCommand cmdSP = new SqlCommand(sqlSP, con);
                    cmdSP.Parameters.AddWithValue("@ten", tenSP);
                    string maSP = cmdSP.ExecuteScalar()?.ToString() ?? "SP001";
                    string sqlNV = "IF EXISTS (SELECT 1 FROM NguoiDung WHERE HoTen = @tnv) " +
               "    SELECT MaNV FROM NguoiDung WHERE HoTen = @tnv; " +
               "ELSE " +
               "BEGIN " +
               "    DECLARE @NewUser VARCHAR(50) = 'user' + CAST(CAST(RAND()*100000 AS INT) AS VARCHAR); " +
               "    INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, Quyen) " +
               "    VALUES (@NewUser, '123', @tnv, N'Nhân viên'); " +
               "    SELECT MaNV FROM NguoiDung WHERE HoTen = @tnv; " +
               "END";
                    SqlCommand cmdNV = new SqlCommand(sqlNV, con);
                    cmdNV.Parameters.AddWithValue("@tnv", tenNhanVien);
                    string maNV_Thuc = cmdNV.ExecuteScalar().ToString();

                    // 4. LƯU HÓA ĐƠN 
                    string sqlHD = "INSERT INTO HoaDon (MaNV, TongTien, NgayLap, LoaiHoaDon, TenNhanVienLap, TenKhachHangMua) " +
                "OUTPUT INSERTED.MaHD VALUES (@maNV, @tong, GETDATE(), N'Bán', @tenNV, @tenKH)";

                    SqlCommand cmdHD = new SqlCommand(sqlHD, con);
                    cmdHD.Parameters.AddWithValue("@maNV", maNV_Thuc);
                    cmdHD.Parameters.AddWithValue("@tong", d_tongTien);
                    cmdHD.Parameters.AddWithValue("@tenNV", tenNhanVien);
                    cmdHD.Parameters.AddWithValue("@tenKH", tenKhach);
                    int maHDMoi = (int)cmdHD.ExecuteScalar();
                    string sqlCT = "INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, DonGia, TrongLuong, TienCong, ThanhTien) " +
                "VALUES (@ma, @masp, @sl, @dg, @tl, @tc, @thanhtien)";
                    SqlCommand cmdCT = new SqlCommand(sqlCT, con);
                    cmdCT.Parameters.AddWithValue("@ma", maHDMoi);
                    cmdCT.Parameters.AddWithValue("@masp", maSP);
                    cmdCT.Parameters.AddWithValue("@sl", d_soLuong);     // Số lượng (1)
                    cmdCT.Parameters.AddWithValue("@dg", d_donGiaVang);  // Đơn giá (1.200.000) -> Kiểm tra xem trong DB cột này có đúng vị trí không
                    cmdCT.Parameters.AddWithValue("@tl", d_trongLuong); // Trọng lượng (2.9)
                    cmdCT.Parameters.AddWithValue("@tc", d_tienCong);
                    cmdCT.Parameters.AddWithValue("@thanhtien", d_tongTien); // Tổng tiền cuối cùng (3.580.000)

                    cmdCT.ExecuteNonQuery();

                    MessageBox.Show("Thanh toán thành công hệ thống KIM BẢO!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private decimal ParseDecimal(string input)
        {
            if (string.IsNullOrEmpty(input)) return 0;
            string clean = "";
            foreach (char c in input)
            {
                if (char.IsDigit(c)) clean += c;
            }
            decimal res = 0;
            decimal.TryParse(clean, out res);
            return res;
        }
    }
}