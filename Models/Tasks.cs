using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ToDoList.Models

{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }
        [Required]
        //[NotNull]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        //[NotNull]

        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        //[NotNull]

        [MaxLength(255)]
        public string Description { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

    }
}