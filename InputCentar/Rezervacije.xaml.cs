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
                new SegmentItem { IconSource = "office.png", Title = "Kancelarije" },
                new SegmentItem { IconSource = "creativity.png", Title = "Kreativnost" },
                  new SegmentItem { IconSource = "cpu.png", Title = "Elektronika" },

                  new SegmentItem { IconSource = "book.png", Title = "Materijali" },
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
    }

    public class SegmentItem
    {
        public string IconSource { get; set; }
        public string Title { get; set; }
    }
}
