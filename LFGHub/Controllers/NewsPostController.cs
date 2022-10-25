using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LFGHub.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LFGHub.Controllers;

public class NewsPostController : Controller
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
    public NewsPostController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpGet("/newsposts/new")]
    public IActionResult New()
    {
        if (HttpContext.Session.GetInt32("UUID") != 1)
        {
            if (!loggedIn)
            {
                return RedirectToAction("Index", "User");
            }
            return RedirectToAction("Dashboard", "Post");
        }

        return View("New");
    }

    [HttpPost("/newsposts/create")]
    public IActionResult Create(NewsPost newPost)
    {
        if (HttpContext.Session.GetInt32("UUID") != 1)
        {
            return RedirectToAction("Index", "User");
        }

        if (ModelState.IsValid == false)
        {
            return New();
        }

        _context.NewsPosts.Add(newPost);
        _context.SaveChanges();
        
        // return ViewNewsPost(newPost.NewsPostId);
        return RedirectToAction("ViewNewsPost", new { newsPostId = newPost.NewsPostId });

    }

    [HttpGet("/newsposts/{newsPostId}/view")]
    public IActionResult ViewNewsPost(int newsPostId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "User");
        }

        NewsPost? post = _context.NewsPosts.FirstOrDefault(np => np.NewsPostId == newsPostId);

        if (post == null)
        {
            return RedirectToAction("Dashboard", "Post");
        }

        return View("View", post);
    }

    [HttpGet("/newsposts/{newsPostId}/edit")]
    public IActionResult Edit(int newsPostId)
    {
        if (HttpContext.Session.GetInt32("UUID") != 1)
        {
            if (!loggedIn)
            {
                return RedirectToAction("Index", "User");
            }
            return RedirectToAction("Dashboard", "Post");
        }

        NewsPost? post = _context.NewsPosts.FirstOrDefault(np => np.NewsPostId == newsPostId);

        if (post == null)
        {
            return RedirectToAction("Dashboard", "Post");
        }

        return View("Edit", post);
    }

    [HttpPost("/newsposts/{newsPostId}/update")]
    public IActionResult Update(int newsPostId, NewsPost updatedNewsPost)
    {
        if (HttpContext.Session.GetInt32("UUID") != 1)
        {
            if (!loggedIn)
            {
                return RedirectToAction("Index", "User");
            }
            return RedirectToAction("Dashboard", "Post");
        }

        if (ModelState.IsValid == false)
        {
            return Edit(newsPostId);
        }

        NewsPost? dbPost = _context.NewsPosts.FirstOrDefault(np => np.NewsPostId == newsPostId);

        if (dbPost == null)
        {
            return RedirectToAction("Dashboard", "Post");
        }

        dbPost.Title = updatedNewsPost.Title;
        dbPost.Subtitle = updatedNewsPost.Subtitle;
        dbPost.ImageUrl = updatedNewsPost.ImageUrl;
        dbPost.SmallImageUrl = updatedNewsPost.SmallImageUrl;
        dbPost.Text = updatedNewsPost.Text;
        dbPost.UpdatedAt = DateTime.Now;
        _context.NewsPosts.Update(dbPost);
        _context.SaveChanges();

        return RedirectToAction("ViewNewsPost", new { newsPostId = dbPost.NewsPostId });

    }
}