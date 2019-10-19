using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace theApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RatingPopup : Rg.Plugins.Popup.Pages.PopupPage
	{
        public ImageButton[] imageButtons = new ImageButton[5];

        public RatingPopup ()
		{
			InitializeComponent ();
            imageButtons[0] = btn1;
            imageButtons[1] = btn2;
            imageButtons[2] = btn3;
            imageButtons[3] = btn4;
            imageButtons[4] = btn5;
        }


        private int rating=0;

        private void Btn1_Clicked(object sender, EventArgs e)
        {
            ChangeColors(btn1);
        }
        private void Btn2_Clicked(object sender, EventArgs e)
        {
            ChangeColors(btn2);
        }
        private void Btn3_Clicked(object sender, EventArgs e)
        {
            ChangeColors(btn3);
        }
        private void Btn4_Clicked(object sender, EventArgs e)
        {
            ChangeColors(btn4);
        }
        private void Btn5_Clicked(object sender, EventArgs e)
        {
            
            ChangeColors(btn5);
           
        }

        private void ChangeColors(ImageButton button)
        {
            rating = 0;
            foreach (ImageButton imageButton in imageButtons)
            {
                imageButton.BackgroundColor = Color.Gray;
            }
            
            for (int i = 0; i < int.Parse(button.StyleId); i++)
            {
                rating++;
                imageButtons[i].BackgroundColor = Color.FromRgb(248, 85, 85);
            }
        }

        private   void BtnRate_Clicked(object sender, EventArgs e)
        {
            double ratingPercentage = (((double)rating / 10) * 100)*2;
           //update rating
             PopupNavigation.PopAsync(true);
             Navigation.PushAsync(new HomePage());
        }

        private void BtnCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
            Navigation.PushAsync(new HomePage());
        }
    }
}