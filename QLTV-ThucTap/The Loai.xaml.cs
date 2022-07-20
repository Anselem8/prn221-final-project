using System;
using System.Collections.Generic;
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
using System.Data.Linq;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace QLTV_ThucTap
{
    /// <summary>
    /// Interaction logic for The_Loai.xaml
    /// </summary>
    public partial class The_Loai : Window
    {
        private List<int> arrKeys = new List<int>();
        public The_Loai()
        {
            InitializeComponent();
            GetData();
        }
        DataClasses1DataContext context = new DataClasses1DataContext();
        private void btnthem_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            if (regex.IsMatch(txtMaTL.Text.Trim()))
            {
                MessageBox.Show("Mã Thể loại là số");
                return;
            }

            if (arrKeys.Contains(int.Parse(txtMaTL.Text.Trim())))
            {
                MessageBox.Show("Ma da ton tai!");
                return;
            }
            AddNewTheLoai();
            GetData();
            MessageBox.Show("bạn đã thêm thành công!");
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
                THE_LOAI tl = (THE_LOAI)datagrid.SelectedItem;
                txTTenTL.Text = tl.tenTL;
                txtMaTL.Text = tl.maTL.ToString();
                txtGhiChu.Text = tl.GhiChu;
                expTheLoai.IsExpanded = true;
            }
        }
        private void btnsua_Click(object sender, RoutedEventArgs e)
        {
            UpdateTheLoai();
            GetData();
            MessageBox.Show("Bạn đã sữa thành công!");
        }
        private void btnxoa_Click(object sender, RoutedEventArgs e)
        {

            DeleteTheLoai();
            GetData();
            MessageBox.Show("Bạn đx xóa thành công!");
        }
        private void GetData()
        {
            var TheLoaiTable = from item in context.GetTable<THE_LOAI>() select item;
            datagrid.ItemsSource = TheLoaiTable;

            foreach(var ele in TheLoaiTable.ToArray())
            {
                arrKeys.Add(ele.maTL);
            }
        }
        private void AddNewTheLoai()
        {
            THE_LOAI tl = new THE_LOAI();

            tl.maTL = int.Parse(txtMaTL.Text.Trim());
            tl.tenTL = txTTenTL.Text;
            tl.GhiChu = txtGhiChu.Text;

            context.THE_LOAIs.InsertOnSubmit(tl);
            context.SubmitChanges();
        }
        private void UpdateTheLoai()
        {
            THE_LOAI tl = context.THE_LOAIs.Single(item => item.maTL == int.Parse(txtMaTL.Text));

            tl.tenTL = txTTenTL.Text;
            tl.GhiChu = txtGhiChu.Text;

            context.SubmitChanges();
        }
        private void DeleteTheLoai()
        {
            THE_LOAI tl = context.THE_LOAIs.Single(item => item.maTL == int.Parse(txtMaTL.Text));
            context.THE_LOAIs.DeleteOnSubmit(tl);
            context.SubmitChanges();
        }
        private void btntimkiem_Click_1(object sender, RoutedEventArgs e)
        {
            switch (txtTimTheoTl.Text.Trim())
            {
                case "":
                    MessageBox.Show("Bạn hãy nhập mã thông tin tìm kiếm vào!", "Thông báo!");
                    break;
                case "*":
                    GetData();
                    break;
                default:
                    datagrid.ItemsSource = context.THE_LOAIs.Where(item =>
                        item.maTL.ToString().Contains(txtTimTheoTl.Text) ||
                        item.tenTL.Contains(txtTimTheoTl.Text)
                    ).ToList();
                    break;
            }
            }

        private void btnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            txtMaTL.Text = "";
            txTTenTL.Text = "";
            txtGhiChu.Text = "";
            
        }
    }
    }
    

