   M S B A M L   `   `   `  ����G  CQLTV-ThucTap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QLTV_ThucTapQLTV_ThucTap  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       QLTV_ThucTap.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:QLTV_ThucTap     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   3System&clr-namespace:System;assembly=mscorlib  5   	     � WindowStartupLocation$  CenterScreen=�5
   	    � Title$ 
MainWindow��5   	   $	��800��5   	   
���������5   	   ��  �� Source# Z�� � 	Resources 5         MenuOpen �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	Menuclose��%O  &	        &	 �     �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ gridMenu��6a   .\�5        $ 	0:0:0:0.2��6'   $	 300Q�6;   5      5      �� 5   
   .��5      U� $ gridMenu��6,   $ (FrameworkElement.Width)�6M   .\�5        $ 	0:0:0:0.2��6'   $ 70Q�6;   5      5      5       � Triggers 5      :� 5   
   	 :� RoutedEvent$	 ButtonBase.Click��6   
 :� 
SourceName$
 btnOpenMenu��66   .[�5      �� #��[  6   5      :� 5   
   $	 ButtonBase.Click��6   $
 btnCloseMenu��66   .[�5       �� #��[ 6   5!      .��5#      � 
�������$��0,0,0,7q�6!   $
��1500��62    � ColumnDefinitions 5$   
   �� 5%      $
��475* �6   �� 5&      $	��61* �6   .+�5(   
   �� $O��ID:\NGAN\ThucTap\LinQ to SQL\QLTV-ThucTap\QLTV-ThucTap\hinhanh\dannhap.jpg��6   $
��Fill=�6c   $��Center=�6r   $��2��6�   $��70,10,10,-10q�6�   $
��1420��6�   � 5)   
   $��60��6   $	��Top=�6   ���#2b1515$
��Left=�6I   $
��1500��6d   $��1,0,-1,0q�6q   $��2��6�   .+�5*      �� $��Algerian)�6   $��Center=�6.   $��Center=�6K   $��40(�6f   $��424,4,266,4q�6t   $	��506��6�   $��Library management��6�   �� 5+      $��Center=�6   $��5q�64   .+�5-      '  !MaterialDesignThemes.Wpf.PopupBox  $��Right=�6*   $��0,10,0,0q�6F      PlacementMode$ BottomAndAlignLeftEdges=�6X      	StaysOpen .  $	��166��6�    J� RenderTransformOrigin$ 8.837,0.308&�6�   $��62��6�      PopupContent. 5.      �� $	��150��6!   .+�5/      �� -   5        $��TKDS Đang Mượn ��5/   !   6;   �� 50      �� 51      -   5        $��TKDS Đã Trả ��51   !   68   �� 52      �� 53      -   5         ��Name$ 	btnlogout��53   !   $��Thoát��64   6D   54      55      56      57      � 58   
   -   5         �Name$ gridMenu��58      $��1,60,0,0q�6!   $��69��63   $
��Left=�6>   ���#211a1a.+�59      �� $��0,0,0,0q�6   .+�5:      � $��60��6   ���#211a1a.+�5;      �� -   5        $ btnOpenMenu��5;      $��80��5<      $��60��5=      ���#211a1a$��0q�5?      $��Right=�5@      $��0,0,0,10q�5A      $��Center=�5B      .��5D      '  !MaterialDesignThemes.Wpf.PackIcon  
��������  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$
 Menu=�6E   $��60��6Q   $��60��6\   5E      �� 5F      -   5        $ btnCloseMenu��5F      $��80��5G      $��60��5H      ���#211a1a$��0q�5J      $��Right=�5K      $��0,0,0,10q�5L      $��Center=�5M      $y�	Collapsed=�5N      .��5P        
�������$ 	ArrowLeft=�6E   $��60��6V   $��60��6a   5Q      5R      �� 5S      $��Disabled=�6   
�������.@�5T      �� -   5        $��80��5T   $   .��5U      ��  �� Orientation$ 
Horizontal=�6%   .+�5V        $ ViewDashboard=�66   $
��15 5q�6K   $��25��6Y   $��25��6d   $��Center=�6p   �� 5W      -   5        $��Student Management��5W   <   $��Center=�6Y   $��20 10 q�6t   $	��205��6�   5X      5Y      �� 5Z      $��80��6$   .��5[      �� $ 
Horizontal=�6%   .+�5\        $
��15 5q�66   $ ViewDashboard=�6D   $��25��6Y   $��25��6d   $��Center=�6p   �� 5]      -	   5        $��Employee Management��5]   <   $��Center=�6Z   $��20 10 q�6u   $	��205��6�   5^      5_      �� 5`      $��80��6$   .��5a      �� $ 
Horizontal=�6%   .+�5b        $
��15 5q�66   $ ViewDashboard=�6D   $��25��6Y   $��25��6d   $��Center=�6p   �� 5c      -
   5        $��Book Management��5c   <   $��Center=�6V   $��20 10 q�6q   $	��205��6�   5d      5e      �� 5f      $��80��6$   .��5g      �� $ 
Horizontal=�6%   .+�5h        $
��15 5q�66   $ ViewDashboard=�6D   $��25��6Y   $��25��6d   $��Center=�6p   �� 5i      -   5        $��Category Management��5i   <   $��Center=�6Z   $��20 10 q�6u   $	��205��6�   5j      5k      �� 5l      $��80��6$   .��5m      �� $ 
Horizontal=�6%   .+�5n        $
��15 5q�66   $ ViewDashboard=�6D   $��25��6Y   $��25��6d   $��Center=�6p   �� 5o      -   5        $��Actor Management��5o   <   $��Center=�6W   $��20 10 q�6r   $	��205��6�   5p      5q      �� 5r      $��80��6$   .��5s      �� $ 
Horizontal=�6%   .+�5t        $
��15 5q�66   $ ViewDashboard=�6D   $��25��6Y   $��25��6d   $��Center=�6p   �� 5u      -   5        $��Publisher Management��5u   <   $��Center=�6[   $��20 10 q�6v   $	��205��6�   5v      5w      �� 5~      $��80��6$   .��5      �� $ 
Horizontal=�6%   .+�5�        $
��15 5q�66   $ ViewDashboard=�6D   $��25��6Y   $��25��6d   $��Center=�6p   �� 5�      -   5        $��Borrow/Lend Management��5�   <   $��Center=�6]   $��20 10 q�6x   $	��205��6�   5�      5�      �� 5�      $��80��6$   .��5�      �� $ 
Horizontal=�6%   .+�5�        $
��15 5q�66   $ ViewDashboard=�6D   $��25��6Y   $��25��6d   $��Center=�6p   �� 5�      -   5        $��Borrow/Lend List��5�   <   $��Center=�6W   $��20 10 q�6r   $	��205��6�   5�      5�      5�      5�      5�      5�      5�      