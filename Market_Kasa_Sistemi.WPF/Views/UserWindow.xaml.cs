using Market_Kasa_Sistemi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Market_Kasa_Sistemi.WPF.Views
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private readonly ResourceDictionary lightModeDictionary = new ResourceDictionary { Source = new Uri("/Resources/Themes/Colors/LightThemeColors.xaml", UriKind.Relative) };
        private readonly ResourceDictionary darkModeDictionary = new ResourceDictionary { Source = new Uri("/Resources/Themes/Colors/DarkThemeColors.xaml", UriKind.Relative) };

        private readonly ResourceDictionary lightMaterialDictionary = new ResourceDictionary { Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml", UriKind.Absolute) };
        private readonly ResourceDictionary darkMaterialDictionary = new ResourceDictionary { Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml", UriKind.Absolute) };

        public UserWindow(UserWindowType windowType)
        {
            InitializeComponent();
            string frameSource = windowType == UserWindowType.Login 
                ? "/Views/UserViews/LoginView.xaml"
                : "/Views/UserViews/RegisterView.xaml";
            frmUser.Source = new Uri(frameSource, UriKind.Relative);
        }

        private void ThemeModeToggle_Click(object sender, RoutedEventArgs e)
        {
            if (ThemeModeToggle.IsChecked == true)
            {
                Application.Current.Resources.MergedDictionaries.Remove(lightModeDictionary);
                Application.Current.Resources.MergedDictionaries.Remove(lightMaterialDictionary);
                Application.Current.Resources.MergedDictionaries.Add(darkModeDictionary);
                Application.Current.Resources.MergedDictionaries.Add(darkMaterialDictionary);

            }
            else if (ThemeModeToggle.IsChecked == false)
            {
                Application.Current.Resources.MergedDictionaries.Remove(darkModeDictionary);
                Application.Current.Resources.MergedDictionaries.Remove(darkMaterialDictionary);
                Application.Current.Resources.MergedDictionaries.Add(lightModeDictionary);
                Application.Current.Resources.MergedDictionaries.Add(lightMaterialDictionary);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
