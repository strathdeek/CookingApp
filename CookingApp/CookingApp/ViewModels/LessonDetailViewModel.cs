using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookingApp.Models;
using Xamarin.Forms;

namespace CookingApp.ViewModels
{
    public class LessonDetailViewModel : BaseViewModel
    {
        string _LessonId;
        public string LessonId
        {
            get { return _LessonId; }
            set { SetProperty(ref _LessonId, value); }
        }

        string _Difficulty;
        public string Difficulty
        {
            get { return _Difficulty; }
            set { SetProperty(ref _Difficulty, value); }
        }

        Lesson _ThisLesson;
        public Lesson ThisLesson
        {
            get { return _ThisLesson; }
            set
            {
                SetProperty(ref _ThisLesson, value);
            }
        }

        Command _NavigateToFeedCommand;
        public Command NavigateToFeedCommand
        {
            get { return _NavigateToFeedCommand; }
            set { SetProperty(ref _NavigateToFeedCommand, value); }
        }

        Command<string> _HandleRecipeTappedCommand;
        public Command<string> HandleRecipeTappedCommand
        {
            get { return _HandleRecipeTappedCommand; }
            set { SetProperty(ref _HandleRecipeTappedCommand, value); }
        }

        string _LessonTitle;
        public string LessonTitle
        {
            get { return _LessonTitle; }
            set { SetProperty(ref _LessonTitle, value); }
        }

        List<Recipe> _Recipes;
        public List<Recipe> Recipes
        {
            get { return _Recipes; }
            set { SetProperty(ref _Recipes, value); }
        }

        bool _IsWebViewVisible;
        public bool IsWebViewVisible
        {
            get { return _IsWebViewVisible; }
            set { SetProperty(ref _IsWebViewVisible, value); }
        }

        bool _IsDetailViewVisible;
        public bool IsDetailViewVisible
        {
            get { return _IsDetailViewVisible; }
            set { SetProperty(ref _IsDetailViewVisible, value); }
        }

        string _RecipeWebViewSource;
        public string RecipeWebViewSource
        {
            get { return _RecipeWebViewSource; }
            set { SetProperty(ref _RecipeWebViewSource, value); }
        }

        Command<string> _RecipeCompletedCommand;
        public Command<string> RecipeCompletedCommand
        {
            get { return _RecipeCompletedCommand; }
            set { SetProperty(ref _RecipeCompletedCommand, value); }
        }

        public LessonDetailViewModel()
        {
            NavigateToFeedCommand = new Command(NavigateToFeed);
            HandleRecipeTappedCommand = new Command<string>(HandleRecipeTapped);
            RecipeCompletedCommand = new Command<string>(RecipeCompleted);
            IsDetailViewVisible = true;
            IsWebViewVisible = false;
            MessagingCenter.Subscribe<ItemsViewModel, string>(this, "SendLessonId", SetLesson);
        }

        

        public void SetLesson(object sender, string arg)
        {
            ThisLesson = LessonDataStore.GetItemAsync(arg).Result;
            LessonTitle = ThisLesson.Title;
            Difficulty = ThisLesson.Level.ToString();
            FetchRecipes(LessonId);
        }

        public void FetchRecipes(string id)
        {
            Recipes = (RecipeDataStore as Services.RecipeDataStore).GetItemsAsync().Result.ToList();
        }

        public void NavigateToFeed(object sender)
        {
            Shell.Current.GoToAsync("//feed/tree");
        }

        private void HandleRecipeTapped(string obj)
        {
            IsDetailViewVisible = false;
            IsWebViewVisible = true;
            RecipeWebViewSource = obj;
        }

        private void RecipeCompleted(string id)
        {

        }

    }
}
