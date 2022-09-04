#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LFGHub.Models;

public class Friend
{
    public int FriendId { get; set; }
    public int UserId1 { get; set; }
    public User? User1 { get; set; }
    public int UserId2 { get; set; }
    public User? User2 { get; set; }
}