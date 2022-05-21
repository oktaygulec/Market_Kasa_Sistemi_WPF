using Market_Kasa_Sistemi.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Kasa_Sistemi.WPF.ViewModels.DialogVMs
{
    public class InformationDialogViewModel : ViewModelBase
    {
        private string _title;
        public string Title 
        {
            get => _title;
            set => SetProperty(ref _title, value); 
        }

        private string _text;
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }
    }
}
