﻿using System;
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
                new Lesson { Id = Guid.NewGuid().ToString(), Title="Chicken", ImageSource=ImageSource.FromFile("DefaultIcon.jpg"), Level=Difficulty.Easy,Tier=1},
                new Lesson { Id = Guid.NewGuid().ToString(), Title="Steak", ImageSource=ImageSource.FromFile("DefaultIcon.jpg"), Level=Difficulty.Easy,Tier=2},
                new Lesson { Id = Guid.NewGuid().ToString(), Title="Lasagna", ImageSource=ImageSource.FromFile("DefaultIcon.jpg"), Level=Difficulty.Easy,Tier=3},
                new Lesson { Id = Guid.NewGuid().ToString(), Title="Pie", ImageSource=ImageSource.FromFile("DefaultIcon.jpg"), Level=Difficulty.Easy,Tier=4},
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