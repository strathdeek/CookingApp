using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CookingApp.Models;
using CookingApp.Views;
using CookingApp.ViewModels;
using CookingApp.Services;
using CookingApp.Views.ContentViews;
using CookingApp.Data;

namespace CookingApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        public Command Focus_Lesson_Picker_Command { get; set; }
        public ItemsPage()
        {
            BindingContext = viewModel = new ItemsViewModel();
            Focus_Lesson_Picker_Command = new Command(FocusLessonPickerButton);
            viewModel.UpdateUI += HandleUIUpdate;
            InitializeComponent();
        }

        private void FocusLessonPickerButton(object obj)
        {
            picker.Focus();
            buttonPicker.IsVisible = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        public void HandleUIUpdate(object sender, EventArgs e)
        {
            LessonLayout.Children.Clear();
            LessonLayout.Children.Add(new LessonTree(viewModel.Lessons));
        }

        void Focus_Lesson_Picker(object sender, EventArgs args)
        {
            picker.Focus();
        }
    }
}