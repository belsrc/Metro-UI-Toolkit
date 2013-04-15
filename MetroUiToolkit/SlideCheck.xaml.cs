// -------------------------------------------------------------------------------
//    SlideCheck.xaml.cs
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

    /// <summary>
    /// Interaction logic for SlideCheck.xaml
    /// </summary>
    /// <remarks>
    /// Public Control Properties:
    ///     IsChecked       : bool
    ///     CheckedColor    : Brush
    ///     UncheckedColor  : Brush
    ///     ThumbColor      : Brush
    ///
    /// Public Event
    ///     CheckChanged
    /// </remarks>
    public partial class SlideCheck : UserControl {
        /// <summary>
        /// Initializes a new instance of the SlideCheck class.
        /// </summary>
        public SlideCheck() {
            InitializeComponent();
        }

        /* Events
           ---------------------------------------------------------------------------------------*/

        /// <summary>
        /// Adds or removes the event handler for the CheckChanged event.
        /// </summary>
        public event RoutedEventHandler CheckChanged {
            add { AddHandler( CheckChangedEvent, value ); }
            remove { RemoveHandler( CheckChangedEvent, value ); }
        }

        /// <summary>
        /// Routed event register for the CheckChanged event.
        /// </summary>
        public static readonly RoutedEvent CheckChangedEvent = EventManager.RegisterRoutedEvent( "CheckChanged",
                                                                                                  RoutingStrategy.Bubble,
                                                                                                  typeof( RoutedEventHandler ),
                                                                                                  typeof( SlideCheck )
                                                                                                );

        /* Properties
           ---------------------------------------------------------------------------------------*/

        /// <summary>
        /// Gets or sets the fill color brush for the Checked path.
        /// </summary>
        public Brush CheckedColor {
            get { return ( Brush )GetValue( CheckedColorProperty ); }
            set { SetValue( CheckedColorProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for CheckedColor.
        /// </summary>
        public static readonly DependencyProperty CheckedColorProperty = DependencyProperty.Register( "CheckedColor",
                                                                                                       typeof( Brush ),
                                                                                                       typeof( SlideCheck ),
                                                                                                       new PropertyMetadata(
                                                                                                           new SolidColorBrush(
                                                                                                               Color.FromArgb( 255, 27, 161, 226 )
                                                                                                           )
                                                                                                       )
                                                                                                     );

        /// <summary>
        /// Gets or sets the fill color brush for the Unchecked path.
        /// </summary>
        public Brush UncheckedColor {
            get { return ( Brush )GetValue( UncheckedColorProperty ); }
            set { SetValue( UncheckedColorProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for UncheckedColor.
        /// </summary>
        public static readonly DependencyProperty UncheckedColorProperty = DependencyProperty.Register( "UncheckedColor",
                                                                                                        typeof( Brush ),
                                                                                                        typeof( SlideCheck ),
                                                                                                        new PropertyMetadata(
                                                                                                            new SolidColorBrush(
                                                                                                                Color.FromArgb( 255, 136, 136, 136 )
                                                                                                            )
                                                                                                        )
                                                                                                      );

        /// <summary>
        /// Gets or sets the fill color brush for the Thumb path.
        /// </summary>
        public Brush ThumbColor {
            get { return ( Brush )GetValue( ThumbColorProperty ); }
            set { SetValue( ThumbColorProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for SliderColor.
        /// </summary>
        public static readonly DependencyProperty ThumbColorProperty = DependencyProperty.Register( "SliderColor",
                                                                                                     typeof( Brush ),
                                                                                                     typeof( SlideCheck ),
                                                                                                     new PropertyMetadata(
                                                                                                         new SolidColorBrush(
                                                                                                             Color.FromArgb( 255, 51, 51, 51 )
                                                                                                         )
                                                                                                     )
                                                                                                   );

        /// <summary>
        /// Gets or sets a value indicating whther the user controls is checked.
        /// </summary>
        public bool IsChecked {
            get { return ( bool )GetValue( IsCheckedProperty ); }
            set { SetValue( IsCheckedProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for IsChecked.
        /// </summary>
        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register( "IsChecked",
                                                                                                   typeof( bool ),
                                                                                                   typeof( SlideCheck ),
                                                                                                   new PropertyMetadata( false,
                                                                                                       new PropertyChangedCallback( CheckedValueChanged ) )
                                                                                                 );

        /* Event Handlers
           ---------------------------------------------------------------------------------------*/

        private static void CheckedValueChanged( DependencyObject obj, DependencyPropertyChangedEventArgs args ) {
            SlideCheck sc = obj as SlideCheck;
            if( sc.IsChecked ) {
                sc.AnimateSlider( 0 );
            }
            else {
                sc.AnimateSlider( -46 );
            }

            sc.RaiseEvent( new RoutedEventArgs( CheckChangedEvent, sc ) );
        }

        private void SlideCheckControl_MouseLeftButtonDown( object sender, MouseButtonEventArgs e ) {
            IsChecked = !IsChecked;
        }

        private void SlideCheckControl_Loaded( object sender, RoutedEventArgs e ) {
            if( this.IsChecked ) {
                this.slideSvg.Margin = new Thickness( 1, 0, 0, 0 );
            }
        }

        /* Methods
           ---------------------------------------------------------------------------------------*/

        private void AnimateSlider( double position ) {
            ThicknessAnimation ta = new ThicknessAnimation {
                To = new Thickness( position, 0, 0, 0 ),
                Duration = new Duration( TimeSpan.FromSeconds( .3 ) )
            };

            this.slideSvg.BeginAnimation( MarginProperty, ta );
        }
    }
}
