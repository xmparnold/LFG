using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LFGHub.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LFGHub.Controllers;

public class GameController : Controller
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
    public GameController(DatabaseContext context)
    {
        _context = context;
    }
}