using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FinalApp
{
    public partial class MainPage : ContentPage
    {
        App _appClass;

        string correctUserName = "s";
        string correctPassword = "s";

        public MainPage(App appClass)
        {
            _appClass = appClass;
            InitializeComponent();
           

        }

        private void Login()
        {
            _appClass.MainPage = new NavigationPage(new Page02(_appClass));
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool userNameFilled = false;
            bool passwordFilled = false;

            //Checking which textboxes are empty
            if (UsernameInput.Text != null && UsernameInput.Text != string.Empty)
                userNameFilled = true;
            if (PasswordInput.Text != null && PasswordInput.Text != string.Empty)
                passwordFilled = true;

            //If the username and password textbox contains text
            if(userNameFilled && passwordFilled)
            {
                if(UsernameInput.Text == correctUserName && PasswordInput.Text == correctPassword)
                {
                    //Login
                    Login();
                } else
                    DisplayAlert("Warning", "Username/Password Incorrect", "OK");
            }
            else if (!userNameFilled && !passwordFilled)
                DisplayAlert("Warning", "Please Specify a Username and Password", "OK");

            else if(!userNameFilled)
                DisplayAlert("Warning", "Please Specify a Username", "OK");

            else
                DisplayAlert("Warning", "Please Specify a Password", "OK");
        }
    }
}
