using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookingApp.Data;
using CookingApp.Models;
using Xamarin.Forms;

namespace CookingApp.Services
{
    public class MockDataStore : IDataStore<Lesson>
    {
        List<Lesson> items;

        public MockDataStore()
        {
            var mockLessons = new List<Lesson>()
            {
                new Lesson { Id = Guid.NewGuid().ToString(), Title="Hard Boiled", ImageSource=ImageSource.FromFile("cooking.png"), Level=Difficulty.Easy,Tier=1, Category = Category.Egg},
                new Lesson { Id = Guid.NewGuid().ToString(), Title="Soft Boiled", ImageSource=ImageSource.FromFile("cooking.png"), Level=Difficulty.Easy,Tier=1, Category = Category.Egg},
                new Lesson { Id = Guid.NewGuid().ToString(), Title="Over Easy", ImageSource=ImageSource.FromFile("cooking.png"), Level=Difficulty.Easy,Tier=2, Category = Category.Egg},
                new Lesson { Id = Guid.NewGuid().ToString(), Title="Poached", ImageSource=ImageSource.FromFile("cooking.png"), Level=Difficulty.Medium,Tier=3, Category = Category.Egg},
                new Lesson { Id = Guid.NewGuid().ToString(), Title="Hollandaise Sauce", ImageSource=ImageSource.FromFile("cooking.png"), Level=Difficulty.Medium,Tier=5, Category = Category.Egg},
                new Lesson { Id = Guid.NewGuid().ToString(), Title="Eggs Benedict", ImageSource=ImageSource.FromFile("cooking.png"), Level=Difficulty.Medium,Tier=5, Category = Category.Egg},
                new Lesson { Id = Guid.NewGuid().ToString(), Title="Scrambled", ImageSource=ImageSource.FromFile("cooking.png"), Level=Difficulty.Easy,Tier=1,Category = Category.Egg},
                new Lesson { Id = Guid.NewGuid().ToString(), Title="Sunny Side Up", ImageSource=ImageSource.FromFile("cooking.png"), Level=Difficulty.Easy,Tier=2,Category = Category.Egg},
                new Lesson { Id = Guid.NewGuid().ToString(), Title="Omelette", ImageSource=ImageSource.FromFile("cooking.png"), Level=Difficulty.Easy,Tier=2,Category = Category.Egg},
                new Lesson { Id = Guid.NewGuid().ToString(), Title="French Omelette", ImageSource=ImageSource.FromFile("cooking.png"), Level=Difficulty.Medium,Tier=3,Category = Category.Egg},
                new Lesson { Id = Guid.NewGuid().ToString(), Title="Mayonnaise", ImageSource=ImageSource.FromFile("cooking.png"), Level=Difficulty.Medium,Tier=4,Category = Category.Egg},
                new Lesson { Id = Guid.NewGuid().ToString(), Title="Meringue Cookies", ImageSource=ImageSource.FromFile("cooking.png"), Level=Difficulty.Medium,Tier=4,Category = Category.Egg},
                new Lesson { Id = Guid.NewGuid().ToString(), Title="Egg Custard", ImageSource=ImageSource.FromFile("cooking.png"), Level=Difficulty.Medium,Tier=5,Category = Category.Egg},
            };

            items = new List<Lesson>();

            foreach (var item in mockLessons)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Lesson item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Lesson item)
        {
            var oldItem = items.Where((Lesson arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Lesson arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Lesson> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Lesson>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}