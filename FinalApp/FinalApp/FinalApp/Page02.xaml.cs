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
	public partial class Page02 : ContentPage
	{
        App _appClass;

		public Page02 (App appClass)
		{
            _appClass = appClass;
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            ScreenArea.HeightRequest = App.ScreenHeight;
            ScreenArea.WidthRequest = App.ScreenWidth;
        }

        private void LogoutButton_Clicked(object sender, EventArgs e)
        {
            _appClass.MainPage = new MainPage(_appClass);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ClientPage());
        }
    }
}