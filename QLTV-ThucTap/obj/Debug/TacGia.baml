   M S B A M L   `   `   `  ����G  CQLTV-ThucTap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QLTV_ThucTapQLTV_ThucTap  5   	       QLTV_ThucTap.TacGia   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:QLTV_ThucTap     5   	     � Title$  Thể Loại��5   	    � Icon$9 3D:\NGAN\ThucTap\Final\QLTV\QLTV\hinhanh\account.png��6   
����� �$��Center=�6q   $	��600��6�   $
��1000��6�   $��0,0,0,7q�6�    � WindowStartupLocation$ CenterScreen=�6�    � 
ResizeMode$ NoResize=�6�   .��5
      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   9� -   5        $��	expTacGia��5      
����� �$��Thông Tác Giả��6?   $	��0,5q�6W   $��Comic Sans MS)�6d   
�������$
��auto��6�   $
��auto��6�   $��0��6�   .��5      �� $	��171��6   .@�5      �� 
�������$��Thông tin chung��6-   $��26��6F   $	��Top=�6R   $��	-2,1,0,-1q�6j   $
��Left=�6}   $	��180��6�   .��5      � 
�������$��
0,-1,-2,-2q�6.    � ColumnDefinitions 5      �� 5      $	��27* �6/   �� 5      $	��80* �6/   �� 5      $	��34* �6/   �� 5      $
��837* �6/   .+�5      �� $��0,10,2,0q�6$   $��Right=�66   $��Mã Tác Giả��6R   $	��Top=�6d    J� RenderTransformOrigin$ 0.694,0.706&�6|   $��1��6�   $��76��6�   �� 5      -   5        $��txtMaTG��5   �    �� 	MaxLength$ 7��6#   $	��150��62   $��1,0,0,0q�6>   $
��Left=�6O   $	��Top=�6j   $��27��6�   $��3��6�   �� 5      $��4,55,0,0q�6$   $
��Left=�66   $��Tên Tác Giả��6Q   $	��Top=�6d   $��1��6|   $��2��6�   $��83��6�   �� 5       -   5        $��btnthem��5    !   
��� �|�
�������$��
0,12,373,0q�6p   $��25��6�   $��80��6�   $��Thêm��6�   $��Right=�6�   $	��Top=�6�   $��3��6�   �� 5!      -   5        $��btnsua��5!   !   
�������
�������$��
0,92,378,0q�6o   $��25��6�   $��80��6�   $��Sửa��6�   $��Right=�6�   $	��Top=�6�   $��3��6�   �� 5"      -   5        $��btnxoa��5"   !   
���  ��
�������$��
0,17,153,0q�6i   $��25��6}   $��80��6�   $
��Xóa��6�   $��Right=�6�   $	��Top=�6�   $��3��6�   �� 5#      $��4,95,0,0q�6$   $
��Left=�66   $��Ghi Chú��6Q   $	��Top=�6`   $��1��6x   $��2��6�   $��83��6�   �� 5'      -   5         ��Name$ 	txtGhiChu��5'   "   $��3��65   $
��Left=�6E   $��27��6`   $��4,97,0,0q�6l   	 �� TextWrapping$
	 Wrap=�6~   $	��Top=�6�   $	��150��6�   �� 5(      -   5        $ txtTenTG��5(   �   $ 7��6#   $	��150��62   $��	29,50,0,0q�6>   $
��Left=�6Q   $	��Top=�6l   $��27��6�   $��2��6�   $ 0.487,2.111&�6�   $��2��6�   �� 5)      -   5        
 ��Name$
 	btnLmaMoi��5)   !   
����+��
�������$��
0,92,138,0q�5*   L   $��25��6`   $	��105��6l   $��
Làm Mới��6x   $��Right=�6�   $	��Top=�6�   $��3��6�   6�   5,      5.      50      51      �� 52   
   $��Comic Sans MS)�6   
�������$��
160,20,0,0q�6B   $
��Left=�6V   $��	Tìm Theo��6q   $	��Top=�6�   $��1��6�   �� 53   
   -	   5        $��txtTimKiemTacGia��53   �   $ 7��6   $��1��6    $	��150��6-   $��
275,11,0,0q�69   $
��Left=�6M   $	��Top=�6h   6�   �� 55   
   -
   5        $��
btntimkiem��55      
���/���
�������$��
600,20,0,0q�6j   $��25��6~   $	��105��6�   $��Tìm Kiếm��6�   $
��Left=�6�   $	��Top=�6�   $��1��6�   $ -0.375,0.56&�6�   &   System.Windows.Controls.DataGrid  56   
   -   5        $��datagrid��57      
����� �$��0,10,0,0q�59         CanUserAddRows .     CanUserReorderColumns .     CanUserResizeRows .     
IsReadOnly .    CanUserResizeColumns .    CanUserSortColumns .  
�������$��Comic Sans MS)�5A      $��2��5B         AutoGenerateColumns .     Columns 5H      0  *System.Windows.Controls.DataGridTextColumn  5I      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã Tác Giả��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *maTG+  5J      $ Tên Tác Giả��6%   $	 200 6:    6F   �� *tenTG+  5K      $ Ghi Chú��6%   $	 200 66    6B   �� *GhiChu+5N      5O      5P      