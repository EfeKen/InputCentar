using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace InputCentar
{
    public partial class Rezervacije : ContentPage
    {
        public ObservableCollection<SegmentItem> SegmentItems { get; set; }

        public Rezervacije()
        {
            InitializeComponent();

            // Initialize the collection of segment items
            SegmentItems = new ObservableCollection<SegmentItem>
            {
                new SegmentItem { IconSource = "office.png" },
                new SegmentItem { IconSource = "creativity.png" },
                  new SegmentItem { IconSource = "cpu.png"},
                  new SegmentItem { IconSource = "book.png"},
                new SegmentItem { IconSource = "it.png"},
                new SegmentItem { IconSource = "stem.png" },
                // Add more segment items as needed
            };

            // Set the data context to this page (for binding purposes)
            BindingContext = this;
        }

        private void SegmentedControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle selection change logic here
            if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
            {
                var selectedItem = e.CurrentSelection[0] as SegmentItem;
                if (selectedItem != null)
                {
                    // Do something with the selected item
                    // For example, you might navigate to a different page or update the content
                }
            }
        }
        private async void LoadItemList(List<string> items)
        {
            await Navigation.PushAsync(new Kalendar());
        }
        private void IconTapped(object sender, EventArgs e)
        {
            // Handle the tap event here 
            LoadItemList();
        }
        private void Icon1Tapped(object sender, EventArgs e)
        {
            // Handle the tap event here 
            LoadItemList1();
        }
        private void Icon2Tapped(object sender, EventArgs e)
        {
            // Handle the tap event here 
            LoadItemList2();
        }
        private void Icon3Tapped(object sender, EventArgs e)
        {
            // Handle the tap event here 
            LoadItemList3();
        }
        private void Icon4Tapped(object sender, EventArgs e)
        {
            // Handle the tap event here 
            LoadItemList4();
        }
        private void Icon5Tapped(object sender, EventArgs e)
        {
            // Handle the tap event here 
            LoadItemList5();
        }
        private void LoadItemList()
        {
            Default.Children.Clear();

           
            ListView listView = new ListView();
       
            listView.ItemsSource = new List<string> { "Edukacija 1", "Edukacija 2", "Edukacija 3" };

            Default.Children.Add(listView);
        }
        private async void LoadItemList1()
        {
            //Default.Children.Clear();


            // ListView listView = new ListView();

            //listView.ItemsSource = new List<string> { "Knjiga 1", "Knjiga 2", "Knjiga 3" };

            // Default.Children.Add(listView);
            await Navigation.PushAsync(new Kalendar());
        }
        private void LoadItemList2()
        {
            Default.Children.Clear();


            ListView listView = new ListView();

            listView.ItemsSource = new List<string> { "Arduino 1", "Arduino 2", "Arduino 3" };

            Default.Children.Add(listView);
        }
        private void LoadItemList3()
        {
            Default.Children.Clear();


            ListView listView = new ListView();

            listView.ItemsSource = new List<string> { "Kancelarija 1", "Kancelarija 2", "Kancelarija 3" };

            Default.Children.Add(listView);
        }
        private void LoadItemList4()
        {
            Default.Children.Clear();


            ListView listView = new ListView();

            listView.ItemsSource = new List<string> { "Stem 1", "Stem 2", "Stem 3" };

            Default.Children.Add(listView);
        }
        private void LoadItemList5()
        {
            Default.Children.Clear();


            ListView listView = new ListView();

            listView.ItemsSource = new List<string> { "Printer 1", "Printer 2", "Preinter 3" };

            Default.Children.Add(listView);
        }
    }

   


    public class SegmentItem
    {
        public string IconSource { get; set; }
        public string Title { get; set; }
    }
}
