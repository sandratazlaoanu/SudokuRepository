   M S B A M L   `   `   `  ���� A  =Sudoku, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Sudoku.ViewModelSudoku.ViewModel      Sudoku.View.Login   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -vmclr-namespace:Sudoku.ViewModel     $	��450��$	��800��  � 	Resources  $  Sudoku.ViewModel.UserViewModel   UserViewModel��%   &	          .���  � DataContext ��  �� Source# [  .+��� $
��Left=�$	��127��$��
537,58,0,0q�$	��Top=�$	��154������  �� ElementName$ userList�� �� Path$ SelectedItem.ImgPath��� -    ��Name$ userList��$
��Left=�$	��227��$��	10,80,0,0q�$	��Top=�$	��296������ *User+ �� View �� .P��� $
��Name�� �� Width$
 Auto�� �� DisplayMemberBinding �� *Name+�� $��SUDOKU��$��45(�
���P��$
��Left=�$��	275,4,0,0q�$	��Top=�$	��201��$��69���� $
��New ��$
��Left=�$��
82,355,0,0q�$	��Top=�$��75������ $ 
NewCommand����� $ userList��$ SelectedItem.Name��� $��Delete��$
��Left=�$��231,355,0,0q�$	��Top=�$��75������ $ DeleteCommand����� $ userList��$ SelectedItem.Name��� $
��Play��$
��Left=�$��422,355,0,0q�$	��Top=�$��74������ $ StartCommand����� $ userList��$ SelectedItem.Name��� -   $
��Exit��$
��Left=�$��616,355,0,0q�$	��Top=�$��75��