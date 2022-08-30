#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LFGHub.Models;

public class Game
{
    [Key]
    public int GameId { get; set; }

    [Required(ErrorMessage ="is required")]
    [MinLength(1, ErrorMessage ="must be at least 1 character")]
    [MaxLength(75, ErrorMessage ="must be 75 characters or less")]
    public string Name { get; set; }

    [Required(ErrorMessage ="is required")]
    public bool CrossPlatform { get; set; }
    
    // 0 = PC, 1 = PS4, 2 = Xbox One, 3 = PS5, 4 = PS3, 5 = Xbox 360
    [Required(ErrorMessage ="is required")]
    public int Platform { get; set; }

    [Required(ErrorMessage ="is required")]
    public bool Approved { get; set; }

    public List<Post> Posts { get; set; }

}