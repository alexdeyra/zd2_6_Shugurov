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
    public partial class Page4 : ContentPage
    {
        public string dsa="";
        public Page4()
        {
            InitializeComponent();

            
        }

        private async void OnSignInClicked(object sender, System.EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(this.FindByName<Entry>("login").Text)&& string.IsNullOrWhiteSpace(this.FindByName<Entry>("pas").Text))
            {
                await DisplayAlert("Ошибка", "Пожалуйста, введите вашу фамилию", "OK");
                return;
            }
            if (!this.FindByName<CheckBox>("prov").IsChecked)
            {
                await DisplayAlert("Ошибка", "Пожалуйста согласитесь с правилами", "OK");
                return;
            }
            else
            {
                if(this.FindByName<Entry>("login").Text=="ects"&& this.FindByName<Entry>("pas").Text == "ects2024")
                {
                    dsa = this.FindByName<Entry>("login").Text.ToString();
                    await Navigation.PushAsync(new MainPage(this.FindByName<Entry>("login").Text.ToString()));
                    
                }
                else
                {
                    await DisplayAlert("Ошибка", "Не верный пароль", "OK");
                }
            }
            
                
            

           
            
        }
    }
}