   M S B A M L   `   `   `  ????F  BGameXepHinh, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:GameXepHinhGameXepHinh  5   	       GameXepHinh.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:GameXepHinh     5   	   -   5          ? Title$  GameXepHinh_BTL_C#??5   	   $	??600??6$   $	??800??61   $	??600??5	   	   $	??600??6   
???????$??Segoe UI Light)?5   	   $??28(?6%   .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $??* ?6    ? ColumnDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $
??auto ?6   ?? 5      $??* ?6   ??5   
   ?? 5       ?? ImageSource$ Assets/nen.jpg??6   .+?5   
   (? $??1??6   $??1??5      $??0,0,0,20q?5      .??5       ?? -   5         ??Name$ 
GameCanvas??5       ???#101010$	??250??5"      $	??510??5#      $
}?True??5$      5%      5&      ?? 5(   
   -   5         ??Name$ DiemText??5(      $??0??5)      $??1??5*      $??	Điểm: ??5+      $??0, 10q?5,       ?? TextAlignment$ Center=?5-      ?? 5/   
   $??1??6   $??0??50      $??Center=?51      $??Right=?52      .+?53      ?? $??Đổi??6   $ Center=?54      ?? 56      -   5         ??Name$ 	Doi_Image??56      $??20q?57      $	??125??58      59      ?? 5;   
   $??1??6   $??2??5<      $??Center=?5=      $
??Left=?5>      .+?5?      ?? $??Tiếp Theo??6   $ Center=?5@      ?? 5B      -   5        $ TiepTheo_Image??5B      $??20q?5C      $	??125??5D      5E      ? 5j   
   -   5         ?Name$ GameOverMenu??5j      ???	#CC000000$??2??5l      $??3??5m      $y?Hidden=?5n      .+?5o      ?? $??Center=?6   $??Center=?5p      .+?5q      ?? $??	Game Over??6   $??48(?5r      $ Center=?5s      ?? 5u      -   5        $ DiemCuoiCungText??5u      $??	Điểm: ??5v      $??36(?5w      $ Center=?5x      ?? 5z      -   5        $??Chơi Lại??5z      
???????$??0,20,0,0q?5|      $??5q?5}      5      5?      5?      5?      5?      