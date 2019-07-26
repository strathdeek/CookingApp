using MarksApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarksApp.Views.ContentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LessonTree : ContentView
    {
        public string TierTitle { get; set; }
        public LessonTree(List<Lesson> lessons)
        {
            BindingContext = this;
            TierTitle ="Level " + lessons.FirstOrDefault().Tier.ToString();
        }

        private StackLayout CreateTier(List<Lesson> lessons)
        {
            
            StackLayout TierStack = new StackLayout() { Orientation = StackOrientation.Horizontal };
        }
    }
}