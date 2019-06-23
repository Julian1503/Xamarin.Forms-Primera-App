using PrimeraApp.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrimeraApp.ViewModels
{
    public class MainPageViewModel : NotifyObject
    {
        private ObservableCollection<Survey> _surveys;

        public ObservableCollection<Survey> Surveys
        {
            get { return _surveys; }
            set
            {
                _surveys = value;
                OnPropertyChanged();
            }
        }
        public ICommand AddCommand { get; set; }

        public MainPageViewModel()
        {
            Surveys = new ObservableCollection<Survey>();
            AddCommand = new Command(AddComamandExecution);

            MessagingCenter.Subscribe<SurveyDetailsViewModel, Survey>(this, "SaveSurvey", (a, s) =>
            {
                Surveys.Add(s);
            });
        }

        private void AddComamandExecution()
        {
            MessagingCenter.Send(this, "AddSurvey");
        }
    }
}
