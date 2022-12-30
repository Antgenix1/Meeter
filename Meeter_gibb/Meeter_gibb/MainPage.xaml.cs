using Meeter_gibb.ViewModels;
using System.Runtime.CompilerServices;

namespace Meeter_gibb
{
    public partial class MainPage : Shell
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}