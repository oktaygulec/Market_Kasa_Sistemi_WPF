using Market_Kasa_Sistemi.Models;
using Market_Kasa_Sistemi.WPF.Controls.Dialogs;
using Market_Kasa_Sistemi.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Market_Kasa_Sistemi.WPF.ViewModels.DialogVMs
{
    public class DeleteItemDialogViewModel : ViewModelBase
    {
        public IModel Item { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public ICommand DeleteCommand { get; set; }
    }
}
