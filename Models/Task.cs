// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiEF.Models;

public class Task
{  
  // [Key]
  public Guid TaskId { get; set; }

  // [Required]
  // [MaxLength(200)]
  public string? Title { get; set; }

  public string? Description { get; set; }

  public Priority TaskPriority { get; set; }

  // [NotMapped]
  public string? Resume { get; set; }

  public DateTime CreationDate { get; set; }

  // [ForeignKey("CategoryId")]
  public Guid CategoryId { get; set; }

  public virtual Category? Category { get; set; }
}

public enum Priority
{
  Low,
  Half,
  High
}