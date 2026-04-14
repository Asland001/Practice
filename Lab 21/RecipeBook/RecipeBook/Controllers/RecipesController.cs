using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeBook.Data;
using RecipeBook.Models;

namespace RecipeBook.Controllers
{
    public class RecipesController : Controller
    {
        private readonly AppDbContext _context;

        public RecipesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var recipes = await _context.Recipes
                .OrderBy(r => r.Title)
                .ToListAsync();

            return View(recipes);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var recipe = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == id);
            if (recipe == null)
                return NotFound();

            return View(recipe);
        }

        public async Task<IActionResult> Alternative(int? id)
        {
            if (id == null)
                return NotFound();

            var recipe = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == id);
            if (recipe == null)
                return NotFound();

            var alternative = GetAlternativeSuggestion(recipe);

            ViewBag.OriginalRecipe = recipe;
            ViewBag.AlternativeText = alternative;

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Recipe recipe)
        {
            if (!ModelState.IsValid)
                return View(recipe);

            recipe.IsSystemRecipe = false;

            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Рецепт «{recipe.Title}» успешно добавлен.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
                return NotFound();

            if (recipe.IsSystemRecipe)
                return RedirectToAction(nameof(Index));

            return View(recipe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Recipe recipe)
        {
            if (id != recipe.Id)
                return NotFound();

            var existing = await _context.Recipes.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
            if (existing == null)
                return NotFound();

            if (existing.IsSystemRecipe)
                return RedirectToAction(nameof(Index));

            if (!ModelState.IsValid)
                return View(recipe);

            recipe.IsSystemRecipe = false;

            _context.Update(recipe);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Рецепт «{recipe.Title}» обновлён.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var recipe = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == id);
            if (recipe == null)
                return NotFound();

            if (recipe.IsSystemRecipe)
                return RedirectToAction(nameof(Index));

            return View(recipe);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
                return RedirectToAction(nameof(Index));

            if (recipe.IsSystemRecipe)
                return RedirectToAction(nameof(Index));

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Рецепт «{recipe.Title}» удалён.";
            return RedirectToAction(nameof(Index));
        }

        private static string GetAlternativeSuggestion(Recipe recipe)
{
    var title = recipe.Title.ToLowerInvariant();

    if (title.Contains("омлет"))
        return "Альтернатива: Омлет с сыром и зеленью.\n" +
               "Ингредиенты: яйца — 3 шт., молоко — 50 мл, сыр — 50 г, укроп — по вкусу.\n" +
               "Приготовление:\n" +
               "1. Взбей яйца с молоком.\n" +
               "2. Добавь натёртый сыр и зелень.\n" +
               "3. Обжарь на слабом огне под крышкой до готовности.";

    if (title.Contains("салат"))
        return "Альтернатива: Салат с курицей и авокадо.\n" +
               "Ингредиенты: куриное филе — 150 г, авокадо — 1 шт., огурец — 1 шт., йогурт — 2 ст.л.\n" +
               "Приготовление:\n" +
               "1. Отвари или обжарь курицу и нарежь.\n" +
               "2. Нарежь авокадо и огурец.\n" +
               "3. Смешай и заправь йогуртом.";

    if (title.Contains("каша"))
        return "Альтернатива: Овсяная каша с фруктами и орехами.\n" +
               "Ингредиенты: овсянка — 50 г, молоко — 200 мл, банан — 1 шт., орехи — 20 г, мёд — 1 ч.л.\n" +
               "Приготовление:\n" +
               "1. Сварить овсянку на молоке.\n" +
               "2. Добавить нарезанный банан.\n" +
               "3. Посыпать орехами и полить мёдом.";

    if (title.Contains("паста") || title.Contains("карбонара"))
        return "Альтернатива: Паста с грибами в сливочном соусе.\n" +
               "Ингредиенты: паста — 200 г, шампиньоны — 150 г, сливки — 150 мл, чеснок — 1 зубчик.\n" +
               "Приготовление:\n" +
               "1. Отварить пасту.\n" +
               "2. Обжарить грибы с чесноком.\n" +
               "3. Добавить сливки и тушить 5 минут.\n" +
               "4. Смешать с пастой.";

    if (title.Contains("суп"))
        return "Альтернатива: Крем-суп из тыквы.\n" +
               "Ингредиенты: тыква — 300 г, картофель — 2 шт., сливки — 100 мл.\n" +
               "Приготовление:\n" +
               "1. Отварить овощи до мягкости.\n" +
               "2. Измельчить блендером.\n" +
               "3. Добавить сливки и довести до кипения.";

    if (title.Contains("блин"))
        return "Альтернатива: Блинчики с творогом.\n" +
               "Ингредиенты: блины, творог — 200 г, сахар — 2 ст.л., ванилин.\n" +
               "Приготовление:\n" +
               "1. Смешать творог с сахаром.\n" +
               "2. Завернуть начинку в блины.\n" +
               "3. Обжарить или подать так.";

    return "Альтернатива: Попробуй изменить блюдо, добавив новые ингредиенты.\n" +
           "Например:\n" +
           "- Добавь специи (паприка, чеснок, базилик)\n" +
           "- Замени соус (сливочный, томатный, йогуртовый)\n" +
           "- Используй другой источник белка (курица, рыба, бобовые)";
}
    }
}