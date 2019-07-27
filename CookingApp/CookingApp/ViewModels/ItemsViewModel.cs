using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using CookingApp.Models;
using CookingApp.Views;

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
        public ItemsViewModel()
        {
            MessagingCenter.Subscribe<LessonIconViewModel,string>(this,"LessonClicked",(sender,arg)=>ItemId=arg);
            Shell.Current.GoToAsync("about");
        }

        
    }
}