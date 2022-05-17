﻿using Market_Kasa_Sistemi.Models;
using Market_Kasa_Sistemi.WPF.ViewModels;
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
    /// Interaction logic for SatisView.xaml
    /// </summary>
    public partial class SatisView : Page
    {
        public SatisView()
        {
            InitializeComponent();
            DataContext = new SatisViewModel();
            dataGridSatislar.Height = Application.Current.MainWindow.ActualHeight - 400;
        }
    }
}
