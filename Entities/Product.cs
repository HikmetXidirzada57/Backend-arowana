using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product:BaseEntity
    {
        [Required(ErrorMessage = " ad hissesi bos ola bilmez!")]
        [MaxLength(100)]

        [Display(Name = "Məhsulun adı")]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Display(Name = "Məhsulun Qiyməti")]
        public decimal Price { get; set; }
        [Display(Name = "Endirim")]
        public decimal Discount { get; set; }
        public int? CoverPhotoId { get; set; }
        public ushort Instock { get; set; }
       
        public bool IsSlider { get; set; }
        public bool IsPopular { get; set; }
        public bool IsBesSelled { get; set; }
        public bool IsDeleted { get; set; }
        [Display(Name = "İstehsal tarixi")]
        public DateTime PublishDate { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int CategoryID { get; set; }
        public virtual Categories? Category { get; set; }
        public virtual List<ProductPicture>? ProductPictures { get; set; }
    }
}
