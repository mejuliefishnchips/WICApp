using System;
using System.Collections.Generic;
using WICApp.ViewModels;
using WICApp.Views;
using Xamarin.Forms;

namespace WICApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(WICEntryPage), typeof(WICEntryPage));
            // Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //  Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
