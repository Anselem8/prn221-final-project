using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace QLTV_ThucTap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string text;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(string text)
        {
            this.text = text;
        }

        private void btnlogout_Click(object sender, RoutedEventArgs e)
        {
            
            Application.Current.Shutdown();
        }

        private void btnopenmenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Collapsed;
            btnCloseMenu.Visibility = Visibility.Visible;
        }

        private void btnclosemenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Visible;
            btnCloseMenu.Visibility = Visibility.Collapsed;
         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frmdangnhap dangnhap = new frmdangnhap();
            dangnhap.ShowDialog();
            //btnclosemenu_Click(sender, e);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            btnCloseMenu.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            SinhVien sv = new SinhVien();
            sv.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            btnCloseMenu.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            Employee nhanvien = new Employee();
            nhanvien.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            btnCloseMenu.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            The_Loai theloai = new The_Loai();
            theloai.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            btnCloseMenu.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            TacGia tacgia = new TacGia();
            tacgia.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            btnCloseMenu.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            NXB nhaxuatban = new NXB();
            nhaxuatban.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            btnCloseMenu.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            Sach sach = new Sach();
            sach.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            btnCloseMenu.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            MuonSach muon = new MuonSach();
            muon.ShowDialog();

        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            btnCloseMenu.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            TestMuon tra = new TestMuon();
            tra.ShowDialog();

        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            btnCloseMenu.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            ThongKe dangmuon = new ThongKe();
            dangmuon.ShowDialog();
        }
        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            btnCloseMenu.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            ThongKeTra tra = new ThongKeTra();
            tra.ShowDialog();
        }

        public void WritetoExcelCol(DataTable dt)
        {

            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = null;
            Excel.Workbooks workbooks = null;
            Excel._Worksheet worksheet = null;
            workbooks = excelApp.Workbooks;
            workbook = workbooks.Add(1);
            worksheet = (Excel.Worksheet)workbook.Sheets[1];
            excelApp.Visible = true;
          
            // đọc dòng tiêu đề để tạo ra cột trong datagrid
            for (int i = 1; i <= dt.Columns.Count; i++)
            {
                worksheet = excelApp.ActiveSheet;
                worksheet.Name = "dữ liệu xuất ra";
                worksheet.Cells[1, i] = dt.Columns[0].ColumnName.ToString();

            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dt.Rows[i][j].ToString();
                }
            }

            excelApp.Quit();
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
