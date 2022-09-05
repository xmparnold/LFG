#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LFGHub.Models;

public class JoinRequest
{
    [Key]
    public int JoinRequestId { get; set; }

    [Required]
    public bool Approved { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public int UserId { get; set; }
    public User? Player { get; set; }
    public int PostId { get; set; }
    public Post? Post { get; set; }

}