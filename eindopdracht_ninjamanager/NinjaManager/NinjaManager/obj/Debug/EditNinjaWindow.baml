   M S B A M L   `   `   `  ����G  CNinjaManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:NinjaManagerNinjaManager  5   	   "    NinjaManager.EditNinjaWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:NinjaManager     5   	   -   5        $��	EditNinja��5	   	     � Title$  EditNinjaWindow��5   	   $	��220��6!   $	��310��6.    � DataContext 5
   
   �� *	EditNinja+   Locator �� Source# [  .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��20 �6   �� 5      $��20 �6   .+�5   
   �� $��0��6   .+�5      �� $��
Edit Ninja��6   $��28(�6*   �� 5      $��Name:��6   $��0,5,0,0q�6%   �� 5      ��6   �� *	NinjaName+ �� Mode$ TwoWay=��� 5      $��Gold:��6   $��0,5,0,0q�6%   �� 5      ��6   �� *	NinjaGold+$ TwoWay=�5      �� 5   
   $��1��6   .+�5      �� ��6   �� *SaveNinjaCommand+��6;   ��  �� ElementName$ 	EditNinja��.��6n   Save6t   5       �� 5"   
   $��2��6   .+�5#      �� 
���  ����6   �� *ErrorMessage+$ TwoWay=�6V   5$      5%      5&      