using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CookingApp.Views.ContentViews
{
    public partial class HeaderIcon : ContentView
    {
        public static BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(HeaderIcon), Color.Black);

        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public static BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(string), typeof(HeaderIcon), string.Empty);

        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static BindableProperty LevelProperty = BindableProperty.Create(nameof(Level), typeof(int), typeof(HeaderIcon), 0);

        public int Level
        {
            get => (int)GetValue(LevelProperty);
            set => SetValue(LevelProperty, value);
        }

        public HeaderIcon()
        {
            InitializeComponent();
        }
    }
}
