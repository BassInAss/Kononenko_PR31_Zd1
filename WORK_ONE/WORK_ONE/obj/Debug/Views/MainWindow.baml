   M S B A M L   `   `   `  ����C  ?WORK_ONE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WORK_ONE.ViewsWORK_ONE.Views  5   	       WORK_ONE.Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WORK_ONE.Views     5   	   -   5          � WindowState$  	Maximized=�5       � Title$ Окно услуг��5   	   $	��768��6   $
��1366��6)    � Icon$. (/Resourses/Images/DesignWindows/logo.png��5	   "    � 	Resources 5
       �� Source�� 5   
   $, &/Resourses/Styles/MainWindowStyle.xaml?�6   %    .��5      �  � RowDefinitions 5   
   �� 5      $��0.12* �6   �� 5      �� 5      $
��0.1* �6   .+�5   
   �� $��Список услуг��6   $��Center=�6'   $��Bottom=�6D      H2#��[  6_   $��0 0 0 40q�6{   �� 5   
    �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ AddServiceButton��5      $#��Добавить услугу��6P     AddButtonStyle#��[ 6j   $��5q�6�   $��Bottom=�6�   $
��Left=�6�   �� 5      -   5        $ CloseClientToService��5      $%��Ближайшие записи��6X   #��[ 6s   $��5q�6�   $��Bottom=�6�   $
��Left=�6�   5      �� 5   
   $ 
Horizontal=�6   $��Right=�6.   $��0 0 10 5q�6J   .+�5      �� $ ��Фильтр скидки:��6     NameProductLabelStyle#��[ 6-   $��Bottom=�6\   $��20 0 0 0q�6w   �� 5      -   5         ��Name$ DiscountComboFilter��5       
 Filter#��[ 6l   $��0q�6�   ��5      �� 5      .R�5      ��   
FilterItem#��[ 6    ��6E   �� 5      5       �� 5!      $ 
Horizontal=�6   .+�5"      �� $��Поиск:��6   #��[ 6)   $��Bottom=�6X   $��Right=�6s   $��20 0 0 0q�6�   �� 5#        BorderTextArea#��[ 6   $��Bottom=�6A   ._�5$      �� -   5        	 ��Name$
	 Find��5$   J   6X   5%      5&      �� 5'      -   5        
 ��Name$
 	SortLabel��5'   r   $.��(Сортировать по цене ↓��6     	SortLabel#��[ 64   $��Bottom=�6W   6�   5(      �� 5)   
   -   5        $
 ISADMIN��5)      $y�	Collapsed=�6!   �� 5*   
   -   5        $
 NoFind��5*   `   $��1��6   $(��"Ничего не найдено..��6   $��18(�6;   
�����p�$y�	Collapsed=�6p   $��	60 60 0 0q�6�   �� 5+   
   -	   5         ��Name$ 	list_serv��5+      $��1��6%   
������ 
������ ��5,      �� 5-       �� 
TargetType" ��6   .�5.      ��  �� Property � �� �� Value 5/      �� 50       �� 
TargetType" ��6.   .R�51   "   �� 52      54      55      ��57      �� 58      .R�59      ��   BorderElement#��[ 6   ��6D   �� *
Discount+  DiscountConverterBackground �� 	Converter# [ ._�5:      �� $ 
Horizontal=�6%   .+�5;      ��  	 BorderImage#��[	 6%   ._�5<   "   �� ��6(   �� *MainImagePath+5=      �� 5>      $��	50 10 0 0q�6)   .+�5?   "   �� #��[ 6B   ��6(   �� *Title+6B   �� 5@   "   $ 
Horizontal=�6-   .+�5A   &   ��  
 TextBlockProductStyle#��[
 6�   ��60   �� *Cost+��6F   �� *
Discount+  StrikelineConverter# [ 6�   �� 5B   &   $��рублей��6,   #��[ 6=   �� 5C   &   $��за ��6,   #��[ 6:   �� 5D   &   #��[ 6R   ��6,   �� *DurationInSeconds+6R   �� 5E   &   $��
минут��6,   #��[ 6<   5F   #   �� 5G   "     DiscountText#��[ 6z   y�6,   �� *
Discount+  DiscountConverter# [ ��5H   &   `� 5I   *     DiscountConverterProcess `� 	Converter# [ 67   .1�5J   .   ��  �� Path$ Discount�66   �� 5K   .   $
 Cost�66   5L   +   5N   #   �� 5O   "   $ 
Horizontal=�6-   $��0 90 0 0q�6F   .+�5P   &   �� $
 ChangeButton��6E   -
   5        $ ��Редактировать��5P   ,     ButtonsStyle#��[ 6�   �� 5Q   &   $
 DeleteButton��6>   -   5        $��Удалить��5Q   ,   #��[ 6�   �� 5R   &   $
 AddClientToService��6G   -   5        $%��Записать клиента��5R   ,   #��[ 6�   5S   #   5T      5U      5V      5W      5Y      �� 5Z   
   ���#e1e4ff$��2��6*   .+�5[      �� -   5        $
 CountService��5[   8   $0��*Выведено 0 записей из 100��6   #��[ 6N   $��Right=�6}   5\      5]      5^      