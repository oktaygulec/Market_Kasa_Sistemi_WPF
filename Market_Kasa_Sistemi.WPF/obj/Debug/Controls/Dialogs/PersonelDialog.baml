   M S B A M L   `   `   `  ����R  NMarket_Kasa_Sistemi.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Market_Kasa_Sistemi.WPF.ValidationRules'Market_Kasa_Sistemi.WPF.ValidationRules  5      c6clr-namespace:Market_Kasa_Sistemi.WPF.Controls.Dialogs(Market_Kasa_Sistemi.WPF.Controls.Dialogs  5      =    7Market_Kasa_Sistemi.WPF.Controls.Dialogs.PersonelDialog   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Arules5clr-namespace:Market_Kasa_Sistemi.WPF.ValidationRules  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      Blocal6clr-namespace:Market_Kasa_Sistemi.WPF.Controls.Dialogs  5      -   5          >�Name$  personelDialog��5      $	��300��5      $��Roboto)�5       � Language$ tr-TR�5      .��5      � $��24q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��Personel Ekle��6    $   MaterialDesignHeadline5TextBlock#��[  5      $
��Bold"�5      $��0 0 0 16q�5      �� 5   
   $��1��6   .+�5      �� -   5         ��Name$ txtPersonelAd��5#      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Personel adını giriniz��5        SurfaceColor#���  5        OnSurfaceColor#���  5        BorderColor#���  5         
Foreground# �  5         
Background# �  5        ! MaterialDesignOutlinedTextBox#��[ 5!      $
��0 16q�5"      .��5#   -   ��5$      �� 5%       �� Path$ 
PersonelAd�6    �� UpdateSourceTrigger$ Explicit=�60   	 �� ValidationRules	 5&      D   >Market_Kasa_Sistemi.WPF.ValidationRules.NotEmptyValidationRule  5'      ,  &System.Windows.Controls.ValidationRule
   ValidatesOnTargetUpdated
 .  6;   5)      .��5*       5+      �� 5,      -   5        $ txtPersonelSoyad��54      $! Personel soyadını giriniz��5,      #���  5-      #���  5.      #���  5/      # �  50      # �  51      #��[ 52      $
��0 16q�53      .��54   0   ��55      �� 56      $ PersonelSoyad�6   $ Explicit=�63   	 57        58      
 .  6;   5:      .��5;       5<      (  "System.Windows.Controls.DatePicker  5=      -   5          Name$! datePickerPersonelBaslangic��5E      $# Başlangıç tarihini giriniz��5=      #���  5>      #���  5?      #���  5@      # �  5A      # �  5B       $  MaterialDesignOutlinedDatePicker#��[ 5C      $
��0 16q�5D         SelectedDate 5F      �� 5G      $ PersonelBaslangicTarih�6   $ Explicit=�6<   	 5H        5I      
 .  6;   5K      5M      �� 5N       �� DisplayMemberPath$ PersonelTipAd��5O       " MaterialDesignOutlinedComboBox#��[ 5Q      #���  5R      #���  5S      #���  5T      $ Personel Tip��5U      # �  5V      # �  5W      $	��260��5X      $
��0 16q�5Y      $
��Left=�5Z      ��5N      �� *PersonelTipler+ �� SelectedItem 5P      �� *SelectedPersonelTip+5[      5\      �� 5]   
    �� Orientation$ 
Horizontal=�6   $��2��5^      $��Bottom=�5_      $��Right=�5`      $��0 32 0 0q�5a      .+�5b      ��   MaterialDesignFlatButton#��[ 5c        PrimaryColor#���  5d      $
��Bold"�5e       �� 	IsDefault . ��5b      �� *
ButtonText+��5g      �� *	OKCommand+��5h      ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$ local:PersonelDialogL��� 5i      $��İPTAL��6   #��[ 5j      #���  5k      $
��Bold"�5l       �� IsCancel . $��8 0 0 0q�5n      )  #MaterialDesignThemes.Wpf.DialogHost   CloseDialogCommand#��Z 5o      5p      5q      5r      