using CookingApp.ViewModels;
using CookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CookingApp.Views.ContentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LessonIcon : ContentView
    {
        public LessonIcon(Lesson lesson)
        {
            BindingContext = new LessonIconViewModel(lesson);
            InitializeComponent();
        }
    }
}
