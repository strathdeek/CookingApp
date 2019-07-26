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
    public partial class LessonTree : ContentView
    {
        public string TierTitle { get; set; }
        public LessonTree(List<Lesson> lessons)
        {
            //lessons
        }
    }
}