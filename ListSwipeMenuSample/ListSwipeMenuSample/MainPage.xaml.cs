using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Diagnostics;

namespace ListSwipeMenuSample
{
    public partial class MainPage : PhoneApplicationPage
    {
        private Canvas _tickAndCrossContainer;
        private double FlickVelocity = 2000.0;
        private List<Page> _pages;
        private object _sendertemp;

        Page _selecteditem;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            _pages = new List<Page>();

            _pages.Add(new Page() { Title = "Satu" });
            _pages.Add(new Page() { Title = "Dua" });
            _pages.Add(new Page() { Title = "Tiga" });
            _pages.Add(new Page() { Title = "Empat" });
            _pages.Add(new Page() { Title = "Lima" });
            _pages.Add(new Page() { Title = "Enam" });
            _pages.Add(new Page() { Title = "Tujuh" });
            _pages.Add(new Page() { Title = "Delapan" });
            _pages.Add(new Page() { Title = "Sembilan" });
            _pages.Add(new Page() { Title = "Sepuluh" });

            pagelist.ItemsSource = _pages;

            base.OnNavigatedTo(e);
        }

        private void GestureListener_DragDelta(object sender, DragDeltaGestureEventArgs e)
        {
            SwipeMenu.DragDelta(sender, e);            
        }

        private void GestureListener_DragCompleted(object sender, DragCompletedGestureEventArgs e)
        {
            SwipeMenu.DragCompleted(sender, e);
        }

        private void GestureListener_Flick(object sender, FlickGestureEventArgs e)
        {
            SwipeMenu.Flick(sender, e);
        }

        private void GestureListener_Hold(object sender, Microsoft.Phone.Controls.GestureEventArgs e)
        {
            if (_sendertemp != null)
            {
                FrameworkElement fe = _sendertemp as FrameworkElement;
                SwipeMenu.MenuBounceBack(fe);
            }

            _sendertemp = sender;

            SwipeMenu.Hold(sender, e);
        }

        private void GestureListener_DragStarted(object sender, DragStartedGestureEventArgs e)
        {
            _selecteditem = pagelist.SelectedItem as Page;

            if(_sendertemp!= null)
            {
                FrameworkElement fe = _sendertemp as FrameworkElement;
                SwipeMenu.MenuBounceBack(fe);
            }

            _sendertemp = sender;
        }

        private void Button1Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (_selecteditem != null)
            {
                MessageBox.Show("Button 1 of " + _selecteditem.Title + " Tapped...");
            }
        }

        private void Button2Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (_selecteditem != null)
            {
                MessageBox.Show("Button 2 of " + _selecteditem.Title + " Tapped...");
            }
        }

        private void ItemTapped(object sender, Microsoft.Phone.Controls.GestureEventArgs e)
        {
            _selecteditem = pagelist.SelectedItem as Page;

            if(_selecteditem != null)
            {
                MessageBox.Show(_selecteditem.Title + " Tapped...");
            }
            
        }

    }

    public class Page 
    {
        public string Title { get; set; }
    }
}