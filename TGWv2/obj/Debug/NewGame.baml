   M S B A M L   `   `   `  ����@  <TGWv2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TGWv2TGWv2  5   	       TGWv2.NewGame   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:TGWv2     5   	     � Title$  NewGame��5   	   $	��300��6   $	��470��6&   .��5	      � .+�5
   
   �� -   5         ��Name$ label��5
      $��
Board Size��6   $
��Left=�64   $��	22,56,0,0q�6O   $	��Top=�6b   $��75��6z   �� 5   
   -   5         ��Name$ boardHeightBox��5      $
��Left=�6+   $��
130,56,0,0q�6F   $	��Top=�6Z   $	��120��6r    �� SelectedItem 6   �� *BoardHeight+�� 5   
   -   5        $ boardWidthBox��5      $
��Left=�6*   $��
304,56,0,0q�6E   $	��Top=�6Y   $	��120��6q    6~   �� *
BoardWidth+�� 5   
   -   5        $ label1��5      $��X��6    $
��Left=�6,   $��
267,56,0,0q�6G   $	��Top=�6[   �� 5   
   -   5         ��Name$ UseInfantryCheck��5      $��Infantry��6-   $
��Left=�6b   $��
22,107,0,0q�6}   $	��Top=�6�    d� 	IsChecked 6@   �� *UseInfantry+6�   �� 5   
   -   5        $ numberOfInfantryBox��5      $
��Left=�6R   $��130,107,0,0q�6m   $	��Top=�6�   $	��120��6�   {�60   �� *UseInfantry+ �� SelectedValue 6�   �� *NumberOfInfantry+5      �� 5   
   -   5        $ UseArmoredCar��5      $��Armored Car��6*   $
��Left=�6d   $��
22,160,0,0q�6   $	��Top=�6�    6@   �� *UseArmoredCar+6�   �� 5   
   -   5        $ numberOfArmoredCar��5      $
��Left=�6S   $��130,160,0,0q�6n   $	��Top=�6�   $	��120��6�   {�6/   �� *UseArmoredCar+ 6�   �� *NumberOfArmoredCar+�� 5   
   -	   5        $ UseArtillery��5      $��	Artillery��6)   $
��Left=�6`   $��
22,212,0,0q�6{   $	��Top=�6�    6=   �� *UseArtillery+6�   �� 5   
   -
   5        $ numberOfArtillery��5      $
��Left=�6Q   $��130,212,0,0q�6l   $	��Top=�6�   $	��120��6�   {�6.   �� *UseArtillery+ 6�   �� *NumberOfArtillery+�� 5   
   -   5         ��Name$ startGameButton��5      $��Start��6*   $
��Left=�6:   $��349,187,0,0q�6U   $	��Top=�6j   $��75��6�    �� 	IsDefault . 6�   �� 5   
   -   5        $ cancelButton��5      $��Cancel��6'   $
��Left=�68   $��349,215,0,0q�6S   $	��Top=�6h   $��75��6�   6�   5      5      