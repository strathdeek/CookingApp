using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CookingApp.Services;
using CookingApp.Views;

namespace CookingApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<LessonDataStore>();
            DependencyService.Register<RecipeDataStore>();
            DependencyService.Register<Profile>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
