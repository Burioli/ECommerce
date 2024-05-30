using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using burioli.alessandro._5H.ECommerce.Models;

namespace burioli.alessandro._5H.ECommerce.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Catalogo()
    {
        string? nomeUtente = HttpContext.Session.GetString("NomeUtente");
        if( nomeUtente == "sa" )
            return View();

        return View("Index");
    }

      [HttpPost]
      public IActionResult login( Utente u )
      {
        if( u.UserName== "sa" && u.UserPassword=="sa")
        {
            HttpContext.Session.SetString("NomeUtente", "sa");
            return View("Index");
        }

        return View();
      }

      [HttpGet]
      public IActionResult login()
      {
        return View();
      }
      public IActionResult logout()
      {
        HttpContext.Session.SetString("NomeUtente", "pippo!!");
        return View("Index");
      }

      public IActionResult registrati()
                    {
                        return View();
                    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
