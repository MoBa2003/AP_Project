   M S B A M L   `   `   `  ����F  BMainProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MainProjectMainProject  5   	   O,clr-namespace:WPFModernVerticalMenu.ControlsWPFModernVerticalMenu.Controls  5   	       MainProject.CustomerPanel   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:MainProject     5   	   =ctls,clr-namespace:WPFModernVerticalMenu.Controls     5   	   -   5          � Title$  
MainWindow��5	   	   $	��650��6   $
��1000��6)    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�6.   
������  � AllowsTransparency$
 True��5   "    � 
ResizeMode$ NoResize=�5   	   $��Poppins)�6   .��5      ��    PrimaryBackgroundColor#���   6    �� CornerRadius$ 8��5      ._�5   
   �  � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5      �� $��0��6     SecundaryBackgroundColor#���  5      $ 8 0 0 8��5      ._�5      � -   5         �Name$ GridNav��5      $��60��6(    � RowDefinitions 5      �� 5      $��60 �6(   �� 5       $��* �6(   .+�5#      � $��0��6   .+�5$      �� $��14 0 0 0q�5%      $��32��5&      $��24��6*   $
��Left=�5'      ��5(      �� 5)   "   	 �� ImageSource$+	 %EmployeePanelFiles/Resources/logo.png��6-   
 j� Stretch$
 Uniform=�6a   5+      �� 5-      -   5        $��lbl_name��5-       $��Poppins��60     PrimaryTextColor#���  5.       $
��Bold"�5/       $��16(�50       $��Center=�51       $
��Left=�52       $��60 0 0 0q�53       54      �� 57      $��1��6!   $��
-1 40 0 20q�6.   .+�58      �� -   5         ��Name$ btn_ChangeUserPass��58   !     PopupButtonStyle#���  6=   .��59      -   'WPFModernVerticalMenu.Controls.MenuItem     	GroupName$ MenuItem��6,     PrimaryBlueColor   IndicatorBrush# �  6A     restore   Icon# �  6u      	IconWidth$ 16��6�      Text$ Change Username Password��6�   $��Center=�6�   5:      �� 5;      -   5        $ 
btn_Wallet��5;   !   #���  65   .��5<        $ MenuItem��6-   # �  6B     billing# �  6v   $ 16��6�   $ Wallet��6�   $��Center=�6�   5=      �� 5>      -   5        $ btn_advanced_Search��5>   !   #���  6>   .��5?        $ MenuItem��6,   # �  6A     eye# �  6u   $ 16��6�   $ Advanced Search��6�   $��Center=�6�   5@      �� 5A      -   5        $ btn_order_info��5A   !   #���  69   .��5B        $ MenuItem��6,   # �  6A     products# �  6u   $ 16��6�   $ 
Order Info��6�   $��Center=�6�   5C      5E      � 5I      -   5         �Name$ Popup��5I       � AllowsTransparency$
 True��6,    � HorizontalOffset$ 0��6G    � VerticalOffset$ 10��6\   .��5J      .   (WPFModernVerticalMenu.Controls.UserPopup  -	   5          Name$ Header��5J   )   #���  69   5K      5N      5O      � 5Q      $��1��6    5R      �� 5S      $��60 �6$   �� 5T      $��* �6$   .+�5W      d� -
   5         d�Name$ Tg_Btn��5W      $��1��6/   $��Center=�6?    	 iToggleButtonStyle#��� 	 6Z   $
��Left=�6�   $��0q�6�   
������ $��
10,15,0,15q�6�   $��30��6�   $��30��6�    � Triggers 5X      :� 5Y       :� RoutedEvent$ ToggleButton.Unchecked��6'   .[�5Z      �� .��5[   "   �� -   5         ��Name$ HideStackPanel��5[   -   .��5\   &   W�  �� 
TargetName$ GridNav��66    �� TargetProperty$ Width�6V    g� 	BeginTime	 0:0:06x    W� From 2106�   	 W� To 606�    g� Duration$ 0:0:0.5D�6�   5]   '   5^   #   5_      5`      :� 5a      $ ToggleButton.Checked��6'   .[�5b      �� .��5c   "   �� -   5        $ ShowStackPanel��5c   -   .��5d   &   W� $ GridNav��66   $ Width�6V   	 0:0:06x    606�    2106�   $ 0:0:0.5D�6�   5e   '   5f   #   5g      5h      5j      �� 5m      $��0��6   $��Right=�6*   $	��Top=�6F   $��0,5,10,0q�6^   $��30��6p     �� Orientation$  
Horizontal=�6|   $��RightToLeft=�6�   $��2��6�   .+�5n      �� -   5        $ btnClose��5n       
 IconButtonsStyle#��[
 6/    	 close#���  6Y   
! � Tag$! IsCloseButton��6�   �� 5{      -   5        $ btnMinimize��5{      #��� 
 62     minimize#���  6]   6�   5|       � 5      -   5        $��
fContainer��5�      $��1��5      $��20q�5�      "  � NavigationUIVisibility$" Hidden=�5�      5�      5�      5�      5�      5�      