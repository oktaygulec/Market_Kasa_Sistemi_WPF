   M S B A M L   `   `   `  ����R  NMarket_Kasa_Sistemi.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:Market_Kasa_Sistemi.WPF.Controls.Dialogs(Market_Kasa_Sistemi.WPF.Controls.Dialogs  5      a5clr-namespace:Market_Kasa_Sistemi.WPF.ValidationRules'Market_Kasa_Sistemi.WPF.ValidationRules  5      9    3Market_Kasa_Sistemi.WPF.Controls.Dialogs.UrunDialog   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Blocal6clr-namespace:Market_Kasa_Sistemi.WPF.Controls.Dialogs  5      Arules5clr-namespace:Market_Kasa_Sistemi.WPF.ValidationRules  5      -   5          >�Name$  
urunDialog��5      $	��300��5      $��Roboto)�5       � Language$ tr-TR�5      .��5      � $��24q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��Ürün Ekle��6    $   MaterialDesignHeadline5TextBlock#��[  5      $
��Bold"�5      $��0 0 0 16q�5      �� 5   
   $��1��6   .+�5      �� -   5         ��Name$ 	txtUrunAd��5#      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Ürün adını giriniz��5        SurfaceColor#���  5        OnSurfaceColor#���  5        BorderColor#���  5         
Foreground# �  5         
Background# �  5        ! MaterialDesignOutlinedTextBox#��[ 5!      $
��0 16q�5"      .��5#   )   ��5$      �� 5%       �� Path$ UrunAd�6    �� UpdateSourceTrigger$ Explicit=�6,   	 �� ValidationRules	 5&      D   >Market_Kasa_Sistemi.WPF.ValidationRules.NotEmptyValidationRule  5'      ,  &System.Windows.Controls.ValidationRule
   ValidatesOnTargetUpdated
 .  6;   5)      .��5*       5+      �� 5,      -   5        $ txtUrunFiyat��54      $= 7Ürün fiyatını giriniz. Virgül (,) ile ayırınız.��5,      #���  5-      #���  5.      #���  5/      # �  50      # �  51      #��[ 52      $
��0 16q�53      .��54   ,   ��55      �� 56      $ 	UrunFiyat�6   $ Explicit=�6/   	 57        58      
 .  6;   E   ?Market_Kasa_Sistemi.WPF.ValidationRules.HasAmountValidationRule  59      
 .  6<   5;      .��5<       5=      �� 5>      -   5        $ txtUrunStokAdet��5F      $ Ürün adeti giriniz��5>      #���  5?      #���  5@      #���  5A      # �  5B      # �  5C      #��[ 5D      $
��0 16q�5E      .��5F   /   ��5G      �� 5H      $ UrunStokAdet�6   $ Explicit=�62   	 5I        5J      
 .  6;     5K      
 .  6<   5M      .��5N       5O      �� 5P       �� DisplayMemberPath$ 
KategoriAd��5Q       " MaterialDesignOutlinedComboBox#��[ 5S      #���  5T      #���  5U      #���  5V      $ Kategori��5W      # �  5X      # �  5Y      $	��260��5Z      $
��0 16q�5[      $
��Left=�5\      ��5P      �� *Kategoriler+ �� SelectedItem 5R      �� *SelectedKategori+5]      �� 5^      $ VergiMiktar��5_      #��[ 5a      #���  5b      #���  5c      #���  5d      $ Vergi Miktar��5e      # �  5f      # �  5g      $	��260��5h      $
��0 16q�5i      $
��Left=�5j      ��5^      �� *
Vergiler+ 5`      �� *SelectedVergi+5k      5l      �� 5m   
    �� Orientation$ 
Horizontal=�6   $��2��5n      $��Bottom=�5o      $��Right=�5p      $��0 32 0 0q�5q      .+�5r      ��   MaterialDesignFlatButton#��[ 5s        PrimaryColor#���  5t      $
��Bold"�5u       �� 	IsDefault . ��5r      �� *
ButtonText+��5w      �� *	OKCommand+��5x      ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$ local:UrunDialogL��� 5y      $��İPTAL��6   #��[ 5z      #���  5{      $
��Bold"�5|       �� IsCancel . $��8 0 0 0q�5~      )  #MaterialDesignThemes.Wpf.DialogHost   CloseDialogCommand#��Z 5      5�      5�      5�      