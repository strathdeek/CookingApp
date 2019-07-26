using System;
using System.Collections.Generic;
using System.Linq;
using CookingApp.Models;
using Xamarin.Forms;

namespace CookingApp.Views.ContentViews
{
    public class LessonTier : ContentView
    {
        public LessonTier(List<Lesson> lessons)
        {
            Label tierHeader = new Label
            {
                Text = "Level " + lessons.FirstOrDefault().Tier.ToString()
            };

            BoxView divider = new BoxView
            {
                HeightRequest = 1,
                Color = Color.Black,
                HorizontalOptions = LayoutOptions.EndAndExpand
            };

            StackLayout headerContainer = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            headerContainer.Children.Add(tierHeader);
            headerContainer.Children.Add(divider);

            Grid lessonContainer = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(.5, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(.5, GridUnitType.Star) }
                }
            };

            int position = 0;
            foreach (var lesson in lessons)
            {
                lessonContainer.Children.Add(new LessonIcon(lesson), position, 0);
                position = position == 0 ? 1 : 0;
            }

            Content = new Label { Text = "Hello ContentView" };
        }
    }
}

