using Market_Kasa_Sistemi.WPF.ViewModels.DialogVMs;
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

namespace Market_Kasa_Sistemi.WPF.Controls.Dialogs
{
    /// <summary>
    /// Interaction logic for InformationDialogView.xaml
    /// </summary>
    public partial class InformationDialog : UserControl
    {
        public InformationDialog(string title, string text)
        {
            InitializeComponent();
            DataContext = new InformationDialogViewModel { Title = title, Text = text };
        }
    }
}
