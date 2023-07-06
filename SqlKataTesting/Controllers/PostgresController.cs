using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SqlKataTesting.Models;
using SqlKataTesting.Services;

namespace SqlKataTesting.Controllers;

public class PostgresController : Controller
{
    private readonly ILogger<PostgresController> _logger;
    private readonly IPostgresService db;

    public PostgresController(ILogger<PostgresController> logger, IPostgresService db)
    {
        _logger = logger;
        this.db = db;
    }

    // GET: /Postgres/
    public IActionResult Index()
    {
        return View();
    }

    // POST: /Postgres/Create
    public IActionResult Create()
    {
        db.Create();
        return View("Index");
    }

    // DELETE: /Postgres/Delete
    public IActionResult Delete()
    {
        db.Delete();
        return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
