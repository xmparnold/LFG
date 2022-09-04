#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LFGHub.Models;

public class Post
{
    [Key]
    public int PostId { get; set; }

    [Required(ErrorMessage ="is required")]
    [MinLength(3, ErrorMessage ="must be at least 3 characters")]
    [MaxLength(50, ErrorMessage ="must be 50 characters or less")]
    public string Title { get; set; }

    [Required(ErrorMessage ="is required")]
    [GreaterThan0]
    [Display(Name ="Players on Team")]
    public int PlayersOnTeam { get; set; }

    [Required(ErrorMessage ="is required")]
    [GreaterThan0]
    [Display(Name ="Max Players On Team")]
    public int MaxPlayersOnTeam { get; set; }

    [Required(ErrorMessage ="is required")]
    [Display(Name ="Players Needed")]
    public int PlayersNeeded { get; set; }

    // 0 = PC, 1 = PS4, 2 = Xbox One, 3 = PS5, 4 = PS3, 5 = Xbox 360
    [Required(ErrorMessage ="is required")]
    public int Platform { get; set; }

    [Required(ErrorMessage ="is required")]
    public string Language { get; set; }

    // 0 = LFG, 1 = LFM
    [Required(ErrorMessage ="is required")]
    [Display(Name ="Group Type")]
    public int GroupType { get; set; }

    [Required(ErrorMessage ="is required")]
    [GreaterThan0]
    [Display(Name ="Minimum Level")]
    public int MinLevel { get; set; }

    [Required(ErrorMessage ="is required")]
    [Display(Name ="Mic Required")]
    public bool MicRequired { get; set; }

    [MinLength(10, ErrorMessage ="must be at least 10 characters")]
    [MaxLength(500, ErrorMessage ="must be 500 characters or less")]
    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    


    public int UserId { get; set; }
    public User? Author { get; set; }
    public List<GroupMember> GroupPlayers { get; set; }
    public List<JoinRequest> JoinRequests { get; set; }
    // public int GameId { get; set; }
    // public Game? Game { get; set; }
    public int ActivityId { get; set; }
    public GameActivity Activity { get; set; }
    
}