using System.ComponentModel;
using WICApp.ViewModels;
using Xamarin.Forms;

namespace WICApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}