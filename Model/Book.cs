using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace dotnet_entrance_test.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Topic { get; set; }
        public int PublishYear { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public Author? Author { get; set; }
        [DisplayFormat(DataFormatString = "{0:$#,###.##}")]
        public double Price { get; set; } = 0;
        [Range(1, 5)]
        public int Rating { get; set; }
    }
}
