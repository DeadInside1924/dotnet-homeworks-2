using System.Diagnostics.CodeAnalysis;
using Hw7.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hw7.Controllers;

public class HomeController : Controller
{
    [ExcludeFromCodeCoverage]
    [HttpGet]
    public IActionResult UserProfile()
    {
        return View();
    }

    [ExcludeFromCodeCoverage]
    [HttpPost]
    public IActionResult UserProfile(UserProfile profile)
    {
        return View(profile);
    }
}