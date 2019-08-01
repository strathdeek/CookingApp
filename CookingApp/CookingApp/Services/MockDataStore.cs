using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookingApp.Data;
using CookingApp.Models;
using Xamarin.Forms;

namespace CookingApp.Services
{
    public class LessonDataStore : IDataStore<Lesson>
    {
        List<Lesson> items;

        public LessonDataStore()
        {
            var mockLessons = new List<Lesson>()
            {
                new Lesson { Id = 1.ToString(), Title="Hard Boiled", ImageSource=ImageSource.FromFile("eggs.png"), Level=Difficulty.Easy,Tier=1, Category = Category.Egg, Completed=false, ExampleUrl="https://i2.wp.com/aspicyperspective.com/wp-content/uploads/2010/04/classic-deviled-eggs-5-256x256.jpg"},
                new Lesson { Id = 2.ToString(), Title="Soft Boiled", ImageSource=ImageSource.FromFile("eggs.png"), Level=Difficulty.Easy,Tier=1, Category = Category.Egg, Completed=false, ExampleUrl="https://i2.wp.com/aspicyperspective.com/wp-content/uploads/2010/04/classic-deviled-eggs-5-256x256.jpg"},
                new Lesson { Id = 3.ToString(), Title="Over Easy", ImageSource=ImageSource.FromFile("eggs.png"), Level=Difficulty.Easy,Tier=2, Category = Category.Egg, Completed=false, ExampleUrl="https://i2.wp.com/aspicyperspective.com/wp-content/uploads/2010/04/classic-deviled-eggs-5-256x256.jpg"},
                new Lesson { Id = 4.ToString(), Title="Poached", ImageSource=ImageSource.FromFile("eggs.png"), Level=Difficulty.Medium,Tier=3, Category = Category.Egg, Completed=false, ExampleUrl="https://i2.wp.com/aspicyperspective.com/wp-content/uploads/2010/04/classic-deviled-eggs-5-256x256.jpg"},
                new Lesson { Id = 5.ToString(), Title="Hollandaise Sauce", ImageSource=ImageSource.FromFile("eggs.png"), Level=Difficulty.Medium,Tier=5, Category = Category.Egg, Completed=false, ExampleUrl="https://i2.wp.com/aspicyperspective.com/wp-content/uploads/2010/04/classic-deviled-eggs-5-256x256.jpg"},
                new Lesson { Id = 6.ToString(), Title="Eggs Benedict", ImageSource=ImageSource.FromFile("eggs.png"), Level=Difficulty.Medium,Tier=5, Category = Category.Egg, Completed=false, ExampleUrl="https://i2.wp.com/aspicyperspective.com/wp-content/uploads/2010/04/classic-deviled-eggs-5-256x256.jpg"},
                new Lesson { Id = 7.ToString(), Title="Scrambled", ImageSource=ImageSource.FromFile("eggs.png"), Level=Difficulty.Easy,Tier=1,Category = Category.Egg, Completed=false, ExampleUrl="https://i2.wp.com/aspicyperspective.com/wp-content/uploads/2010/04/classic-deviled-eggs-5-256x256.jpg"},
                new Lesson { Id = 8.ToString(), Title="Sunny Side Up", ImageSource=ImageSource.FromFile("eggs.png"), Level=Difficulty.Easy,Tier=2,Category = Category.Egg, Completed=false, ExampleUrl="https://i2.wp.com/aspicyperspective.com/wp-content/uploads/2010/04/classic-deviled-eggs-5-256x256.jpg"},
                new Lesson { Id = 9.ToString(), Title="Omelette", ImageSource=ImageSource.FromFile("eggs.png"), Level=Difficulty.Easy,Tier=2,Category = Category.Egg, Completed=false, ExampleUrl="https://i2.wp.com/aspicyperspective.com/wp-content/uploads/2010/04/classic-deviled-eggs-5-256x256.jpg"},
                new Lesson { Id = 10.ToString(), Title="French Omelette", ImageSource=ImageSource.FromFile("eggs.png"), Level=Difficulty.Medium,Tier=3,Category = Category.Egg, Completed=false, ExampleUrl="https://i2.wp.com/aspicyperspective.com/wp-content/uploads/2010/04/classic-deviled-eggs-5-256x256.jpg"},
                new Lesson { Id = 11.ToString(), Title="Mayonnaise", ImageSource=ImageSource.FromFile("eggs.png"), Level=Difficulty.Medium,Tier=4,Category = Category.Egg, Completed=false, ExampleUrl="https://i2.wp.com/aspicyperspective.com/wp-content/uploads/2010/04/classic-deviled-eggs-5-256x256.jpg"},
                new Lesson { Id = 12.ToString(), Title="Meringue Cookies", ImageSource=ImageSource.FromFile("eggs.png"), Level=Difficulty.Medium,Tier=4,Category = Category.Egg, Completed=false, ExampleUrl="https://i2.wp.com/aspicyperspective.com/wp-content/uploads/2010/04/classic-deviled-eggs-5-256x256.jpg"},
                new Lesson { Id = 13.ToString(), Title="Egg Custard", ImageSource=ImageSource.FromFile("eggs.png"), Level=Difficulty.Medium,Tier=5,Category = Category.Egg, Completed=false, ExampleUrl="https://i2.wp.com/aspicyperspective.com/wp-content/uploads/2010/04/classic-deviled-eggs-5-256x256.jpg"},

                new Lesson { Id = 14.ToString(), Title="Sandwich Bread", ImageSource=ImageSource.FromFile("bread.png"), Level=Difficulty.Easy,Tier=1, Category = Category.Bread, Completed=false, ExampleUrl="https://www.wholesomeyum.com/wp-content/uploads/2017/03/wholesomeyum_low-carb-bread-recipe-almond-flour-bread-paleo-gluten-free-2.jpg"},
                new Lesson { Id = 15.ToString(), Title="Marble Rye", ImageSource=ImageSource.FromFile("bread.png"), Level=Difficulty.Easy,Tier=1, Category = Category.Bread, Completed=false, ExampleUrl="https://www.wholesomeyum.com/wp-content/uploads/2017/03/wholesomeyum_low-carb-bread-recipe-almond-flour-bread-paleo-gluten-free-2.jpg"},
                new Lesson { Id = 16.ToString(), Title="Oat", ImageSource=ImageSource.FromFile("bread.png"), Level=Difficulty.Easy,Tier=2, Category = Category.Bread, Completed=false, ExampleUrl="https://www.wholesomeyum.com/wp-content/uploads/2017/03/wholesomeyum_low-carb-bread-recipe-almond-flour-bread-paleo-gluten-free-2.jpg"},
                new Lesson { Id = 17.ToString(), Title="Banana Bread", ImageSource=ImageSource.FromFile("bread.png"), Level=Difficulty.Medium,Tier=3, Category = Category.Bread, Completed=false, ExampleUrl="https://www.wholesomeyum.com/wp-content/uploads/2017/03/wholesomeyum_low-carb-bread-recipe-almond-flour-bread-paleo-gluten-free-2.jpg"},
                new Lesson { Id = 18.ToString(), Title="Croissant", ImageSource=ImageSource.FromFile("bread.png"), Level=Difficulty.Medium,Tier=4, Category = Category.Bread, Completed=false, ExampleUrl="https://www.wholesomeyum.com/wp-content/uploads/2017/03/wholesomeyum_low-carb-bread-recipe-almond-flour-bread-paleo-gluten-free-2.jpg"},
                new Lesson { Id = 19.ToString(), Title="Garlic Bread", ImageSource=ImageSource.FromFile("bread.png"), Level=Difficulty.Medium,Tier=5, Category = Category.Bread, Completed=false, ExampleUrl="https://www.wholesomeyum.com/wp-content/uploads/2017/03/wholesomeyum_low-carb-bread-recipe-almond-flour-bread-paleo-gluten-free-2.jpg"},
                new Lesson { Id = 20.ToString(), Title="French Toast", ImageSource=ImageSource.FromFile("bread.png"), Level=Difficulty.Easy,Tier=1,Category = Category.Bread, Completed=false, ExampleUrl="https://www.wholesomeyum.com/wp-content/uploads/2017/03/wholesomeyum_low-carb-bread-recipe-almond-flour-bread-paleo-gluten-free-2.jpg"},
                new Lesson { Id = 21.ToString(), Title="Baguette", ImageSource=ImageSource.FromFile("bread.png"), Level=Difficulty.Easy,Tier=2,Category = Category.Bread, Completed=false, ExampleUrl="https://www.wholesomeyum.com/wp-content/uploads/2017/03/wholesomeyum_low-carb-bread-recipe-almond-flour-bread-paleo-gluten-free-2.jpg"},
                new Lesson { Id = 22.ToString(), Title="Cinnamon Bun", ImageSource=ImageSource.FromFile("bread.png"), Level=Difficulty.Easy,Tier=1,Category = Category.Bread, Completed=false, ExampleUrl="https://www.wholesomeyum.com/wp-content/uploads/2017/03/wholesomeyum_low-carb-bread-recipe-almond-flour-bread-paleo-gluten-free-2.jpg"},
                new Lesson { Id = 23.ToString(), Title="Pretzel", ImageSource=ImageSource.FromFile("bread.png"), Level=Difficulty.Medium,Tier=1,Category = Category.Bread, Completed=false, ExampleUrl="https://www.wholesomeyum.com/wp-content/uploads/2017/03/wholesomeyum_low-carb-bread-recipe-almond-flour-bread-paleo-gluten-free-2.jpg"},
                new Lesson { Id = 24.ToString(), Title="Challah", ImageSource=ImageSource.FromFile("bread.png"), Level=Difficulty.Medium,Tier=3,Category = Category.Bread, Completed=false, ExampleUrl="https://www.wholesomeyum.com/wp-content/uploads/2017/03/wholesomeyum_low-carb-bread-recipe-almond-flour-bread-paleo-gluten-free-2.jpg"},
                new Lesson { Id = 25.ToString(), Title="Crackers", ImageSource=ImageSource.FromFile("bread.png"), Level=Difficulty.Medium,Tier=4,Category = Category.Bread, Completed=false, ExampleUrl="https://www.wholesomeyum.com/wp-content/uploads/2017/03/wholesomeyum_low-carb-bread-recipe-almond-flour-bread-paleo-gluten-free-2.jpg"},
                new Lesson { Id = 26.ToString(), Title="Sourdough", ImageSource=ImageSource.FromFile("bread.png"), Level=Difficulty.Medium,Tier=5,Category = Category.Bread, Completed=false, ExampleUrl="https://www.wholesomeyum.com/wp-content/uploads/2017/03/wholesomeyum_low-carb-bread-recipe-almond-flour-bread-paleo-gluten-free-2.jpg"},
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

        public async Task<IEnumerable<Lesson>> GetItemsByCategoryAsync(string category)
        {
            var res = items.FindAll(x => x.Category.ToString().Equals(category));
            return await Task.FromResult(res);
        }
    }
}