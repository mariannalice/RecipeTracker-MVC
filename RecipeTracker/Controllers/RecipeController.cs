using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

public class RecipeController : Controller
{
  private readonly string _filePath = "recipes.json";
  private List<Recipe> _recipes;

  public RecipeController()
  {
    if (System.IO.File.Exists(_filePath))
    {
      var json = System.IO.File.ReadAllText(_filePath);
      _recipes = JsonSerializer.Deserialize<List<Recipe>>(json) ?? new List<Recipe>();
    }
    else
    {
      _recipes = new List<Recipe>();
    }
  }

  public IActionResult Index()
  {
    return View(_recipes);
  }

  public IActionResult Create()
  {
    return View();
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult Create(Recipe recipe)
  {
    if (ModelState.IsValid)
    {
      recipe.Id = _recipes.Count + 1;
      _recipes.Add(recipe);
      SaveChanges();
      return RedirectToAction(nameof(Index));
    }
    return View(recipe);
  }

  private void SaveChanges()
  {
    var json = JsonSerializer.Serialize(_recipes, new JsonSerializerOptions { WriteIndented = true });
    System.IO.File.WriteAllText(_filePath, json);
  }
}