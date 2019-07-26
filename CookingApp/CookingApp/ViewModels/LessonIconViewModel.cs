using System;
using CookingApp.Models;
using CookingApp.ViewModels;
using Xamarin.Forms;

namespace CookingApp.ViewModels
{
    public class LessonIconViewModel : BaseViewModel
    {
        
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
        }
    }
}
