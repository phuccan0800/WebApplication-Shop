using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationTEST.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name must be 100 Characters ")]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 1000, ErrorMessage ="Display Order must be 1-1000")]
        public int DisplayOrder { get; set; }
    }
}
