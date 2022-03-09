using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Categories:BaseEntity
    {
        public string CategoryName { get; set; }
        public bool IsDeleted { get; set; }
        public string CategoryIcon { get; set; }
    }
}
