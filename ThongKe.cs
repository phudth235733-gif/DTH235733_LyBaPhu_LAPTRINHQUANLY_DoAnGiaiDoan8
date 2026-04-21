using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using OfficeOpenXml;       // Của thư viện EPPlus
using OfficeOpenXml.Style; // Định dạng Excel
using System.Drawing.Printing; // Dành cho In Báo Cáo

namespace QuanLyQuanNet
{
    public partial class ThongKe : UserControl
    {
        // Khai báo chuỗi kết nối dùng chung
        private string chuoiKetNoi = "Server=localhost;Database=QuanLyQuanNet;Uid=root;Pwd=123456;";


        public ThongKe()
        {
            InitializeComponent();

            // Móc sự kiện cho 3 nút ở dưới (Dữ liệu cũ từ Form1)
            btnDoanhThu.Click += (s, e) => VeBieuDo("Doanh Thu Hôm Nay (VNĐ)", Form1.dataDoanhThu, Color.Lime);
            btnPCHD.Click += (s, e) => VeBieuDo("PC Đang Hoạt Động", Form1.dataSoMay, Color.Tomato);
            btnMember.Click += (s, e) => VeBieuDo("Thành Viên Mới", Form1.dataSoUser, Color.DeepSkyBlue);
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            CauHinhGiaoDienToi();



            // 1. Cài đặt các mốc thời gian cho cbmThangNay
            cbmThangNay.Items.Clear();
            cbmThangNay.Items.AddRange(new string[] { "Hôm nay", "Tuần này", "Tháng này", "Tháng trước", "Tất cả" });

            // 2. Chọn mặc định là "Tháng này" (Sự kiện SelectedIndexChanged sẽ tự động chạy và Load data)
            if (cbmThangNay.Items.Count > 0) cbmThangNay.SelectedIndex = 2;

            // Cập nhật text cho 3 nút ở dưới (Theo data Form1)
            CapNhatThongTin3Nut();
        }

        // ==============================================================
        // SỰ KIỆN KHI CHỌN COMBOBOX (LỌC THỜI GIAN)
        // ==============================================================
        private void cbmThangNay_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            // Tự động tính toán và nhảy ngày theo lựa chọn
            switch (cbmThangNay.Text)
            {
                case "Hôm nay":
                    dtpTuNgay.Value = now.Date;
                    dtpDenNgay.Value = now.Date;
                    break;

                case "Tuần này":
                    // Tính từ Thứ 2 của tuần hiện tại đến hôm nay
                    int diff = (7 + (now.DayOfWeek - DayOfWeek.Monday)) % 7;
                    dtpTuNgay.Value = now.AddDays(-1 * diff).Date;
                    dtpDenNgay.Value = now.Date;
                    break;

                case "Tháng này":
                    dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
                    dtpDenNgay.Value = now.Date; // Chỉ lấy đến ngày hôm nay
                    break;

                case "Tháng trước":
                    DateTime thangTruoc = now.AddMonths(-1);
                    dtpTuNgay.Value = new DateTime(thangTruoc.Year, thangTruoc.Month, 1);
                    dtpDenNgay.Value = new DateTime(thangTruoc.Year, thangTruoc.Month, DateTime.DaysInMonth(thangTruoc.Year, thangTruoc.Month));
                    break;

                case "Tất cả":
                    dtpTuNgay.Value = new DateTime(2024, 1, 1); // Hoặc năm mở quán
                    dtpDenNgay.Value = now.Date;
                    break;
            }

            // GỌI HÀM LẤY DỮ LIỆU TỪ MYSQL NGAY SAU KHI TÍNH NGÀY XONG
            LoadDuLieuThongKe();
        }

        // ==============================================================
        // KẾT NỐI MYSQL VÀ TÍNH DOANH THU (BẢN CHUẨN DATETIME 100%)
        // ==============================================================
        private void LoadDuLieuThongKe()
        {
            // CÁCH CHUẨN: Dùng object DateTime thay vì ép String
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1); // Ép tới 23:59:59 của ngày đó

