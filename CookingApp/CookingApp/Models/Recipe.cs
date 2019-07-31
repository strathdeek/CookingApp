using System;
namespace CookingApp.Models
{
    public class Recipe
    {
        public string Title { get; set; }

        public string Id { get; set; }

        public string RecipeUrl { get; set; }

        public string LessonId { get; set; }

        public float Rating { get; set; }
    }
}
