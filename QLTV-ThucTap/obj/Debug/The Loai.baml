   M S B A M L   `   `   `  ����G  CQLTV-ThucTap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QLTV_ThucTapQLTV_ThucTap  5   	       QLTV_ThucTap.The_Loai   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:QLTV_ThucTap     5   	     � Title$  Thể Loại��5   
    � Icon$9 3D:\NGAN\ThucTap\Final\QLTV\QLTV\hinhanh\account.png��6   
����� �$��Center=�6r   $	��600��6�   $
��1000��6�   $��0,0,0,7q�6�    � WindowStartupLocation$ CenterScreen=�6�    � 
ResizeMode$ NoResize=�6�   .��5
      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   9� -   5        $��
expTheLoai��5      
����� �$��Thông Thể Loại��6@   $��
0,-5,10,15q�6Y   $��Comic Sans MS)�6m   
�������$
��auto��6�   $
��auto��6�   $��0��6�   .��5      �� $	��171��6   .@�5      �� 
�������$��Thông tin chung��6-   $��26��6F   $	��Top=�6R   $��	-2,1,0,-1q�6j   $
��Left=�6}   $	��180��6�   .��5      � 
�������$��	0,0,-2,-2q�6.    � ColumnDefinitions 5      �� 5      $	��27* �6/   �� 5      $	��80* �6/   �� 5      $	��34* �6/   �� 5      $
��837* �6/   .+�5      �� $��	0,37,31,0q�6$   $��Right=�67   $��Mã Thể Loại��6S   $	��Top=�6f    J� RenderTransformOrigin$ 0.694,0.706&�6~   $��1��6�   $��2��6�   $��76��6�   �� 5      -   5        $��txtMaTL��5   �    �� 	MaxLength$ 7��6#   $	��150��62   $��7,29,0,0q�6>   $
��Left=�6P   $	��Top=�6k   $��27��6�   $��3��6�   �� 5      $��4,62,0,0q�6$   $
��Left=�66   $��Tên Thể Loại��6Q   $	��Top=�6e   $��1��6}   $��2��6�   $��83��6�   �� 5      -   5        $��txTTenTL��5   �   $ 50��6"   $	��145��61   $��8,57,0,0q�6=   $
��Left=�6O   $	��Top=�6j   
 � Tag$ HoTen��6�   $��25��6�   $��3��6�   �� 5       -   5        $��btnthem��5    !   
��� �|�
�������$��
0,16,383,0q�6q   $��25��6�   $��80��6�   $��Thêm��6�   $��Right=�6�   $	��Top=�6�   $��3��6�   $ 	0.75,-0.8&�6�   �� 5!      -   5        $��btnsua��5!   !   
�������
�������$��
0,91,383,0q�6o   $��25��6�   $��80��6�   $��Sửa��6�   $��Right=�6�   $	��Top=�6�   $��3��6�   �� 5"      -   5        $��btnxoa��5"   !   
���  ��
�������$��
0,16,203,0q�6i   $��25��6}   $��80��6�   $
��Xóa��6�   $��Right=�6�   $	��Top=�6�   $��3��6�   �� 5#      $��4,95,0,0q�6$   $
��Left=�66   $��Ghi Chú��6Q   $	��Top=�6`   $��1��6x   $��2��6�   $��83��6�   �� 5$      -   5        $��	txtGhiChu��5$   "   $��3��63   $
��Left=�6C   $��27��6^   $��8,94,0,0q�6j   	 �� TextWrapping$
	 Wrap=�6|   $	��Top=�6�   $	��150��6�   �� 5%      -   5        
 ��Name$
 	btnLamMoi��5%   !   
����+��
�������$��
0,91,198,0q�6`   $��25��6t   $��90��6�   $��
Làm Mới��6�   $��Right=�6�   $	��Top=�6�   $��3��6�   6�   5*      5,      5.      5/      �� 50   
   $��Comic Sans MS)�6   
�������$��
160,20,0,0q�6B   $
��Left=�6V   $��	Tìm Theo��6q   $	��Top=�6�   $��1��6�   �� 51   
   -	   5        $��txtTimTheoTl��51   �   $ 7��6   $��1��6    $	��150��6-   $��
275,20,0,0q�69   $
��Left=�6M   $	��Top=�6h   6�   �� 52   
   -
   5        $��
btntimkiem��52      
���/���
�������$��
600,20,0,0q�6j   $��25��6~   $	��105��6�   $��Tìm Kiếm��6�   $
��Left=�6�   $	��Top=�6�   $��1��6�   $ -0.375,0.56&�6�   &   System.Windows.Controls.DataGrid  53   
   -   5        $��datagrid��54      
����� �$��0,10,0,0q�56         CanUserAddRows .     CanUserReorderColumns .     CanUserResizeRows .     
IsReadOnly .    CanUserResizeColumns .    CanUserSortColumns .  
�������$��Comic Sans MS)�5>      $��2��5?         AutoGenerateColumns .  ��5A      �� *	theloai+   Columns 5G      0  *System.Windows.Controls.DataGridTextColumn  5H      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã Thể Loại��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6:   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *maTL+  5I      $ Tên Thể Loại��6%   $	 200 6;    6G   �� *tenTL+  5J      $ Ghi Chú��6%   $	 250 66    6B   �� *GhiChu+5M      5N      5O      