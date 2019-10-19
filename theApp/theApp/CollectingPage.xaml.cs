using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
namespace theApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CollectingPage : ContentPage
	{
		public CollectingPage ()
		{
			InitializeComponent ();
            stackContents.HeightRequest = App.ScreenHeight;
            stackContents.WidthRequest = App.ScreenWidth;
            Position iJobAgencyLocation = new Position(-33.019466, 27.915112);

            var pin = new Pin
            {
                Label = "iJob Agency",
                Type = PinType.Place,
                Address = "11 Jameson Street",
                Position = iJobAgencyLocation
            };
          //  customMap.Pins.Add(pin);
        }
     
        


      

        private async  void btGetLocation_Clicked(object sender, EventArgs e)
        {
          
          await NavigateToAgency();
            //try
            //{

               
            //    Position iJobAgencyLocation = new Position(-33.019466, 27.915112);

            //    var pin = new Pin
            //    {
            //        Label = "iJob Agency",
            //        Type = PinType.Place,
            //        Address = "11 Jameson Street",
            //        Position = iJobAgencyLocation
            //    };
            //    customMap.Pins.Add(pin);

            //    try
            //    {
            //        //  await Task.Run(() => stackMap.Children.Add(new Label { Text="helloooooo"}));

            //        //
                   

            //    }
            //    catch (Exception ex)
            //    {
            //        await DisplayAlert("", ex.Message, "");
            //        await DisplayAlert("Map Function", "In App map loading failed, You will be redirected to the default map app,Please return to the app signal your arrival ", "OK");
            //        await NavigateToAgency();
            //    }

            //}
            //catch (Exception ex)
            //{

            //    await DisplayAlert("Map error", ex.Message, "OK");

            //}

        }
        ////////////////////////////////////////////////////////////////////
        public async Task NavigateToAgency()
        {
            var location = new Location(-33.019466, 27.915112);
            
            var options = new MapLaunchOptions { Name = "iJob Agency", NavigationMode = NavigationMode.Driving };
            await Xamarin.Essentials.Map.OpenAsync(location, options);
           
         
        }

        private async void BtnArrived_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new JobInProgressPage());
        }
    }
}