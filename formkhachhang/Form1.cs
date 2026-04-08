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
namespace formkhachhang
{
    public partial class Form1 : Form
    {
        string strCon = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyVangBac;Integrated Security=True";
        SqlConnection sqlCon = null;
        int maKH_DangChon = -1;
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }
        private bool KiemTraNhapLieu()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Họ tên không được để trống nha em!");
                textBox1.Focus(); return false;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text) || textBox2.Text.Length < 10)
            {
                MessageBox.Show("Số điện thoại phải có ít nhất 10 số !");
                textBox2.Focus(); return false;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Em quên nhập số CCCD rồi kìa!");
                textBox3.Focus(); return false;
            }
            return true; 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // Đảm bảo không bấm nhầm tiêu đề
            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                try
                {
                    // DÒNG QUAN TRỌNG NHẤT NẰM ĐÂY: Bắt lấy Mã KH gán vào biến
                    maKH_DangChon = Convert.ToInt32(row.Cells["Mã KH"].Value);

                    // Đổ dữ liệu lên các ô chữ để sửa
                    textBox1.Text = row.Cells["Họ và tên"].Value?.ToString() ?? "";
                    textBox2.Text = row.Cells["Số điện thoại"].Value?.ToString() ?? "";
                    textBox3.Text = row.Cells["Cccd"].Value?.ToString() ?? "";
                    textBox4.Text = row.Cells["Địa chỉ"].Value?.ToString() ?? "";
                    textBox5.Text = row.Cells["Ngày bán vàng"].Value?.ToString() ?? "";

                    string gioiTinh = row.Cells["Giới tính"].Value?.ToString() ?? "";
                    if (gioiTinh == "Nam")
                        radioButton1.Checked = true;
                    else
                        radioButton2.Checked = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ông chưa chạy lại đoạn SQL tôi gửi đúng không? \nLỗi: " + ex.Message);
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            try
            {
                // 1. Kiểm tra và khởi tạo kết nối
                if (sqlCon == null) sqlCon = new SqlConnection(strCon);

                // 2. Gọi cái Procedure 
                SqlCommand sqlCmd = new SqlCommand("sp_LayDanhSachKhachHang", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                // 3. Dùng Adapter để đổ dữ liệu vào bộ nhớ tạm (DataTable)
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // 4. Đẩy dữ liệu lên cái lưới trên màn hình
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi rồi em ơi: " + ex.Message);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra rỗng trước khi thêm
            if (!KiemTraNhapLieu()) return;

            try
            {
                // 2. Dùng biến strCon để kết nối
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();
                    // 3. Gọi Store Procedure Thêm Khách Hàng
                    SqlCommand cmd = new SqlCommand("sp_LuuKhachHangVaoData", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 4. Truyền 5 tham số chuẩn theo SQL
                    cmd.Parameters.AddWithValue("@TenKH", textBox1.Text);
                    cmd.Parameters.AddWithValue("@SDT", textBox2.Text);
                    cmd.Parameters.AddWithValue("@CCCD", textBox3.Text);
                    cmd.Parameters.AddWithValue("@DiaChi", textBox4.Text);
                    cmd.Parameters.AddWithValue("@GioiTinh", radioButton1.Checked ? "Nam" : "Nữ");

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã THÊM khách hàng mới thành công!");

                    LoadData(); // Cập nhật lưới
                    button5_Click(sender, e); // Làm trắng Form
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm (Có thể trùng SĐT hoặc CCCD): " + ex.Message);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text)) return;

            if (MessageBox.Show("Em có chắc muốn xóa khách này không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(strCon))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM KhachHang WHERE SDT = @sdt", con);
                        cmd.Parameters.AddWithValue("@sdt", textBox2.Text.Trim());
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Anh đã xóa xong rồi nhé!");
                        LoadData();
                        button5_Click(sender, e); // Chỉ xóa trắng TextBox, KHÔNG gọi nút Lưu
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            // Nếu biến vẫn là -1 nghĩa là chưa click chọn ai
            if (maKH_DangChon == -1)
            {
                MessageBox.Show("Em phải chọn 1 khách hàng dưới bảng để SỬA nhé!");
                return;
            }

            if (!KiemTraNhapLieu()) return; //

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon)) //
                {
                    conn.Open();
                    // Dùng thẳng lệnh UPDATE cho nhanh gọn, không lo gọi nhầm Store
                    string query = "UPDATE KhachHang SET TenKH = @TenKH, SDT = @SDT, CCCD = @CCCD, DiaChi = @DiaChi, GioiTinh = @GioiTinh WHERE MaKH = @MaKH";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Phải truyền @MaKH để nó biết sửa ai
                    cmd.Parameters.AddWithValue("@MaKH", maKH_DangChon);
                    cmd.Parameters.AddWithValue("@TenKH", textBox1.Text);
                    cmd.Parameters.AddWithValue("@SDT", textBox2.Text);
                    cmd.Parameters.AddWithValue("@CCCD", textBox3.Text);
                    cmd.Parameters.AddWithValue("@DiaChi", textBox4.Text);
                    cmd.Parameters.AddWithValue("@GioiTinh", radioButton1.Checked ? "Nam" : "Nữ");

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("SỬA thông tin thành công!");

                    LoadData(); //
                    button5_Click(sender, e); //
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
           
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                try
                {
                    // Gọi thẳng tên cột giống hệt trong SQL
                    textBox1.Text = row.Cells["Họ và tên"].Value?.ToString() ?? "";
                    textBox2.Text = row.Cells["Số điện thoại"].Value?.ToString() ?? "";
                    textBox3.Text = row.Cells["Cccd"].Value?.ToString() ?? "";
                    textBox4.Text = row.Cells["Địa chỉ"].Value?.ToString() ?? "";

                    // Nếu cái bảng chưa có 2 cột này thì comment (//) 2 dòng này lại tạm nhé
                    textBox5.Text = row.Cells["Ngày bán vàng"].Value?.ToString() ?? "";
           
                    string gioiTinh = row.Cells["Giới tính"].Value?.ToString() ?? "";
                    if (gioiTinh == "Nam")
                        radioButton1.Checked = true;
                    else
                        radioButton2.Checked = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cột em tìm không có trong bảng! Vui lòng kiểm tra lại SQL.\nLỗi chi tiết: " + ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear();
            textBox4.Clear(); textBox5.Clear(); 
            radioButton1.Checked = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Em có chắc muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
