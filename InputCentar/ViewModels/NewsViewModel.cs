using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InputCentar.Models;

namespace InputCentar.ViewModels
{
   public class NewsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<NewsItem> NewsItems { get; set; }

        public NewsViewModel()
        {
            NewsItems = new ObservableCollection<NewsItem>
            {
                new NewsItem
                {
                    Title = "Title 1",
                    Description = "Description 1",
                    ImageUrl = "image1.jpg",
                    Date = DateTime.Now.ToString()
                },
                new NewsItem
                {
                    Title = "Title 2",
                    Description = "Description 2",
                    ImageUrl = "image2.jpg",
                    Date = DateTime.Now.ToString()
                },
                new NewsItem
                {
                    Title = "Title 3",
                    Description = "Description 3",
                    ImageUrl = "image3.jpg",
                    Date = DateTime.Now.ToString()
                }
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
