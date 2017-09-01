using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientPage : ContentPage
    {
        //External client collection
        ObservableCollection<Client> clientList = new ObservableCollection<Client>();

        class Context
        {
            public ObservableCollection<Client> ClientCollection { get; set; }
        }


        public ClientPage()
        {
            InitializeComponent();
            //Disables navigation bar
            NavigationPage.SetHasNavigationBar(this, false);

            //Set absolute layout to screen width and height
            ScreenArea.HeightRequest = App.ScreenHeight;
            ScreenArea.WidthRequest = App.ScreenWidth;

            //Populating client list with dummy data
            InsertDummyData();

            //Creating new binding context
            BindingContext = new Context()
            {
                ClientCollection = clientList
            };
           

        }

        void InsertDummyData()
        {
            var products = new ObservableCollection<Product>();

            for (int i = 0; i < 10; i++)
                products.Add(new Product { Name = "Product" + i });

            


                for (int i = 0; i < 10; i++)
                    clientList.Add(new Client()
                    {
                        Name = "Client" + i,
                        Address = "Some Address",
                        TelephoneNumber = RandomGen.RandomNumber.Next(100000, 999999).ToString(),
                        RegistrationDate = DateTime.Now.ToString("d"),
                        Products = products
                    });
        }

        private void ClientList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new ClientInformationPage((Client)ClientList.SelectedItem));
        }
    }
}