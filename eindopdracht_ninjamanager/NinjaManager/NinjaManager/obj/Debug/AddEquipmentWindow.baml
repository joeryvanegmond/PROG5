   M S B A M L   `   `   `  ����G  CNinjaManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:NinjaManagerNinjaManager  5   	   %    NinjaManager.AddEquipmentWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:NinjaManager     5   	   -   5        $��AddEquipment��5	   	     � Title$  AddEquipmentWindow��5   	   $	��450��6$   $	��400��61    � DataContext 5
   	   �� *AddEquipment+   Locator �� Source# [  .��5      �� .+�5   
   �� .��6   Name6   �� 5   
   ��6   �� *EquipmentName+ �� Mode$ TwoWay=��� 5   
   .��6   Gold6   �� 5   
   ��6   �� *EquipmentGold+$ TwoWay=��� 5   
   .��6   
Category6   �� 5   
    �� SelectedIndex$ 0��6s   ��6   �� *CatagoryNames+$ OneWay=� �� SelectedValue 6G   �� *EquipmentCatagory+6s   �� 5   
   .��6   
Strength6   �� 5   
   ��6   �� *EquipmentStrength+$ TwoWay=��� 5   
   .��6   Intelligence6   �� 5   
   ��6   �� *EquipmentIntelligence+$ TwoWay=��� 5   
   .��6   	Agility6   �� 5   
   ��6   �� *EquipmentAgillity+$ TwoWay=��� 5   
   ��6   �� *SaveEquipmentCommand+��6:   ��  �� ElementName$ AddEquipment��.��6p   Save6v   �� 5   
   
���  ����6   �� *ErrorMessage+$ TwoWay=�6R   5      5      