            try
            {
                using (MySqlConnection conn = new MySqlConnection(chuoiKetNoi))
                {
                    conn.Open();

                    // 1. Tính tổng Doanh Thu
                    string queryTien = "SELECT IFNULL(SUM(ThanhToan), 0) FROM GiaoDich WHERE ThoiGian BETWEEN @TuNgay AND @DenNgay";

                    MySqlCommand cmdTien = new MySqlCommand(queryTien, conn);
                    // Ép chuẩn tham số MySqlDbType.DateTime để không bao giờ bị lệch 
                    cmdTien.Parameters.Add("@TuNgay", MySqlDbType.DateTime).Value = tuNgay;
                    cmdTien.Parameters.Add("@DenNgay", MySqlDbType.DateTime).Value = denNgay;

                    double tong = Convert.ToDouble(cmdTien.ExecuteScalar());

                    // Cập nhật lên ô txtDoanhThu
                    txtDoanhThu.Text = tong.ToString("#,##0") + " VNĐ";

                    // 2. Vẽ Biểu đồ từ DB
                    VeBieuDoDatabase(conn, tuNgay, denNgay);
                }
            }
            catch (Exception ex)
            {
                // Hiện lỗi chi tiết nếu MySQL báo sai
                MessageBox.Show("Lỗi Database: " + ex.Message, "Báo Cáo");
            }
        }

        // ==============================================================
        // VẼ BIỂU ĐỒ TỪ DỮ LIỆU MYSQL
        // ==============================================================
        private void VeBieuDoDatabase(MySqlConnection conn, DateTime tuNgay, DateTime denNgay)
        {
            string sqlChart = @"
                SELECT DATE(ThoiGian) AS Ngay, SUM(ThanhToan) AS Tien
                FROM GiaoDich 
                WHERE ThoiGian BETWEEN @TuNgay AND @DenNgay
                GROUP BY DATE(ThoiGian) 
                ORDER BY Ngay ASC";

            MySqlCommand cmdChart = new MySqlCommand(sqlChart, conn);
            cmdChart.Parameters.Add("@TuNgay", MySqlDbType.DateTime).Value = tuNgay;
            cmdChart.Parameters.Add("@DenNgay", MySqlDbType.DateTime).Value = denNgay;

            MySqlDataAdapter da = new MySqlDataAdapter(cmdChart);
            DataTable dtChart = new DataTable();
            da.Fill(dtChart);

            // Xóa dữ liệu cũ, chuẩn bị vẽ nét mới
            chartThongKe.Series.Clear();
            chartThongKe.Series.Add("Data");

            var series = chartThongKe.Series["Data"];
            series.ChartType = SeriesChartType.Area;
            series.Color = Color.FromArgb(70, Color.Lime);
            series.BorderColor = Color.Lime;
            series.BorderWidth = 3;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 7;
            series.MarkerColor = Color.White;
            series.MarkerBorderColor = Color.Lime;

            // Đổi tiêu đề
            chartThongKe.Titles.Clear();
            chartThongKe.Titles.Add("Biểu Đồ Doanh Thu");
            chartThongKe.Titles[0].ForeColor = Color.White;
            chartThongKe.Titles[0].Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            chartThongKe.Titles[0].Alignment = ContentAlignment.TopLeft;

            // Chấm điểm lên trục đồ thị (Chỉ chấm nếu có dữ liệu)
            if (dtChart.Rows.Count > 0)
            {
                foreach (DataRow row in dtChart.Rows)
                {
                    string ngayX = Convert.ToDateTime(row["Ngay"]).ToString("dd/MM");
                    double tienY = Convert.ToDouble(row["Tien"]);
                    series.Points.AddXY(ngayX, tienY);
                }
            }
        }

        // ==============================================================
        // CÁC HÀM CŨ (Đã giữ lại để không hỏng code của ní)
        // ==============================================================
        private void CauHinhGiaoDienToi()
        {
            Color mauNen = Color.FromArgb(30, 31, 34);
            Color mauLuoi = Color.FromArgb(64, 66, 73);

            chartThongKe.BackColor = mauNen;
            chartThongKe.ChartAreas[0].BackColor = mauNen;
            chartThongKe.Legends.Clear();
            chartThongKe.BorderlineColor = mauNen;

            var chartArea = chartThongKe.ChartAreas[0];
            chartArea.AxisX.LabelStyle.ForeColor = Color.Silver;
            chartArea.AxisY.LabelStyle.ForeColor = Color.Silver;

            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.LineColor = mauLuoi;
            chartArea.AxisX.LineColor = mauLuoi;
            chartArea.AxisY.LineColor = mauLuoi;

            chartArea.AxisY.IsStartedFromZero = true;
        }

        private void CapNhatThongTin3Nut()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(chuoiKetNoi))
                {
                    conn.Open();

                    // 1. Tự động lôi Tổng Doanh Thu hôm nay từ SQL
                    string sqlDoanhThu = "SELECT IFNULL(SUM(ThanhToan), 0) FROM GiaoDich WHERE DATE(ThoiGian) = CURDATE()";
                    MySqlCommand cmd1 = new MySqlCommand(sqlDoanhThu, conn);
                    double tongDoanhThu = Convert.ToDouble(cmd1.ExecuteScalar());

                    // 2. Tự động đếm trực tiếp xem CÓ BAO NHIÊU MÁY ĐANG BẬT trong kho TrangThaiMay
                    string sqlMayBat = "SELECT COUNT(*) FROM TrangThaiMay WHERE TrangThai = 'CoKhach'";
                    MySqlCommand cmd2 = new MySqlCommand(sqlMayBat, conn);
                    int soMayDangBat = Convert.ToInt32(cmd2.ExecuteScalar());

                    // 3. Tự động đếm số lượng khách (Thành viên) đã nạp tiền/chơi hôm nay
                    string sqlUser = "SELECT COUNT(DISTINCT ThanhVien) FROM GiaoDich WHERE DATE(ThoiGian) = CURDATE()";
                    MySqlCommand cmd3 = new MySqlCommand(sqlUser, conn);
                    int tongUser = Convert.ToInt32(cmd3.ExecuteScalar());

                    // Tự động đắp số liệu lên 3 nút trên màn hình
                    btnDoanhThu.Text = $"Doanh thu\n{tongDoanhThu:#,##0} VNĐ";
                    btnPCHD.Text = $"PC Đang bật\n{soMayDangBat}";
                    btnMember.Text = $"Tổng User\n{tongUser}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy thông tin 3 nút: " + ex.Message);
            }
        }
        // Hàm vẽ biểu đồ theo Giờ (Dùng cho 3 nút ở dưới)
        private void VeBieuDo<T>(string tieuDe, Dictionary<int, T> duLieu, Color mauSac)
        {
            chartThongKe.Series.Clear();
            chartThongKe.Series.Add("Data");

            var series = chartThongKe.Series["Data"];
            series.ChartType = SeriesChartType.Area;
            series.Color = Color.FromArgb(70, mauSac);
            series.BorderColor = mauSac;
            series.BorderWidth = 3;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 7;
            series.MarkerColor = Color.White;
            series.MarkerBorderColor = mauSac;

            chartThongKe.Titles.Clear();
            chartThongKe.Titles.Add(tieuDe);
            chartThongKe.Titles[0].ForeColor = Color.White;
            chartThongKe.Titles[0].Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            chartThongKe.Titles[0].Alignment = ContentAlignment.TopLeft;

            for (int h = 0; h < 24; h++)
            {
                double giaTri = duLieu.ContainsKey(h) ? Convert.ToDouble(duLieu[h]) : 0;
                series.Points.AddXY(h.ToString() + "h", giaTri);
            }
        }

        // Hàm trống để chống lỗi Designer
        private void dgvThongKeChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        // Vẫn giữ lại sự kiện tự chọn tay trên lịch
        private void dtpTuNgay_ValueChanged(object sender, EventArgs e) => LoadDuLieuThongKe();
        private void dtpDenNgay_ValueChanged(object sender, EventArgs e) => LoadDuLieuThongKe();

        // Nút Lọc (Nếu ní có bấm Lọc thủ công)
        private void btnLoc_Click(object sender, EventArgs e)
        {
            // Chèn dòng này vào để test
            MessageBox.Show($"Đang tiến hành lọc từ ngày {dtpTuNgay.Value.ToString("dd/MM/yyyy")} đến {dtpDenNgay.Value.ToString("dd/MM/yyyy")}", "Kểm tra nút");

            LoadDuLieuThongKe();
        }

        // ==============================================================
        // HÀM BỔ TRỢ: LẤY CHI TIẾT GIAO DỊCH ĐỂ XUẤT BÁO CÁO
        // ==============================================================
        private DataTable LayChiTietGiaoDich()
        {
            DataTable dt = new DataTable();
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);

            using (MySqlConnection conn = new MySqlConnection(chuoiKetNoi))
            {
                // Lấy chi tiết để in/xuất excel
                string sql = @"SELECT ThoiGian AS 'Thời Gian', MoTa AS 'Mô Tả Giao Dịch', 
                                      ThanhVien AS 'Người Dùng', ThanhToan AS 'Số Tiền (VNĐ)', Nguon AS 'Nguồn Thu'
                               FROM GiaoDich 
                               WHERE ThoiGian BETWEEN @TuNgay AND @DenNgay 
                               ORDER BY ThoiGian DESC";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add("@TuNgay", MySqlDbType.DateTime).Value = tuNgay;
                cmd.Parameters.Add("@DenNgay", MySqlDbType.DateTime).Value = denNgay;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        // ==============================================================
        // 1. CHỨC NĂNG XUẤT EXCEL (CHUYÊN NGHIỆP) - ĐÃ FIX EPPLUS 8+
        // ==============================================================
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            // TUI ĐÃ FIX CHỖ NÀY CHO NÍ: Dùng SetNonCommercialPersonal thay vì kiểu cũ
            ExcelPackage.License.SetNonCommercialPersonal("QuanLyQuanNet");

            DataTable dt = LayChiTietGiaoDich();
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu trong khoảng thời gian này để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
            sfd.FileName = $"BaoCaoDoanhThu_{DateTime.Now.ToString("ddMMyyyy")}.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor; // Đổi con trỏ chuột thành hình chờ

                    using (ExcelPackage pck = new ExcelPackage())
                    {
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Doanh Thu");

                        // 1. Ghi Tiêu đề Báo Cáo
                        ws.Cells["A1:E1"].Merge = true;
                        ws.Cells["A1"].Value = "BÁO CÁO CHI TIẾT DOANH THU QUÁN NET";
                        ws.Cells["A1"].Style.Font.Bold = true;
                        ws.Cells["A1"].Style.Font.Size = 16;
                        ws.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        ws.Cells["A2:E2"].Merge = true;
                        ws.Cells["A2"].Value = $"Từ ngày: {dtpTuNgay.Value.ToString("dd/MM/yyyy")} - Đến ngày: {dtpDenNgay.Value.ToString("dd/MM/yyyy")}";
                        ws.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells["A2"].Style.Font.Italic = true;

                        // 2. Đổ Headers (Tên cột)
                        int startRow = 4;
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            ws.Cells[startRow, i + 1].Value = dt.Columns[i].ColumnName;
                            ws.Cells[startRow, i + 1].Style.Font.Bold = true;
                            ws.Cells[startRow, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws.Cells[startRow, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(70, 130, 180)); // Màu nền cột xanh thép
                            ws.Cells[startRow, i + 1].Style.Font.Color.SetColor(Color.White);
                        }

                        // 3. Đổ Dữ liệu
                        int row = startRow + 1;
                        double tongTien = 0;
                        foreach (DataRow dr in dt.Rows)
                        {
                            ws.Cells[row, 1].Value = Convert.ToDateTime(dr["Thời Gian"]).ToString("dd/MM/yyyy HH:mm");
                            ws.Cells[row, 2].Value = dr["Mô Tả Giao Dịch"].ToString();
                            ws.Cells[row, 3].Value = dr["Người Dùng"].ToString();
                            ws.Cells[row, 4].Value = Convert.ToDouble(dr["Số Tiền (VNĐ)"]);
                            ws.Cells[row, 5].Value = dr["Nguồn Thu"].ToString();

                            tongTien += Convert.ToDouble(dr["Số Tiền (VNĐ)"]);
                            row++;
                        }

                        // 4. Dòng Tổng Cộng
                        ws.Cells[row, 3].Value = "TỔNG CỘNG:";
                        ws.Cells[row, 3].Style.Font.Bold = true;
                        ws.Cells[row, 4].Value = tongTien;
                        ws.Cells[row, 4].Style.Font.Bold = true;
                        ws.Cells[row, 4].Style.Font.Color.SetColor(Color.Red);

                        // 5. Định dạng (Format) chuyên nghiệp
                        ws.Cells[startRow, 4, row, 4].Style.Numberformat.Format = "#,##0"; // Cột tiền
                        ws.Cells[startRow, 1, row, 5].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        ws.Cells[startRow, 1, row, 5].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        ws.Cells[startRow, 1, row, 5].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        ws.Cells[startRow, 1, row, 5].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                        ws.Cells.AutoFitColumns(); // Tự động độ rộng cột

                        // Lưu file
                        FileInfo fi = new FileInfo(sfd.FileName);
                        pck.SaveAs(fi);
                    }
                    MessageBox.Show("Xuất Excel thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Cursor = Cursors.Default; // Trả lại chuột bình thường
                }
            }
        }

        // ==============================================================
        // 2. CHỨC NĂNG XUẤT BÁO CÁO (XEM TRƯỚC / IN / LƯU PDF)
        // ==============================================================
        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            DataTable dt = LayChiTietGiaoDich();
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += (s, ev) => PrintDoc_PrintPage(s, ev, dt); // Gọi hàm vẽ giấy in

            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDoc;
            previewDialog.Width = 800;
            previewDialog.Height = 600;
            previewDialog.ShowDialog(); // Mở bảng xem trước
        }

        // Hàm thiết kế trang in (Dùng bút vẽ lên tờ giấy trắng)
        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e, DataTable dt)
        {
            Graphics g = e.Graphics;
            Font fontTieuDe = new Font("Arial", 18, FontStyle.Bold);
            Font fontThuong = new Font("Arial", 12, FontStyle.Regular);
            Font fontDam = new Font("Arial", 12, FontStyle.Bold);
            Brush brush = Brushes.Black;

            int yPos = 40;
            int margin = 50;

            // 1. Vẽ Tiêu đề quán
            g.DrawString("G-CAFE INTERNET ESPORTS", fontDam, brush, margin, yPos);
            yPos += 30;
            g.DrawString("BÁO CÁO DOANH THU HOẠT ĐỘNG", fontTieuDe, brush, margin + 150, yPos);
            yPos += 40;
            g.DrawString($"Thời gian: {dtpTuNgay.Value.ToString("dd/MM/yyyy")} đến {dtpDenNgay.Value.ToString("dd/MM/yyyy")}", fontThuong, brush, margin + 200, yPos);
            yPos += 50;

            // 2. Vẽ Tiêu đề cột bảng
            g.DrawLine(Pens.Black, margin, yPos, e.PageBounds.Width - margin, yPos);
            yPos += 10;
            g.DrawString("Thời gian", fontDam, brush, margin, yPos);
            g.DrawString("Mô tả", fontDam, brush, margin + 150, yPos);
            g.DrawString("Người dùng", fontDam, brush, margin + 350, yPos);
            g.DrawString("Nguồn", fontDam, brush, margin + 500, yPos);
            g.DrawString("Số tiền", fontDam, brush, margin + 600, yPos);
            yPos += 25;
            g.DrawLine(Pens.Black, margin, yPos, e.PageBounds.Width - margin, yPos);
            yPos += 10;

            // 3. Vẽ dữ liệu từng dòng
            double tongTien = 0;
            foreach (DataRow row in dt.Rows)
            {
                string thoiGian = Convert.ToDateTime(row["Thời Gian"]).ToString("dd/MM HH:mm");
                string moTa = row["Mô Tả Giao Dịch"].ToString();
                if (moTa.Length > 20) moTa = moTa.Substring(0, 17) + "..."; // Cắt ngắn nếu quá dài

                string nguoiDung = row["Người Dùng"].ToString();
                string nguon = row["Nguồn Thu"].ToString();
                double tien = Convert.ToDouble(row["Số Tiền (VNĐ)"]);

                g.DrawString(thoiGian, fontThuong, brush, margin, yPos);
                g.DrawString(moTa, fontThuong, brush, margin + 150, yPos);
                g.DrawString(nguoiDung, fontThuong, brush, margin + 350, yPos);
                g.DrawString(nguon, fontThuong, brush, margin + 500, yPos);
                g.DrawString(tien.ToString("#,##0"), fontThuong, brush, margin + 600, yPos);

                tongTien += tien;
                yPos += 30;

                // Nếu in dài quá hết 1 trang (Giả sử cơ bản 1 trang)
                if (yPos > e.PageBounds.Height - 100)
                {
                    g.DrawString("... (Xem tiếp trang sau) ...", fontThuong, brush, margin + 250, yPos);
                    break; // Bản cơ bản tui viết 1 trang. Ní muốn in nhiều trang thì cần nâng cao thêm biến đếm.
                }
            }

            // 4. Vẽ Tổng kết
            yPos += 10;
            g.DrawLine(Pens.Black, margin, yPos, e.PageBounds.Width - margin, yPos);
            yPos += 10;
            g.DrawString("TỔNG DOANH THU:", fontDam, Brushes.Red, margin + 400, yPos);
            g.DrawString(tongTien.ToString("#,##0") + " VNĐ", fontDam, Brushes.Red, margin + 600, yPos);
        }

        private void chartThongKe_Click(object sender, EventArgs e)
        {

        }

        private void btnMember_Click(object sender, EventArgs e)
        {

        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {

        }

        private void btnPCHD_Click(object sender, EventArgs e)
        {

        }
    }
}