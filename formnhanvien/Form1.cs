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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace formnhanvien
{
    public partial class Form1 : Form
    {
        string trangThai = "";
        string strCon = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyVangBac;Integrated Security=True";
        SqlConnection sqlCon = null;
        private void LoadData()
        {
            try
            {
                // 1. Tạo kết nối
                using (SqlConnection sqlCon = new SqlConnection(strCon))
                {
                    // 2. Gọi Store Procedure ông đã viết bên SQL
                    SqlDataAdapter adapter = new SqlDataAdapter("EXEC sp_LayDanhSachNhanVien", sqlCon);

                    // 3. Đổ dữ liệu vào DataTable
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // 4. Hiển thị lên GridView
                    dataGridView1.DataSource = dt;

                    // 5. Chỉnh tên cột cho đẹp (tùy ý ông)
                    dataGridView1.Columns["MaNV"].HeaderText = "Mã NV";
                    dataGridView1.Columns["HoTen"].HeaderText = "Họ và Tên";
                    dataGridView1.Columns["TenDangNhap"].HeaderText = "Username";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối rồi " + ex.Message);
            }
        }
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
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

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // 1. Mã NV và Họ Tên
                textBox2.Text = row.Cells["MaNV"].Value.ToString();   // Mã NV (đang dùng textBox2)
                textBox1.Text = row.Cells["HoTen"].Value.ToString();  // Họ tên

                // 2. Xử lý Giới tính
                string gioiTinh = row.Cells["GioiTinh"].Value.ToString();
                if (gioiTinh == "Nam") radioButton1.Checked = true;
                else radioButton2.Checked = true;

                // 3. NGÀY SINH (CHỖ NÀY NÈ - FIX BỎ GIỜ)
                if (row.Cells["NgaySinh"].Value != DBNull.Value)
                {
                    textBox2.Text = Convert.ToDateTime(row.Cells["NgaySinh"].Value).ToString("dd/MM/yyyy");
                }

                textBox3.Text = row.Cells["SDT"].Value.ToString();
                textBox4.Text = row.Cells["QueQuan"].Value.ToString();

                // 4. CÁC THÔNG TIN KHÁC
                textBox5.Text = row.Cells["CCCD"].Value.ToString();
                textBox6.Text = row.Cells["Email"].Value.ToString();

                // 5. NGÀY VÀO LÀM (CHỖ NÀY NỮA - FIX BỎ GIỜ)
                if (row.Cells["NgayVaoLam"].Value != DBNull.Value)
                {
                    textBox7.Text = Convert.ToDateTime(row.Cells["NgayVaoLam"].Value).ToString("dd/MM/yyyy");
                }

                textBox8.Text = row.Cells["CaLam"].Value.ToString();
            }
        
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(textBox1.Text)) { MessageBox.Show("Vui lòng nhập Họ tên!"); textBox1.Focus(); return; }
            if (string.IsNullOrWhiteSpace(textBox2.Text)) { MessageBox.Show("Vui lòng nhập Ngày sinh!"); textBox2.Focus(); return; }
            if (string.IsNullOrWhiteSpace(textBox3.Text)) { MessageBox.Show("Vui lòng nhập Số điện thoại!"); textBox3.Focus(); return; }
            if (string.IsNullOrWhiteSpace(textBox5.Text)) { MessageBox.Show("Vui lòng nhập CCCD!"); textBox5.Focus(); return; }
            if (string.IsNullOrWhiteSpace(textBox8.Text)) { MessageBox.Show("Vui lòng nhập Ca làm!"); textBox8.Focus(); return; }

            // 2. NẾU ĐÃ ĐỦ THÔNG TIN THÌ LƯU VÀO SQL
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strCon))
                {
                    sqlCon.Open();
                    // Gọi Store sp_ThemNhanVien mà mình đã viết bên SQL
                    SqlCommand cmd = new SqlCommand("sp_ThemNhanVien", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Truyền dữ liệu từ TextBox vào các biến trong SQL
                    cmd.Parameters.AddWithValue("@TenDangNhap", textBox3.Text); // Lấy SDT làm tên đăng nhập
                    cmd.Parameters.AddWithValue("@MatKhau", "123");
                    cmd.Parameters.AddWithValue("@HoTen", textBox1.Text);
                    cmd.Parameters.AddWithValue("@GioiTinh", radioButton1.Checked ? "Nam" : "Nữ");
                    cmd.Parameters.AddWithValue("@SDT", textBox3.Text);
                    cmd.Parameters.AddWithValue("@CCCD", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Email", textBox6.Text);
                    cmd.Parameters.AddWithValue("@QueQuan", textBox4.Text);
                    cmd.Parameters.AddWithValue("@CaLam", textBox8.Text);
                    DateTime NgaySinh;
                    DateTime NgayVaoLam;
                    bool isNgaySinhOk = DateTime.TryParseExact(textBox2.Text.Trim(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out NgaySinh);
                    bool isNgayVaoLamOk = DateTime.TryParseExact(textBox7.Text.Trim() , "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out NgayVaoLam);
                    cmd.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                    cmd.Parameters.AddWithValue("@NgayVaoLam", NgayVaoLam);
                    cmd.Parameters.AddWithValue("@Quyen", "NhanVien");

                    // Thực thi lệnh và lấy thông báo trả về từ SQL
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show(dt.Rows[0]["ThongBao"].ToString());
                        if (dt.Rows[0]["Code"].ToString() == "1")
                        {
                            LoadData(); // Thêm xong tự động hiện lên bảng luôn
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem ông đã chọn ai dưới bảng chưa
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Ông phải chọn 1 nhân viên dưới bảng để sửa nhé!");
                return;
            }

            // 2. Lấy Mã NV trực tiếp từ dòng đang chọn trên bảng cho an toàn
            string maNV = dataGridView1.CurrentRow.Cells["MaNV"].Value.ToString();

            try
            {
                // 3. Khởi tạo và mở kết nối
                if (sqlCon == null) sqlCon = new SqlConnection(strCon);
                if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();

                // 4. Gọi Store Procedure Sửa Nhân Viên
                SqlCommand cmd = new SqlCommand("sp_SuaNhanVien", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                // Xóa tham số cũ
                cmd.Parameters.Clear();

                // 5. Truyền đúng 12 tham số theo đúng thứ tự bản cập nhật mới nhất
                // Lưu ý: Sửa thì cần @MaNV, KHÔNG CẦN @TenDangNhap và @MatKhau
                // 1. Ép kiểu trước
                DateTime ns, nvl;
                DateTime.TryParseExact(textBox2.Text.Trim(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ns);
                DateTime.TryParseExact(textBox7.Text.Trim(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out nvl);

                // 2. Nạp tham số (Dùng biến đã ép kiểu)
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@HoTen", textBox1.Text);
                cmd.Parameters.AddWithValue("@GioiTinh", radioButton1.Checked ? "Nam" : "Nữ");
                cmd.Parameters.AddWithValue("@NgaySinh", ns);     // Dùng biến ns
                cmd.Parameters.AddWithValue("@SDT", textBox3.Text);
                cmd.Parameters.AddWithValue("@CCCD", textBox5.Text);
                cmd.Parameters.AddWithValue("@Email", textBox6.Text);
                cmd.Parameters.AddWithValue("@QueQuan", textBox4.Text);
                cmd.Parameters.AddWithValue("@CaLam", textBox8.Text);
                cmd.Parameters.AddWithValue("@NgayVaoLam", nvl); // Dùng biến nvl
                cmd.Parameters.AddWithValue("@Quyen", "NhanVien");
                cmd.Parameters.AddWithValue("@TrangThai", "Đang làm việc");

                // 6. Thực thi và nhận thông báo từ SQL
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    // Báo lên màn hình (VD: "Cập nhật thành công!")
                    MessageBox.Show(dt.Rows[0]["ThongBao"].ToString());

                    // Nếu thành công (Code = 1) thì load lại bảng cho dữ liệu mới hiện lên
                    if (dt.Rows[0]["Code"].ToString() == "1")
                    {
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối
                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon == null) sqlCon = new SqlConnection(strCon);
                if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                // 1. KIỂM TRA XEM ĐANG Ở CHẾ ĐỘ NÀO
                if (trangThai == "SUA")
                {
                    cmd.CommandText = "sp_SuaNhanVien";

                    // Lấy Mã NV từ DataGridView để biết đang sửa ai
                    string maNV = dataGridView1.CurrentRow.Cells["MaNV"].Value.ToString();
                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    cmd.Parameters.AddWithValue("@TrangThai", "Đang làm việc");
                }
                else // Mặc định là Thêm mới
                {
                    cmd.CommandText = "sp_ThemNhanVien";
                    cmd.Parameters.AddWithValue("@TenDangNhap", textBox3.Text);
                    cmd.Parameters.AddWithValue("@MatKhau", "123");
                }

                // 2. CÁC THÔNG TIN CHUNG (Dùng cho cả Thêm và Sửa)

                cmd.Parameters.AddWithValue("@HoTen", textBox1.Text);
                cmd.Parameters.AddWithValue("@GioiTinh", radioButton1.Checked ? "Nam" : "Nữ");
                cmd.Parameters.AddWithValue("@NgaySinh", textBox2.Text);
                cmd.Parameters.AddWithValue("@SDT", textBox3.Text);
                cmd.Parameters.AddWithValue("@CCCD", textBox5.Text);
                cmd.Parameters.AddWithValue("@Email", textBox6.Text);
                cmd.Parameters.AddWithValue("@QueQuan", textBox4.Text);
                
                cmd.Parameters.AddWithValue("@Quyen", "NhanVien");

                // 3. THỰC THI VÀ LẤY THÔNG BÁO TỪ SQL
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show(dt.Rows[0]["ThongBao"].ToString()); // Báo thành công hay thất bại

                    if (dt.Rows[0]["Code"].ToString() == "1") // Nếu Code = 1 là OK
                    {
                        LoadData(); // Cập nhật lại bảng
                        trangThai = "THEM"; // Sửa xong thì trả lại trạng thái mặc định
                        button6_Click(null, null); // Gọi nút Làm mới để xóa trắng form
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tại nút Lưu: " + ex.Message);
            }
            finally
            {
                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strCon))
                {
                    sqlCon.Open();
                    // Tìm kiếm thông minh theo Tên hoặc Mã NV hoặc Số điện thoại
                    string query = @"SELECT * FROM NguoiDung 
                             WHERE HoTen LIKE N'%" + textBox9.Text + @"%' 
                             OR MaNV LIKE '%" + textBox9.Text + @"%'
                             OR SDT LIKE '%" + textBox9.Text + "%'";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                // Để trống để tránh hiện lỗi phiền phức khi đang gõ nhanh
            }
        }
        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strCon))
                {
                    sqlCon.Open(); 

                    SqlDataAdapter adapter = new SqlDataAdapter("EXEC sp_LayDanhSachNhanVien", sqlCon);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        

    }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // 1. Xóa sạch chữ trong các ô nhập liệu
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            LoadData();
        
    }

        private void button3_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem ông đã chọn nhân viên nào trên bảng (DataGridView) chưa
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên trong bảng để xóa!");
                return;
            }

            // 2. Lấy Mã NV và Họ Tên từ dòng đang được chọn
            string maNV = dataGridView1.CurrentRow.Cells["MaNV"].Value.ToString();
            string hoTen = dataGridView1.CurrentRow.Cells["HoTen"].Value.ToString();

            // 3. Hiển thị hộp thoại hỏi lại cho chắc chắn, tránh bấm nhầm bay mất dữ liệu
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên: {hoTen} ({maNV}) không?",
                                                  "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // 4. Khởi tạo và mở kết nối (sử dụng biến sqlCon và strCon của ông)
                    if (sqlCon == null) sqlCon = new SqlConnection(strCon);
                    if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();

                    // 5. Gọi Store Procedure sp_XoaNhanVien từ SQL
                    SqlCommand cmd = new SqlCommand("sp_XoaNhanVien", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 6. Truyền tham số @MaXoa mà SQL đang yêu cầu
                    cmd.Parameters.AddWithValue("@MaXoa", maNV);

                    // 7. Hứng kết quả từ SQL trả về (Bao gồm cột Code và ThongBao)
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // 8. Xử lý thông báo
                    if (dt.Rows.Count > 0)
                    {
                        string thongBao = dt.Rows[0]["ThongBao"].ToString();
                        string code = dt.Rows[0]["Code"].ToString();

                        MessageBox.Show(thongBao); // Hiện thông báo (VD: "Không thể xóa Admin!" hoặc "Đã xóa thành công!")

                        // Nếu Code = 1 (Xóa thành công) thì làm mới lại bảng và xóa trắng các ô nhập liệu
                        if (code == "1")
                        {
                            LoadData();
                            button6_Click(null, null);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
                finally
                {
                    // Đóng kết nối cho sạch bộ nhớ
                    if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                    {
                        sqlCon.Close();
                    }
                }
            }
        }
    }
    }

