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
        public int MinTier { get; set; }
        public int MaxTier { get; set; }

        public LessonTree(List<Lesson> lessons)
        {
            InitializeComponent();
            MinTier = lessons.Min(x => x.Tier);
            MaxTier = lessons.Max(x => x.Tier);

            for (int i = MinTier; i <= MaxTier; i++)
            {
                MainStack.Children.Add(new LessonTier(lessons.FindAll(x => x.Tier == i)));
            }
        }
    }
}