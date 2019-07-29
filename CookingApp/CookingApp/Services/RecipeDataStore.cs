using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookingApp.Models;

namespace CookingApp.Services
{
    public class RecipeDataStore : IDataStore<Recipe>
    {
        List<Recipe> items;

        public RecipeDataStore()
        {
            var mockRecipes = new List<Recipe>
            {

            };

            items.AddRange(mockRecipes);
        }

        public async Task<bool> AddItemAsync(Recipe item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            items.Remove(items.Where(x => x.Id == id).FirstOrDefault());

            return await Task.FromResult(true);
        }

        public async Task<Recipe> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Recipe>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<bool> UpdateItemAsync(Recipe item)
        {
            var oldItem = items.Where((Recipe arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);
            return await Task.FromResult(true);

        }

        public async Task<IEnumerable<Recipe>> GetRecipesForLessonAsync(string lessonId)
        {
            return await Task.FromResult(items.Where(x => x.LessonId == lessonId));
        }
    }
}
