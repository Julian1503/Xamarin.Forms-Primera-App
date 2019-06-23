using PrimeraApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrimeraApp.ViewModels
{
    public class SurveyDetailsViewModel: NotifyObject
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        private string _favoriteFood;

        public string FavoriteFood
        {
            get { return _favoriteFood; }
            set
            {
                _favoriteFood = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; set; }

        public SurveyDetailsViewModel()
        {
            SaveCommand = new Command(() =>
            {
                var newSurvey = new Survey()
                {
                    Name=this.Name,
                    FavoriteFood=this.FavoriteFood
                };
                MessagingCenter.Send(this, "SaveSurvey",newSurvey);
            });
            
        }
    }
}
