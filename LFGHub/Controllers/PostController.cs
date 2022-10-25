using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LFGHub.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LFGHub.Controllers;

public class PostController : Controller
{
     private int? uid
    {
        get
        {
            return HttpContext.Session.GetInt32("UUID");
        }
    }

    private bool loggedIn
    {
        get
        {
            return uid != null;
        }
    }

    // db is just a variable name, can be called anything (e.g. DATABASE, db, _db, etc)
    private DatabaseContext _context;
     
    // here we can "inject" our context service into the constructor
    public PostController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpGet("/dashboard")]
    public IActionResult Dashboard()
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "User");
        }

        

        List<NewsPost> allNews = _context.NewsPosts.ToList();
        allNews.Sort(delegate(NewsPost np1, NewsPost np2) { return DateTime.Compare(np2.CreatedAt, np1.CreatedAt); });
        return View("Dashboard", allNews);
    }

    [HttpGet("/lfg/posts/all")]
    public IActionResult All()
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "User");
        }

        List<Post> allPosts = _context.Posts
        .Include(p => p.Author)
        .Include(p => p.GroupPlayers)
        .ThenInclude(groupplayer => groupplayer.User)
        .ToList();
        allPosts.Sort(delegate(Post p1, Post p2) { return DateTime.Compare(p2.CreatedAt, p1.CreatedAt); });
        return View("All", allPosts);
    }

    [HttpGet("/lfg/posts/new")]
    public IActionResult New()
    {
        int? userId = HttpContext.Session.GetInt32("UUID");
        if (userId == null || !loggedIn)
        {
            return RedirectToAction("Index", "User");
        }

        List<GameActivity> allActivities = _context.GameActivities.Where(ga => ga.Approved == true).ToList();
        ViewBag.allActivities = allActivities;

        return View("New");
    }

    [HttpPost("/lfg/posts/create")]
    public IActionResult Create(Post newPost)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "User");
        }

        if (uid != null)
        {
            newPost.UserId = (int)uid;
        }

        if (ModelState.IsValid == false)
        {
            return New();
        }


        _context.Posts.Add(newPost);
        _context.SaveChanges();

        return Dashboard();
    }

    [HttpGet("/lfg/posts/{postId}")]
    public IActionResult ViewPost(int postId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "User");
        }

        Post? post = _context.Posts
            .Include(p => p.Author)
            .Include(p => p.GroupPlayers)
            .ThenInclude(groupPlayer => groupPlayer.User)
            .FirstOrDefault(p => p.PostId == postId);

        if (post == null)
        {
            return Dashboard();
        }
        return View("ViewPost", post);
    }

    [HttpPost("/lfg/posts/{postId}/delete")]
    public IActionResult Delete(int postId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "User");
        }

        Post? postToDelete = _context.Posts.FirstOrDefault(p => p.PostId == postId);

        if (postToDelete != null)
        {
            if (postToDelete.UserId == uid)
            {
                _context.Posts.Remove(postToDelete);
                _context.SaveChanges();
            }
        }
        return Dashboard();
    }

    [HttpGet("/lfg/posts/{postId}/edit")]
    public IActionResult Edit(int postId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "User");
        }

        Post? post = _context.Posts.FirstOrDefault(p => p.PostId == postId);

        if (post == null || post.UserId != uid)
        {
            return Dashboard();
        }
        return View("Edit", post);
    }

    [HttpPost("/lfg/posts/{postId}/update")]
    public IActionResult Update(int postId, Post updatedPost)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "User");
        }

        if (ModelState.IsValid == false)
        {
            return Edit(postId);
        }

        Post? dbPost = _context.Posts.FirstOrDefault(p => p.PostId == postId);

        if (dbPost == null || dbPost.UserId != uid)
        {
            return Dashboard();
        }

        dbPost.Title = updatedPost.Title;
        dbPost.PlayersOnTeam = updatedPost.PlayersOnTeam;
        dbPost.MaxPlayersOnTeam = updatedPost.MaxPlayersOnTeam;
        // dbPost.PlayersNeeded = updatedPost.PlayersNeeded;
        dbPost.Platform = updatedPost.Platform;
        dbPost.Language = updatedPost.Language;
        dbPost.GroupType = updatedPost.GroupType;
        dbPost.MinLevel = updatedPost.MinLevel;
        dbPost.Description = updatedPost.Description;
        // dbPost.GameId = updatedPost.GameId;
        dbPost.GameActivity = updatedPost.GameActivity;
        dbPost.UpdatedAt = DateTime.Now;
        _context.Posts.Update(dbPost);
        _context.SaveChanges();

        return RedirectToAction("ViewPost", new { postId = dbPost.PostId});
    }

    [HttpPost("/lfg/posts/{postId}/joingroup")]
    public IActionResult JoinGroup(int postId)
    {
        if (!loggedIn || uid == null)
        {
            return RedirectToAction("Index", "User");
        }

        GroupMember? existingMember = _context.GroupMembers.FirstOrDefault(gm => gm.PostId == postId && gm.UserId == uid);

        if (existingMember == null)
        {
            GroupMember newMember = new GroupMember(){
                PostId = postId,
                UserId = (int)uid
            };
            _context.GroupMembers.Add(newMember);
        }
        else
        {
            _context.Remove(existingMember);
        }

        _context.SaveChanges();
        return Dashboard();
    }
    
}