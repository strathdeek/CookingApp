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
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(5,0,0,0)
            };

            StackLayout headerContainer = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand
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

            StackLayout leftStack = new StackLayout
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            StackLayout rightStack = new StackLayout
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            lessonContainer.Children.Add(leftStack, 0, 0);
            lessonContainer.Children.Add(rightStack, 1, 0);

            int position = 0;

            foreach (var lesson in lessons)
            {
                if (position == 0)
                {
                    leftStack.Children.Add(new LessonIcon(lesson));
                    position = 1;
                }
                else
                {
                    rightStack.Children.Add(new LessonIcon(lesson));
                    position = 0;
                }
            }

            StackLayout contentStack = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            contentStack.Children.Add(headerContainer);
            contentStack.Children.Add(lessonContainer);

            Content = contentStack;
        }
    }
}

