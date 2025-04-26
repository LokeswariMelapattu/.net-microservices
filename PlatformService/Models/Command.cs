using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq; 
namespace PlatformService.Models;
public class Command
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string HowTo { get; set; } = string.Empty;
    [Required]
    public string CommandLine { get; set; } = string.Empty;
    [Required]
    [ForeignKey("Platform")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int PlatformId { get; set; }

    // Navigation property
    public Platform Platform { get; set; } = null!;
}