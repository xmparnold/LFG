#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LFGHub.Models;

public class NewsPost
{
    [Key]
    public int NewsPostId { get; set; }

    [Required(ErrorMessage ="is required")]
    [MinLength(4, ErrorMessage ="must be at least 4 characters")]
    [MaxLength(40, ErrorMessage ="must be 40 characters or less")]
    public string Title { get; set; }

    [MinLength(4, ErrorMessage ="must be at least 4 characters if included")]
    [MaxLength(400, ErrorMessage ="must be 400 characters or less if included")]
    public string? Subtitle { get; set; }

    [Required(ErrorMessage ="is required")]
    [Display(Name ="Image Url")]
    public string ImageUrl { get; set; }

    [Required(ErrorMessage ="is required")]
    [Display(Name ="Small Image Url")]
    public string SmallImageUrl { get; set; }

    [Required(ErrorMessage ="is required")]
    [MinLength(50, ErrorMessage ="must be at least 50 characters")]
    [MaxLength(5000, ErrorMessage ="must be 5000 characters or less")]
    public string Text { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

}