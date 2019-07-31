using System;
using System.Collections.Generic;
using CookingApp.ViewModels;
using Xamarin.Forms;

namespace CookingApp.Views
{
    public partial class LessonDetailPage : ContentPage
    {

        LessonDetailViewModel viewModel;

        public LessonDetailPage()
        {
            BindingContext = viewModel = new LessonDetailViewModel();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            RequestSelectedLesson();
        }

        private void RequestSelectedLesson()
        {
            MessagingCenter.Send(this, "RequestLessonId");
        }
    }
}
