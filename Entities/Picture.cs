using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Picture : BaseEntity
    {
        [MaxLength(650)]
        public string Url { get; set; }
    }
}