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
        Recipe _SelectedRecipe;
        public Recipe SelectedRecipe
        {
            get { return _SelectedRecipe; }
            set { SetProperty(ref _SelectedRecipe, value); }
        }

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

        Command _RecipeCompletedCommand;
        public Command RecipeCompletedCommand
        {
            get { return _RecipeCompletedCommand; }
            set { SetProperty(ref _RecipeCompletedCommand, value); }
        }

        Command _NavigateToProfileCommand;
        public Command NavigateToProfileCommand
        {
            get { return _NavigateToProfileCommand; }
            set { SetProperty(ref _NavigateToProfileCommand, value); }
        }

        string _ExamplePictureUrl;
        public string ExamplePictureUrl
        {
            get { return _ExamplePictureUrl; }
            set { SetProperty(ref _ExamplePictureUrl, value); }
        }

        public LessonDetailViewModel()
        {
            NavigateToFeedCommand = new Command(NavigateToFeed);
            HandleRecipeTappedCommand = new Command<string>(HandleRecipeTapped);
            RecipeCompletedCommand = new Command(RecipeCompleted);
            NavigateToProfileCommand = new Command(NavigateToProfile);
            IsDetailViewVisible = true;
            IsWebViewVisible = false;
            LessonTitle = "Select A Lesson!";
            Difficulty = "N/A";
            MessagingCenter.Subscribe<ItemsViewModel, string>(this, "SendLessonId", SetLesson);
        }

        

        public void SetLesson(object sender, string arg)
        {
            if (string.IsNullOrEmpty(arg)) return;
            ThisLesson = LessonDataStore.GetItemAsync(arg).Result;
            LessonTitle = ThisLesson.Title;
            Difficulty = ThisLesson.Level.ToString();
            ExamplePictureUrl = ThisLesson.ExampleUrl;
            FetchRecipes(LessonId);
        }

        public void FetchRecipes(string id)
        {
            Recipes = (RecipeDataStore as Services.RecipeDataStore).GetItemsAsync().Result.OrderByDescending(x => x.Rating).ToList();
        }

        public void NavigateToFeed(object sender)
        {
            Shell.Current.GoToAsync("//feed/tree");
        }

        public void NavigateToProfile(object sender)
        {
            Shell.Current.GoToAsync("//account/profile");
        }

        private void HandleRecipeTapped(string obj)
        {
            SelectedRecipe = RecipeDataStore.GetItemAsync(obj).Result;
            IsDetailViewVisible = false;
            IsWebViewVisible = true;
            RecipeWebViewSource = SelectedRecipe.RecipeUrl;
        }

        private void RecipeCompleted()
        {
            ThisLesson.Completed = true;
            LessonDataStore.UpdateItemAsync(ThisLesson);
            MessagingCenter.Send(this, "RefreshFeed");
            IsDetailViewVisible = true;
            IsWebViewVisible = false;
            Shell.Current.GoToAsync("//feed/tree");
        }

    }
}
