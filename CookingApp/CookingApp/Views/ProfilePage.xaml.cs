using System;
using System.Collections.Generic;
using CookingApp.ViewModels;
using Xamarin.Forms;

namespace CookingApp.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfileViewModel viewModel { get; set; }

        public ProfilePage()
        {
            BindingContext = viewModel = new ProfileViewModel();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.CalculateProgress();
        }
    }
}
