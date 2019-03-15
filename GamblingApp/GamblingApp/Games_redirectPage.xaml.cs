using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GamblingApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Games_redirectPage : ContentPage
	{
		public Games_redirectPage ()
		{
			InitializeComponent ();
            Title = "Games";
            BackgroundColor = Color.DarkGray;




        }

        void Button_Clicked_Dice(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new Games_Dice());

        }

        void Button_Clicked_BlackJack(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new Games_BlackJack());

        }

        void Button_Clicked_CoinToss(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new Games_redirectPage());

        }
    }
}