   M S B A M L   `   `   `  ���� A  =Sudoku, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Sudoku.ViewSudoku.View  5clr-namespace:Sudoku.View.TableSudoku.View.Table  3clr-namespace:Sudoku.ViewModelSudoku.ViewModel      Sudoku.View.Sudoku   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:Sudoku.View     1viewsclr-namespace:Sudoku.View.Table     -vmclr-namespace:Sudoku.ViewModel       � Title$  Sudoku��$	��450��$��819.2�� � 	Resources   Sudoku.ViewModel.GameVM 
  GameVM  _9x9 �� DataType   Sudoku.View.Sudoku   Sudoku.View.Table._9x9  _6x6   Sudoku.View.Table._6x6  _4x4   Sudoku.View.Table._4x4��%c   &	        &	      &	      &	 )       �� "  .R�  �� "  .R�  �� "  .R�  .���  � DataContext ��  �� Source# [   � RowDefinitions �� $��20 ��� .+�o� 
�������$��0��.@�m� $
��File��.@�m� $��New Game�� m� Command ��  �� Path$ NewGameCommand�m� $��	Open Game�� �� $ OpenSaveCommand�m� $��	Save Game�� �� $ SaveCommand�m� $��
Statistics�� �� $ StatisticiCommand�m� -   $
��Exit��m� $��Options��.@�m� $��Standard 9x9�� m� CommandParameter$ 9�� �� $ DimensionCommand�m� $��Custom��.@�m� $
��4×4��$ 4�� �� $ DimensionCommand�m� $
��6×6��$ 6�� �� $ DimensionCommand�m� -   $��About��� -   $��gridSDK��$
��Left=�$��	10,10,0,0q�$��1��$	��Top=��� -   $��
buttonStop��$
��Stop��$
��Left=�$��708,201,0,0q�$��1��$	��Top=�$��76���� $��
Let's play��$
��Left=�$��
647,10,0,0q�$��1��$	��Top=�$��20(�$��Segoe Print)�$
��Bold"����� �� -   $��	labelName��$
��Left=�$��
639,55,0,0q�$��1��$	��Top=�$��BIZ UDGothic)�$��36(�$
��Bold"�$
��Nume���� -   $��	labelTime��$��4 : 00��$
��Left=�$��708,125,0,0q�$��1��$	��Top=�$��20(�$
��Bold"�$��Impact)�$��76���� -   $��buttonStart��$��Start��$
��Left=�$��612,201,0,0q�$��1��$	��Top=�$��75���� -   $��buttonCheck��$��Check��$
��Left=�$��616,251,0,0q�$��1��$	��Top=�$	��168������ $ CheckCommand��� $��Time :��$
��Left=�$��612,121,0,0q�$��1��$	��Top=�$��24(�$��Impact)�$��71���� -	   $��
Reset Time��$
��Left=�$��660,226,0,0q�$��1��$	��Top=�$��75��