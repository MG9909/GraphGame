   M S B A M L   `   `   `  ����B  >WpfApp4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp4WpfApp4  5   	       WpfApp4.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp4     5   	   -   5        $
��wind��5   	     � Title$  
MainWindow��5   	    � WindowState$ 	Maximized=�5	   	    � WindowStyle$
 None=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   $	��906��6.   $
��1607��6;   ��5      �� 5   
   -   5        bg�� j� Stretch$ UniformToFill=�5   !    j� TileMode$
 None=�69   .��5      � -   5        $��parent��5      .+�5   
   � -   5        $��over_screen��5      .+�5      r� -   5        $��over_gif��5      $��87,90,75,72q�6+    J� Opacity$ 0Q�6A    r� LoadedBehavior$ Manual=�6M   6g   5      � 5   
   -   5         �Name$
 main��5      	 J� RenderTransformOrigin$	 
0.477,0.49&�6   $	��898��6@   $	��Top=�6M   .+�5      � $��0,0,0,49q�6   .+�5      �� -   5        $��border1��5       
���  ��$
��Left=�5      $	��Top=�5      $��	38,13,0,0q�5      $	��309��5      $	��301��5      $��3q�5      
 �� CornerRadius$
 5��5       J� Effect 5"      -  'System.Windows.Media.Effects.BlurEffect  5#         Radius$ 1Q�6%   ��5%      �� 5&       �� Opacity$	 0.5Q�5'      -   5        
intro2��5(      ._�5*      �� -	   5        $	��st1��5*   4   $��	-1,-3,0,0q�6!   $��Bottom=�6?   .+�5,      �� -
   5        $��
player1_hp��5,   A   $��Center=�6$   $��100/100��5-       
���  ��$��20(�5/       $��Oblique$�50       � 52      -   5         �Name$ player1��52   X    � Minimum$ 0Q�6&    � Maximum$	 100Q�62    � Value$	 100Q�6@   $��29��6L   6X   53      54      56      � 58      $��0,0,0,10q�6   .+�59      �� 
����  �$
��Left=�5:      $	��Top=�5;      $��1264,10,0,0q�5<      $	��309��5=      $	��301��5>      $��3q�5?      $
 5��5@       5A        5B      $ 1Q�6%   ��5D      �� 5E      $	 0.5Q�5F      -   5        	intro��5G      ._�5I      �� -   5        $	��st2��5I   4   $��	0,-3,-1,0q�6!   $��Bottom=�6?   .+�5J      �� -   5        $��
player2_hp��5J   B   $��Center=�6%   $��100/100��5K       
���  ��$��20(�5M       $��Oblique$�5N       � 5P      -   5        $ player2��5P   X   $ 0Q�6&   $	 100Q�62   $	 100Q�6@   $��29��6L   6X   5Q      5R      5S      5T      5U      5V      