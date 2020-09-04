using Appagar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Appagar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BillsPage : ContentPage
    {
        public BillsPage()
        {
            InitializeComponent();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}