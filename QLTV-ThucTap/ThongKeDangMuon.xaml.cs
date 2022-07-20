using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace QLTV_ThucTap
{
    /// <summary>
    /// Interaction logic for ThongKe.xaml
    /// </summary>
    public partial class ThongKe : Window
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public ThongKe()
        {
            InitializeComponent();
        }

        public IEnumerable<CT_PHIEUMUON>DanhSachDangMuonSach()
        {
            var result = db.CT_PHIEUMUONs.
                Where(x => x.tinhTrang == "dang muon").
                OrderBy(y => y.id);
            return result;
        }
        private void btnSachMuon_Click(object sender, RoutedEventArgs e)
        {
            datagrid.ItemsSource = DanhSachDangMuonSach();
        }
        public void WritetoExcelCol()
        {
            IEnumerable<CT_PHIEUMUON> arr = DanhSachDangMuonSach();
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            //Ghi Tieu đề
            xlWorkSheet.Cells[1, 1] = "Mã Sinh Viên";
            xlWorkSheet.Cells[1, 2] = "Mã Sách";
            xlWorkSheet.Cells[1, 3] = "Ngày Mượn";
            xlWorkSheet.Cells[1, 4] = "Ngày trả";
            xlWorkSheet.Cells[1, 5] = "Số Lượng";
            xlWorkSheet.Cells[1, 6] = "Tình trạng";
            // Ghi Data 
            int idx = 2;
            foreach (var row in arr)
            {
                xlWorkSheet.Cells[idx, 1] = row.maSV.ToString();
                xlWorkSheet.Cells[idx, 2] = row.maSach.ToString();
                xlWorkSheet.Cells[idx, 3] = row.ngayMuon.ToString();
                xlWorkSheet.Cells[idx, 4] = row.ngayTra.ToString();
                xlWorkSheet.Cells[idx, 5] = row.soLuong.ToString();
                xlWorkSheet.Cells[idx, 6] = row.tinhTrang.ToString();
                idx++;
            }
            string fileName = AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.Ticks + ".xls";
            xlWorkBook.SaveAs(fileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
            MessageBox.Show("File excel đã tạo , bạn có thể tìm  kiếm trong " + fileName);
            FileInfo fi = new FileInfo(fileName);
            if (fi.Exists)
            {
                System.Diagnostics.Process.Start(fileName);
            }
            else
            {
                //file doesn't exist
            }
        }
        private void btnXuatexcel(object sender, RoutedEventArgs e)
        {
            WritetoExcelCol();
        }
    }
}
