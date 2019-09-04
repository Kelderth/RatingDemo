using System;
using System.Linq;
using CoreGraphics;
using Foundation;
using RatingAndReview.Controls;
using RatingAndReview.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RatingSlider), typeof(CustomSliderRenderer))]
namespace RatingAndReview.iOS.Renderers
{
    public class CustomSliderRenderer : ViewRenderer
    {
        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
            OnTouchElement(touches, evt);
        }

        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            base.TouchesMoved(touches, evt);
            OnTouchElement(touches, evt);
        }

        private void OnTouchElement(NSSet touches, UIEvent evt)
        {
            var slider = (Element as RatingSlider);
            var t = evt.AllTouches.Last() as UITouch;
            CGPoint location = t.LocationInView(this);

            int numberOfItems = slider.Children.Count;
            double s = slider.ColumnSpacing;
            double w = (this.Bounds.Width - (s * (numberOfItems - 1))) / numberOfItems;

            double p = 0;
            double k = w;

            for (double i = 0, j = 0; i <= numberOfItems; i++, j = j + s)
            {
                if ((location.X >= (p + j)) && (location.X <= (k + j)))
                {
                    slider.SetSelectedPosition((int)i);
                    slider.SetBackgroundColorPosition((int)i);
                    break;
                }
                p = k;
                k = w * (i + 1);
            }
        }
    }

}