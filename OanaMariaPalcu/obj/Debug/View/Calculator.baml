   M S B A M L   `   `   `  ����I  EOanaMariaPalcu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:OanaMariaPalcuOanaMariaPalcu  5   	   C&clr-namespace:OanaMariaPalcu.ViewModelOanaMariaPalcu.ViewModel  5   	       OanaMariaPalcu.Calculator   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:OanaMariaPalcu     5   	   <	ViewModel&clr-namespace:OanaMariaPalcu.ViewModel     5   	     � Title$  
Calculator��5	   	   $	��200��6   $	��400��6)    � Icon$. (/OanaMariaPalcu;component/calculator.ico��65    � DataContext 5
      2   ,OanaMariaPalcu.ViewModel.CalculatorViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� $��0��6   ��6'   �� *Expression.Val1+ �� UpdateSourceTrigger$ PropertyChanged=��� 5      $��1��6   ��6'   �� *Expression.Val2+$ PropertyChanged=�5      �� 5   
   $��1��6    �� 
IsReadOnly . ��6    �� *Expression.Result+$ PropertyChanged=�6h   � 5   
   $��2��6    5      �� 5       $��* �6#   �� 5!      $��* �6#   �� 5"      $��* �6#   �� 5#      $��* �6#   .+�5%      �� $��+��6   $��0��6!   ��61   �� *
AddCommand+�� 5&      $��-��6   $��1��6!   ��61   �� *
SubCommand+�� 5'      $��x��6   $��2��6!   ��61   �� *
MulCommand+�� 5(      $��:��6   $��3��6!   ��61   �� *
DivCommand+5)      �� 5*   
   $��Reset��6   $��3��6!   ��6.   �� *ResetCommand+�� 5+   
   $��Adaugare functie��6   $��4��6,   ��69   �� *AdaugareFunctieCommand+5,      5-      