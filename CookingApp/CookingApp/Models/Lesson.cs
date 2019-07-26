using MarksApp.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MarksApp.Models
{
    public class Lesson
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public Difficulty Level { get; set; }

        public ImageSource Image { get; set; }

        public int Tier { get; set; }
    }
}
