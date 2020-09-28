using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dotnet.Mvc.Models;
namespace Dotnet.Mvc.Controllers
{
  public class MovieController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public MovieController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Create()
    {
      return View("Views/Movie/Create.cshtml");
    }

    public IActionResult Delete()
    {
      return View("Views/Movie/Delete.cshtml");
    }

    public IActionResult Edit()
    {
      return View("Views/Movie/Edit.cshtml");
    }
  }
}
