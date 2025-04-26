using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;

namespace PlatformService.Models;
public class Platform
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [MaxLength(250)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [MaxLength(250)]
    public string Publisher { get; set; } = string.Empty;
    [Required]
    public string Cost { get; set; } = string.Empty;

    // Navigation property
    public ICollection<Command> Commands { get; set; } = new List<Command>();
}