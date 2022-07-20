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
    /// Interaction logic for TacGia.xaml
    /// </summary>
    public partial class TacGia : Window
    {
        private List<int> arrKeys = new List<int>();
        public TacGia()
        {
            InitializeComponent();
            GetData();
        }
        DataClasses1DataContext context = new DataClasses1DataContext();
        private void btnthem_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            if (regex.IsMatch(txtMaTG.Text.Trim()))
            {
                MessageBox.Show("Mã Tác giả là số");
                return;
            }
            if (arrKeys.Contains(int.Parse(txtMaTG.Text.Trim())))
            {
                MessageBox.Show("Ma da ton tai!");
                return;
            }

            AddNewTacGia();
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
                TAC_GIA1 tg = (TAC_GIA1)datagrid.SelectedItem;
                txtMaTG.Text = tg.maTG.ToString();
                txtTenTG.Text = tg.tenTG.ToString();
                txtGhiChu.Text = tg.GhiChu;
                expTacGia.IsExpanded = true;
            }
        }
        private void btnsua_Click(object sender, RoutedEventArgs e)
        {
            UpdateTacGia();
            GetData();
        }
        private void btnxoa_Click(object sender, RoutedEventArgs e)
        {

            DeleteTacGia();
            GetData();
        }
        private void GetData()
        {
            var TacGiaTable = from item in context.GetTable<TAC_GIA1>() select item;
            datagrid.ItemsSource = TacGiaTable;
            foreach (var ele in TacGiaTable.ToArray())
            {
                arrKeys.Add(ele.maTG);
            }
        }
        private void AddNewTacGia()
        {
            TAC_GIA1 tg = new TAC_GIA1();

            tg.maTG = int.Parse(txtMaTG.Text.Trim());
            tg.tenTG = txtTenTG.Text;
            tg.GhiChu = txtGhiChu.Text;

            context.TAC_GIA1s.InsertOnSubmit(tg);
            context.SubmitChanges();
        }
        private void UpdateTacGia()
        {
            TAC_GIA1 tg = context.TAC_GIA1s.Single(item => item.maTG == int.Parse(txtMaTG.Text));

            tg.tenTG = txtTenTG.Text;
            tg.GhiChu = txtGhiChu.Text;

            context.SubmitChanges();
        }
        private void DeleteTacGia()
        {
            TAC_GIA1 tg = context.TAC_GIA1s.Single(item => item.maTG == int.Parse(txtMaTG.Text));
            context.TAC_GIA1s.DeleteOnSubmit(tg);
            context.SubmitChanges();
        }
        private void btntimkiem_Click_1(object sender, RoutedEventArgs e)
        {
            switch (txtTimKiemTacGia.Text.Trim())
            {
                case "":
                    MessageBox.Show("Bạn hãy nhập mã thông tin tìm kiếm vào!", "Thông báo!");
                    break;
                case "*":
                    GetData();
                    break;
                default:
                    datagrid.ItemsSource = context.TAC_GIA1s.Where(item =>
                        item.maTG.ToString().Contains(txtTimKiemTacGia.Text) ||
                        item.tenTG.Contains(txtTimKiemTacGia.Text)
                    ).ToList();
                    break;
            }
            }

        private void btnLmaMoi_Click(object sender, RoutedEventArgs e)
        {
            txtMaTG.Text = "";
            txtGhiChu.Text = "";
            txtTenTG.Text = "";

        }
    }
    }

