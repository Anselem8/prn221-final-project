   M S B A M L   `   `   `  ����G  CQLTV-ThucTap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QLTV_ThucTapQLTV_ThucTap  5   	       QLTV_ThucTap.ThongKe   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:QLTV_ThucTap     5   	     � Title$  Thống kê ��5   	    � Icon$9 3D:\NGAN\ThucTap\Final\QLTV\QLTV\hinhanh\account.png��6   
�������$��Center=�6j   $	��537��6�   $	��963��6�   $��0,0,0,7q�6�    � WindowStartupLocation$ CenterScreen=�6�    � 
ResizeMode$ NoResize=�6�   .��5	      � $��0,1,81,0q�6   .+�5
   
   � 
�������$
��Left=�6"   $��45��6=   $	��Top=�6I   $	��955��6a   $��	0,0,-79,0q�6m   .+�5      �� -   5         ��Name$ btnSachMuon��5      
���  ��
�������$��
0,10,805,0q�5      $��25��6)   $	��150��5      $��Danh Sách mượn��6!   $��Right=�5      $	��Top=�61   �� 5      -   5        $ 
btnTraSach��5      
���i��
�������$��	0,10,40,0q�5   (   $��25��5      $	��150��6!   $��Xuất ra file Excel��6-   $��Right=�5      $	��Top=�61   5      � 5   
   $
��Left=�6   $��0,50,-74,-38q�6*   $	��950��6@    � ColumnDefinitions 5      �� 5      $
��200* �6#   �� 5      $
��199* �6#   �� 5      $
��276* �6#   �� 5      $
��275* �6#   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��datagrid��5      
����� �$��
0,-5,-5,40q�5         CanUserAddRows .     CanUserReorderColumns .     CanUserResizeRows .  	   
IsReadOnly	 . 
   CanUserResizeColumns
 .    CanUserSortColumns .  
�������$��Comic Sans MS)�5'         AutoGenerateColumns .  $��4��5(   )      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells 5)         Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã Sinh Viên��6)      Width$	 100 6?   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6K   �� *maSV+  5-      $ Mã Phiếu��6)   $	 100 6;    6G   �� *	maPhieu+  5.      $ 	Mã Sách��6)   $	 100 6:    6F   �� *maSach+  5/      $ Ngày Mượn��6)   $	 180 6<    6H   �� *
ngayMuon+  50      $ Ngày Trả��6)   $	 180 6;    6G   �� *	ngayTra+  51      $ Số Lượng��6)   $	 180 6;    6G   �� *	soLuong+  52      $ Tình Trạng��6)   $	 150 6=    6I   �� *	tinhTrang+54      55      57      58      