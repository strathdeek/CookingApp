using CookingApp.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CookingApp.Models
{
    public class Lesson
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public Difficulty Level { get; set; }

        public ImageSource ImageSource { get; set; }

        public int Tier { get; set; }

        public Category Category { get; set; }
    }
}
