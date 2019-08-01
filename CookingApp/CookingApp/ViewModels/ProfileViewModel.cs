using System;
using System.Collections.Generic;
using System.Linq;
using CookingApp.Models;
using Xamarin.Forms;

namespace CookingApp.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { SetProperty(ref _UserName, value); }
        }

        Command _NavigateToFeedCommand;
        public Command NavigateToFeedCommand
        {
            get { return _NavigateToFeedCommand; }
            set { SetProperty(ref _NavigateToFeedCommand, value); }
        }

        bool _IsGuestUser;
        public bool IsGuestUser
        {
            get { return _IsGuestUser; }
            set { SetProperty(ref _IsGuestUser, value); }
        }

        string _EntryName;
        public string EntryName
        {
            get { return _EntryName; }
            set { SetProperty(ref _EntryName, value); }
        }

        string _EntryPassword;
        public string EntryPassword
        {
            get { return _EntryPassword; }
            set { SetProperty(ref _EntryPassword, value); }
        }

        string _EntryEmail;
        public string EntryEmail
        {
            get { return _EntryEmail; }
            set { SetProperty(ref _EntryEmail, value); }
        }

        string _Email;
        public string Email
        {
            get { return _Email; }
            set { SetProperty(ref _Email, value); }
        }

        Command _SignUpCommand;
        public Command SignUpCommand
        {
            get { return _SignUpCommand; }
            set { SetProperty(ref _SignUpCommand, value); }
        }

        int _LessonsCompleted;
        public int LessonsCompleted
        {
            get { return _LessonsCompleted; }
            set { SetProperty(ref _LessonsCompleted, value); }
        }

        int _TotalLessons;
        public int TotalLessons
        {
            get { return _TotalLessons; }
            set { SetProperty(ref _TotalLessons, value); }
        }

        double _LessonProgress;
        public double LessonProgress
        {
            get { return _LessonProgress; }
            set { SetProperty(ref _LessonProgress, value); }
        }

        string _ProgressDisplayString;
        public string ProgressDisplayString
        {
            get { return _ProgressDisplayString; }
            set { SetProperty(ref _ProgressDisplayString, value); }
        }

        bool _DisplayProfileScreen;
        public bool DisplayProfileScreen
        {
            get { return _DisplayProfileScreen; }
            set { SetProperty(ref _DisplayProfileScreen, value); }
        }

        List<Lesson> _Lessons;
        public List<Lesson> Lessons
        {
            get { return _Lessons; }
            set { SetProperty(ref _Lessons, value); }
        }



        public ProfileViewModel()
        {
            NavigateToFeedCommand = new Command(NavigateToFeed);
            SignUpCommand = new Command(SignUp);
            SetUser();
        }

        public void SetUser()
        {
            UserName = UserProfile.Name;
            IsGuestUser = UserProfile.IsGuestUser;
            DisplayProfileScreen = !IsGuestUser;
            Email = UserProfile.Email;
        }

        public void SignUp()
        {
            UserProfile.Email = EntryEmail;
            UserProfile.Name = EntryName;
            UserProfile.Password = EntryPassword;
            UserProfile.IsGuestUser = false;
            SetUser();
        }

        private void NavigateToFeed(object obj)
        {
            Shell.Current.GoToAsync("//feed/tree");
        }

        public void CalculateProgress()
        {
            var lessons = LessonDataStore.GetItemsAsync().Result.ToList();
            LessonsCompleted = lessons.Count(x => x.Completed);
            TotalLessons = lessons.Count();
            Lessons = lessons.FindAll(x => x.Completed).ToList();
            LessonProgress = (double)LessonsCompleted / TotalLessons;
            ProgressDisplayString = string.Format("Lessons Completed: {0}/{1}", LessonsCompleted,TotalLessons);
        }
    }
}
