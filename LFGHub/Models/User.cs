#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LFGHub.Models;

public class User {

    [Key]
    public int UserId { get; set; }

    [Required(ErrorMessage ="is required.")]
    [MinLength(2, ErrorMessage ="must be at least 2 characters.")]
    [MaxLength(25, ErrorMessage ="must be 25 characters or less")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }


    [Required(ErrorMessage ="is required.")]
    [MinLength(2, ErrorMessage ="must be at least 2 characters.")]
    [MaxLength(25, ErrorMessage ="must be 25 characters or less")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required(ErrorMessage ="is required.")]
    [MinLength(2, ErrorMessage ="must be at least 2 characters.")]
    [MaxLength(26, ErrorMessage ="must be 26 characters or less")]
    public string Username { get; set; }


    [Required(ErrorMessage ="is required.")]
    [EmailAddress]
    public string Email { get; set; }


    [Required(ErrorMessage ="is required.")]
    [MinLength(8, ErrorMessage ="must be at least 8 characters.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }


    [NotMapped]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "doesn't match password.")]
    [Display(Name = "Confirm Password")]
    public string ConfirmPassword { get; set; }


    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    public List<Post> PostsCreated { get; set; } = new List<Post>();
    public List<GroupMember> GroupsIn { get; set; } = new List<GroupMember>();

    public string FullName() {
        return FirstName + " " + LastName;
    }
}