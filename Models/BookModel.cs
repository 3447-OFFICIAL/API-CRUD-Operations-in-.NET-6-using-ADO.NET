using System.ComponentModel.DataAnnotations;

namespace assignment_1.Models
{
    public class BookModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Description { get; set; }

        

    }
}
