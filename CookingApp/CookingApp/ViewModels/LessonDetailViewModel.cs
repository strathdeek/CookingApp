using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookingApp.Models;

namespace CookingApp.ViewModels
{
    public class LessonDetailViewModel : BaseViewModel
    {
        public string LessonId { get; set; }

        public List<Recipe> Recipes { get; set; }

        public LessonDetailViewModel(string lessonId)
        {
            LessonId = lessonId;
            FetchRecipes();
        }

        public void FetchRecipes()
        {
            Recipes = (RecipeDataStore as Services.RecipeDataStore).GetRecipesForLessonAsync(LessonId).Result.ToList();

        }
    }
}
