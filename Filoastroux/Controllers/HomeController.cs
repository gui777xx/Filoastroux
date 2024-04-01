using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Filoastroux.Models;
using System.Text.Json;

namespace Filoastroux.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Astrologia> astrologias = [];
        using (StreamReader leitor = new("Data\\astrologia.json"))
        {
            string dados = leitor.ReadToEnd();
            astrologias = JsonSerializer.Deserialize<List<Astrologia>>(dados);
        }
        return View(astrologias);
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
