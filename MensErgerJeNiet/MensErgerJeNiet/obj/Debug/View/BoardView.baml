   M S B A M L   `   `   `  ����  MensErgerJeNiet$    MensErgerJeNiet.View.BoardView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  BoardWindow��5   	    � Title$ 	BoardView��5   	    � SizeToContent$ WidthAndHeight=�6    � 
ResizeMode$ NoResize=�6:   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5
   
   �� 
���  ��$��4q�6#   ._�5      � -   5         �Name$ 
FieldsGrid��5      $��0��6'   ��5      �� 5       �� Color$ #FFFFA6��6&   5      5      � 5   
   -   5        $��TurnView��5      $��1��6   $
��auto��6,   
�������.+�5      �� $��10,0,0,0q�6   .��6&   Aan de beurt:65   �� 5      $��	210,0,0,0q�6   �� 5      $��	130,0,0,0q�6   6)   �� 5      -   5         ��Name$ 	TurnLabel��5      $��	110,0,0,0q�6'   5      5      5      