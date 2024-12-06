using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
      
        public Page1()
        {
            InitializeComponent();
        }

      


        private void CalculateButton_Clicked(object sender, System.EventArgs e)
        {
            
            var mp = this.FindByName<Label>("MonthlyPaymentLabel");
            var ta = this.FindByName<Label>("TotalAmountLabel");
            var ol = this.FindByName<Label>("OverpaymentLabel");
            var la= this.FindByName<Entry>("LoanAmountEntry");
            var lt= this.FindByName<Entry>("LoanTermEntry");
            var ptp= this.FindByName<Picker>("PaymentTypePicker");
            var irs= this.FindByName<Slider>("InterestRateSlider");
            int pp = Convert.ToInt32(la.Text.ToString());
            int pp1 = Convert.ToInt32(lt.Text.ToString());
            if (pp > 0 && pp1 > 0)
            {
                if (double.TryParse(la.Text, out double loanAmount) &&
               int.TryParse(lt.Text, out int loanTerm) &&
               ptp.SelectedIndex == 0)
                {
                    double annualRate = irs.Value / 100;
                    double monthlyRate = annualRate / 12;


                    double monthlyPayment = loanAmount * monthlyRate / (1 - System.Math.Pow(1 + monthlyRate, -loanTerm));
                    double totalAmount = monthlyPayment * loanTerm;
                    double overpayment = totalAmount - loanAmount;


                    mp.Text = monthlyPayment.ToString("F2");
                    ta.Text = totalAmount.ToString("F2");
                    ol.Text = overpayment.ToString("F2");
                }
                else if (ptp.SelectedIndex == 1)
                {

                    int aa = Convert.ToInt32(la.Text.ToString());
                    double annualRate = irs.Value / 100;
                    double monthlyRate = annualRate / 12;
                    double totalAmount = 0;
                    double overpayment = 0;

                    for (int month = 1; month <= aa; month++)
                    {
                        double principalPayment = loanAmount / aa;
                        double interestPayment = (loanAmount - (principalPayment * (month - 1))) * monthlyRate;
                        double monthlyPayment = principalPayment + interestPayment;

                        totalAmount += monthlyPayment;
                        overpayment += interestPayment;
                    }

                    mp.Text = "...";
                    ta.Text = totalAmount.ToString("F2");
                    ol.Text = overpayment.ToString("F2");
                }
                else
                {
                    DisplayAlert("Ошибка", "Пожалуйста, заполните все поля корректно", "OK");
                }
            }
            else
            {
                DisplayAlert("Ошибка", "Пожалуйста, заполните все поля корректно", "OK");
            }





        }
    }
}