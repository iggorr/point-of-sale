   M S B A M L   `   `   `  ����  cw2_40125689    cw2_40125689.OrdersWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Orders��5   	   $	��300��6   $	��300��6%   .��5      � .+�5   
   �� -   5         ��Name$ lblOrderType��5      $��Order Type:��6&   $
��Left=�6<   $��	25,23,0,0q�6W   $	��Top=�6j   	� 5   
   -   5         	�Name$ rdbSitIn��5      $��Sit-in��6(   $
��Left=�69   $��
113,28,0,0q�6T   $	��Top=�6h   6�   	� 5   
   -   5        $ rdbDelivery��5      $��Delivery��6+   $
��Left=�6>   $��
185,28,0,0q�6Y   $	��Top=�6m   6�   �� 5	   
   -   5         ��Name$ lbxSitInOrders��5	      $
��Left=�6*   $	��100��6E   $��	25,86,0,0q�6R   $	��Top=�6e   $	��100��6}   $y�Hidden=�5
   )   ��6
   �� *SitIns+��5      �� 5      .R�5      �� ��6    �� *OrderNumber+5      5      �� 5   
   -   5        $ lblSitInOrders��5      $��Sit-in Orders��6(   $
��Left=�6@   $��	25,60,0,0q�6[   $	��Top=�6n   $y�Hidden=�6�   �� 5   
   -   5        $ lblTable��5      $��Table:��6"   $
��Left=�63   $��157,121,0,0q�6N   $	��Top=�6c   $y�Hidden=�6{   $
��Bold"�6�   �� 5   
   -   5        $ lblTableValue��5      $
��Left=�6o   $��157,147,0,0q�6�   $	��Top=�6�   $y�Hidden=�6�   ��6'   ��  �� ElementName$ lbxSitInOrders�� �� Path$ SelectedItem.Table�6�   �� 5   
   -   5        $ 	lblServer��5      $��Server:��6#   $
��Left=�65   $��
157,60,0,0q�6P   $	��Top=�6d   $
��Bold"�6|   $y�Hidden=�6�   �� 5   
   -	   5        $ lblSitInServer��5      $
��Left=�6w   $��
157,86,0,0q�6�   $	��Top=�6�   $y�Hidden=�6�   ��6(   �� $ lbxSitInOrders��$ SelectedItem.TakenBy.Name�6�   �� 5   
   -
   5        $ lblTotal��5      $��Amount Paid:��6"   $
��Left=�69   $��157,192,0,0q�6T   $	��Top=�6i   $
��Bold"�6�   $y�Hidden=�6�   �� 5   
   -   5        $ lblSitInTotal��5      $
��Left=�6t   $��157,218,0,0q�6�   $	��Top=�6�   $y�Hidden=�6�   ��6'   �� $ lbxSitInOrders��$ SelectedItem.AmountPaid�6�   �� 5   
   -   5        $ lbxDeliveryOrders��5      $
��Left=�6-   $	��100��6H   $��	25,86,0,0q�6U   $	��Top=�6h   $	��100��6�   $y�Hidden=�5   -   ��6
   �� *
Deliveries+��5      �� 5      .R�5      �� ��6    �� *OrderNumber+5      5      �� 5    
   -   5        $ lblDeliveryOrders��5       $��Delivery Orders��6+   $
��Left=�6E   $��	25,60,0,0q�6`   $	��Top=�6s   $y�Hidden=�6�   �� 5!   
   -   5        $ 	lblDriver��5!      $��Driver:��6#   $
��Left=�65   $��157,103,0,0q�6P   $	��Top=�6e   $
��Bold"�6}   $y�Hidden=�6�   �� 5"   
   -   5        $ lblDriverValue��5"      $
��Left=�6y   $��157,119,0,0q�6�   $	��Top=�6�   ��6(   �� *SelectedItem.DeliveredBy.Name+$ lbxDeliveryOrders��6�   �� 5#   
   -   5        $ lblDeliveryServer��5#      $
��Left=�6x   $��
157,76,0,0q�6�   $	��Top=�6�   ��6+   �� *SelectedItem.TakenBy.Name+$ lbxDeliveryOrders��6�   �� 5$   
   -   5        $ lblDeliveryTotal��5$      $
��Left=�6u   $��157,208,0,0q�6�   $	��Top=�6�   ��6*   �� *SelectedItem.AmountPaid+$ lbxDeliveryOrders��6�   �� 5%   
   -   5        $ lblCustomerName��5%      $��Customer Name:��6)   $
��Left=�6B   $��157,146,0,0q�6]   $	��Top=�6r   $
��Bold"�6�   $y�Hidden=�6�   �� 5&   
   -   5        $ lblCustomerNameValue��5&      $
��Left=�6{   $��157,162,0,0q�6�   $	��Top=�6�   ��6.   �� *SelectedItem.CustomerName+$ lbxDeliveryOrders��6�   5(      5)      