#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LFGHub.Models;

public class GameCharacter
{
    [Key]
    public int GameCharacterId { get; set; }

    [Required(ErrorMessage ="is required")]
    public string Name { get; set; }

    //0 = Hunter, 1 = Warlock, 2 = Titan
    [Required(ErrorMessage ="is required")]
    public int Class { get; set; }

    [Required(ErrorMessage ="is required")]
    public int Power { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }
}