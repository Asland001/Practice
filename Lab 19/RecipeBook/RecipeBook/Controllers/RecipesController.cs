using Microsoft.AspNetCore.Mvc;
using RecipeBook.Models;

namespace RecipeBook.Controllers
{
    public class RecipesController : Controller
    {
        private static List<Recipe> _recipes = new List<Recipe>
        {
            new Recipe
            {
                Id = 1,
                Title = "Омлет",
                Ingredients = "Яйца, молоко, соль",
                Steps = "1. Взбить яйца " +
                        "2. Добавить молоко" +
                        "3. Жарить на сковороде"
            },
            new Recipe
            {
                Id = 2,
                Title = "Салат",
                Ingredients = "Огурцы, помидоры, масло",
                Steps = "1. Нарезать овощи " +
                        "2. Cмешать " +
                        "3. Заправить маслом"
            }
        };

        //Список рецептов
        public IActionResult Index()
        {
            return View(_recipes);
        }

        //Просмотр одного рецепта по /Recipes/View/{id}
        public IActionResult View(int id)
        {
            var recipe = _recipes.FirstOrDefault(r => r.Id == id);

            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        //Форма добавления рецепта
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //Обработка отправки формы
        [HttpPost]
        public IActionResult Create(Recipe recipe)
        {
            if (string.IsNullOrWhiteSpace(recipe.Title) ||
                string.IsNullOrWhiteSpace(recipe.Ingredients) ||
                string.IsNullOrWhiteSpace(recipe.Steps))
            {
                ModelState.AddModelError("", "Все поля должны быть заполнены.");
                return View(recipe);
            }

            recipe.Id = _recipes.Count > 0 ? _recipes.Max(r => r.Id) + 1 : 1;
            _recipes.Add(recipe);

            return RedirectToAction("Index");
        }
    }
}