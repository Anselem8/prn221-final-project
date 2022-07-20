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
    /// Interaction logic for Sach.xaml
    /// </summary>
    public partial class Sach : Window
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        private List<int> arrKeys = new List<int>();
        public Sach()
        {
            InitializeComponent();
            GetData();
            loadMaTL();
            loadTG();
            loadNXB();
        }
        public void loadMaTL()
        {
            cbMaTL.ItemsSource = db.THE_LOAIs;
            cbMaTL.DisplayMemberPath = "maTL";
            cbMaTL.SelectedValuePath = "maTL";
            cbMaTL.SelectedIndex = 0;
        }
        public void loadTG()
        {
            cbMaTG.ItemsSource = db.TAC_GIA1s;
            cbMaTG.DisplayMemberPath = "maTG";
            cbMaTG.SelectedValuePath = "maTG";
            cbMaTG.SelectedIndex = 0;
        }
        public void loadNXB()
        {
            cbMaNXB.ItemsSource = db.NHA_XUAT_BANs;
            cbMaNXB.DisplayMemberPath = "maNXB";
            cbMaNXB.SelectedValuePath = "maNXB";
            cbMaNXB.SelectedIndex = 0;
        }
        DataClasses1DataContext context = new DataClasses1DataContext();
        private void btnthem_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            if (regex.IsMatch(txtMaSach.Text.Trim()))
            {
                MessageBox.Show("Mã Thể Loại Là Số");
                return;
            }
            if (arrKeys.Contains(int.Parse(txtMaSach.Text.Trim())))
            {
                MessageBox.Show("Mã đã tồn tại !");
                return;
            }
            AddNewSach();
            GetData();
           
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

                SACH sach = (SACH)datagrid.SelectedItem;
                txtMaSach.Text = sach.maSach.ToString();
                txtTenSach.Text = sach.tenSach;
                txtGia.Text = sach.gia.ToString();
                txtSoLuong.Text = sach.soLuong.ToString();
                txtTinhTrang.Text = sach.soLuongTon.ToString();
                cbMaNXB.SelectedValue = sach.maNXB;
                cbMaTG.SelectedValue = sach.maTG;
                cbMaTL.SelectedValue = sach.maTL;

                expSach.IsExpanded = true;


            }
        }

        private void btnsua_Click(object sender, RoutedEventArgs e)
        {
            UpdateSach();
            GetData();
        }

        private void btnxoa_Click(object sender, RoutedEventArgs e)
        {

            DeleteSach();
            GetData();
        }

        private void GetData()
        {
            var SinhVienTable = from item in context.GetTable<SACH>() select item;
            datagrid.ItemsSource = SinhVienTable;
            foreach (var ele in SinhVienTable.ToArray())
            {
                arrKeys.Add(ele.maSach);
            }
        }
        private void AddNewSach()
        {
            int soluong = int.Parse(txtSoLuong.Text);

            SACH sach = new SACH();
            sach.maSach = int.Parse(txtMaSach.Text.Trim());
            sach.tenSach = txtTenSach.Text;
            sach.maNXB =int.Parse( cbMaNXB.SelectedValue.ToString());
            sach.maTG = int.Parse(cbMaTG.SelectedValue.ToString());
            sach.maTL = int.Parse(cbMaTL.SelectedValue.ToString());
            sach.gia = int.Parse(txtGia.Text);
            sach.soLuong = soluong;
            sach.soLuongTon = soluong;
            context.SACHes.InsertOnSubmit(sach);
            context.SubmitChanges();
        }


        private void UpdateSach()
        {
            int soluong = int.Parse(txtSoLuong.Text);

            SACH sach = context.SACHes.Single(item => item.maSach == int.Parse(txtMaSach.Text));
            sach.tenSach = txtTenSach.Text;
            sach.maNXB = int.Parse(cbMaNXB.SelectedValue.ToString());
            sach.maTG = int.Parse(cbMaTG.SelectedValue.ToString());
            sach.maTL = int.Parse(cbMaTL.SelectedValue.ToString());
            sach.gia = int.Parse(txtGia.Text);
            sach.soLuongTon = soluong;
            sach.soLuong = soluong;
            context.SubmitChanges();
        }

        private void DeleteSach()
        {


            SACH sach = context.SACHes.Single(item => item.maSach == int.Parse(txtMaSach.Text));

            context.SACHes.DeleteOnSubmit(sach);

            context.SubmitChanges();
        }

        private void btntimkiem_Click_1(object sender, RoutedEventArgs e)
        {

            switch (txtTimSach.Text.Trim())
            {
                case "":
                    MessageBox.Show("Bạn hãy nhập mã thông tin tìm kiếm vào!", "Thông báo!");
                    break;
                case "*":
                    GetData();
                    break;
                default:
                    datagrid.ItemsSource = context.SACHes.Where(item =>
                        item.maSach.ToString().Contains(txtTimSach.Text) ||
                        item.tenSach.Contains(txtTimSach.Text)
                    ).ToList();
                    break;
            }
            }

        private void btnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            txtMaSach.Text = "";
            txtTenSach.Text = "";
            txtSoLuong.Text = "";
            txtGia.Text = "";
            txtTinhTrang.Text = "";
            cbMaNXB.Text = "";
            cbMaTG.Text = "";
            cbMaTL.Text = "";
        }
    }
    }
    

