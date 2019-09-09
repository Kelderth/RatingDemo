using Prism.Navigation;
using Prism.Services;
using System;
using System.Threading.Tasks;

namespace RatingAndReview.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private int _selectedPosition;

        public int SelectedPosition
        {
            get { return _selectedPosition; }
            set
            {
                SetProperty(ref _selectedPosition, value);
                Console.Write($"\r\n=== Selected Position: {_selectedPosition} ===\r\n");
                //RatingSelected(_selectedPosition);
            }
        }

        private int _numberOfItems;

        public int NumberOfItems
        {
            get { return _numberOfItems; }
            set { _numberOfItems = value; }
        }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
            Title = "Main Page";
            _numberOfItems = 5;
        }

        public void RatingSelected(int ratingSelected)
        {
            DialogService.DisplayAlertAsync("Rating & Review", $"Your rating choice was: {ratingSelected.ToString()}", "OK");
        }

    }
}