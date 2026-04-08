using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KhoHang
{
    public partial class Form1 : Form
    {
        string strCon = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyVangBac;Integrated Security=True";
        SqlDataAdapter da;
        DataTable dt;


        public Form1()
        {
            InitializeComponent();
            SetupAutoComplete();

            // 👉 THÊM DÒNG NÀY VÀO ĐỂ BẬT TÍNH NĂNG CLICK CHUỘT LÊN BẢNG:
            dataGridView1.CellClick += dataGridView1_CellClick;
        }
        private void SetupAutoComplete()
        {
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            try
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    con.Open();
                    string sql = "SELECT TenSP FROM SanPham";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) data.Add(reader["TenSP"].ToString());
                    }
                }
                textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBox1.AutoCompleteCustomSource = data;
            }
            catch { }
        }


        private void LoadDataDirect()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    // Thay vì gọi Store Procedure đang bị lỗi trong SQL, ta dùng lệnh SELECT trực tiếp
                    string sql = @"SELECT MaSP AS [Mã SP], 
                                  TenSP AS [Tên Sản Phẩm], 
                                  LoaiVang AS [Loại Vàng], 
                                  TrongLuong AS [Trọng Lượng], 
                                  FORMAT(TienCong, 'N0') AS [Tiền Công], 
                                  SoLuongTon AS [Tồn Kho], 
                                  FORMAT(GiaNiemYet, 'N0') AS [Giá Niêm Yết], 
                                  FORMAT(ThanhTien, 'N0') AS [Thành Tiền] 
                           FROM SanPham";

                    da = new SqlDataAdapter(sql, con);
                    dt = new DataTable();
                    da.Fill(dt); // Lúc này sẽ đổ dữ liệu mượt mà, không văng lỗi nữa
                    dataGridView1.DataSource = dt;

                    // Căn chỉnh tự động cho đẹp
                    // 1. Dàn đều các cột
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // 2. Ép 2 cột chữ dài phải giãn rộng hết cỡ, không bị cắt dấu 3 chấm
                    dataGridView1.Columns["Tên Sản Phẩm"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns["Giá Niêm Yết"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi DataFill: " + ex.Message);
            }
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Lấy trực tiếp từ Grid, không cần tìm kiếm trong DataTable nữa
                textBox2.Text = row.Cells["Mã SP"].Value?.ToString();
                textBox1.Text = row.Cells["Tên Sản Phẩm"].Value?.ToString();
                textBox3.Text = row.Cells["Loại Vàng"].Value?.ToString();
                textBox5.Text = row.Cells["Trọng Lượng"].Value?.ToString();
                textBox4.Text = row.Cells["Tiền Công"].Value?.ToString();
                textBox6.Text = row.Cells["Tồn Kho"].Value?.ToString();
                textBox7.Text = row.Cells["Giá Niêm Yết"].Value?.ToString();
                textBox8.Text = row.Cells["Thành Tiền"].Value?.ToString();
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }


        private void label4_Click(object sender, EventArgs e)
        {

        }



        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }


        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }




        private void button10_Click_1(object sender, EventArgs e)
        {
            LoadDataDirect();
            textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox6.Clear(); textBox5.Clear();
        }



        private void groupBox2_Enter_2(object sender, EventArgs e)
        {
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

    private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadDataDirect();
            MessageBox.Show("Đã cập nhật dữ liệu kho hàng mới nhất!", "Thông báo");
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    // FIX: Bỏ cột DonVi và MaLoai vì SQL của Bảo đã xóa chúng
                    string sql = @"SELECT MaSP AS [Mã SP], 
                                          TenSP AS [Tên Sản Phẩm], 
                                          LoaiVang AS [Loại Vàng], 
                                          TrongLuong AS [Trọng Lượng], 
                                          FORMAT(TienCong, 'N0') AS [Tiền Công], 
                                          SoLuongTon AS [Tồn Kho], 
                                          FORMAT(GiaNiemYet, 'N0') AS [Giá Niêm Yết], 
                                          FORMAT(ThanhTien, 'N0') AS [Thành Tiền] 
                                   FROM SanPham";

                    da = new SqlDataAdapter(sql, con);
                    dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    // Chỉnh độ rộng cột cho đẹp
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message);
            }
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra không được để trống Tên và Mã SP
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Bảo ơi, nhập Tên sản phẩm và Mã SP đã nhé!");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    con.Open();
                    // Lệnh này sẽ kiểm tra: Nếu trùng Mã SP thì báo lỗi, nếu mới thì Thêm vào
                    string sqlInsert = @"INSERT INTO SanPham (MaSP, TenSP, TrongLuong, TienCong, SoLuongTon) 
                                VALUES (@maSP, @ten, @tl, @tc, @sl)";

                    SqlCommand cmd = new SqlCommand(sqlInsert, con);
                    cmd.Parameters.AddWithValue("@maSP", textBox2.Text.Trim()); // Mã SP (SP001...)
                    cmd.Parameters.AddWithValue("@ten", textBox1.Text.Trim());  // Tên SP

                    // Dùng TryParse để tránh lỗi "Format" nếu Bảo lỡ nhập chữ vào ô số
                    double.TryParse(textBox5.Text, out double tl);
                    decimal.TryParse(textBox4.Text, out decimal tc);
                    int.TryParse(textBox6.Text, out int sl);

                    cmd.Parameters.AddWithValue("@tl", tl); // Trọng lượng
                    cmd.Parameters.AddWithValue("@tc", tc); // Tiền công
                    cmd.Parameters.AddWithValue("@sl", sl); // Tồn kho

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã lưu sản phẩm " + textBox2.Text + " vào danh sách!");

                    LoadDataDirect(); // Cập nhật lại bảng bên trái ngay lập tức
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi rồi: " + ex.Message + "\n(Có thể do trùng Mã SP đó Bảo)");
            }
        
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            if (!KiemTraNhapLieu()) return;

            try
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    con.Open();
                    // Lệnh SQL chèn đầy đủ các cột bạn đang hiện trên Form
                    string sql = @"INSERT INTO SanPham (MaSP, TenSP, MaLoai, TrongLuong, TienCong, SoLuongTon, GiaNiemYet, ThanhTien) 
                           VALUES (@ma, @ten, @loai, @tl, @tc, @sl, @gia, @tong)";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@ma", textBox2.Text.Trim());   // Mã SP
                    cmd.Parameters.AddWithValue("@ten", textBox1.Text.Trim());  // Tên SP
                    cmd.Parameters.AddWithValue("@loai", textBox3.Text.Trim()); // Loại vàng
                    cmd.Parameters.AddWithValue("@tl", double.Parse(textBox5.Text));
                    cmd.Parameters.AddWithValue("@tc", decimal.Parse(textBox4.Text));
                    cmd.Parameters.AddWithValue("@sl", int.Parse(textBox6.Text));
                    // Xóa dấu phẩy trước khi chuyển sang số để tránh văng lỗi Format
                    decimal.TryParse(textBox7.Text.Replace(",", ""), out decimal gia);
                    decimal.TryParse(textBox8.Text.Replace(",", ""), out decimal tong);
                    cmd.Parameters.AddWithValue("@gia", gia);
                    cmd.Parameters.AddWithValue("@tong", tong);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm sản phẩm mới thành công!");
                    LoadDataDirect(); // Chỉ load lại bảng, không sửa logic load của bạn
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi khi thêm: " + ex.Message); }
        }
        private void button8_Click_2(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text)) // textBox2 là ô chứa Mã SP
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm từ bảng để sửa!");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    con.Open();
                    string sqlUpdate = @"UPDATE SanPham 
            SET TenSP = @ten, 
                MaLoai = @loai,
                TrongLuong = @tl, 
                TienCong = @tc, 
                SoLuongTon = @sl,
                GiaNiemYet = @gia,
                ThanhTien = @tong
            WHERE MaSP = @maSP";

                    SqlCommand cmd = new SqlCommand(sqlUpdate, con);
                    cmd.Parameters.AddWithValue("@maSP", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@ten", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@loai", textBox3.Text.Trim());

                    double.TryParse(textBox5.Text, out double tl);
                    decimal.TryParse(textBox4.Text.Replace(",", ""), out decimal tc);
                    int.TryParse(textBox6.Text, out int sl);
                    decimal.TryParse(textBox7.Text.Replace(",", ""), out decimal gia);
                    decimal.TryParse(textBox8.Text.Replace(",", ""), out decimal tong);

                    cmd.Parameters.AddWithValue("@tl", tl);
                    cmd.Parameters.AddWithValue("@tc", tc);
                    cmd.Parameters.AddWithValue("@sl", sl);
                    cmd.Parameters.AddWithValue("@gia", gia);
                    cmd.Parameters.AddWithValue("@tong", tong);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã cập nhật thông tin sản phẩm " + textBox2.Text);
                    LoadDataDirect();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi Sửa: " + ex.Message); }
        }
        private bool KiemTraNhapLieu()
        {
            // 1. Chặn để trống Tên, Loại vàng, Tiền công, Trọng lượng hoặc Tồn kho
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Bảo ơi, bạn phải nhập đầy đủ các ô thông tin bên phải nhé!", "Thiếu thông tin");
                return false;
            }

            // 2. Kiểm tra xem các ô số có bị nhập nhầm chữ hay không
            double tl; decimal tc; int tk;
            bool laSoTl = double.TryParse(textBox5.Text, out tl);
            bool laSoTc = decimal.TryParse(textBox4.Text, out tc);
            bool laSoTk = int.TryParse(textBox6.Text, out tk);

            if (!laSoTl || !laSoTc || !laSoTk)
            {
                MessageBox.Show("Trọng lượng, Tiền công và Tồn kho phải là số (không được nhập chữ)!", "Lỗi nhập liệu");
                return false;
            }

            // 3. Chặn trường hợp nhập số 0 hoặc số âm làm sai lệch kho
            if (tl <= 0)
            {
                MessageBox.Show("Trọng lượng sản phẩm phải lớn hơn 0 mới hợp lệ!");
                return false;
            }

            return true; // Nếu vượt qua hết thì cho phép Thêm/Sửa
        
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string tenCanTim = textBox1.Text.Trim();
                if (string.IsNullOrEmpty(tenCanTim)) return;

                try
                {
                    using (SqlConnection con = new SqlConnection(strCon))
                    {
                        con.Open();
                        // 1. Phải SELECT thêm MaSP thì mới có số 1, 2 để hiện vào ô Mã
                        string sql = @"SELECT S.MaSP, S.TenSP, S.LoaiVang, S.TrongLuong, S.SoLuongTon, S.TienCong, S.GiaNiemYet 
                               FROM SanPham S 
                               WHERE S.TenSP LIKE N'%' + @ten + '%'";

                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@ten", tenCanTim);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Dán đoạn này vào thay thế cái cũ:
                                textBox2.Text = reader["MaSP"].ToString();  // Mã SP hiện vào ô số 2
                                textBox1.Text = reader["TenSP"].ToString(); // Tên SP hiện vào ô số 1

                                textBox3.Text = reader["LoaiVang"].ToString();
                                textBox5.Text = reader["TrongLuong"].ToString();
                                textBox4.Text = reader["TienCong"].ToString();
                                textBox6.Text = reader["SoLuongTon"].ToString();
                                textBox7.Text = reader["GiaNiemYet"].ToString();
                            }
                            else { MessageBox.Show("Không tìm thấy món này Bảo ơi!"); }
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi tìm kiếm: " + ex.Message); }
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

       

        private void button9_Click_1(object sender, EventArgs e)
        {
            // 1. Xóa sạch nội dung trong tất cả các ô nhập liệu bên phải
            textBox1.Clear(); // Tên sản phẩm
            textBox2.Clear(); // Mã sản phẩm
            textBox3.Clear(); // Loại vàng
            textBox4.Clear(); // Tiền công
            textBox5.Clear(); // Trọng lượng
            textBox6.Clear(); // Tồn kho
            textBox7.Clear(); // Giá niêm yết
            textBox8.Clear(); // Thành tiền bán

            // 2. Tải lại dữ liệu từ SQL lên bảng bên trái để đảm bảo khớp dữ liệu mới nhất
            LoadDataDirect();

            // 3. Đưa con trỏ chuột về ô Tên sản phẩm để Bảo nhập món mới cho nhanh
            textBox1.Focus();

            MessageBox.Show("Đã làm mới dữ liệu, Bảo nhập món mới đi nhé!");
        
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click_2(object sender, EventArgs e)
        {

        }

        private void button11_Click_2(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            string tenSP = dataGridView1.CurrentRow.Cells["Tên Sản Phẩm"].Value.ToString();
            DialogResult dr = MessageBox.Show($"Bảo có chắc muốn xóa '{tenSP}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    string maSP = dataGridView1.CurrentRow.Cells["Mã SP"].Value.ToString();
                    using (SqlConnection con = new SqlConnection(strCon))
                    {
                        con.Open();
                        string sqlDelete = "DELETE FROM SanPham WHERE MaSP = @maSP";
                        SqlCommand cmd = new SqlCommand(sqlDelete, con);
                        cmd.Parameters.AddWithValue("@maSP", maSP);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Đã xóa xong món này!");
                        LoadDataDirect();
                    }
                }
                catch { MessageBox.Show("Món này đã có trong hóa đơn nên không xóa được Bảo ơi!"); }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }
    }
    }

    


    






