using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Market_Kasa_Sistemi.WPF.ValidationRules
{
    public class HasAmountValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            // Virgül ile giriş yapılmalı
            // Nokta ile giriş yapıldığında integer değer return ediyor
            bool isNumber = decimal.TryParse(value.ToString(), out decimal newValue);

            if (!isNumber) return new ValidationResult(false, "Sadece sayı girişi yapılmalı.");

            return newValue > 0 
                ? ValidationResult.ValidResult 
                : new ValidationResult(false, "Değer 0'dan büyük olmalı.");
        }
    }
}
