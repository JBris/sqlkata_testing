using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SqlKataTesting.Models;
using SqlKataTesting.Services;

namespace SqlKataTesting.Controllers;

public class MySQLController : Controller
{
    private readonly ILogger<MySQLController> _logger;
    private readonly IMySQLService db;

    public MySQLController(ILogger<MySQLController> logger, IMySQLService db)
    {
        _logger = logger;
        this.db = db;
    }

    // GET: /MySQ/
    public IActionResult Index()
    {
        return View();
    }
    
    // POST: /MySQ/Create
    public IActionResult Create()
    {
        db.Create();
        return View("Index");
    }

    // DELETE: /MySQ/Delete
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
