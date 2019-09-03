using Android.Content;
using Android.Views;
using RatingAndReview.Controls;
using RatingAndReview.Droid.Renderers;
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
            double s = slider.ColumnSpacing;
            double w = (this.Width - (s * (numberOfItems - 1))) / numberOfItems;

            System.Diagnostics.Debug.WriteLine($"{touchX}");

            double p = 0;
            double k = w;

            for (double i = 1, j = 0; i <= numberOfItems; i++, j = j + s)
            {
                if ((touchX >= (p + j)) && (touchX <= (k + j)))
                {
                    slider.SetSelectedPosition((int)i);
                    System.Diagnostics.Debug.WriteLine($"{i}");
                    break;
                }
                p = k;
                k = w * (i + 1);
            }

            return true;
        }

        public override bool OnInterceptTouchEvent(MotionEvent ev)
        {
            return true;
        }
    }
}