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

namespace QLTV_ThucTap
{
    /// <summary>
    /// Interaction logic for frmdangnhap.xaml
    /// </summary>
    public partial class frmdangnhap : Window
    {
       

        public frmdangnhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có muốn hủy bỏ ?", "xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow frmMain = new MainWindow();
            frmMain.ShowDialog();
            //frmMain.
            // DataClasses1DataContext db = new DataClasses1DataContext();
            // List<NHAN_VIEN> data = db.NHAN_VIENs.Where(t => t.tenNV == txtDangNhap.Text && t.matKhau == txtMatkhau.Password).ToList();
            /* {
                if(txtDangNhap.Text =="" || txtMatkhau.Password=="")
                {
                    MessageBox.Show("You are enter the full information from database to!", "Thông Báo");
                }
                else
                {
                    if(data.Count>0)
                    {
                       
                        //MessageBox.Show("Ban da dang nhap thanh cong !");
                        this.Hide();
                        MainWindow frmMain = new MainWindow();
                        frmMain.ShowDialog();
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show("Ten or a few times when you're not allowed to log in !", "Thong Bao");
                        txtDangNhap.Focus();
                        txtMatkhau.Focus();
                        return;
                    }
                }
            }
            */

        }


    }
}
