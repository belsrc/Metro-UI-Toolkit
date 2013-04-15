// -------------------------------------------------------------------------------
//    WinStatesButton.xaml.cs
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
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;
using System.ComponentModel;

    /// <summary>
    /// Interaction logic for WinStatesButton.xaml
    /// </summary>
    /// <remarks>
    /// Public Properties:
    ///     BackgroundHover   : Brush
    ///     ForegroundHover   : Brush
    ///     IsCloseVisible    : bool
    ///     IsMinimizeVisible : bool
    ///     IsMaximizeVisible : bool
    ///     
    /// Public Events:
    ///     MinimizeClick     : Bubble
    ///     MaximizeClick     : Bubble
    ///     NormalizeClick    : Bubble
    ///     CloseClick        : Bubble
    /// </remarks>
    public partial class WinStatesButton : UserControl {
        /// <summary>
        /// Initializes a new instance of the WinStateButtons class.
        /// </summary>
        public WinStatesButton() {
            InitializeComponent();
        }
        
        /* Events
           ---------------------------------------------------------------------------------------*/

        /// <summary>
        /// Adds or removes the event handler for the MinimizeClick event.
        /// </summary>
        public event RoutedEventHandler MinimizeClick {
            add { AddHandler( MinimizeClickEvent, value ); }
            remove { RemoveHandler( MinimizeClickEvent, value ); }
        }

        /// <summary>
        /// Routed event register for the MinimizeClick event.
        /// </summary>
        public static readonly RoutedEvent MinimizeClickEvent =
            EventManager.RegisterRoutedEvent( "MinimizeClick",
                                              RoutingStrategy.Bubble,
                                              typeof( RoutedEventHandler ),
                                              typeof( WinStatesButton )
                                            );

        /// <summary>
        /// Adds or removes the event handler for the MaximizeClick event.
        /// </summary>
        public event RoutedEventHandler MaximizeClick {
            add { AddHandler( MaximizeClickEvent, value ); }
            remove { RemoveHandler( MaximizeClickEvent, value ); }
        }

        /// <summary>
        /// Routed event register for the MaximizeClick event.
        /// </summary>
        public static readonly RoutedEvent MaximizeClickEvent =
            EventManager.RegisterRoutedEvent( "MaximizeClick",
                                              RoutingStrategy.Bubble,
                                              typeof( RoutedEventHandler ),
                                              typeof( WinStatesButton )
                                            );

        /// <summary>
        /// Adds or removes the event handler for the NormalizeClick event.
        /// </summary>
        public event RoutedEventHandler NormalizeClick {
            add { AddHandler( NormalizeClickEvent, value ); }
            remove { RemoveHandler( NormalizeClickEvent, value ); }
        }

        /// <summary>
        /// Routed event register for the NormalizeClick event.
        /// </summary>
        public static readonly RoutedEvent NormalizeClickEvent =
            EventManager.RegisterRoutedEvent( "NormalizeClick",
                                              RoutingStrategy.Bubble,
                                              typeof( RoutedEventHandler ),
                                              typeof( WinStatesButton )
                                            );

        /// <summary>
        /// Adds or removes the event handler for the CloseClick event.
        /// </summary>
        public event RoutedEventHandler CloseClick {
            add { AddHandler( CloseClickEvent, value ); }
            remove { RemoveHandler( CloseClickEvent, value ); }
        }

        /// <summary>
        /// Routed event register for the CloseClick event.
        /// </summary>
        public static readonly RoutedEvent CloseClickEvent =
            EventManager.RegisterRoutedEvent( "CloseClick",
                                              RoutingStrategy.Bubble,
                                              typeof( RoutedEventHandler ),
                                              typeof( WinStatesButton )
                                            );

        /* Properties
        ---------------------------------------------------------------------------------------*/

        /// <summary>
        /// Gets or sets the foreground hover color brush.
        /// </summary>
        public Brush ForegroundHover {
            get { return ( Brush )GetValue( ForegroundHoverProperty ); }
            set { SetValue( ForegroundHoverProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for ForegroundHover.
        /// </summary>
        public static readonly DependencyProperty ForegroundHoverProperty =
            DependencyProperty.Register( "ForegroundHover",
                                         typeof( Brush ),
                                         typeof( WinStatesButton ),
                                         new PropertyMetadata(
                                             new SolidColorBrush(
                                                 Color.FromArgb( 255, 51, 51, 51 ) ) )
                                       );

        /// <summary>
        /// Gets or sets the background hover color brush.
        /// </summary>
        public Brush BackgroundHover {
            get { return ( Brush )GetValue( BackgroundHoverProperty ); }
            set { SetValue( BackgroundHoverProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for BackgroundHover.
        /// </summary>
        public static readonly DependencyProperty BackgroundHoverProperty =
            DependencyProperty.Register( "BackgroundHover",
                                         typeof( Brush ),
                                         typeof( WinStatesButton ),
                                         new PropertyMetadata(
                                             new SolidColorBrush(
                                                 Color.FromArgb( 255, 200, 200, 200 ) ) )
                                       );

        /// <summary>
        /// Gets or sets a value indicating whether the close button is visible.
        /// </summary>
        public bool IsCloseVisible {
            get { return ( bool )GetValue( IsCloseVisibleProperty ); }
            set { SetValue( IsCloseVisibleProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for IsCloseVisible.
        /// </summary>
        public static readonly DependencyProperty IsCloseVisibleProperty =
            DependencyProperty.Register( "IsCloseVisible",
                                         typeof( bool ),
                                         typeof( WinStatesButton ),
                                         new PropertyMetadata( true )
                                       );

        /// <summary>
        /// Gets or sets a value indicating whether the minimize button is visible.
        /// </summary>
        public bool IsMinimizeVisible {
            get { return ( bool )GetValue( IsMinimizeVisibleProperty ); }
            set { SetValue( IsMinimizeVisibleProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for IsMinimizeVisible.
        /// </summary>
        public static readonly DependencyProperty IsMinimizeVisibleProperty =
            DependencyProperty.Register( "IsMinimizeVisible",
                                         typeof( bool ),
                                         typeof( WinStatesButton ),
                                         new PropertyMetadata( true )
                                       );

        /// <summary>
        /// Gets or sets a value indicating whether the maximize button is visible.
        /// </summary>
        public bool IsMaximizeVisible {
            get { return ( bool )GetValue( IsMaximizeVisibleProperty ); }
            set { SetValue( IsMaximizeVisibleProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for IsMaximizeVisible.
        /// </summary>
        public static readonly DependencyProperty IsMaximizeVisibleProperty =
            DependencyProperty.Register( "IsMaximizeVisible",
                                         typeof( bool ),
                                         typeof( WinStatesButton ),
                                         new PropertyMetadata( true )
                                       );

        /* Event Handlers
           ---------------------------------------------------------------------------------------*/

        private void SvgButton_MouseEnter( object sender, MouseEventArgs e ) {
            HoverChange( sender as Canvas, this.ForegroundHover, this.BackgroundHover );
        }

        private void SvgButton_MouseLeave( object sender, MouseEventArgs e ) {
            HoverChange( sender as Canvas, this.Foreground, this.Background );
        }

        private void CloseSvg_MouseLeftButtonDown( object sender, MouseButtonEventArgs e ) {
            this.RaiseEvent( new RoutedEventArgs( CloseClickEvent, this ) );
        }

        private void MaxSvg_MouseLeftButtonDown( object sender, MouseButtonEventArgs e ) {
            this.RaiseEvent( new RoutedEventArgs( MaximizeClickEvent, this ) );
        }

        private void NormSvg_MouseLeftButtonDown( object sender, MouseButtonEventArgs e ) {
            this.RaiseEvent( new RoutedEventArgs( NormalizeClickEvent, this ) );
        }

        private void MiniSvg_MouseLeftButtonDown( object sender, MouseButtonEventArgs e ) {
            this.RaiseEvent( new RoutedEventArgs( MinimizeClickEvent, this ) );
        }

        private void StateButtons_Loaded( object sender, RoutedEventArgs e ) {
            Window parent = Window.GetWindow( this );

            if( parent != null ) {
                parent.StateChanged += new EventHandler( parent_StateChanged );
            }
        }

        private void parent_StateChanged( object sender, EventArgs e ) {
            if( IsMaximizeVisible ) {
                Window win = sender as Window;
                if( win.WindowState == WindowState.Normal ) {
                    NormSvg.Visibility = Visibility.Collapsed;
                    MaxSvg.Visibility = Visibility.Visible;
                }
                else {
                    NormSvg.Visibility = Visibility.Visible;
                    MaxSvg.Visibility = Visibility.Collapsed;
                }
            }
        }

        /* Methods
           ---------------------------------------------------------------------------------------*/

        private void HoverChange( Canvas can, Brush foreground, Brush background ) {
            // Make sure they are both SolidColorBrushes, hassle fading other brush types
            if( this.Background != null &&
                this.Background.GetType() == typeof( SolidColorBrush ) &&
                this.BackgroundHover.GetType() == typeof( SolidColorBrush ) ) {
                // Get the background brush.
                SolidColorBrush curBg = can.Background as SolidColorBrush;
                can.Background = EaseBrush( curBg,
                                           ( background as SolidColorBrush ).Color,
                                            new Duration( TimeSpan.FromSeconds( .2 ) )
                                          );

                // See if we can animate the foreground
                if( this.Foreground != null &&
                    this.Foreground.GetType() == typeof( SolidColorBrush ) &&
                    this.ForegroundHover.GetType() == typeof( SolidColorBrush ) ) {
                    // Get the foreground brush.
                    SolidColorBrush fillBrush = ( can.Children[ 0 ] as Path ).Fill as SolidColorBrush;
                    ( can.Children[ 0 ] as Path ).Fill = EaseBrush( fillBrush,
                                                                    ( foreground as SolidColorBrush ).Color,
                                                                    new Duration( TimeSpan.FromSeconds( .2 ) )
                                                                  );
                }
                else {
                    ( can.Children[ 0 ] as Path ).Fill = foreground;
                }
            }
            else {
                // Forget the animation and just set the colors
                can.Background = background;
            }
        }

        private SolidColorBrush EaseBrush( SolidColorBrush brush, Color finish, Duration time ) {
            ColorAnimation ca = new ColorAnimation {
                To = finish,
                Duration = time
            };

            var tmp = new SolidColorBrush( brush.Color );
            tmp.BeginAnimation( SolidColorBrush.ColorProperty, ca );

            return tmp;
        }
    }
}
