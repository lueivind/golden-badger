   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 (  $TreeViewItem.TreeArrow.Static.Stroke  �� Color & "TreeViewItem.TreeArrow.Static.Fill + 'TreeViewItem.TreeArrow.MouseOver.Stroke ) %TreeViewItem.TreeArrow.MouseOver.Fill 0 ,TreeViewItem.TreeArrow.Static.Checked.Stroke . *TreeViewItem.TreeArrow.Static.Checked.Fill 3 /TreeViewItem.TreeArrow.MouseOver.Checked.Stroke 1 -TreeViewItem.TreeArrow.MouseOver.Checked.Fill  	TreeArrow E� IsFilled E� 
StartPoint E� IsClosed �� Point 	 ExpandCollapseToggleStyle �� 
TargetType �� Property �� Value �� 
TargetType	 �� Padding
 F�Name �� Angle �� CenterX �� CenterY �� Triggers P� Property P� Value �� 
TargetName ]� 
Conditions �� Property �� Value 
 TreeViewItemFocusVisual  ExplorerItem �� Path �� RelativeSource �� AncestorType � ColumnDefinitions � RowDefinitions d�Name �� 	ClickMode d� 	IsChecked J� SnapsToDevicePixels ��Name ��Name  P� 
SourceName ! treeviewitem-background-hover $  treeviewitem-background-selected! �� Triggers  StructureExplorerItemHeight�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      1system&clr-namespace:System;assembly=mscorlib  5      %  &	        &	 #     &	 F     &	 i     &	 �     &	 �     &	 �     &	 �     &	     &		 �    7  7   7  7  7  7  7  7  7  &	
 i    &	 �    7 
 7 	 7  7  &	 C    �� 5      $  	#FF818181��6C   �� 5      $  	#FFFFFFFF��6A   �� 5      $  	#FF27C7F7��6F   �� 5      $  	#FFCCEEFB��6D   �� 5	      $  	#FF262626��6K   �� 5
      $  	#FF595959��6I   �� 5      $  	#FF1CC4F7��6N   �� 5      $  	#FF82DFFB��6L   B� 5      ��5      D� E� 5       . $	 0 0&�5       . ��5      @� �� 5      $	 0 6&�6*   �� 5      $	 6 0&�6*   5      5      5      5      �� 5       " d�6.   .�5!   
   ��  � |� .  6&   �� 5"   
    � ��$ 16��6"   �� 5#   
    � ��$ 16��6#   �� 5$   
    � �� 5%      �� 5&      " d�6"   .R�5'      �� $��16��6   $��16��5(      
������ $	 5,5,5,5q�5*      ._�5+      F� $
 
ExpandPath��6   8��  8�� 8�� z�5/      �� 50   "   $	 135Q�62   $ 3Q�51   2   $ 3Q�52   2   54      55       56      P� 57       �@d�	IsChecked$
 TrueY�67   . �58      �� $ 
ExpandPath��6%    � z� 59   "   �� 5:   &   $	 180Q�66   $ 3Q�6B   $ 3Q�6N   5<      �� 5=      $ 
ExpandPath��6%   8   � ��6M   �� 5>      $ 
ExpandPath��6%   8   � ��6O   5?      P� 5@       �@J�IsMouseOver . . �5B      �� $ 
ExpandPath��6%   8   � ��5D   %   �� 5E      $ 
ExpandPath��6%   8   � ��5G   %   5H      ]� 5I       5J      �� 5K   "    �@J�IsMouseOver . 6C   �� 5L   "    �@d�	IsChecked$
 TrueY�6A   ./�5N      �� $ 
ExpandPath��6%   8   � ��5P   %   �� 5Q      $ 
ExpandPath��6%   8   � ��5S   %   5T      5V      5X      5Y      �� 5[      .�5\   
   ��  � �� 5]      �� 5^      .R�5_      �� 5`      5b      5c      �� 5f      " Q�6!   .�5g   
   ��  � ��
 ���� 6'   �� 5h   
    � �� 67   �� $  HorizontalContentAlignment� �� " ���� 5i   
    � �� 65   �� $ VerticalContentAlignment� �� " ���� 5j   
    � ��$ 1,0,0,0q�6$   �� 5k   
    � ��# � ��6'   �� 5l   
    �@�FocusVisualStyle8   6-   �� 5m   
    � �� 5n      �� 5o      " Q�6"   .R�5p      �  5q      �� 5r      $��19��6/   $
��Auto �6=   �� 5s      $��* �6/    5u      �� 5v      $
��Auto �6,   �� 5w      .+�5y      d� $ Expander��6'   8�� $ Press=�5{   7    5z   7   �� $ 
IsExpanded� �� *TemplatedParent+5{   7   �� 5|      $��Bd��6!   $��1��5}   1   #��z��5~   1   #��z��5   1   #��z��5�   1   #	 z��5�   1    . ._�5�      �� $ PART_Header��6/   $��Header��5�   /   #��z��5�   /   # z 5�   /   5�      �� 5�      $ 	ItemsHost��6)   $��Stretch=�6<   $��1��5�   )   $��1��5�   )   5�       5�      P� 5�       �@Q�
IsExpanded .  . �5�      �� $ 	ItemsHost��6%    � y�$ 	Collapsed=�6R   5�      P� 5�       �@��HasItems .  . �5�      �� $ Expander��6%    � y�$ Hidden=�6Q   5�      P� 5�      $  Bd��6F    �@J�IsMouseOver . . �5�      �� 8   � ��6;   5�      P� 5�       �@Q�
IsSelected . . �5�      �� 8   � ��6;   5�      ]� 5�       5�      �� 5�   "    �@Q�
IsSelected . 6B   �� 5�   "    �@Q�IsSelectionActive .  6I   ./�5�      ��  6;   �� *
Background+ �� " �� � ��5�      P� 5�       � {� .  . �5�      �� # � ��6;    � ��5�      5�      5�      ! 5�   
   P� 5�       �@%�IsVirtualizing . . �5�      ��  � �� 5�      �� 5�      .R�5�      $� 5�      5�      5�      5�      X�5�      25Q�6<   5�      