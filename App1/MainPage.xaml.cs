using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : TabbedPage
    {
        public string name = "";
        public MainPage(string nn)
        {
            InitializeComponent();
            name = nn;
           
           
        }
    }
}
