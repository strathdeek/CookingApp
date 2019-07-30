using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using CookingApp.Models;
using CookingApp.Views;
using System.Collections.Generic;
using System.Linq;
using CookingApp.Data;
using CookingApp.Services;

namespace CookingApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        string _ItemId = "Nothing";
        public string ItemId
        {
            get { return _ItemId; }
            set { SetProperty(ref _ItemId, value); }
        }

        List<string> _CategoryList;
        public List<string> CategoryList
        {
            get { return _CategoryList; }
            set { SetProperty(ref _CategoryList, value); }
        }

        string _SelectedCategory;
        public string SelectedCategory
        {
            get { return _SelectedCategory; }
            set
            {
                SetProperty(ref _SelectedCategory, value);
                FetchLessons();

            }
        }
        public event EventHandler UpdateUI;

        public List<Lesson> Lessons { get; set; }

        public ItemsViewModel()
        {
            MessagingCenter.Subscribe<LessonIconViewModel, string>(this, "LessonClicked", NavigateToLesson);
            CategoryList = Enum.GetNames(typeof(Category)).ToList();
        }

        public void FetchLessons()
        {
            Lessons = (LessonDataStore as LessonDataStore).GetItemsByCategoryAsync(SelectedCategory).Result.ToList();
            UpdateUI.Invoke(null, new EventArgs());
        }

        public void NavigateToLesson(object sender, string arg)
        {
            Shell.Current.GoToAsync("lesson?lessonId={arg}");
        }


    }
}