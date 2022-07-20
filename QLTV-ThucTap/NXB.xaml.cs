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
    /// Interaction logic for NXB.xaml
    /// </summary>
    public partial class NXB : Window
    {
        private List<int> arrKeys = new List<int>();
        public NXB()
        {
            InitializeComponent();
            GetData();
        }
        DataClasses1DataContext context = new DataClasses1DataContext();
        private void btnthem_Click(object sender, RoutedEventArgs e)
        {

            Regex regex = new Regex("[^0-9]+");
            if (regex.IsMatch(txtMaNXB.Text.Trim()))
            {
                MessageBox.Show("Ma The lai la number");
                return;
            }
            if (arrKeys.Contains(int.Parse(txtMaNXB.Text.Trim())))
            {
                MessageBox.Show("Ma da ton tai!");
                return;
            }
            AddNewNXB();
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

                NHA_XUAT_BAN nxb = (NHA_XUAT_BAN)datagrid.SelectedItem;

                txtTenNXB.Text = nxb.tenNXB;
                txtMaNXB.Text = nxb.maNXB.ToString().Trim();
                txtDiaChi.Text = nxb.diachiNXB.ToString().Trim();
                txtSDT.Text = nxb.dienthoaiNXB.ToString().Trim();
                txtwebsite.Text = nxb.websiteNXB.ToString().Trim();
                txtGhiChu.Text = nxb.GhiChu.ToString().Trim();
                expNXB.IsExpanded = true;


            }
        }

        private void btnsua_Click(object sender, RoutedEventArgs e)
        {
            UpdateNXB();
            GetData();
        }

        private void btnxoa_Click(object sender, RoutedEventArgs e)
        {


            DeleteNXB();
            GetData();
        }

        private void GetData()
        {
            var NXBTable = from item in context.GetTable<NHA_XUAT_BAN>() select item;
            datagrid.ItemsSource = NXBTable;
            foreach (var ele in NXBTable.ToArray())
            {
                arrKeys.Add(ele.maNXB);
            }

        }
        private void AddNewNXB()
        {
            NHA_XUAT_BAN nxb = new NHA_XUAT_BAN();
            nxb.maNXB = int.Parse(txtMaNXB.Text);
            nxb.tenNXB = txtTenNXB.Text;
            nxb.diachiNXB = txtDiaChi.Text;
            nxb.dienthoaiNXB = txtSDT.Text;
            nxb.websiteNXB = txtwebsite.Text;
            nxb.GhiChu = txtGhiChu.Text;

            context.NHA_XUAT_BANs.InsertOnSubmit(nxb);
            context.SubmitChanges();
        }
        private void UpdateNXB()
        {
            NHA_XUAT_BAN nxb = context.NHA_XUAT_BANs.Single(item => item.maNXB == int.Parse(txtMaNXB.Text));
            nxb.maNXB = int.Parse(txtMaNXB.Text);
            nxb.tenNXB = txtTenNXB.Text;
            nxb.diachiNXB = txtDiaChi.Text;
            nxb.dienthoaiNXB = txtSDT.Text;
            nxb.websiteNXB = txtwebsite.Text;
            nxb.GhiChu = txtGhiChu.Text;
            context.SubmitChanges();
        }
        private void DeleteNXB()
        {
            NHA_XUAT_BAN nxb = context.NHA_XUAT_BANs.Single(item => item.maNXB == int.Parse(txtMaNXB.Text));
            context.NHA_XUAT_BANs.DeleteOnSubmit(nxb);
            context.SubmitChanges();
        }

        private void btntimkiem_Click_1(object sender, RoutedEventArgs e)
        {

            switch (txtTimKiemNXB.Text.Trim())
            {
                case "":
                    MessageBox.Show("Bạn hãy nhập mã thông tin tìm kiếm vào!", "Thông báo!");
                    break;
                case "*":
                    GetData();
                    break;
                default:
                    datagrid.ItemsSource = context.NHA_XUAT_BANs.Where(item =>
                        item.maNXB.ToString().Contains(txtTimKiemNXB.Text) ||
                        item.tenNXB.Contains(txtTimKiemNXB.Text)
                    ).ToList();
                    break;
            }
            }

        private void btnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            txtDiaChi.Text = "";
            txtGhiChu.Text = "";
            txtMaNXB.Text = "";
            txtSDT.Text = "";
            txtTenNXB.Text = "";
            txtwebsite.Text = "";
        }
    }

    }


