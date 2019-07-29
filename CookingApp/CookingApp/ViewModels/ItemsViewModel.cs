using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using CookingApp.Models;
using CookingApp.Views;
using System.Collections.Generic;
using System.Linq;

namespace CookingApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        string _ItemId = "Nothing";
        public string ItemId
        {
            get { return _ItemId; }
            set { SetProperty(ref _ItemId, value); }
        }

        public event EventHandler UpdateUI;

        public List<Lesson> Lessons { get; set; }

        public ItemsViewModel()
        {
            MessagingCenter.Subscribe<LessonIconViewModel,string>(this,"LessonClicked",(sender,arg)=>ItemId=arg);
        }

        public void FetchLessons()
        {
            Lessons = LessonDataStore.GetItemsAsync().Result.ToList();
            UpdateUI.Invoke(null, new EventArgs());
        }


    }
}