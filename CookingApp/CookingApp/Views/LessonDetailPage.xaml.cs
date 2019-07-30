using System;
using System.Collections.Generic;
using CookingApp.ViewModels;
using Xamarin.Forms;

namespace CookingApp.Views
{
    [QueryProperty("LessonId", "lessonId")]
    public partial class LessonDetailPage : ContentPage
    {
        public string LessonId { get; set; }

        LessonDetailViewModel viewModel;

        public LessonDetailPage()
        {
            BindingContext = viewModel = new LessonDetailViewModel(LessonId);
            InitializeComponent();
            textbox.Text = LessonId ?? "Select a Lesson on the Main Tab!";
        }
    }
}
