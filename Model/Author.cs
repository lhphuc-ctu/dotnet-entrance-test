using System.ComponentModel.DataAnnotations;

namespace dotnet_entrance_test.Model
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool Female { get; set; }
        public int Born { get; set; }
        public int? Died { get; set; }
    }
}
