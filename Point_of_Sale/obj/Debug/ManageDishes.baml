   M S B A M L   `   `   `  ����  cw2_40125689    cw2_40125689.ManageDishes   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Manage Menu Items��5   	   $��353.333��6#   $��562.333��64   .��5      � .+�5   
   �� -   5         ��Name$ 	lbxDishes��5      $
��Left=�6%   $	��100��6@   $��	30,55,0,0q�6M   $	��Top=�6`   $	��130��6x   ��5   
   ��  �� Path$ Dishes���5      �� 5	      .R�5
      �� ��6    �� *Description+6?   5      5      �� 5   
   -   5         ��Name$ 
btnAddDish��5      $	��Add��6%   $
��Left=�63   $��352,191,0,0q�6N   $	��Top=�6c   $��75��6{   6�   �� 5   
   -   5        $ btnAmendDish��5      $��Amend��6'   $
��Left=�67   $��190,191,0,0q�6R   $	��Top=�6g   $��75��6   6�   �� 5   
   -   5        $ btnRemoveDish��5      $��Remove��6(   $
��Left=�69   $��
30,191,0,0q�6T   $	��Top=�6h   $��75��6�   6�   �� 5   
   -   5         ��Name$ 	lblDishes��5      $��
Menu Items��6#   $
��Left=�68   $��	30,29,0,0q�6S   $	��Top=�6f   �� 5   
   -   5        $ lblDescription��5      $��Description��6(   $
��Left=�6>   $��
190,29,0,0q�6Y   $	��Top=�6m   �� 5   
   -   5         ��Name$ txtDescription��5      $
��Left=�6*   $��23��6E   $��
190,55,0,0q�6Q    �� TextWrapping$
 Wrap=�6e   $	��Top=�6y   $	��120��6�   ��6�   ��  �� ElementName$ 	lbxDishes��$ SelectedItem.Description� �� Mode$ OneWay=��� 5   
   -   5        $ lblPrice��5      $��Price, (pence)��6"   $
��Left=�6;   $��
190,90,0,0q�6V   $	��Top=�6j   �� 5   
   -	   5        $ txtPrice��5      $
��Left=�6$   $��23��6?   $��190,116,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $	��120��6�   ��6�   �� $ 	lbxDishes��$ SelectedItem.Price�$ OneWay=��� 5   
   -
   5        	 ��Name$	 ckbVegetarian��5      $��
Vegetarian��6*   $
��Left=�6?   $��190,156,0,0q�6Z   $	��Top=�6o   
 d� 	IsChecked
 6�   �� $ 	lbxDishes��$ SelectedItem.Vegetarian�$ OneWay=��� 5   
   -   5        $ lblNewDescription��5      $��Description��6+   $
��Left=�6A   $��
352,29,0,0q�6\   $	��Top=�6p   �� 5   
   -   5        $ txtNewDescription��5      $
��Left=�6-   $��23��6H   $��
352,55,0,0q�6T   $
 Wrap=�6h   $	��Top=�6|   $	��120��6�   �� 5   
   -   5        $ lblNewPrice��5      $��Price, (pence)��6%   $
��Left=�6>   $��
352,90,0,0q�6Y   $	��Top=�6m   �� 5   
   -   5        $ txtNewPrice��5      $
��Left=�6'   $��23��6B   $��352,116,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��120��6�   �� 5   
   -   5        $	 ckbNewVegetarian��5      $��
Vegetarian��6-   $
��Left=�6B   $��352,159,0,0q�6]   $	��Top=�6r   �� 5   
   -   5        $ lblAdd��5      $��Add New Menu Item��6    $
��Left=�6<   $��	352,3,0,0q�6W   $	��Top=�6j   $
��Bold"�6�   �� 5   
   -   5        $ lblExisting��5      $��Existing Menu Items��6%   $
��Left=�6C   $��30,3,0,0q�6^   $	��Top=�6p   $
��Bold"�6�   �� 5   
   -   5        $ lblQuantity��5      $��Quantity ordered:��6%   $
��Left=�6A   $��
30,160,0,0q�6\   $	��Top=�6p   �� 5   
   -   5        $ lblQty��5      $
��Left=�6f   $��134,160,0,0q�6�   $	��Top=�6�   ��6    �� $ 	lbxDishes��$ SelectedItem.Quantity�6�   5       5!      