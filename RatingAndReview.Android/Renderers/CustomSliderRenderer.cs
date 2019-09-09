using Android.Content;
using Android.Views;
using RatingAndReview.Controls;
using RatingAndReview.Droid.Renderers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(RatingSlider),typeof(CustomSliderRenderer))]
namespace RatingAndReview.Droid.Renderers
{
    public class CustomSliderRenderer : ViewRenderer
    {
        /// <summary>
        /// Constructor That solves the compatibility problem with the ViewRenderer in Android.
        /// </summary>
        /// <param name="context">Context that is needed as a parameter.</param>
        public CustomSliderRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            var touchX = e.GetX();
            var touchY = e.GetY();

            var slider = (Element as RatingSlider);

            int numberOfItems = slider.Children.Count;
            double columnSpacing = slider.ColumnSpacing;
            double itemWidth = (this.Width - (columnSpacing * (numberOfItems - 1))) / numberOfItems;

            double p = 0;
            double k = itemWidth;

            System.Diagnostics.Debug.WriteLine($"=============================================");
            System.Diagnostics.Debug.WriteLine($"Touch: {touchX}");
            System.Diagnostics.Debug.WriteLine($"ItemWidth: {itemWidth}");


            for (double i = 1, j = 0; i <= numberOfItems; i++, j = j + columnSpacing)
            {
                if ((touchX >= (p + j)) && (touchX <= (k + j)))
                {
                    slider.SetSelectedPosition((int)i);
                    slider.SetBackgroundColorPosition((int)i);

                    if (touchX < (k + j))
                    {
                        double iBeforeRealSelectedPosition = --i;
                        System.Diagnostics.Debug.WriteLine($"i: {iBeforeRealSelectedPosition}");
                        double positionRest = (k + j) - touchX;
                        System.Diagnostics.Debug.WriteLine($"Difference: {positionRest}");
                        double percentageToPaint = 100 - ((positionRest * 100) / 203.6);
                        System.Diagnostics.Debug.WriteLine($"Percentage to paint: {percentageToPaint}");
                        double realSelectedPosition = Math.Round( iBeforeRealSelectedPosition + (percentageToPaint / 100), 1);
                        System.Diagnostics.Debug.WriteLine($"Percentage to paint: {realSelectedPosition}");
                    }

                    break;
                }
                p = k;
                k = itemWidth * (i + 1);
            }

            return true;
        }

        public override bool OnInterceptTouchEvent(MotionEvent ev)
        {
            return true;
        }
    }
}