using Microsoft.EntityFrameworkCore;
using SQLite;
namespace InputCentar.Models
{
    public class NewsItem
    {
        [SQLite.PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Date { get; set; }
        public string DetailText { get; set; }
    }
}
