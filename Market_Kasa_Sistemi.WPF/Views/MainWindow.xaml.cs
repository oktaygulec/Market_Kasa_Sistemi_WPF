using Market_Kasa_Sistemi.WPF.ViewModels;
using MaterialDesignThemes.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Market_Kasa_Sistemi.WPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ResourceDictionary lightModeDictionary = new ResourceDictionary { Source = new Uri("/Themes/Colors/LightThemeColors.xaml", UriKind.Relative) };
        private readonly ResourceDictionary darkModeDictionary = new ResourceDictionary { Source = new Uri("/Themes/Colors/DarkThemeColors.xaml", UriKind.Relative) };
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            foreach (var item in (DataContext as MainWindowViewModel).Items)
            {
                lstDrawer.Items.Add(item);
            }
        }

        private void DrawerToggleButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ThemeModeToggle_Click(object sender, RoutedEventArgs e)
        {
            if (ThemeModeToggle.IsChecked == true)
            {
                Application.Current.Resources.MergedDictionaries.Remove(lightModeDictionary);
                Application.Current.Resources.MergedDictionaries.Add(darkModeDictionary);
            }
            else if (ThemeModeToggle.IsChecked == false)
            {
                Application.Current.Resources.MergedDictionaries.Remove(darkModeDictionary);
                Application.Current.Resources.MergedDictionaries.Add(lightModeDictionary);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //Application.Current.Shutdown();
        }

        private void lstDrawer_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DrawerToggleButton.IsChecked = false;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
