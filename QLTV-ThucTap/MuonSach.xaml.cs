using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QLTV_ThucTap
{
    //tạo ra 1 class đối tượng là GridInfo
    public class GridInfo: INotifyPropertyChanged
    {
        // đây là sự kiện giúp phát sinh ra thông điệp thay đổi giá trị của thuộc tính dựa trêm đối số là tên của thuộc tính truền vào
        public event PropertyChangedEventHandler PropertyChanged;
       // phương thức phát sinh thông điệp
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        // khai báo thuộc tính , biến
        private int _maPhieu;
        private int _maSV;
        private int _maNV;
        private int _maSach;
        private DateTime _ngayMuon;
        private DateTime _ngayTra;
        private int _soLuong;
        private string _tinhTrang;
        //  phát sinh thông điệp thay đổi dữ liệu trên thuộc tính MaPhieu
        public int maPhieu
        {
            get { return _maPhieu; }
            set
            {
                _maPhieu = value;
                OnPropertyChanged("maPhieu");
            }
        }
        public int maSV
        {
            get { return _maSV; }
            set
            {
                _maSV = value;
                OnPropertyChanged("maSV");
            }
        }
        public int maNV
        {
            get { return _maNV; }
            set
            {
                _maNV = value;
                OnPropertyChanged("maNV");
            }
        }

        public int maSach
        {
            get
            {
                return _maSach;
            }

            set
            {
                _maSach = value;
                OnPropertyChanged("maSach");
            }
        }

        public DateTime ngayMuon
        {
            get
            {
                return _ngayMuon;
            }

            set
            {
                _ngayMuon = value;
                OnPropertyChanged("ngayMuon");
            }
        }

        public DateTime ngayTra
        {
            get
            {
                return _ngayTra;
            }

            set
            {
                _ngayTra = value;
                OnPropertyChanged("ngayTra");
            }
        }

        public int soLuong
        {
            get
            {
                return _soLuong;
            }

            set
            {
                _soLuong = value;
                OnPropertyChanged("soLuong");
            }
        }

        public string tinhTrang
        {
            get
            {
                return _tinhTrang;
            }

            set
            {
                _tinhTrang = value;
                OnPropertyChanged("tinhTrang");
            }
        }
    }

    public partial class MuonSach : Window
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        ArrayList gridInfos = new ArrayList();
        int selected = -1;
        private List<int> arrKeys = new List<int>();
        public MuonSach()
        {
            InitializeComponent();
            loadMaSV();
            loadMaSach();
            loadMaNV();
            foreach (var ele in db.PHIEU_MUONs.ToArray())
            {
                arrKeys.Add(ele.maPhieu);
            }
        }
        public void loadMaSV()
        {
            cbSinhVien.ItemsSource = db.SINH_VIENs;
            cbSinhVien.DisplayMemberPath = "maSV";
            cbSinhVien.SelectedValuePath = "maSV";
            cbSinhVien.SelectedIndex = 1;
        }
        public void loadMaSach()
        {
            cbMaSach.ItemsSource = db.SACHes;
            cbMaSach.DisplayMemberPath = "maSach";
            cbMaSach.SelectedValuePath = "maSach";
            cbMaSach.SelectedIndex = 0;
        }
        public void loadMaNV()
        {
            cbNhanVien.ItemsSource = db.NHAN_VIENs;
            cbNhanVien.DisplayMemberPath = "maNV";
            cbNhanVien.SelectedValuePath = "maNV";
            cbNhanVien.SelectedIndex = 0;
        }
  
        DataClasses1DataContext context = new DataClasses1DataContext();
        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int rowindex = datagrid.SelectedIndex;
            if (rowindex == -1)
            {
                return;
            }

            //selected = rowindex;
            GridInfo info = gridInfos[rowindex] as GridInfo;

            txtMaPhieu.Text = info.maPhieu.ToString();
            cbSinhVien.SelectedValue = info.maSV.ToString();
            cbNhanVien.SelectedValue = info.maNV.ToString();
            cbMaSach.SelectedValue = info.maSV.ToString();
            txtNgayTra.Text = info.ngayTra.ToString();
            txtSoLuong.Text = info.soLuong.ToString();
            expMuonSach.IsExpanded = false;
        }
        private void GetData()
        {
            datagrid.ItemsSource = null;
            datagrid.ItemsSource = gridInfos;
        }
        private void addnewMuon()
        {
            PHIEU_MUON muon = new PHIEU_MUON();
            muon.maPhieu = int.Parse(txtMaPhieu.Text.Trim());
            muon.maNV = int.Parse(cbNhanVien.Text.Trim());
            muon.maSV = int.Parse(cbSinhVien.Text.Trim());
            context.PHIEU_MUONs.InsertOnSubmit(muon);
            context.SubmitChanges();
        }
        private void addNewCTMuon(GridInfo info)
        {
            CT_PHIEUMUON ct = new CT_PHIEUMUON();
            ct.tinhTrang = info.tinhTrang;
            ct.maPhieu = info.maPhieu;
            ct.maSach = info.maSach;
            ct.ngayMuon = info.ngayMuon;
            ct.ngayTra = info.ngayTra;
            ct.soLuong = info.soLuong;
            ct.maSV = info.maSV;

            context.CT_PHIEUMUONs.InsertOnSubmit(ct);
            context.SubmitChanges();
            UpdateSoLuongTonSach(info.maSach, -info.soLuong);
        }

        private void UpdateSoLuongTonSach(int maSach, int soLuong)
        {
            SACH sach = context.SACHes.Single(item => item.maSach == maSach);
            sach.soLuongTon = sach.soLuongTon + soLuong;
            context.SubmitChanges();
        }
        private bool kiemTraSoLuongMuon(int maSach, int soLuong)
        {
            SACH sach = context.SACHes.Single(item => item.maSach == maSach);
            if (soLuong > sach.soLuongTon)
            {
                MessageBox.Show("Xin lỗi ! Tạm thời sách đã hết trong thư viện ");
                return false;
            }
            return true;
        }
        private void btnMuon_Click(object sender, RoutedEventArgs e)
        {
            addnewMuon();
            
            foreach (var info in gridInfos)
            {
                addNewCTMuon(info as GridInfo);
                MessageBox.Show("Ban da muon thanh cong !");
            }
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            int maPhieu = int.Parse(txtMaPhieu.Text.Trim());
            int maNV = int.Parse(cbNhanVien.SelectedValue.ToString().Trim());
            int maSV = int.Parse(cbSinhVien.SelectedValue.ToString().Trim());
            if (arrKeys.Contains(maPhieu))
            {
                MessageBox.Show("Ma da ton tai!");
                return;
            }
            if (gridInfos.Count <= 0)
            {
                addInfo();
                return;
            }

            GridInfo info = gridInfos[0] as GridInfo;


            if (maPhieu != info.maPhieu || maNV != info.maNV || maSV != info.maSV)
            {
                MessageBox.Show("Moi Phieu Muon chi co 1 Ma Phieu, 1 Nhan vienn va 1 sinh vien");
                return;
            }
            addInfo();
        }
        private void addInfo()
        {
            int maSach = int.Parse(cbMaSach.SelectedValue.ToString().Trim());
            int soLuong = int.Parse(txtSoLuong.Text.Trim());

            if (kiemTraSoLuongMuon(maSach, soLuong) == false) {
                return;
            }

            GridInfo info = new GridInfo();
            info.maPhieu = int.Parse(txtMaPhieu.Text.Trim());
            info.maNV = int.Parse(cbNhanVien.SelectedValue.ToString().Trim());
            info.maSV = int.Parse(cbSinhVien.SelectedValue.ToString().Trim());
            info.maSach = maSach;
            info.ngayMuon = DateTime.UtcNow.Date;
            info.ngayTra = DateTime.Parse(txtNgayTra.Text.Trim());
            info.soLuong = soLuong;
            info.tinhTrang = "dang muon";
            gridInfos.Add(info);

            GetData();
        }
        private void btnTra_Click(object sender, RoutedEventArgs e)
        {
            int maPhieu = int.Parse(txtMaPhieu.Text.Trim());
            int maSach = int.Parse(cbMaSach.SelectedValue.ToString());
            if (maSach < 0 && maPhieu < 0)
            {
                MessageBox.Show("ban can nhap thong tin MaSach, MaPhieuMuon can tra");
                return;
            }
            CT_PHIEUMUON ct = context.CT_PHIEUMUONs.Single(item => item.maPhieu == maPhieu && item.maSach == maSach);
            if (ct.GetType() != typeof(CT_PHIEUMUON))
            {
                MessageBox.Show("Khong tim thay phieu muon co Thong Tin da tim");
                return;
            }

            if (ct.tinhTrang.Trim().ToLower() == "da tra")
            {
                MessageBox.Show("Sach Da duoc tra. Vui Long vao DS Phieu Muon xem lai");
                return;
            }

            ct.tinhTrang = "da tra";

            int soLuong = (int)ct.soLuong;

            UpdateSoLuongTonSach(maSach, soLuong);
            context.SubmitChanges();

            MessageBox.Show("Sach Da tra Thanh Cong, Vui long vao form Danh Sach Muon va Sach de kiem Tra");
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (selected != -1)
            {
                gridInfos.RemoveAt(selected);
                GetData();
            }
        }

        private void btnTKsachMuon_Click(object sender, RoutedEventArgs e)
        {
            switch (txtTimKiemsachmuon.Text.Trim())
            {
                case "":
                    MessageBox.Show("Bạn hãy nhập mã thông tin tìm kiếm vào!", "Thông báo!");
                    break;
                case "*":
                    GetData();
                    break;
                default:
                    datagrid.ItemsSource = context.CT_PHIEUMUONs.Where(item =>
                        item.maPhieu.ToString().Contains(txtTimKiemsachmuon.Text) 
                    ).ToList();
                    break;
            }
        }
    }
}


