   M S B A M L   `   `   `  ����W  SFastReport.Tools, Version=1.2.1.0, Culture=neutral, PublicKeyToken=02c9b8a34f25774di9clr-namespace:FastReport.DictionaryExtension.UserControls+FastReport.DictionaryExtension.UserControls  5      A    ;FastReport.DictionaryExtension.UserControls.DataSetSelector   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Klocal9clr-namespace:FastReport.DictionaryExtension.UserControls     5      $��5q�5   ?   $��Stretch=�6J   $��Stretch=�6h   .��5	      �   � ColumnDefinitions  5
   
   �� 5      $	��10* �6   6-   �� 5      $��8* �6   6,    � RowDefinitions 5   
   �� 5      $��20 �6   6*   �� 5      $	��20* �6   6+   �� 5      $	��13* �6   6+   �� 5      $��40 �6   6*   .+�5   
   �� -   5         ��Name$ 
lbDataSets��5      $��0��6q   $��1��6�    �� SelectionMode$ Single=�6�   $��
10,5,10,10q�6�   ��6&   ��  �� Path$ DataSets� �� UpdateSourceTrigger$ PropertyChanged=���5      �� 5      .R�5      �� ��6    �� *
FullName+6<   5      5      �� 5   
   -   5        $ lbDataTables��5   &   $��
10,5,10,10q�6   $��1��6�   $��1��6�   $ Multiple=�6�   ��6<   �� $ 
DataTables�$ PropertyChanged=���5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property �@��
IsSelected �� Value 63   �� $ 	IsChecked�	 �� Mode$	 TwoWay=�5      ��5"      �� 5#      .R�5$      �� 
 �� Orientation$
 
Horizontal=�6!   $��3,3,3,3q�6:   .+�5%      �� $��Center=�5&      $��0,0,4,0q�5'       d� 	IsChecked 5%   #   ��  �� RelativeSource ��  �� AncestorType" ��$ 
IsSelected�5'      �� 5(      $��Center=�6:   ��6$   �� *Name+6:   5)      5*      5,      �� 5-   
   $��	10,6,10,0q�6   $
��Wrap=�6'   $��Select DatSet��6;   $��14��6P   $	��Top=�6\   �� 5.   
   $��1��6   $��	11,5,10,0q�6$   $
��Wrap=�67   $��Select DataTables��6K   $��15��6d   $	��Top=�6p   �� 5/   
   -   5         ��Name$ cbSelectAll��5/      $��1��6(   $��
Select All��68   $��Right=�6M   $��68��6i   $��0,0,10,0q�6t   $��15��6�   $��Bottom=�6�   6�   �� 50   
   $��2��6   $��0��6!   $��Select relations��61   $��10,0,0,0q�6I   $
��Left=�6[   $	��152��6v   $��14��6�   $	��Top=�6�   �� 51   
   -   5        $ lbRelations��51   '   $��10,19,10,10q�6   $��0��6�   $��2��6�   $��2��6�   $ Multiple=�6�   ��6<   �� $ 	Relations�$ PropertyChanged=���52      �� 53      " ��6   .�54      ��  �@��
IsSelected 63   �� $ 	IsChecked�$	 TwoWay=�55      ��58      �� 59      .R�5:      �� $
 
Horizontal=�6!   $��3,3,3,3q�6:   .+�5;      �� $��Center=�5<      $��0,0,4,0q�5=       5;   #   ��  �� " ��$ 
IsSelected�5=      �� 5>      $��Center=�6>   ��6$   �� *
FullName+6>   5?      5@      5B      �� 5C   
   -   5         ��Name$ btImport��5C      $��Import��6#   $��1��64   $��	0,0,10,10q�6D   $��4��6W   $��20��6d   $��Bottom=�6p   {�.  $��Right=�6�   $��75��6�   6�   �� 5D   
   -   5        $ cbSelectAllRelations��5D      $��
Select All��62   $��1��6G   $��0,0,10,0q�6W   $��2��6i   $��Right=�6v   $��68��6�   $��15��6�   $	��Top=�6�   6�   5E      5F      