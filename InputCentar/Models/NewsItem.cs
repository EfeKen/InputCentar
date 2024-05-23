using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace InputCentar.Models
{
    public class NewsItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Date { get; set; }
    }
}
