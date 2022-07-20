using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Data;
using System.Text.RegularExpressions;

namespace QLTV_ThucTap
{
    /// <summary>
    /// Interaction logic for SinhVien.xamlA
    /// </summary>

    
    public partial class SinhVien : Window
    {
        private string gender = "";
        DataClasses1DataContext context = new DataClasses1DataContext();
        private List<int> arrKeys = new List<int>();
        public SinhVien()
        {
            InitializeComponent();
            GetData();
        }

        private void btnthem_Click(object sender, RoutedEventArgs e)
        {

            Regex regex = new Regex("[^0-9]+");
            if (regex.IsMatch(txtmasinhvien.Text.Trim()))
            {
                MessageBox.Show("Mã sinh viên là số");
                return;
            }
            if (arrKeys.Contains(int.Parse(txtmasinhvien.Text.Trim())))
            {
                MessageBox.Show("Ma da ton tai!");
                return;
            }
            AddNewSinhVien();
            GetData();
            MessageBox.Show("Bạn đã thêm thành công!");
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int rowindex = datagrid.SelectedIndex;

            if (rowindex == -1)
            {
                return;
            }
            else
            {
                SINH_VIEN sv = (SINH_VIEN)datagrid.SelectedItem;

                txtHoTen.Text = sv.hotenSV;
                txtmasinhvien.Text = sv.maSV.ToString();
                txtlopSV.Text = sv.lopSV.ToString();
                txtNgaySinh.Text = sv.ngaysinhSV.ToString();
                txtngaylamthe.Text = sv.ngayLamThe.ToString();
                txtNgayHetHan.Text = sv.ngayHetHan.ToString();
                expSinhVien.IsExpanded = true;
                if (sv.gioiTinhSV.Trim() == "nam")
                {
                    nam.IsChecked = true;
                    nu.IsChecked = false;
                }
                else
                {
                    nam.IsChecked = false;
                    nu.IsChecked = true;
                }
             }
        }

        private void btnsua_Click(object sender, RoutedEventArgs e)
        {
            UpdateSinhVien();
            GetData();
            MessageBox.Show("Bạn đã sửa thành công!");
        }

        private void btnxoa_Click(object sender, RoutedEventArgs e)
        {
            DeleteSinhVien();
            GetData();
            MessageBox.Show("Bạn đã xóa thành công!");
        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            gender = button.Name;
        }


        private void GetData()
        {
            var SinhVienTable = from item in context.GetTable<SINH_VIEN>() select item;
            datagrid.ItemsSource = SinhVienTable;
            foreach (var ele in SinhVienTable.ToArray())
            {
                arrKeys.Add(ele.maSV);
            }
        }


        private void AddNewSinhVien()
        {
            SINH_VIEN sv = new SINH_VIEN();
            sv.maSV = int.Parse(txtmasinhvien.Text);
            sv.hotenSV = txtHoTen.Text;
            sv.lopSV = txtlopSV.Text;
            sv.ngaysinhSV = DateTime.Parse(txtNgaySinh.Text);
            sv.ngayLamThe = DateTime.Parse(txtngaylamthe.Text);
            sv.ngayHetHan = DateTime.Parse(txtNgayHetHan.Text);
            sv.gioiTinhSV = gender;
            context.SINH_VIENs.InsertOnSubmit(sv);
            context.SubmitChanges();
        }
        private void UpdateSinhVien()
        {
            SINH_VIEN sv = context.SINH_VIENs.Single(item => item.maSV == int.Parse(txtmasinhvien.Text));
            sv.lopSV = txtlopSV.Text;
            sv.hotenSV = txtHoTen.Text;
            sv.lopSV = txtlopSV.Text;
            sv.ngaysinhSV = DateTime.Parse(txtNgaySinh.Text);
            sv.ngayHetHan = DateTime.Parse(txtNgayHetHan.Text);
            sv.ngayLamThe = DateTime.Parse(txtngaylamthe.Text);
            sv.gioiTinhSV = gender;
            context.SubmitChanges();
        }
        private void DeleteSinhVien()
        {
            SINH_VIEN sv = context.SINH_VIENs.Single(item => item.maSV == int.Parse(txtmasinhvien.Text));
            context.SINH_VIENs.DeleteOnSubmit(sv);
            context.SubmitChanges();
        }
        private void btntimkiem_Click_1(object sender, RoutedEventArgs e)
        {
            switch(txtTimKiemSV.Text.Trim())
            {
                case "":
                    MessageBox.Show("Bạn hãy nhập mã thông tin tìm kiếm vào!", "Thông báo!");
                    break;
                case "*":
                    GetData();
                    break;
                default:
                    datagrid.ItemsSource = context.SINH_VIENs.Where(item =>
                        item.maSV.ToString().Contains(txtTimKiemSV.Text) ||
                        item.hotenSV.Contains(txtTimKiemSV.Text)
                    ).ToList();
                    break;
            }
        }

        private void btnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            txtmasinhvien.Text = "";
            txtHoTen.Text = "";
            txtlopSV.Text = "";
            txtNgayHetHan.Text = "";
            txtngaylamthe.Text = "";
            txtNgaySinh.Text = "";
        }
    }
}