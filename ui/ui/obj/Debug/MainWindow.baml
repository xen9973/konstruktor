   M S B A M L   `   `   `  ����=  9ui, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:uiui  5   	   3clr-namespace:ui.MWM.ViewModelui.MWM.ViewModel  5   	       ui.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   "localclr-namespace:ui     5   	   4	ViewModelclr-namespace:ui.MWM.ViewModel     5   	   $	��600��5
   	   $	��920��6     � WindowStyle$
  none=�5   	    � 
ResizeMode$ NoResize=�5   	   
������  � AllowsTransparency .  � DataContext 5      $  ui.MWM.ViewModel.MainViewModel  5   
   .��5   
   �� ���#272537 �� CornerRadius$ 15��5   	   ._�5   
   �  � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5       � RowDefinitions 5      �� 5      $��75 �6    �� 5      .+�5      �� $
��gool��6   $��Center=�5       $
��Left=�5!      
�������$��22(�5#      $��20,0,0,0q�5$      �� 5%      $��1��6   .+�5'      	� $
��Home��6   $��50��5(      
�������$��14(�5*         MenuButtonTheme#��[  5+       d� 	IsChecked$ FalseY�5,      ��5-      �� *HomeViewCommand+	� 5/      $��	Discovery��6   $��50��50      
�������$��14(�52      #��[  53      ��55      �� *DiscoveryViewCommand+	� 57      $��Featured��6   $��50��58      
�������$��14(�5:      #��[  5;      5=      �� 5>      $	��250��6   $��40��5?      $��Center=�5@      $
��Left=�5A      $��5q�5B      $��1��5C        ModernTextBox#��[ 5D      �� 5F      $��1��6   $��1��5G      $��10q�5H      ��5I      �� *CurrentView+5J      5K      5L      