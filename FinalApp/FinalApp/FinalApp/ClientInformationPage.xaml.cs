using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientInformationPage : ContentPage
    {
        Client _selectedClient;

        public ClientInformationPage(Client selectedClient)
        {
            _selectedClient = selectedClient;
            NavigationPage.SetHasNavigationBar(this, false);          
            InitializeComponent();

            ScreenArea.HeightRequest = App.ScreenHeight;
            ScreenArea.WidthRequest = App.ScreenWidth;

            SetClientData(selectedClient);
        }

        void SetClientData(Client selectedClient)
        {
            //Checking if information is null or empty

            if(selectedClient.Name != null || selectedClient.Name != string.Empty)
                ClientName.Text = "Name: " + selectedClient.Name;
            else
                ClientName.Text = "Name: N/A";

            if(selectedClient.Address != null || selectedClient.Address != string.Empty)
                ClientAddress.Text = "Address: " + selectedClient.Address;
            else
                ClientAddress.Text = "Address: N/A";

            if (selectedClient.TelephoneNumber != null || selectedClient.TelephoneNumber != string.Empty)
                ClientTelephone.Text = "Telephone: " + selectedClient.TelephoneNumber;
            else
                ClientTelephone.Text = "Telephone: N/A";

            if (selectedClient.RegistrationDate != null)
                ClientRegistrationDate.Text = "Registration Date: " + selectedClient.RegistrationDate.ToString();
            else
                ClientRegistrationDate.Text = "Registration Date: N/A";


        }

        //View products button clicked
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProductsPage(_selectedClient));
        }
    }
}