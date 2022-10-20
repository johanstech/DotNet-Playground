namespace ToDoMinimalAPI.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ToDo
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}
