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
    public partial class HamburgerMenu : MasterDetailPage
    {
        public HamburgerMenu()
        {
            InitializeComponent();
            MyMenu();
        }

        public void MyMenu()
        {
            var nav = new NavigationPage();
            nav.PushAsync(new Games_redirectPage());
           // nav.BarBackgroundColor = Color.Black;
           // nav.BarTextColor = Color.White;

            Detail = nav;

           // Detail = new NavigationPage(new Games_redirectPage()); //Homepage
            

            List<Menu> menu = new List<Menu> { 
                //Create menu items
                new Menu {Page = new Games_redirectPage(), MenuTitle = "Games", MenuDetail = "Choose game", icon = "gamepad.png"},
                new Menu {Page = new My_Profile(), MenuTitle = "My Profile", MenuDetail = "Details", icon = "gamepad.png"},
                new Menu {Page = new About(), MenuTitle = "About", MenuDetail = "About us", icon = "gamepad.png"},
            };
            ListMenu.ItemsSource = menu;
        }

        private void HamburgerMenu_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as Menu;
            if (menu != null)
            {
                IsPresented = false;
                Detail = new NavigationPage(menu.Page);
                
                
            }
        }

        public class Menu
        {
            public string MenuTitle
            {
                get;
                set;
            }

            public string MenuDetail
            {
                get;
                set;
            }

            public ImageSource icon
            {
                get;
                set;
            }

            public Page Page
            {
                get;
                set;
            }
        }
    }
}