using Microsoft.EntityFrameworkCore;
using RecipeBook.Data;
using RecipeBook.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=recipes.db"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();

    if (!db.Recipes.Any())
    {
        db.Recipes.AddRange(
    new Recipe
    {
        Title = "Классический омлет",
        Ingredients = "Яйца — 3 шт.; Молоко — 50 мл; Соль — по вкусу; Масло сливочное — 10 г",
        Instructions = "1. Взбить яйца с молоком и солью.\n" +
                       "2. Разогреть сковороду и растопить масло.\n" +
                       "3. Вылить смесь на сковороду.\n" +
                       "4. Готовить на среднем огне 3–5 минут до готовности.",
        IsSystemRecipe = true
    },
    new Recipe
    {
        Title = "Греческий салат",
        Ingredients = "Помидоры — 2 шт.; Огурцы — 2 шт.; Фета — 150 г; Оливковое масло — 2 ст.л.; Оливки — 50 г; Соль — по вкусу",
        Instructions = "1. Нарезать помидоры и огурцы крупными кусками.\n" +
                       "2. Добавить оливки.\n" +
                       "3. Нарезать сыр фета кубиками и добавить в салат.\n" +
                       "4. Заправить оливковым маслом и аккуратно перемешать.",
        IsSystemRecipe = true
    },
    new Recipe
    {
        Title = "Паста Карбонара",
        Ingredients = "Спагетти — 200 г; Бекон — 100 г; Яйца — 2 шт.; Пармезан — 50 г; Сливки — 100 мл; Чеснок — 1 зубчик",
        Instructions = "1. Отварить спагетти до состояния al dente.\n" +
                       "2. Обжарить бекон с чесноком.\n" +
                       "3. Взбить яйца со сливками и тертым сыром.\n" +
                       "4. Смешать горячие спагетти с беконом.\n" +
                       "5. Быстро добавить соус и перемешать.",
        IsSystemRecipe = true
    },
    new Recipe
    {
        Title = "Блинчики",
        Ingredients = "Мука — 200 г; Молоко — 500 мл; Яйца — 2 шт.; Сахар — 1 ст.л.; Соль — щепотка; Масло — для жарки",
        Instructions = "1. Смешать яйца, сахар и соль.\n" +
                       "2. Постепенно добавить молоко и муку.\n" +
                       "3. Перемешать до однородности.\n" +
                       "4. Жарить тонкие блинчики на сковороде.",
        IsSystemRecipe = true
    },
    new Recipe
    {
        Title = "Куриный суп",
        Ingredients = "Курица — 300 г; Картофель — 3 шт.; Морковь — 1 шт.; Лук — 1 шт.; Вода — 2 л; Соль — по вкусу",
        Instructions = "1. Отварить курицу в воде.\n" +
                       "2. Добавить нарезанный картофель.\n" +
                       "3. Обжарить лук и морковь и добавить в суп.\n" +
                       "4. Варить до готовности овощей.",
        IsSystemRecipe = true
    }
);

        db.SaveChanges();
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Recipes}/{action=Index}/{id?}");

app.Run();