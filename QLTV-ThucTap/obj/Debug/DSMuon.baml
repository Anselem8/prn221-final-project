   M S B A M L   `   `   `  ����G  CQLTV-ThucTap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QLTV_ThucTapQLTV_ThucTap  5   	       QLTV_ThucTap.TestMuon   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:QLTV_ThucTap     5   	     � Title$  Danh Sách Mượn��5   
    � Icon$9 3D:\NGAN\ThucTap\Final\QLTV\QLTV\hinhanh\account.png��6!   
����� �$��Center=�6x   $	��500��6�   $
��1000��6�   $��0,0,0,7q�6�    � WindowStartupLocation$ CenterScreen=�6�    � 
ResizeMode$ NoResize=�6�   .��5	      � $��0,0,6,0q�6    � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $
��Auto=�6   $
��Auto=�5      $��	0,5,58,15q�6<   $��3��6O   .��5      &   System.Windows.Controls.DataGrid  -   5        $��datagrid��5      
����� �   CanUserAddRows .     CanUserReorderColumns .     CanUserResizeRows .     
IsReadOnly . 	   CanUserResizeColumns	 . 
   CanUserSortColumns
 .  
�������$��Comic Sans MS)�5      $��2��5         AutoGenerateColumns .  $	��400��5   )      Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã Phiếu��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *	maPhieu+  5$      $ Mã Sinh Viên��6)   $	 120 6?    6K   �� *maSV+  5%      $ Mã Nhân Viên��6)   $	 120 6?    6K   �� *maNV+  5&      $ 	Mã Sách��6)   $	 120 6:    6F   �� *maSach+  5'      $ Ngày Mượn��6)   $	 180 6<    6H   �� *
ngayMuon+  5(      $ Ngày Trả��6)   $	 180 6;    6G   �� *	ngayTra+  5)      $ So Luong��6)   $	 180 6;    6G   �� *	soLuong+  5*      $ Tình Trạng��6)   $	 150 6=    6I   �� *	tinhTrang+5,      5.      5/      50      