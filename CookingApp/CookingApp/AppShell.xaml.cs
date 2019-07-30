using System;
using System.Collections.Generic;
using CookingApp.Views;
using Xamarin.Forms;

namespace CookingApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("lesson", typeof(LessonDetailPage));
;        }
    }
}
