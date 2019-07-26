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
    public partial class LessonIcon : ContentView
    {

        public Lesson ThisLesson { get; set; }

        public ImageSource IconImageSource { get; set; }

        public string LessonTitle { get; set; }

        public LessonIcon(Lesson lesson)
        {
            LessonTitle = lesson.Title;
            IconImageSource = lesson.Image ?? ImageSource.FromFile()
            InitializeComponent();
            
        }
    }
}
