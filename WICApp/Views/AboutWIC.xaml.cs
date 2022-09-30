using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WICApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WICApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutWIC : ContentPage
    {
        //string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");

        public AboutWIC()
        {
            InitializeComponent();

            //// Read the file.
            //if (File.Exists(_fileName))
            //{
            //    editor.Text = File.ReadAllText(_fileName);
            //}
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var notes = new List<Database>();

            // Create a Note object from each file.
            var files = Directory.EnumerateFiles(App.FolderPath, "*.notes.txt");
            foreach (var filename in files)
            {
                notes.Add(new Database
                {
                    Filename = filename,
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                });
            }

            // Set the data source for the CollectionView to a
            // sorted collection of notes.
            collectionView.ItemsSource = notes
                .OrderBy(d => d.Date)
                .ToList();
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            // Navigate to the NoteEntryPage, without passing any data.
            await Shell.Current.GoToAsync(nameof(WICEntryPage));
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the NoteEntryPage, passing the filename as a query parameter.
                Database note = (Database)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(WICEntryPage)}?{nameof(WICEntryPage.ItemId)}={note.Filename}");
            }
        }
    }
}
