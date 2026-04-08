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

namespace frombanhang
{
    public partial class Form1 : Form
    {

        string strCon = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyVangBac;Integrated Security=True";
        SqlConnection con;

        DataTable dtGioHang;

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

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) return;

            // Lấy thông tin đã load từ SQL ở trên để đẩy vào bảng 5 cột
            dtGioHang.Rows.Add(
                comboBox1.Text,
                textBox2.Text,
                textBox3.Text,
                textBox4.Text,  // <-- SỬA Ở ĐÂY: Đổi label6.Text thành textBox4.Text (để lấy đúng 200,000 của Tiền Công)
                textBox5.Text
            );
        }
        private void button4_Click(object sender, EventArgs e)
        
        {
            try
            {
                // 1. Lấy dữ liệu và lọc sạch định dạng
                // Chuyển sang decimal để tính tiền vàng chính xác hơn double
                decimal giaVang = 0, trongLuong = 0, tienCong = 0, soLuong = 1;

                // LƯU Ý: Kiểm tra label6.Text có đúng là Giá Vàng không nhé!
                string sGiaVang = label6.Text.Replace("Giá vàng SJC", "").Replace("VNĐ", "").Replace(",", "").Replace(".", "").Trim();
                decimal.TryParse(sGiaVang, out giaVang);

                decimal.TryParse(textBox3.Text.Trim(), out trongLuong);
                decimal.TryParse(textBox4.Text.Trim(), out tienCong);

                // Nếu có ô số lượng (giả sử là textBox8), hãy lấy giá trị đó, nếu không mặc định là 1
                // decimal.TryParse(textBox8.Text, out soLuong); 

                // Công thức tính tổng tiền chuẩn
                decimal tongTien = (giaVang * trongLuong) + tienCong;
                textBox5.Text = tongTien.ToString("N0");

                // 2. Lưu vào Database (Sử dụng chuỗi kết nối của máy em)
                string strCon = @"Data Source=DESKTOP-CCJUSV8\SQLEXPRESS;Initial Catalog=QuanLyVangBac;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(strCon))
                {
                    con.Open();
                    // Lưu Hóa Đơn chính
                    string sqlHD = "INSERT INTO HoaDon (NgayLap, TongTien) OUTPUT INSERTED.MaHD VALUES (GETDATE(), @tong)";
                    SqlCommand cmd = new SqlCommand(sqlHD, con);
                    cmd.Parameters.AddWithValue("@tong", tongTien);
                    int maHD = (int)cmd.ExecuteScalar();

                    // Lưu Chi Tiết Hóa Đơn (Khớp tên cột với bảng ChiTietHoaDon của em)
                    string sqlCT = "INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, DonGia, TrongLuong, DonGiaVang, TienCongBan, ThanhTien) " +
                                   "VALUES (@ma, @masp, @sl, @dg, @tl, @dgv, @tcb, @thanhtien)";

                    SqlCommand cmdCT = new SqlCommand(sqlCT, con);
                    cmdCT.Parameters.AddWithValue("@ma", maHD);
                    cmdCT.Parameters.AddWithValue("@masp", comboBox1.SelectedValue ?? (object)DBNull.Value);
                    cmdCT.Parameters.AddWithValue("@sl", soLuong);
                    cmdCT.Parameters.AddWithValue("@dg", giaVang); // Đơn giá là giá vàng 1 chỉ
                    cmdCT.Parameters.AddWithValue("@tl", trongLuong);
                    cmdCT.Parameters.AddWithValue("@dgv", giaVang);
                    cmdCT.Parameters.AddWithValue("@tcb", tienCong);
                    cmdCT.Parameters.AddWithValue("@thanhtien", tongTien);

                    cmdCT.ExecuteNonQuery();
                }

                // 3. Mở Form In Hóa Đơn (Truyền tham số ĐÚNG THỨ TỰ)
                inhoadon.Form1 frmIn = new inhoadon.Form1();
                frmIn.NhanThongTin(
                    textBox6.Text,     // Tên khách hàng
                    textBox7.Text,     // Số điện thoại
                    DateTime.Now.ToString("dd/MM/yyyy"), // Ngày
                    DateTime.Now.ToString("HH:mm:ss"),   // Giờ
                    comboBox1.Text,    // Tên sản phẩm
                    trongLuong.ToString(), // Trọng lượng
                    tienCong.ToString("N0"), // Tiền công 
                    giaVang.ToString("N0"),  // Đơn giá vàng
                    tongTien.ToString("N0"), // Tổng tiền
                    textBox9.Text,     // Cccd
                    soLuong.ToString() // Số lượng
                );
                frmIn.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Anh ơi lỗi rồi: " + ex.Message);
            }
        }
        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn sản phẩm chưa
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trước khi lưu tạm!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem các ô số liệu có trống không
            if (string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Thông tin sản phẩm chưa đầy đủ (Trọng lượng/Tổng tiền)!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Đẩy dữ liệu vào bảng tạm (dtGioHang)
                dtGioHang.Rows.Add(
                    comboBox1.Text,   // Tên SP
                    textBox2.Text,   // Loại
                    textBox3.Text,   // Trọng lượng
                    textBox4.Text,   // Tiền công
                    textBox5.Text    // Giá tiền
                );

                MessageBox.Show("Đã thêm vào giỏ hàng tạm thời!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu tạm: " + ex.Message);
            }
        }
        
       
        private void button3_Click(object sender, EventArgs e)
        {
            // 1. Xóa thông tin sản phẩm
            comboBox1.SelectedIndex = -1;
            textBox2.Clear(); // Loại vàng
            textBox3.Clear(); // Trọng lượng
            textBox4.Clear(); // Tiền công
            textBox5.Clear(); // Tổng tiền món hàng
            label6.Text = "0"; // Giá vàng

            // 2. Xóa thông tin khách hàng
            textBox6.Clear(); // Tên KH
            textBox7.Clear(); // SĐT
            textBox9.Clear(); // CCCD (trong form bán hàng là ô này)

            // 3. Xóa giỏ hàng (nếu muốn xóa trắng danh sách đang chọn)
            if (dtGioHang != null)
            {
                dtGioHang.Clear();
            }

            // Đưa chuột về ô tìm kiếm cho tiện
            comboBox1.Focus();

            MessageBox.Show("Đã làm mới toàn bộ biểu mẫu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra an toàn để tránh lỗi chọn nhầm giá trị chữ (nvarchar)
            if (comboBox1.SelectedValue == null || comboBox1.SelectedValue is DataRowView) return;

            try
            {
                using (con = new SqlConnection(strCon))
                {
                    con.Open();
                    // Câu lệnh này cực quan trọng: Nó nối bảng Sản Phẩm với bảng Loại Vàng 
                    // để lấy đúng Trọng lượng, Tiền công và Giá bán đã nhập sẵn trong SQL.
                    string sql = @"SELECT L.TenLoai, S.TrongLuong, S.TienCong, L.GiaBanRa 
                           FROM SanPham S JOIN LoaiVang L ON S.MaLoai = L.MaLoai 
                           WHERE S.MaSP = @ma";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@ma", comboBox1.SelectedValue);

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            // Lôi dữ liệu từ SQL đổ vào các ô trên Form
                            textBox2.Text = r["TenLoai"].ToString();
                            textBox3.Text = r["TrongLuong"].ToString();

                            decimal giaVang = Convert.ToDecimal(r["GiaBanRa"]);
                            decimal tienCong = Convert.ToDecimal(r["TienCong"]);
                            double trongLuong = Convert.ToDouble(r["TrongLuong"]);

                            label6.Text = giaVang.ToString("N0"); // Hiện giá vàng SJC đã nhập trong SQL
                            textBox4.Text = tienCong.ToString("N0"); // Hiện tiền công đã nhập trong SQL

                            // Tự động tính tổng tiền dựa trên giá vừa lấy về
                            decimal tongTien = (decimal)(trongLuong * (double)giaVang) + tienCong;
                            textBox5.Text = tongTien.ToString("N0");
                        }
                    }
                }
            }
            catch { /* Chặn lỗi lúc khởi tạo */ }
        }


        private void Form1_Load_1(object sender, EventArgs e)
        {
            try
            {
                dtGioHang = new DataTable();
                dtGioHang.Columns.Add("Tên Sản Phẩm");
                dtGioHang.Columns.Add("Loại");
                dtGioHang.Columns.Add("Trọng Lượng");

                // SỬA DÒNG NÀY: Đổi "Giá Vàng SJC" thành "Tiền Công"
                dtGioHang.Columns.Add("Tiền Công");

                dtGioHang.Columns.Add("Giá Tiền");
                dataGridView1.DataSource = dtGioHang;
                using (con = new SqlConnection(strCon))
                {
                    con.Open();
                    // Lấy MaSP để làm "mối nối" với dữ liệu nhập sẵn trong SQL
                    string sql = "SELECT MaSP, TenSP FROM SanPham WHERE SoLuongTon > 0";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "TenSP";
                    comboBox1.ValueMember = "MaSP"; // QUAN TRỌNG: Phải có dòng này mới liên kết được
                    comboBox1.SelectedIndex = -1;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}