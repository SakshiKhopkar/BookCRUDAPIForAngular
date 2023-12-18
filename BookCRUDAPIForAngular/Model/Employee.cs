using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookCRUDAPIForAngular.Model
{
    [Table("employee2")]
    public class Employee
    {
        [Key]//pk in col in DB
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int Salary { get; set; }
    }
}
