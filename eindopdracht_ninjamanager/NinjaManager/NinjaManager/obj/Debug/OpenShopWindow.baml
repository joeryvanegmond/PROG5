   M S B A M L   `   `   `  ����G  CNinjaManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:NinjaManagerNinjaManager  5   	   !    NinjaManager.OpenShopWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:NinjaManager     5   	   -   5        $
��Shop��5	   	     � Title$  OpenShopWindow��5   	   $	��500��6    $	��810��6-    � DataContext 5
   	   �� *Shop+   Locator �� Source# [  .��5      �� .+�5   
   �  � ColumnDefinitions 5      �� 5      $	��150 �6#   �� 5      $	��150 �6#   �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� $
��Shop��6   $��28(�6$   $
��Bold"�62   $��0��6D   �� 5      $��50��6   $��50��6    $��28(�6,   $��+��6:   
�������$
��Bold"�5   ,   ���	#FF44AE3F$��2��5      ��6*   �� *ShowAddEquipmentCommand+5      �� 5      $��3��6   .+�5      �� 
���  ��$��Black"�6K   ��6   �� *ErrorMessage+6`   5      5      &   System.Windows.Controls.DataGrid  5    
      AutoGenerateColumns .     
IsReadOnly . $	��400��6�   $��0,6,0,0q�6�   ���	#FF979494   GridLinesVisibility$ 
Horizontal=�6�      HorizontalGridLinesBrush �	#FFF0E0E0   HeadersVisibility$ Column=�6  	 �� SelectedItem	 6A   �� *SelectedEquipment+��6l   �� *EquipmentCollection+
   Columns
 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ Category��6%      
Foreground �	#FF1D1616   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6k   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *
Category+6k     5#      $
 Name��6%   $ * 6L    63   �� *Name+6L     5$      $
 Gold��6%   $ * 6L    63   �� *Gold+6L     5%      $ Strength��6%   $ * 6T    67   �� *
Strength+6T     5&      $ Intelligence��6%   $ * 6\    6;   �� *Intelligence+6\     5'      $ Agility��6%   $ * 6R    66   �� *	Agility+6R   4  .System.Windows.Controls.DataGridTemplateColumn  5)      $ 75 6)      CellTemplate 5*      �� 5+      .R�5,      �� $��0,0,0,1q�6�   ���	#FF999A9B
�������$��2q�6�   $��Center=�6  $��Center=�6"  $��60��6=  $��30��6H  ���	#FF6F9BDA��6%   �� *DataContext.BuyCommand+ �� RelativeSource ��  �� AncestorType$ DataGridL���6�   ��  �� ElementName$
 Shop��.��6k  Buy6p  5-      5/        51      $ 50 6)    52      �� 53      .R�55      �� $��0,0,0,1q�56   )   ���	#FF999A9B
�������$��2q�6n   $��Center=�6y   $��Center=�6�   $��60��6�   $��30��6�   ���	#FFD45134��55   %   �� *" DataContext.SellEquipmentCommand+ �� $ DataGridL���6�   �� $
 Shop��.��56   �   Sell6�   57      59        5;      $ 50 6)    5<      �� 5=      .R�5?      �� $��0,0,0,1q�5@   )   ���	#FF999A9B
�������$��2q�6n   $��Center=�6y   $��Center=�6�   $��60��6�   $��30��6�   ���	#FFDA8229��5?   %   �� *&$DataContext.ShowEditEquipmentCommand+ �� $ DataGridL���6�   �� $
 Shop��.��5@   �   Edit6�   5A      5C        5D      $ 50 6)    5E      �� 5F      .R�5H      �� $��0,0,0,1q�5I   )   ���	#FF999A9B
�������$��2q�6n   $��Center=�6y   $��Center=�6�   $��60��6�   $��30��6�   ���	#FFD45134��5H   %   �� *$"DataContext.DeleteEquipmentCommand+ �� $ DataGridL���6�   �� $
 Shop��.��5I   �   Delete6�   5J      5L      5N      5P      5Q      