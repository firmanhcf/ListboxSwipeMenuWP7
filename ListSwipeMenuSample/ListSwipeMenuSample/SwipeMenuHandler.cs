using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace ListSwipeMenuSample
{
    public static class SwipeMenu
    {
        private const double FlickVelocity = 1000.0;

        public static void DragDelta(object sender, DragDeltaGestureEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            double offset = fe.GetHorizontalOffset().Value + e.HorizontalChange;

            if (e.HorizontalChange < 0.0)
            {
                if (offset > -258)
                {
                    fe.SetHorizontalOffset(offset);
                }
            }
            else
            {
                if (offset <= 0)
                {
                    fe.SetHorizontalOffset(offset);
                }
            }
        }

        public static void DragCompleted(object sender, DragCompletedGestureEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            double offset = fe.GetHorizontalOffset().Value + e.HorizontalChange;

            if (e.HorizontalChange < 0.0)
            {
                if (offset < -125)
                {
                    MenuOpen(fe);
                }
                else
                {
                    MenuBounceBack(fe);
                }
            }
            else
            {
                if (offset < -195)
                {
                    MenuOpen(fe);
                }
                else
                {
                    MenuBounceBack(fe);
                }
            }
        }

        public static void Flick(object sender, FlickGestureEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            double offset = fe.GetHorizontalOffset().Value;

            if (e.HorizontalVelocity < -FlickVelocity)
            {
                MenuOpen(fe);
            }
            else if (e.HorizontalVelocity > FlickVelocity)
            {
                MenuBounceBack(fe);
            }
        }

        public static void Hold(object sender, Microsoft.Phone.Controls.GestureEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            double offset = fe.GetHorizontalOffset().Value;

            if (offset >= 0)
            {
                MenuOpen(fe);
            }
            else
            {
                MenuBounceBack(fe);
            }
        }

        public static void MenuOpen(FrameworkElement fe)
        {
            var trans = fe.GetHorizontalOffset().Transform;

            trans.Animate(trans.X, -258, TranslateTransform.XProperty, 300, 0, new QuadraticEase());
        }

        public static void MenuBounceBack(FrameworkElement fe)
        {
            var trans = fe.GetHorizontalOffset().Transform;

            trans.Animate(trans.X, 0, TranslateTransform.XProperty, 300, 0, new QuadraticEase());
        }

    }
}
