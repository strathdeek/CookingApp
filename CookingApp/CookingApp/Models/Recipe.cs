using System;
namespace CookingApp.Models
{
    public class Recipe
    {
        public string Id { get; set; }

        public Uri RecipeUrl { get; set; }

        public string LessonId { get; set; }

        public float Rating { get; set; }
    }
}
