using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название рецепта")]
        [StringLength(100, ErrorMessage = "Название не должно быть длиннее 100 символов")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите ингредиенты")]
        [StringLength(500, ErrorMessage = "Ингредиенты не должны быть длиннее 500 символов")]
        public string Ingredients { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите инструкцию приготовления")]
        [StringLength(2000, ErrorMessage = "Инструкция не должна быть длиннее 2000 символов")]
        public string Instructions { get; set; } = string.Empty;

        public bool IsSystemRecipe { get; set; }
    }
}