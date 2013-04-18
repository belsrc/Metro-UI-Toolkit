// -------------------------------------------------------------------------------
//    SimplePager.xaml.cs
//    Copyright (c) 2012-2013 Bryan Kizer
//    All rights reserved.
//    https://github.com/belsrc/Metro-UI-Toolkit
//
//    Redistribution and use in source and binary forms, with or without
//    modification, are permitted provided that the following conditions are
//    met:
//
//    Redistributions of source code must retain the above copyright notice,
//    this list of conditions and the following disclaimer.
//
//    Redistributions in binary form must reproduce the above copyright notice,
//    this list of conditions and the following disclaimer in the documentation
//    and/or other materials provided with the distribution.
//
//    Neither the name of the Organization nor the names of its contributors
//    may be used to endorse or promote products derived from this software
//    without specific prior written permission.
//
//    THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS
//    IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED
//    TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
//    PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
//    HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
//    SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED
//    TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
//    PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
//    LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
//    NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
//    SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// -------------------------------------------------------------------------------
namespace MetroUiToolkit {
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for SimplePager.xaml
    /// </summary>
    /// <remarks>
    /// Public Properties:
    ///     CurrentPage : int
    ///     PageCount   : int
    /// 
    /// Public Event
    ///     PageChanged : Bubble
    /// </remarks>
    public partial class SimplePager : UserControl {
        private string _selected;

        /// <summary>
        /// Initializes a new instance of the SimplePager class.
        /// </summary>
        public SimplePager() {
            InitializeComponent();
            this._selected = "btnFirst";
        }

        /* Event
           ---------------------------------------------------------------------------------------*/

        /// <summary>
        /// Adds or removes the event handler for the PageChanged event.
        /// </summary>
        public event RoutedEventHandler PageChanged {
            add { AddHandler( PageChangedEvent, value ); }
            remove { RemoveHandler( PageChangedEvent, value ); }
        }

        /// <summary>
        /// Routed event register for the PageChanged event.
        /// </summary>
        public static readonly RoutedEvent PageChangedEvent =
            EventManager.RegisterRoutedEvent( "PageChanged",
                                              RoutingStrategy.Bubble,
                                              typeof( RoutedEventHandler ),
                                              typeof( SimplePager )
                                            );

        /* Properties
           ---------------------------------------------------------------------------------------*/

