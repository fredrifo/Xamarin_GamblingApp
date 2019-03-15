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
    public partial class Games_Dice : ContentPage
    {
        private int playerDice;
        private int opponentDice;

        private bool computing = false;

        private int balance = 150;
        



        public Games_Dice()
        {
            InitializeComponent();
            Credits.Text = "Balance: $" + balance.ToString();
            Title = "Dice";
        }



        private async void Button_ThrowDiceAsync(object sender, EventArgs e)
        {
            try {
                if (computing)
                {
                    return;
                }
                computing = true; //Button is disabled



                //check credit


                int bet = int.Parse(betAmount.Text);

                if (bet > balance) // return
                {
                    computing = false;
                    return;
                }
                Output.Text = "Rolling the dice...";

                //Read and Generate data // 
                Random rand = new Random();
                playerDice = rand.Next(1, 7); //between 1 and 6
                opponentDice = rand.Next(1, 7); //between 1 and 6

                //Animation
                for (int spins = 0; spins < 20; spins++)
                {
                    PlayerDice.Source = "dice" + rand.Next(1, 7) + ".png";
                    OpponentDice.Source = "dice" + rand.Next(1, 7) + ".png";
                    await Task.Delay(100);
                }

                //Present result

                PlayerDice.Source = "dice" + playerDice + ".png";
                OpponentDice.Source = "dice" + opponentDice + ".png";

                if (playerDice < opponentDice)
                {
                    balance -= bet;
                    Output.Text = "You lost $" + bet + ".";
                }

                else if (playerDice > opponentDice)
                {
                    balance += bet;
                    Output.Text = "Congratulations, you Won $" + bet + ".";
                }

                else
                {
                    Output.Text = "It's a tie!";
                }


                Credits.Text = "Balance: $" + balance.ToString(); // printing new balance


                //Enable the button again
                computing = false;

                //<div>Icons made by <a href="https://www.flaticon.com/authors/smashicons" title="Smashicons">Smashicons</a> from <a href="https://www.flaticon.com/" 		    title="Flaticon">www.flaticon.com</a> is licensed by <a href="http://creativecommons.org/licenses/by/3.0/" 		    title="Creative Commons BY 3.0" target="_blank">CC 3.0 BY</a></div>
            }
            catch
            {
                Output.Text = "Fill in amount";
            }
            }

        private void BetAmount_Dice_Focused(object sender, FocusEventArgs e)
        {
            betAmount.Text = "";
            betAmount.HorizontalTextAlignment = TextAlignment.Center;
        }
    }
}