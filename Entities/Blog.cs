using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Blog:BaseEntity
    {
        public string? BlogName { get; set; }
        public string? Author { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string? BlogDescription { get; set; }
        public string? BlogPicture { get; set; }
        public int BlogCategoyID { get; set; }
        public virtual BlogCategory BlogCategory { get; set; }
    }
}
