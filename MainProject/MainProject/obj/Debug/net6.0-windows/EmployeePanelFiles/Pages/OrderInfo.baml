   M S B A M L   `   `   `  ����F  BMainProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:WPFModernVerticalMenu.PagesWPFModernVerticalMenu.Pages  5      4    .MainProject.EmployeePanelFiles.Pages.OrderInfo   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:WPFModernVerticalMenu.Pages     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5        .��5      ��   �� CornerRadius$  5��6      SecundaryBackgroundColor#���   6   ._�5   
   �� .+�5      � $��10 10q�6    � ColumnDefinitions 5      �� 5      �� 5      �� 5      �� 5      .+�5      �� $��0��6   .+�5      �� -   5        $��txt_Id��5       % !MaterialDesignFloatingHintTextBox#��[ 6-   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 ID: ��5   &      FloatingOffset$ 0,-20&�5   &   
����������#c5c8cc$��	0 0 0 1.5q�5   &   $	��134��5   '   $
��Left=�5      5"   &   �� 5$      -   5        $��lbl_id_warning��5$       $��empty!!!��66   
���  ��$y�Hidden=�6W   6m   5%      �� 5(      -   5        $��
btn_Search��5(      $	��Top=�6+   $��139,5,140,0q�6C     MaterialDesignFlatButton#��[ 6Y   $��2��6�   .��5*      ��  �� Orientation$ 
Horizontal=�6!   .+�5+      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Magnify=�5,      $��Center=�5-      $��0,0,0,0q�5.      �� 50      $
��Left=�6$   $��Search��6@   $��Center=�6N   $��51��6i   51      52      5:      � 5;      $��10q�6    5<      �� 5=      �� 5>      .+�5A      �� -   5        $��txt_sender_national_code��5A      $��0��6:   #��[ 6J   $ Sender National Code: ��5B   &   $ 0,-20&�5C   &   
����������#c5c8cc$��	0 0 0 1.5q�5F   &   $
��Left=�5G      $	��134��5H      �� 5J      -   5        $��txt_receiver_phone_number��5J      $��1��6<   #��[ 6L   $ Receiver Phone Number: ��5K   &   $ 0,-20&�5L   &   
����������#c5c8cc$��	0 0 0 1.5q�5O   &   $
��Left=�5P      $	��134��5Q      5T      � 5U      $��10q�6    5V      �� 5W      �� 5X      �� 5Y      �� 5Z      .+�5^      �� $��0��6   $��2��6.   .+�5`      �� -   5        $��txt_sender_address��5`      #��[ 68   $ Sender Address: ��5a   &   $ 0,-20&�5b   &   
����������#c5c8cc$��	0 0 0 1.5q�5e   &   �� 5h      -   5        $��txt_receiver_address��5h      #��[ 6:   $ Receiver Address: ��5i   &   $
��0 30q�5j   &   $ 0,-20&�5k   &   
����������#c5c8cc$��	0 0 0 1.5q�5n   &   �� 5q      .+�5s      �� -	   5        $��
txt_weight��5s   "   #��[ 65   $ Weight (kg): ��5t   &   $	��134��5u   &   $
��Left=�5v   "   $ 0,-20&�5z   &   
����������#c5c8cc$��	0 0 0 1.5q�5}   &   $��0,0,97,0q�6B   �� 5�      -
   5        $#��checkbox_has_expensive_object��5�   5   $��0 40 0 0q�6#   $
��Left=�6[   $��is Expensive��6v   
�������$
��Bold"�6�   $	��115��6�   ��5�      �� 5�   "    �� 
TargetType" ��6(     MaterialDesignCheckBox �� BasedOn# [ 6G   .�5�   &   ��  �� Property � ��	 �� Value$	 16(�6A   �� 5�   &    � ��$	 10q�6?   5�   #   5�      5�      5�      �� 5�      $��2��6   $��2��6-   $��10q�6A   .+�5�      �� -   5        $��combo_contenttype��5�      $��0��69    " MaterialDesignOutlinedComboBox#��[ 6F   $��Center=�6~   $ Content Type :��6�   #���   6�   
�������.@�5�      �� -   5        $��item_object��5�   '   
���   �$��Object��6N   �� 5�      -   5        $��item_document��5�   '   
���   �$��Document��6P   �� 5�      -   5        $��item_breakable��5�   '   
���   �$��	Breakable��6Q   5�      �� 5�      -   5        $��combo_typeofdelivery��5�      $
��0 20q�6;   #��[ 6I   $ Delivery Type :��6�   #���   6�   
�������.@�5�      �� 
���   �$��Ordinary��6;   �� 5�      
���   �$��Swift��6;   5�      5�      5�      � 5�      $��10q�6   .+�5�      �� 6   5�      � 5�      $��10q�6    5�      �� 5�      �� 5�      .+�5�      � $��0��6   $��0 -20q�6'   
 � RowDefinitions
 5�      �� 5�      �� 5�      �� 5�      �� 5�      .+�5�      �� 
�������$��0��6/   $��20(�6<   $��	Status : ��6J   6`   �� 5�      $��0 -40 0 -40q�6!   $��1��66   $ 
Horizontal=�6C   .+�5�      	� -   5        $��radio_Registered��5�   9   
�������$��20q�6Q   $��
Registered��6]    	� 	GroupName$ Options��6r   	� 5�      -   5        $��radio_ReadytoSend��5�   9   
�������$
��20 0q�6R   $��Ready to Send��6`   $ Options��6x   5�      �� 5�      $��2��6!   $ 
Horizontal=�6.   .+�5�      	� -   5        $��radio_Sending��5�   9   
�������$
��20 0q�6N   $��Sending��6\   $ Options��6n   	� 5�      -   5        $��radio_Delivered��5�   9   
�������$
��32 0q�6P   $��	Delivered��6^   $ Options��6r   5�      5�      � 5�      $��1��6   .+�5�      �� $��	0 -30 0 0q�6!   .+�5�      �� 
�������$��Customer Cumment��64   $��	0,10,0,10q�6O   6d   �� 5�      -   5        $��txt_Customer_comment��5�   "   
�������$��77��6Q   5�      5�      5�      � 5�      $��10 -10q�6    5�      �� 5�      �� 5�      .+�5�      �� -   5        $��
btn_update��5�      $��Update��6-   6>   5�      5<     5>     5?     