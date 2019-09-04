using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using RatingAndReview.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatingAndReview.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            MyMessage();
        }

        public void MyMessage()
        {
            Console.WriteLine("==================This is a Test From MainPageViewModel: " + RatingSlider.itemPosition);
        }
    }
}
