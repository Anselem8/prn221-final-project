using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : Window
    {
        private List<int> arrKeys = new List<int>();
        public Employee()
        {
            InitializeComponent();
            GetData();
        }
        DataClasses1DataContext context = new DataClasses1DataContext();
        private void btnthem_Click(object sender, RoutedEventArgs e)
        {

            Regex regex = new Regex("[^0-9]+");
            if (regex.IsMatch(txtMaNV.Text.Trim()))
            {
                MessageBox.Show("Mã nhân viên là số");
                return;
            }
            if (arrKeys.Contains(int.Parse(txtMaNV.Text.Trim())))
            {
                MessageBox.Show("Ma da ton tai!");
                return;
            }
            AddNewNhanVien();
            GetData();
            MessageBox.Show("Bạn đã thêm thành công");

        }
        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string query = "INSERT INTO NHAN_VIEN(tenNV) VALUES (N'tenNV') ";
            int rowindex = datagrid.SelectedIndex;
            if (rowindex == 1)
            {
                return;
            }
            else
            {
                NHAN_VIEN nv = (NHAN_VIEN)datagrid.SelectedItem;
                txtMaNV.Text = nv.maNV.ToString();
                txtHoTenNV.Text = nv.tenNV;
                txtGioiTinhNV.Text = nv.gioiTinhNV.ToString();
                txtNgaySinhNV.Text = nv.ngaySinhNV.ToString();
                txtSDT.Text = nv.dienThoaiNV;
                txtDiaChi.Text = nv.diaChiNV;
                txtNgayVaoLam.Text = nv.ngayVaoLam.ToString();
                txtMatKhau.Text = nv.matKhau.ToString(); 
                expnhanvien.IsExpanded = true;
            }
        }

        private void btnsua_Click(object sender, RoutedEventArgs e)
        {
            UpdateNhanVien();
            GetData();
            MessageBox.Show("Bạn đã sửa thành công");
        }

        private void btnxoa_Click(object sender, RoutedEventArgs e)
        {

            DeleteSinhVien();
            GetData();
            MessageBox.Show("Bạn đã xóa thành công!");
        }

        private void GetData()
        {
            var SinhVienTable = from item in context.GetTable<NHAN_VIEN>() select item;
            this.datagrid.ItemsSource = SinhVienTable;
            foreach (var ele in SinhVienTable.ToArray())
            {
                arrKeys.Add(ele.maNV);
            }
        }

        private void AddNewNhanVien()
        {
            NHAN_VIEN nv = new NHAN_VIEN();

            nv.maNV = int.Parse(txtMaNV.Text.Trim());
            nv.tenNV = txtHoTenNV.Text.Trim();
            nv.gioiTinhNV = txtGioiTinhNV.Text.Trim();
            nv.ngaySinhNV = DateTime.Parse(txtNgaySinhNV.Text.Trim());
            nv.ngayVaoLam = DateTime.Parse(txtNgayVaoLam.Text.Trim());
            nv.diaChiNV = txtDiaChi.Text.Trim();
            nv.dienThoaiNV = txtSDT.Text.Trim();
            nv.matKhau = txtMatKhau.Text.Trim();
            context.NHAN_VIENs.InsertOnSubmit(nv);
            context.SubmitChanges();
        }
        private void UpdateNhanVien()
        {
            NHAN_VIEN nv = context.NHAN_VIENs.Single(item => item.maNV == int.Parse(txtMaNV.Text));
            nv.tenNV = txtHoTenNV.Text.Trim();
            nv.gioiTinhNV = txtGioiTinhNV.Text.Trim();
            nv.ngaySinhNV = DateTime.Parse(txtNgaySinhNV.Text.Trim());
            nv.ngayVaoLam = DateTime.Parse(txtNgayVaoLam.Text.Trim());
            nv.diaChiNV = txtDiaChi.Text.Trim();
            nv.dienThoaiNV = txtSDT.Text.Trim();
            nv.matKhau = txtMatKhau.Text.Trim();
            context.SubmitChanges();
        }

        private void DeleteSinhVien()
        {
            NHAN_VIEN nv = context.NHAN_VIENs.Single(item => item.maNV == int.Parse(txtMaNV.Text));
            context.NHAN_VIENs.DeleteOnSubmit(nv);
            context.SubmitChanges();
        }

        private void btntimkiem_Click_1(object sender, RoutedEventArgs e)
        {
            switch (txtTimKiemNV.Text.Trim())
            {
                case "":
                    MessageBox.Show("Bạn hãy nhập mã thông tin tìm kiếm vào!", "Thông báo!");
                    break;
                case "*":
                    GetData();
                    break;
                default:
                    datagrid.ItemsSource = context.NHAN_VIENs.Where(item =>
                        item.maNV.ToString().Contains(txtTimKiemNV.Text) ||
                        item.tenNV.Contains(txtTimKiemNV.Text)
                    ).ToList();
                    break;
            }
        }
        private void btnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            txtDiaChi.Text = "";
            txtGioiTinhNV.Text = "";
            txtHoTenNV.Text = "";
            txtMaNV.Text = "";
            txtNgayVaoLam.Text = "";
            txtNgaySinhNV.Text = "";
            txtSDT.Text = "";
            txtMatKhau.Text = "";
        }
    }
    }

