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
    public partial class Page2 : ContentPage
    {
        public string CurrentDate { get; set; }
        public Page2()
        {
            InitializeComponent();
            CurrentDate = DateTime.Now.ToString(); 
            BindingContext = this;
            /*var lt = this.FindByName<DatePicker>("CurrentDatePicker");
            lt.Date = DateTime.Now;*/
        }
    }
}