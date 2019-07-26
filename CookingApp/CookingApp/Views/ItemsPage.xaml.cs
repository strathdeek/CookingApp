using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MarksApp.Models;
using MarksApp.Views;
using MarksApp.ViewModels;
using MarksApp.Services;
using MarksApp.Views.ContentViews;

namespace MarksApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {

            BindingContext = viewModel = new ItemsViewModel();
            InitializeComponent();
            var lessons = viewModel.DataStore.GetItemsAsync().Result;
            foreach (var item in lessons)
            {
                LessonLayout.Children.Add(new LessonIcon(item) { WidthRequest=150 });
            }
        }

        
        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
    }
}