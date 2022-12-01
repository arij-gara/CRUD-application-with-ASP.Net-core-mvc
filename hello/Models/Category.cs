using Microsoft.AspNetCore.Authentication;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace hello.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="display order must be betweeen 1 and 100 only")]
        public int Displayorder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
