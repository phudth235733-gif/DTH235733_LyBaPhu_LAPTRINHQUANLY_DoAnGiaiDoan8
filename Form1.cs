using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace QuanLyQuanNet
{
    public partial class Form1 : Form
    {
        // ==========================================
        // 1. KẾT NỐI DATABASE VÀ BIẾN TẠM CHO BIỂU ĐỒ
        // ==========================================
        DataService db = new DataService();

        public static Dictionary<int, long> dataDoanhThu = new Dictionary<int, long>();
        public static Dictionary<int, int> dataSoMay = new Dictionary<int, int>();
        public static Dictionary<int, int> dataSoUser = new Dictionary<int, int>();

        // KHAI BÁO CÁC BIẾN GIAO DIỆN VÀ PHÂN QUYỀN
        ThongKe trangThongKe;
        TrangGiaoDich trangGD;
        private ucKhachHang trangKhachHang;
        private GiaoCa trangGiaoCa;
        private Kho trangKho;
        // ĐÃ XÓA DÒNG KHAI BÁO KHO HÀNG Ở ĐÂY VÌ MÌNH KHÔNG DÙNG USERCONTROL NỮA

        Form formDangNhap;
        string quyenHan = "";
        string tenNhanVien = "";
        string duongDanAnh = "";

        // ==========================================
        // HÀM KHỞI TẠO
        // ==========================================
        public Form1(Form frmLogin, string quyen, string hoTen = "", string linkAnh = "")
        {
            InitializeComponent();
            formDangNhap = frmLogin;
            quyenHan = quyen;
            tenNhanVien = string.IsNullOrEmpty(hoTen) ? "Admin" : hoTen;
            duongDanAnh = linkAnh;

            for (int h = 0; h < 24; h++)
            {
                dataDoanhThu[h] = 0;
                dataSoMay[h] = 0;
                dataSoUser[h] = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            LoadDanhSachMay();

            Timer timerDongBo = new Timer();
            timerDongBo.Interval = 3000;
            timerDongBo.Tick += (s, ev) => { DongBoTrangThaiMay(); };
            timerDongBo.Start();

            LoadCacMayDangHoatDongTuSQL();

            if (quyenHan == "Nhân Viên")
            {
                btnThongKe.Enabled = false;
                btnGiaoDich.Enabled = false;
                this.Text = $"Phần mềm Quản Lý Quán Net - Trực máy: NHÂN VIÊN ({tenNhanVien})";
            }
            else
            {
                this.Text = $"Phần mềm Quản Lý Quán Net - Trực máy: CHỦ QUÁN ({tenNhanVien})";
            }
        }

        // ==========================================
        // QUẢN LÝ DANH SÁCH MÁY
        // ==========================================
        private void LoadDanhSachMay()
        {
            flpViTriPC.Controls.Clear();
            cmbChonPC.Items.Clear();

            for (int i = 1; i <= 30; i++)
            {
                string tenMay = "PC " + i.ToString("00");

                ucTramMay tramMay = new ucTramMay();
                tramMay.Name = "uc" + tenMay.Replace(" ", "");
                tramMay.TenMay = tenMay;
                tramMay.Margin = new Padding(10);
                tramMay.Tag = "Trong";
                tramMay.SetStatus(false);

                tramMay.Click += May_Click;

                flpViTriPC.Controls.Add(tramMay);
                cmbChonPC.Items.Add(tenMay);
            }

            if (cmbChonPC.Items.Count > 0) cmbChonPC.SelectedIndex = 0;
        }

        private void May_Click(object sender, EventArgs e)
        {
            ucTramMay mayDuocChon = sender as ucTramMay;
            if (mayDuocChon != null)
            {
                cmbChonPC.Text = mayDuocChon.TenMay;
                foreach (Control ctrl in flpViTriPC.Controls)
                {
                    if (ctrl is ucTramMay may) may.SetSelected(false);
                }
                mayDuocChon.SetSelected(true);
            }
        }

        private void cmbChonPC_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mayDangChon = cmbChonPC.Text;
            foreach (Control ctrl in flpViTriPC.Controls)
            {
                if (ctrl is ucTramMay may)
                {
                    if (may.TenMay == mayDangChon) may.SetSelected(true);
                    else may.SetSelected(false);
                }
            }
        }

        private void CapNhatThongKe()
        {
            int count = 0;
            foreach (Control ctrl in flpViTriPC.Controls)
            {
                if (ctrl is ucTramMay may && may.Tag != null && may.Tag.ToString() == "CoKhach") count++;
            }
            dataSoMay[DateTime.Now.Hour] = count;
        }

        // ==========================================
        // CÁC NÚT CHỨC NĂNG CHÍNH
        // ==========================================
        private void btnBatDau_Click(object sender, EventArgs e)
        {
            string mayDangChon = cmbChonPC.Text;
            ucTramMay tramMay = flpViTriPC.Controls["uc" + mayDangChon.Replace(" ", "")] as ucTramMay;

            if (tramMay != null)
            {
                if (tramMay.Tag != null && tramMay.Tag.ToString() == "CoKhach")
                {
                    MessageBox.Show(mayDangChon + " đang có người sử dụng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                tramMay.ThoiGianBatDau = DateTime.Now;
                tramMay.TienTraTruoc = 0;
                tramMay.Tag = "CoKhach";
                tramMay.SetStatus(true, "00:00:00");

                dataSoUser[DateTime.Now.Hour]++;
                CapNhatThongKe();

                MessageBox.Show("Đã mở " + mayDangChon + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string mayDangChon = cmbChonPC.Text;
            ucTramMay tramMay = flpViTriPC.Controls["uc" + mayDangChon.Replace(" ", "")] as ucTramMay;

            if (tramMay != null && tramMay.Tag.ToString() == "CoKhach")
            {
                TimeSpan thoiGianDaChoi = DateTime.Now - tramMay.ThoiGianBatDau;
                int tongSoPhut = (int)Math.Ceiling(thoiGianDaChoi.TotalMinutes);

                double donGiaMotPhut = 10000.0 / 60.0;
                double tongTienGio = tongSoPhut * donGiaMotPhut;
                if (tongTienGio < 2000) tongTienGio = 2000;

                double tienCanThu = tongTienGio - tramMay.TienTraTruoc;

                string hoaDon = $"HÓA ĐƠN THANH TOÁN {mayDangChon}:\n";
                hoaDon += $"- Thời gian chơi: {(int)thoiGianDaChoi.TotalHours} giờ {thoiGianDaChoi.Minutes} phút\n";
                hoaDon += $"- Tổng tiền giờ: {tongTienGio:#,##0} VNĐ\n";
                hoaDon += $"- Khách đã nạp trước: {tramMay.TienTraTruoc:#,##0} VNĐ\n";
                hoaDon += "-------------------------------\n";
                if (tienCanThu > 0) hoaDon += $"=> CẦN THU THÊM: {tienCanThu:#,##0} VNĐ";
                else if (tienCanThu < 0) hoaDon += $"=> TRẢ LẠI TIỀN THỪA: {Math.Abs(tienCanThu):#,##0} VNĐ";
                else hoaDon += $"=> KHÁCH ĐÃ TRẢ VỪA ĐỦ (0 VNĐ)";

                if (MessageBox.Show(hoaDon + "\n\nXác nhận thanh toán?", "Thanh toán", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    try
                    {
                        string sql = "INSERT INTO GiaoDich (ThoiGian, MoTa, ThanhVien, CuocPhi, ThanhToan, Nguon) VALUES (@time, @mota, @user, @phi, @tra, @nguon)";
                        MySqlParameter[] p = {
                            new MySqlParameter("@time", DateTime.Now),
                            new MySqlParameter("@mota", "Thanh toán giờ"),
                            new MySqlParameter("@user", mayDangChon),
                            new MySqlParameter("@phi", tongTienGio),
                            new MySqlParameter("@tra", Math.Max(0, tienCanThu)),
                            new MySqlParameter("@nguon", "Máy Trạm")
                        };
                        db.Execute(sql, p);

                        tramMay.Tag = "Trong";
                        tramMay.TienTraTruoc = 0;
                        tramMay.SetStatus(false);

                        dataDoanhThu[DateTime.Now.Hour] += (long)tongTienGio;
                        CapNhatThongKe();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi lưu Database: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnThemGio_Click(object sender, EventArgs e)
        {
            string mayDangChon = cmbChonPC.Text;
            ucTramMay tramMay = flpViTriPC.Controls["uc" + mayDangChon.Replace(" ", "")] as ucTramMay;

            if (tramMay != null && tramMay.Tag.ToString() == "CoKhach")
            {
                string tienNhapVao = HienThiFormNhapTien(mayDangChon);
                if (double.TryParse(tienNhapVao, out double soTien))
                {
                    try
                    {
                        tramMay.TienTraTruoc += soTien;

                        string sql = "INSERT INTO GiaoDich (ThoiGian, MoTa, ThanhVien, CuocPhi, ThanhToan, Nguon) VALUES (@time, @mota, @user, @phi, @tra, @nguon)";
                        MySqlParameter[] p = {
                            new MySqlParameter("@time", DateTime.Now),
                            new MySqlParameter("@mota", "Nạp tiền"),
                            new MySqlParameter("@user", mayDangChon),
                            new MySqlParameter("@phi", soTien),
                            new MySqlParameter("@tra", soTien),
                            new MySqlParameter("@nguon", "Máy Trạm")
                        };
                        db.Execute(sql, p);

                        MessageBox.Show($"Đã nạp {soTien:#,##0} VNĐ vào {mayDangChon}.\nTổng tiền trả trước hiện tại: {tramMay.TienTraTruoc:#,##0} VNĐ", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi lưu Database: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            string mayDangChon = cmbChonPC.Text;
            ucTramMay tramMay = flpViTriPC.Controls["uc" + mayDangChon.Replace(" ", "")] as ucTramMay;

            if (tramMay != null && tramMay.Tag.ToString() == "CoKhach")
            {
                DialogResult traloi = MessageBox.Show("Bạn có chắc chắn muốn TẮT " + mayDangChon + "? (Chưa thanh toán)", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    tramMay.Tag = "Trong";
                    tramMay.SetStatus(false);
                    CapNhatThongKe();
                }
            }
        }

        private void btnChuyenMay_Click(object sender, EventArgs e)
        {
            string mayCu = cmbChonPC.Text;
            ucTramMay tramMayCu = flpViTriPC.Controls["uc" + mayCu.Replace(" ", "")] as ucTramMay;

            if (tramMayCu != null && tramMayCu.Tag.ToString() == "CoKhach")
            {
                List<string> dsMayTrong = new List<string>();
                foreach (Control ctrl in flpViTriPC.Controls)
                {
                    if (ctrl is ucTramMay may && may.Tag.ToString() == "Trong") dsMayTrong.Add(may.TenMay);
                }

                if (dsMayTrong.Count == 0) return;

                string mayMoi = HienThiFormChuyenMay(dsMayTrong);
                if (!string.IsNullOrEmpty(mayMoi))
                {
                    ucTramMay tramMayMoi = flpViTriPC.Controls["uc" + mayMoi.Replace(" ", "")] as ucTramMay;
                    tramMayMoi.ThoiGianBatDau = tramMayCu.ThoiGianBatDau;
                    tramMayMoi.TienTraTruoc = tramMayCu.TienTraTruoc;
                    tramMayMoi.Tag = "CoKhach";

                    tramMayCu.Tag = "Trong";
                    tramMayCu.TienTraTruoc = 0;
                    tramMayCu.SetStatus(false);

                    cmbChonPC.Text = mayMoi;
                }
            }
        }

        private void MoFormDichVu()
        {
            string mayDangChon = cmbChonPC.Text;
            ucTramMay tramMay = flpViTriPC.Controls["uc" + mayDangChon.Replace(" ", "")] as ucTramMay;

            if (tramMay != null && tramMay.Tag != null && tramMay.Tag.ToString() == "CoKhach")
            {
                AnTatCaCacTrang();

                frmDichVu formDV = new frmDichVu(mayDangChon);
                formDV.TopLevel = false;
                formDV.Dock = DockStyle.Fill;

                guna2Panel1.Controls.Add(formDV);
                formDV.BringToFront();
                formDV.Show();
            }
            else
            {
                MessageBox.Show($"Máy {mayDangChon} chưa được mở!\nVui lòng nhấn 'Bắt Đầu' để mở máy trước khi gọi dịch vụ.",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDichVuMay_Click(object sender, EventArgs e) => MoFormDichVu();
        private void btnGoiMon_Click(object sender, EventArgs e) => MoFormDichVu();

        private string HienThiFormChuyenMay(List<string> danhSachMayTrong)
        {
            Form prompt = new Form() { Width = 300, Height = 180, FormBorderStyle = FormBorderStyle.FixedDialog, Text = "Chuyển Máy", StartPosition = FormStartPosition.CenterScreen, TopMost = true };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = "Chọn máy muốn chuyển ĐẾN:", AutoSize = true };
            ComboBox cmb = new ComboBox() { Left = 20, Top = 50, Width = 240, DropDownStyle = ComboBoxStyle.DropDownList };
            cmb.Items.AddRange(danhSachMayTrong.ToArray());
            if (cmb.Items.Count > 0) cmb.SelectedIndex = 0;
            Button confirmation = new Button() { Text = "Xác nhận", Left = 160, Width = 100, Top = 90, DialogResult = DialogResult.OK };
            prompt.Controls.Add(textLabel); prompt.Controls.Add(cmb); prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;
            return prompt.ShowDialog() == DialogResult.OK ? cmb.Text : "";
        }

        private string HienThiFormNhapTien(string tenMay)
        {
            Form prompt = new Form() { Width = 300, Height = 180, FormBorderStyle = FormBorderStyle.FixedDialog, Text = "Nạp Tiền", StartPosition = FormStartPosition.CenterScreen, TopMost = true };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = $"Nhập số tiền khách nạp cho {tenMay}:", AutoSize = true };
            TextBox txtTien = new TextBox() { Left = 20, Top = 50, Width = 240 };
            Button confirmation = new Button() { Text = "Nạp tiền", Left = 160, Width = 100, Top = 90, DialogResult = DialogResult.OK };
            prompt.Controls.Add(textLabel); prompt.Controls.Add(txtTien); prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;
            return prompt.ShowDialog() == DialogResult.OK ? txtTien.Text : "";
        }

        // ==============================================================
        // TUYỆT CHIÊU FIX LỖI "ĐÈ MÀN HÌNH"
        // ==============================================================
        private void AnTatCaCacTrang()
        {
            if (trangThongKe != null) trangThongKe.Visible = false;
            if (trangGD != null) trangGD.Visible = false;
            if (trangKhachHang != null) trangKhachHang.Visible = false;
            if (trangGiaoCa != null) trangGiaoCa.Visible = false;
            if (trangKho != null) trangKho.Visible = false;

            // Ẩn 2 panel hiển thị PC mặc định
            guna2Panel2.Visible = false;
            guna2Panel3.Visible = false;

            // Nếu ní vẽ Panel Kho hàng trên Form1 (ví dụ tên pnlKhoHang) thì nhét nó vào đây để giấu:
            // pnlKhoHang.Visible = false;
        }

        // ==========================================
        // CHUYỂN TRANG BẰNG DOCK FILL
        // ==========================================
        private void btnViTriPC_Click(object sender, EventArgs e)
        {
            AnTatCaCacTrang();

            for (int i = guna2Panel1.Controls.Count - 1; i >= 0; i--)
            {
                if (guna2Panel1.Controls[i] is frmDichVu)
                {
                    guna2Panel1.Controls[i].Dispose();
                }
            }

            guna2Panel2.Visible = true;
            guna2Panel3.Visible = true;
            flpViTriPC.BringToFront();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            AnTatCaCacTrang();

            if (trangThongKe == null)
            {
                trangThongKe = new ThongKe();
                trangThongKe.Dock = DockStyle.Fill;
                guna2Panel1.Controls.Add(trangThongKe);
            }

            trangThongKe.BringToFront();
            trangThongKe.Visible = true;
        }

        private void btnGiaoDich_Click(object sender, EventArgs e)
        {
            AnTatCaCacTrang();

            if (trangGD == null)
            {
                trangGD = new TrangGiaoDich();
                trangGD.Dock = DockStyle.Fill;
                guna2Panel1.Controls.Add(trangGD);
            }

            trangGD.LoadDuLieuGiaoDich();
            trangGD.BringToFront();
            trangGD.Visible = true;
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            AnTatCaCacTrang();

            if (trangKhachHang == null)
            {
                trangKhachHang = new ucKhachHang();
                trangKhachHang.Dock = DockStyle.Fill;
                guna2Panel1.Controls.Add(trangKhachHang);
            }

            trangKhachHang.BringToFront();
            trangKhachHang.Visible = true;
        }

        private void btnGiaoCa_Click(object sender, EventArgs e)
        {
            AnTatCaCacTrang();

            if (trangGiaoCa == null)
            {
                trangGiaoCa = new GiaoCa();
                trangGiaoCa.Dock = DockStyle.Fill;
                guna2Panel1.Controls.Add(trangGiaoCa);
            }

            trangGiaoCa.ThietLapThongTin(tenNhanVien, DateTime.Now.AddHours(-6));
            trangGiaoCa.BringToFront();
            trangGiaoCa.Visible = true;
        }

        // ==========================================
        // SỰ KIỆN NÚT KHO HÀNG (SỬA LẠI ĐỂ DÙNG PANEL TRỰC TIẾP TRÊN FORM)
        // ==========================================
        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            AnTatCaCacTrang();

            // Nếu trang Kho chưa được tạo thì tạo mới nó
            if (trangKho == null)
            {
                trangKho = new Kho(); // Triệu hồi cái UserControl tên Kho của ní
                trangKho.Dock = DockStyle.Fill; // Ép nó phình to lấp đầy màn hình
                guna2Panel1.Controls.Add(trangKho); // Nhét nó vào khung chính
            }

            trangKho.BringToFront(); // Lôi nó lên mặt tiền
            trangKho.Visible = true; // Mở đèn cho nó sáng
        }

        // ==========================================
        // ĐỒNG HỒ & ĐĂNG XUẤT
        // ==========================================
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Control ctrl in flpViTriPC.Controls)
            {
                if (ctrl is ucTramMay may && may.Tag != null && may.Tag.ToString() == "CoKhach")
                {
                    TimeSpan thoiGianDaChoi = DateTime.Now - may.ThoiGianBatDau;
                    string chuoiThoiGian = string.Format("{0:D2}:{1:D2}:{2:D2}",
                        (int)thoiGianDaChoi.TotalHours, thoiGianDaChoi.Minutes, thoiGianDaChoi.Seconds);
                    may.SetStatus(true, chuoiThoiGian);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                if (formDangNhap != null) formDangNhap.Show();
                this.Hide();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
        }

        private void flpViTriPC_Paint(object sender, PaintEventArgs e) { }

        // ==========================================
        // CÁC HÀM XỬ LÝ MYSQL CHO TRẠNG THÁI MÁY
        // ==========================================
        private void LoadCacMayDangHoatDongTuSQL()
        {
            try
            {
                DataTable dtMayBat = db.GetTable("SELECT * FROM TrangThaiMay WHERE TrangThai = 'CoKhach'");
                string mayDangBatDauTien = "";

                foreach (DataRow row in dtMayBat.Rows)
                {
                    string tenMay = row["TenMay"].ToString();
                    ucTramMay tramMay = flpViTriPC.Controls["uc" + tenMay.Replace(" ", "")] as ucTramMay;

                    if (tramMay != null)
                    {
                        tramMay.Tag = "CoKhach";
                        tramMay.ThoiGianBatDau = Convert.ToDateTime(row["ThoiGianBatDau"]);
                        tramMay.TienTraTruoc = Convert.ToDouble(row["TienTraTruoc"]);

                        int gioBatDau = tramMay.ThoiGianBatDau.Hour;
                        dataSoUser[gioBatDau]++;
                        CapNhatThongKe();

                        TimeSpan thoiGianDaChoi = DateTime.Now - tramMay.ThoiGianBatDau;
                        string chuoiThoiGian = string.Format("{0:D2}:{1:D2}:{2:D2}",
                            (int)thoiGianDaChoi.TotalHours, thoiGianDaChoi.Minutes, thoiGianDaChoi.Seconds);

                        tramMay.SetStatus(true, chuoiThoiGian);

                        if (mayDangBatDauTien == "") mayDangBatDauTien = tenMay;
                    }
                }

                if (mayDangBatDauTien != "") cmbChonPC.Text = mayDangBatDauTien;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải trạng thái máy từ MySQL: " + ex.Message);
            }
        }

        private void DongBoTrangThaiMay()
        {
            try
            {
                DataTable dtMayBat = db.GetTable("SELECT * FROM TrangThaiMay WHERE TrangThai = 'CoKhach'");
                List<string> dsMayBatTrongDB = new List<string>();

                foreach (DataRow row in dtMayBat.Rows)
                {
                    string tenMay = row["TenMay"].ToString();
                    dsMayBatTrongDB.Add(tenMay);

                    ucTramMay tramMay = flpViTriPC.Controls["uc" + tenMay.Replace(" ", "")] as ucTramMay;
                    if (tramMay != null)
                    {
                        if (tramMay.Tag == null || tramMay.Tag.ToString() == "Trong")
                        {
                            tramMay.Tag = "CoKhach";
                            tramMay.ThoiGianBatDau = Convert.ToDateTime(row["ThoiGianBatDau"]);
                            tramMay.TienTraTruoc = Convert.ToDouble(row["TienTraTruoc"]);

                            int gioBatDau = tramMay.ThoiGianBatDau.Hour;
                            dataSoUser[gioBatDau]++;
                            CapNhatThongKe();

                            TimeSpan thoiGianDaChoi = DateTime.Now - tramMay.ThoiGianBatDau;
                            string chuoiThoiGian = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                (int)thoiGianDaChoi.TotalHours, thoiGianDaChoi.Minutes, thoiGianDaChoi.Seconds);
                            tramMay.SetStatus(true, chuoiThoiGian);
                        }
                    }
                }

                foreach (Control ctrl in flpViTriPC.Controls)
                {
                    if (ctrl is ucTramMay may && may.Tag != null && may.Tag.ToString() == "CoKhach")
                    {
                        if (!dsMayBatTrongDB.Contains(may.TenMay))
                        {
                            may.Tag = "Trong";
                            may.TienTraTruoc = 0;
                            may.SetStatus(false);
                            CapNhatThongKe();
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {

        }
    }

    public class GiaoDichLog
    {
        public int ID { get; set; }
        public string ThoiGian { get; set; }
        public string MoTa { get; set; }
        public string ThanhVien { get; set; }
        public double CuocPhi { get; set; }
        public double ThanhToan { get; set; }
        public string Nguon { get; set; }
    }
}