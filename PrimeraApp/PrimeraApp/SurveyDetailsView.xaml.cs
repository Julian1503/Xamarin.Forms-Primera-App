using PrimeraApp.Models;
using PrimeraApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PrimeraApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class SurveyDetailsView : ContentPage
    {
        public SurveyDetailsView()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<SurveyDetailsViewModel,Survey>(this,"SaveSurvey", async (a,s)=> 
            {
                await Navigation.PopModalAsync();
            });

        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<SurveyDetailsViewModel, Survey>(this, "SaveSurvey");
        }
    }
}