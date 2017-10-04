using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace FinalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientPage : ContentPage
    {

        bool isBusy = false;

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


            //Creating new binding context
            BindingContext = new Context()
            {
                ClientCollection = clientList
            };

            Client clientObject = new Client()
            {
                Name = "Matthew",
                MainContact = "015893029",
                RegistrationDate = "26/03/16",
                TelephoneNumber = "739603",
                Id = 1,
                Address = "SomeStreet 1234"
            };

            PostClient(clientObject);

            AddClient(1);



        }

        async void PostClient(Client clientInput)
        {
            await PostData(clientInput);
        }

        async void AddClient(int inputId)
        {
           Client client = await GetData(inputId);
            clientList.Add(client);

        }

        async Task PostData(Client clientObject)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var jsonObj = JsonConvert.SerializeObject(clientObject);
                    var content = new StringContent(jsonObj, Encoding.UTF8, "application/json");
                    await client.PostAsync("Http://scs-site1.gdproof.co.uk/api/postmattsdata", content);
                }
            }
            catch
            {

            }



        }


        async Task<Client> GetData(int inputId)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    Client obtainedClient;

                    var response = await httpClient.GetAsync("Http://scs-site1.gdproof.co.uk/api/getmattsdatabyid/" + inputId);
                    var content = await response.Content.ReadAsStringAsync();

                    obtainedClient = JsonConvert.DeserializeObject<Client>(content);

                    return obtainedClient;
                }
            }
            catch
            {
                return null;
            }

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
                        TelephoneNumber = "584950494849",
                        RegistrationDate = DateTime.Now.ToString("d")
                    });
        }

        protected override void OnAppearing()
        {
            isBusy = false;
            base.OnAppearing();
        }
        private void ClientList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(!isBusy)
            {
                isBusy = true;
                Navigation.PushAsync(new ClientInformationPage((Client)ClientList.SelectedItem));            
            }

            
        }
    }
}