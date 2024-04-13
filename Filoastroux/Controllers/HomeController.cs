using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Filoastroux.Models;

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
        List<Astrologia> astrologias = GetAstrologias();
        List<Tipo> tipos = GetTipos();
        ViewData["Tipos"] = tipos;
        return View(astrologias);
    }

    public IActionResult Details(int id)
    {
        List<Astrologia> astrologias = GetAstrologias();
        List<Tipo> tipos = GetTipos();
        DetailsVM details = new() {
            Tipos = tipos,
            Atual = astrologias.FirstOrDefault(p => p.Numero == id),
            Anterior = astrologias.OrderByDescending(p => p.Numero).FirstOrDefault(p => p.Numero < id),
            Proximo = astrologias.OrderBy(p => p.Numero).FirstOrDefault(p => p.Numero > id), 
        };
        return View(details);
    }
    
    private List<Astrologia> GetAstrologias()
    {
        using (StreamReader leitor = new("Data\\astrologia.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Astrologia>>(dados);
        }
    }

    private List<Tipo> GetTipos()
    {
        using (StreamReader leitor = new("Data\\tipos.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Tipo>>(dados);
        }
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
