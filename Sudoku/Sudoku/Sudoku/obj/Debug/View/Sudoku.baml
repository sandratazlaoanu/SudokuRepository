   M S B A M L   `   `   `  ����A  =Sudoku, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Sudoku.ViewSudoku.View  5   	   5clr-namespace:Sudoku.View.TableSudoku.View.Table  5   	   3clr-namespace:Sudoku.ViewModelSudoku.ViewModel  5   	       Sudoku.View.Sudoku   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Sudoku.View     5   	   1viewsclr-namespace:Sudoku.View.Table     5   	   -vmclr-namespace:Sudoku.ViewModel     5   	     � Title$  Sudoku��5
   	   $	��450��6   $��819.2��6%    � 	Resources 5        Sudoku.ViewModel.GameVM 
  GameVM  _9x9 �� DataType   Sudoku.View.Sudoku   Sudoku.View.Table._9x9  _6x6   Sudoku.View.Table._6x6  _4x4   Sudoku.View.Table._4x4��%�   &	        &	      &	 E     &	 w       5   
   6   �� 5   
   "  6$   .R�5        5      �� 5   
   "  6$   .R�5        5      �� 5   
   "  6$   .R�5        5      5      .��5      �  � DataContext 6   ��  �� Source# [  ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFDEFBFF��6    � Offset$ 0.474Q�61   � 5      $ 	#FF35B0C3��6   $ 1Q�61   5      	 � RowDefinitions	 5    
   �� 5!      $��20 �6   6*   �� 5"      6   .+�5%   
   o� 
�������$��0��6"   .@�5&      m� $
��File��6   .@�5'      m� $��New Game��6   
 m� Command
 6-   ��  �� Path$ NewGameCommand�6W   m� 5(      $��	Open Game��6   
 6.   �� $ OpenSaveCommand�6Y   m� 5)      $��	Save Game��6   
 6/   �� $ SaveCommand�6V   m� 5*      $��
Statistics��6   
 6/   �� $ StatisticiCommand�6\   m� 5+      -   5        $
��Exit��5+      6>   5,      m� 5-      $��Options��6   .@�5.      m� $��Standard 9x9��6    m� CommandParameter$ 9��5/   E   
 6   �� $ DimensionCommand�6\   m� 50      $��Custom��6   .@�51      m� $
��4×4��6   $ 4��6W   
 6-   �� $ DimensionCommand�6n   m� 52      $
��6×6��6   $ 6��6W   
 6-   �� $ DimensionCommand�6n   54      55      m� 56      -   5        $��About��56      6<   57      � 58   
   -   5        $��gridSDK��58      $��Right=�6   $��	10,10,0,0q�6<   $��1��6O   $	��Top=�6\   5:      �� 5;   
   -   5        $��
buttonStop��5;   '   $
��Stop��69   $
��Left=�6H   $��193,208,0,0q�6c   $��1��6x   $	��Top=�6�   $��76��6�   �� 5<   
   $��Player��6   $
��Left=�6!   $��0,71,0,0q�6<   $��1��6N   $	��Top=�6[   $��20(�6s   $��Lucida Handwriting)�6�   $
��Bold"�6�   $	��106��6�   ��5=      �� 5>      5@      �� 5A   
   -   5        $��	labelName��5A      $��100,71,579,283q�6!   $��1��69   $��Lucida Handwriting)�6F   $��20(�6f   $
��Nume��5B      $��Italic$�6   �� 5C   
   -   5        $��	labelTime��5C      $��10 : 00��6!   $
��Left=�63   $��
91,130,0,0q�6N   $��1��6b   $	��Top=�6o   $��15(�6�   $��Black"�6�   $��Lucida Handwriting)�6�   $��97��6�   �� 5D   
   -   5        $��buttonStart��5D   (   $��Start��6;   $
��Left=�6K   $��192,176,0,0q�6f   $��1��6{   $	��Top=�6�   $��75��6�   �� 5E   
   -   5        $��buttonCheck��5E   9   $��Check��6L   $
��Left=�6\   $��193,277,0,0q�6w   $��1��6�   $	��Top=�6�   $��76��6�   ��6   �� $ CheckCommand�6�   �� 5F   
   $��Time:��6   $
��Left=�6    $��	0,121,0,0q�6;   $��1��6N   $	��Top=�6[   $��24(�6s   $��Lucida Handwriting)�6�   $��86��6�   �� 5G   
   -	   5        $��
Reset Time��5G   )   $
��Left=�6>   $��192,243,0,0q�6Y   $��1��6n   $	��Top=�6{   $��75��6�   5H      5I      