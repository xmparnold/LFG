using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LFGHub.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LFGHub.Controllers;

public class GameActivityController : Controller
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
    public GameActivityController(DatabaseContext context)
    {
        _context = context;
    }




    [HttpGet("/lfg/gameactivities/suggest")]
    public IActionResult New()
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "User");
        }

        return View("New");
    }

    [HttpPost("/lfg/gameactivities/addsuggestion")]
    public IActionResult Add(GameActivity newActivity)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "User");
        }

        if (ModelState.IsValid == false)
        {
            return New();
        }

        if (uid != null)
        {
            newActivity.UserId = (int)uid;
        }

        newActivity.Approved = false;
        _context.GameActivities.Add(newActivity);
        _context.SaveChanges();

        return RedirectToAction("Dashboard", "Post");
    }

    [HttpGet("/lfg/gameactivities/suggestions")]
    public IActionResult Suggestions()
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "User");
        }

        if (HttpContext.Session.GetInt32("UUID") != 1)
        {
            return RedirectToAction("Dashboard", "Post");
        }

        List<GameActivity> allActivities = _context.GameActivities
            .Include(ga => ga.SuggestedBy)
            .ToList();

        return View("Suggestions", allActivities);
    }

    [HttpPost("/lfg/gameactivities/{gameActivityId}/approve")]
    public IActionResult Approve(int gameActivityId)
    {
        GameActivity? activity = _context.GameActivities.FirstOrDefault(ga => ga.GameActivityId == gameActivityId);
        
        if (activity == null | HttpContext.Session.GetInt32("UUID") != 1)
        {
            return RedirectToAction("Dashboard", "Post");
        }

        if (activity.Approved)
        {
            activity.Approved = false;

        }
        else
        {
            activity.Approved = true;
        }

        _context.Update(activity);
        _context.SaveChanges();

        return Suggestions();
    }
}