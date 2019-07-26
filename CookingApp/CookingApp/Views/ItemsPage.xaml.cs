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

        public ItemsPage()
        {
            BindingContext = viewModel = new ItemsViewModel();
            var lessons = viewModel.DataStore.GetItemsAsync().Result;
            InitializeComponent();
            LessonLayout.Children.Add(new LessonIcon(new Lesson { Id = Guid.NewGuid().ToString(), Title = "Chicken", ImageSource = ImageSource.FromUri(new Uri("https://s3.amazonaws.com/pix.iemoji.com/images/emoji/apple/ios-12/256/egg.png")), Level = Difficulty.Easy, Tier = 1 }));
        }



        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
    }
}