   M S B A M L   `   `   `  ����G  CNinjaManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:NinjaManagerNinjaManager  5   	   &     NinjaManager.OpenInventoryWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:NinjaManager     5   	   IStyle9http://schemas.microsoft.com/netfx/2009/xaml/presentation    5   	   -   5        $��	Inventory��5
   	     � Title$  InventoryWindow��5	   	   $	��600��6!   $	��800��6.    � DataContext 5   	   �� *NinjaInventory+   Locator �� Source# [  .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6%   .+�5      �� $��24(�6   ��6&   �� *SelectedNinja.Name+6L   5      � 5   
   $��1��6   $��0��6    5      �� 5       $��* �6#   �� 5!      $��* �6#   .+�5$      �� $��0��6   $��24(�6(   Gold: �� 6=   $��24(�6G   ��6U   �� *Gold+6m   6z   �� 5%      $��1��6   
���  ��$
��Bold"�6W   ��6(   �� *ErrorMessage+6k   5&      � 5)   
   $��0��6   $��1��6   .+�5*      �� 
���   �$��15q�6)   ._�5+      �� ��5,      �� 5-       �� ImageSource$N Hhttps://images-na.ssl-images-amazon.com/images/I/5106pO9TTUL._UX679_.jpg��6%    j� Stretch$ Uniform=�6}   5/      50      51      � 53      $��1��6   $��1��6!    55      �� 56      $��* �6    �� 57      $��70 �6    .+�5:      &   System.Windows.Controls.DataGrid     AutoGenerateColumns .     
IsReadOnly . $��0,6,0,0q�6�   ���	#FF979494	   GridLinesVisibility$	 
Horizontal=�6�   
   HorizontalGridLinesBrush
 �	#FFF0E0E0   HeadersVisibility$ Column=�6   �� SelectedItem 6E   �� *SelectedEquipment+��6p   �� *EquipmentCollection+   Columns 5;      0  *System.Windows.Controls.DataGridTextColumn  5<      ,  &System.Windows.Controls.DataGridColumn   Header$ Category��6)      
Foreground �	#FF1D1616   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6o   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *
Category+6o     5=      $
 Name��6)   $ * 6P    67   �� *Name+6P     5>      $
 Gold��6)   $ * 6P    67   �� *Gold+6P   5A      � 5C      $��1��6   $��1��6     5D      �� 5E      $	��175 �6'   �� 5F      $	��100 �6'   �� 5G      $��* �6'   �� 5H      $	��100 �6'   .+�5K      �� $��1��6   $��0��6*   .+�5L      �� 
Waarde: �� 6)   ��63   �� *EquipmentValue+ �� Mode$ TwoWay=�6b   6o   �� 5M      Totale strength: �� 62   ��6<   �� *StrengthValue+$ TwoWay=�6j   6w   �� 5N      Totale intelligence: �� 66   ��6@   �� *IntelligenceValue+$ TwoWay=�6r   6   �� 5O      Totale agility: �� 61   ��6;   �� *AgilityValue+$ TwoWay=�6h   6u   5R      �� 5T      $��1��6v   
���  ��$��20(�6�   $
��Bold"�6�   
���������6   �� *EmptyInventoryCommand+��6C   ��  �� ElementName$ 	Inventory��.��6�   Legen6�   �� 5U      $��3��6=   
���  ��$��20(�6b   $
��Bold"�6p   
���������6   �� *OpenShopCommand+.��6�   Shop6�   5W      5Z      5]      5     