        /// <summary>
        /// Gets or sets the current page number.
        /// </summary>
        public int CurrentPage {
            get { return ( int )GetValue( CurrentPageProperty ); }
            set { SetValue( CurrentPageProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for CurrentPage.
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register( "CurrentPage",
                                         typeof( int ),
                                         typeof( SimplePager ),
                                         new PropertyMetadata(
                                             1,
                                             new PropertyChangedCallback( CurrentPageChanged ) )
                                       );

        /// <summary>
        /// Gets or sets the current page number.
        /// </summary>
        public int PageCount {
            get { return ( int )GetValue( PageCountProperty ); }
            set { SetValue( PageCountProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for CurrentPage.
        /// </summary>
        public static readonly DependencyProperty PageCountProperty =
            DependencyProperty.Register( "PageCount",
                                         typeof( int ),
                                         typeof( SimplePager ),
                                         new PropertyMetadata( 
                                             1,
                                             new PropertyChangedCallback(PageCountChanged) )
                                       );

        // TODO : ActiveColor DP ?

        // TODO : InactiveColor DP ?

        /* Event Handlers
           ---------------------------------------------------------------------------------------*/

        private static void CurrentPageChanged( DependencyObject d, DependencyPropertyChangedEventArgs e ) {
            SimplePager page = d as SimplePager;
            page.svgBack.Visibility = page.CurrentPage == 1 ? Visibility.Hidden : Visibility.Visible;
            page.svgForward.Visibility = page.CurrentPage == page.PageCount ? Visibility.Hidden : Visibility.Visible;
            page.RaiseEvent( new RoutedEventArgs( PageChangedEvent, page ) );
        }

        private static void PageCountChanged( DependencyObject d, DependencyPropertyChangedEventArgs e ) {
            SimplePager page = d as SimplePager;
            page.CurrentPage = 1;
            page.SetSelected( page.btnFirst );
        }

        private void Button_MouseEnter( object sender, MouseEventArgs e ) {
            var color = new SolidColorBrush( Color.FromArgb( 255, 27, 161, 226 ) );
            var btn = sender as Button;

            if( !IsSelected( btn ) ) {
                btn.Background = Brushes.Transparent;
                btn.Foreground = color;
                btn.BorderBrush = color;
            }
        }

        private void Button_MouseLeave( object sender, MouseEventArgs e ) {
            var color = new SolidColorBrush( Color.FromArgb( 255, 137, 137, 137 ) );
            var btn = sender as Button;

            if( !IsSelected( btn ) ) {
                btn.Background = Brushes.Transparent;
                btn.Foreground = color;
                btn.BorderBrush = color;
            }
        }

        private void Svg_MouseEnter( object sender, MouseEventArgs e ) {
            var can = sender as Canvas;
            ( can.Children[ 0 ] as Path ).Fill = new SolidColorBrush( Color.FromArgb( 255, 27, 161, 226 ) );
        }

        private void Svg_MouseLeave( object sender, MouseEventArgs e ) {
            var can = sender as Canvas;
            ( can.Children[ 0 ] as Path ).Fill = new SolidColorBrush( Color.FromArgb( 255, 137, 137, 137 ) );
        }

        private void Button_Click( object sender, RoutedEventArgs e ) {
            Button ctrl = sender as Button;
            var color = new SolidColorBrush( Color.FromArgb( 255, 27, 161, 226 ) );

            if( !IsSelected( ctrl ) ) {
                this.CurrentPage = int.Parse( ctrl.Content.ToString() );
                SetSelected( ctrl );
            }
        }

        private void svgForward_MouseLeftButtonDown( object sender, MouseButtonEventArgs e ) {
            CurrentPage++;
            foreach( var child in this.root.Children ) {
                if( child is MetroButton &&
                   ( child as MetroButton ).Content.ToString() == CurrentPage.ToString() ) {
                    var btn = child as MetroButton;
                    SetSelected( btn );
                }
            }
        }

        private void svgBack_MouseLeftButtonDown( object sender, MouseButtonEventArgs e ) {
            CurrentPage--;
            foreach( var child in this.root.Children ) {
                if( child is MetroButton &&
                   ( child as MetroButton ).Content.ToString() == CurrentPage.ToString() ) {
                    var btn = child as MetroButton;
                    SetSelected( btn );
                }
            }
        }

        private bool IsSelected( Button btn ) {
            return this._selected == btn.Name;
        }

        private void ResetButtons() {
            var color = new SolidColorBrush( Color.FromArgb( 255, 137, 137, 137 ) );

            foreach( var btn in root.Children ) {
                if( btn.GetType() == typeof( MetroButton ) ) {
                    ( btn as Button ).Background = Brushes.Transparent;
                    ( btn as Button ).Foreground = color;
                    ( btn as Button ).BorderBrush = color;
                }
            }
        }

        private void SetSelected( Button btn ) {
            this._selected = btn.Name;
            if( btn.Name == "btnFirst" || btn.Name == "btnFifth" ) {
                ShiftButtons();
            }
            else {
                FillButton( btn );
            }
        }

        private void ShiftButtons() {
            if( CurrentPage == 1 ) {
                SetFirstPage();
                return;
            }

            btnForth.Visibility = CurrentPage + 1 > PageCount ?
                                  Visibility.Hidden :
                                  Visibility.Visible;

            btnFifth.Visibility = CurrentPage + 2 > PageCount ?
                                  Visibility.Hidden :
                                  Visibility.Visible;

            btnFirst.Content = CurrentPage - 2;
            btnSecond.Content = CurrentPage - 1;
            btnThird.Content = CurrentPage;
            btnForth.Content = CurrentPage + 1;
            btnFifth.Content = CurrentPage + 2;

            FillButton( btnThird );
            this._selected = "btnThird";
        }

        private void SetFirstPage() {
            FillButton( btnFirst );
            btnSecond.Visibility = CurrentPage + 1 > PageCount ?
                                   Visibility.Hidden :
                                   Visibility.Visible;
            btnThird.Visibility = CurrentPage + 2 > PageCount ?
                                  Visibility.Hidden :
                                  Visibility.Visible;
            btnForth.Visibility = CurrentPage + 3 > PageCount ?
                                  Visibility.Hidden :
                                  Visibility.Visible;

            btnFifth.Visibility = CurrentPage + 4 > PageCount ?
                                  Visibility.Hidden :
                                  Visibility.Visible;
        }

        private void FillButton( Button btn ) {
            var color = new SolidColorBrush( Color.FromArgb( 255, 27, 161, 226 ) );
            ResetButtons();
            btn.Background = color;
            btn.BorderBrush = color;
            btn.Foreground = Brushes.White;
        }
    }
}
