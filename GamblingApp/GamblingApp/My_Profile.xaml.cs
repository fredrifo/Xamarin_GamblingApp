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
    public partial class My_Profile : TabbedPage
    {
        public My_Profile ()
        {
            InitializeComponent();
            Title = "Profile";
        }
    }
}