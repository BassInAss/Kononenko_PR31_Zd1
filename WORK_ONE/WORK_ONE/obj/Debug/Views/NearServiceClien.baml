   M S B A M L   `   `   `  ����C  ?WORK_ONE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WORK_ONE.ViewsWORK_ONE.Views  5   	   %    WORK_ONE.Views.NearServiceClien   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WORK_ONE.Views     5   	   -   5          � WindowState$  	Maximized=�5       � Title$% Ближайшие записи��5   	   $	��768��6"   $
��1366��6/    � Icon$. (/Resourses/Images/DesignWindows/logo.png��5	   	    � 	Resources 5
       �� Source�� 5   
   $, &/Resourses/Styles/MainWindowStyle.xaml?�6   %    .��5      �  � RowDefinitions 5   
   �� 5      $��0.12* �6   �� 5      �� 5      $
��0.1* �6   .+�5   
   �� $4��.Список ближайших записей��6   $��Center=�63   $��Bottom=�6P      H2#��[  6k   $��0 0 0 40q�6�   �� 5   
    �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ TodayButton��5   '   $��Сегодня��6     NearButtons#��[ 6V   $��5q�6{   $��Bottom=�6�   $
��Left=�6�   {�.  6�   �� 5      -   5        $ TomorrowButton��5   &   $��Завтра��6   #��[ 6[   $��5q�6�   $��Bottom=�6�   $
��Left=�6�   �� 5      -   5        $ 	AllButton��5   *   $��Все записи��6   #��[ 6U   $��5q�6z   $��Bottom=�6�   $
��Left=�6�   5      �� 5   
   -   5         ��Name$ 	list_serv��5      $��1��6%   
������ 
������ ��5      �� 5      	 �� 
TargetType"	 ��6   .�5      �� 
 �� Property
 � �� �� Value 5      �� 5       �� 
TargetType" ��6.   .R�5   "   �� 5       5"      5#      ��5%      �� 5&      .R�5'      ��   BorderElement#��[ 6   ._�5(      �� $ 
Horizontal=�6%   .+�5)      �� $��	50 10 0 0q�6)   .+�5*   "   ��   NameProductLabelStyle#��[ 6X   $
��Bold"�6�   ��6(   �� *clientService.Service.Title+6�   �� 5+   "   $��10 0 0 0q�6-   .+�5-   "   �� $ 
Horizontal=�6-   .+�5.   &   �� $��ФИО:��6,   #��[ 6;   �� 5/   &   #��[ 6_   $��0q�6�   ��6,   �� * clientService.Client.FirstName+6�   �� 50   &   #��[ 6^   $��0q�6�   ��6,   �� *clientService.Client.LastName+6�   �� 51   &   #��[ 6`   $��0q�6�   ��6,   �� *!clientService.Client.Patronymic+6�   52   #   �� 53   "   $ 
Horizontal=�6-   .+�54   "   �� $��E-mail адресс:��6(   #��[ 6A   �� 55   &   #��[ 6[   $��0q�6�   ��6,   �� *clientService.Client.Email+6�   56   #   �� 57   "   $ 
Horizontal=�6-   .+�58   "   �� $#��Номер телефона: ��6(   #��[ 6C   �� 59   &   #��[ 6[   $��0q�6�   ��6,   �� *clientService.Client.Phone+6�   5:   #   �� 5;   "   $ 
Horizontal=�6-   .+�5<   "   �� $��Дата записи:��6(   #��[ 6?   �� 5=   &   #��[ 6J   $��0q�6y   ��6,   �� *	shortdate+6y   5>   #   �� 5?   "   $ 
Horizontal=�6-   .+�5@   &   �� $��Время записи:��6,   #��[ 6D   �� 5A   &    �� ContentStringFormat$ h:��6E   #��[ 6^   $��0q�6�   ��6,   �� *time+6�   5B   #   �� 5C   &   $ 
Horizontal=�61   y�6J   �� *clientService.StartTime+  TodayConverter �� 	Converter# [ .+�5D   *   �� $#��Время до начала:��60   #��[ 6K   ��6z   �� *timetostart+  LessOneHourDate# [ �� 5E   *   #��[ 6P   $��0q�6   ��60   �� *timetostart+��6�   �� *timetostart+# [ 5F   '   5G   #   5H      5I      5J      5K      5M      5O      5P      