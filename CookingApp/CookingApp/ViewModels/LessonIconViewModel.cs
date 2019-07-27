using System;
using CookingApp.Models;
using CookingApp.ViewModels;
using Xamarin.Forms;

namespace CookingApp.ViewModels
{
    public class LessonIconViewModel : BaseViewModel
    {
        public Lesson ThisLesson { get; set; }

        Command _NavigateToRecipeCommand;
        public Command NavigateToRecipeCommand
        {
            get { return _NavigateToRecipeCommand; }
            set { SetProperty(ref _NavigateToRecipeCommand, value); }
        }

        ImageSource iconImageSource;
        public ImageSource IconImageSource
        {
            get { return iconImageSource; }
            set { SetProperty(ref iconImageSource, value); }
        }


        string _LessonTitle;
        public string LessonTitle
        {
            get { return _LessonTitle; }
            set { SetProperty(ref _LessonTitle, value); }
        }

        public LessonIconViewModel(Lesson lesson)
        {
            LessonTitle = lesson.Title;
            IconImageSource = lesson.ImageSource;
            ThisLesson = lesson;
            NavigateToRecipeCommand = new Command(NavigateToRecipe);
        }

        public void NavigateToRecipe()
        {
            Console.WriteLine("Here");
            MessagingCenter.Send<LessonIconViewModel, string>(this, "LessonClicked", ThisLesson.Id);
            Console.WriteLine("Here");
        }
    }
}
