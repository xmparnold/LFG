#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LFGHub.Models;

public class GameActivity
{
    [Key]
    public int GameActivityId { get; set; }

    [Required(ErrorMessage ="is required")]
    [MinLength(2, ErrorMessage ="must be at least 2 characters")]
    [MaxLength(50, ErrorMessage ="must be 50 characters or less")]
    public string Name { get; set; }

    [Required(ErrorMessage ="is required.")]
    [GreaterThan0]
    public int MaxPlayers { get; set; }

    [Required(ErrorMessage ="is required.")]
    [GreaterThan0]
    public int MinPlayers { get; set; }

    [Required(ErrorMessage ="is required")]
    public bool Approved { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;



    // public int GameId { get; set; }
    // public Game? Game { get; set; }
    public List<Post> Posts { get; set; } = new List<Post>();
    public int UserId { get; set; }
    public User? SuggestedBy { get; set; }
}