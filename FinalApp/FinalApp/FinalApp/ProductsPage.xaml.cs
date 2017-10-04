using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : ContentPage
    {
        class Context
        {
            public ObservableCollection<Product> ProductCollection;
        }

        
        public ProductsPage(Client selectedClient)
        {  
            InitializeComponent();
            ScreenArea.HeightRequest = App.ScreenHeight;
            ScreenArea.WidthRequest = App.ScreenWidth;
            NavigationPage.SetHasNavigationBar(this, false);

            /*
            BindingContext = new Context()
            {
                ProductCollection = selectedClient.Products
            };
            */


        }
    }
}