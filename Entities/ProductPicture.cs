using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProductPicture:BaseEntity
    {
        public int ProductId { get; set; }
        public int PictureId { get; set; }
        public virtual Picture Picture { get; set; }

     
    }
}
