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
    /// Interaction logic for TestMuon.xaml
    /// </summary>
    public partial class TestMuon : Window
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public TestMuon()
        {
            InitializeComponent();
            loadGridSource();
        }

        private void loadGridSource()
        {
            var query = from pm in db.PHIEU_MUONs
                        join cpm in db.CT_PHIEUMUONs on pm.maPhieu equals cpm.maPhieu
                        select new { pm.maPhieu, pm.maNV, pm.maSV, cpm.maSach, cpm.ngayTra, cpm.ngayMuon, cpm.tinhTrang, cpm.soLuong };

            datagrid.ItemsSource = query.ToList();
        }
    }
}
