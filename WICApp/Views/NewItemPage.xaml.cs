using System;
using System.Collections.Generic;
using System.ComponentModel;
using WICApp.Models;
using WICApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WICApp.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}