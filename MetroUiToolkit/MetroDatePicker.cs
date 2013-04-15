// -------------------------------------------------------------------------------
//    MetroDatePicker.cs
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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Controls;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Input;

    /// <summary>
    /// Represents a Metro UI datepicker control.
    /// </summary>
    /// <remarks>
    /// Public Properties:
    ///     CalendarIconColor      : Brush
    ///     CalendarIconHoverColor : Brush
    ///     TodayBackground        : Brush
    ///     SelectedBackground     : Brush
    ///     HighlightBackground    : Brush
    ///     CalendarForeground     : Brush
    ///     CalendarBackground     : Color
    ///     CalendarHeaderColor    : Color
    /// </remarks>
    public class MetroDatePicker : DatePicker {

        /* Constructors
           ---------------------------------------------------------------------------------------*/

        /// <summary>
        /// Initializes a new instance of the MetroDatePicker class.
        /// </summary>
        public MetroDatePicker()
            : base() {
            DefaultStyleKey = typeof( MetroDatePicker );
            this.PreviewKeyDown +=new KeyEventHandler(MetroDatePicker_PreviewKeyDown);
        }

        /* Properties
           ---------------------------------------------------------------------------------------*/

        /// <summary>
        /// Gets or sets the calendar icon color.
        /// </summary>
        public Brush CalendarIconColor {
            get { return ( Brush )GetValue( CalendarIconColorProperty ); }
            set { SetValue( CalendarIconColorProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for CalendarIconColor.
        /// </summary>
        public static readonly DependencyProperty CalendarIconColorProperty =
            DependencyProperty.Register( "CalendarIconColor",
                                         typeof( Brush ),
                                         typeof( MetroDatePicker ),
                                         new PropertyMetadata(
                                             new SolidColorBrush(
                                                 Color.FromArgb( 255, 51, 51, 51 ) ) )
                                       );

        /// <summary>
        /// Gets or sets the calendar icon hover color.
        /// </summary>
        public Brush CalendarIconHoverColor {
            get { return ( Brush )GetValue( CalendarIconHoverColorProperty ); }
            set { SetValue( CalendarIconHoverColorProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for CalendarIconHoverColor.
        /// </summary>
        public static readonly DependencyProperty CalendarIconHoverColorProperty =
            DependencyProperty.Register( "CalendarIconHoverColor",
                                         typeof( Brush ),
                                         typeof( MetroDatePicker ),
                                         new PropertyMetadata(
                                             new SolidColorBrush(
                                                 Color.FromArgb( 255, 27, 161, 226 ) ) )
                                       );

        /// <summary>
        /// Gets or sets today's date background color.
        /// </summary>
        public Brush TodayBackground {
            get { return ( Brush )GetValue( TodayBackgroundProperty ); }
            set { SetValue( TodayBackgroundProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for TodayBackground.
        /// </summary>
        public static readonly DependencyProperty TodayBackgroundProperty =
            DependencyProperty.Register( "TodayBackground",
                                         typeof( Brush ),
                                         typeof( MetroDatePicker ),
                                         new PropertyMetadata(
                                             new SolidColorBrush(
                                                 Color.FromArgb( 255, 235, 80, 0 ) ) )
                                       );

        /// <summary>
        /// Gets or sets the selected date background color.
        /// </summary>
        public Brush SelectedBackground {
            get { return ( Brush )GetValue( SelectedBackgroundProperty ); }
            set { SetValue( SelectedBackgroundProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for SelectedBackground.
        /// </summary>
        public static readonly DependencyProperty SelectedBackgroundProperty =
            DependencyProperty.Register( "SelectedBackground",
                                         typeof( Brush ),
                                         typeof( MetroDatePicker ),
                                         new PropertyMetadata(
                                             new SolidColorBrush(
                                                 Color.FromArgb( 255, 27, 161, 226 ) ) )
                                       );


        /// <summary>
        /// Gets or sets the highlighted date background color.
        /// </summary>
        public Brush HighlightBackground {
            get { return ( Brush )GetValue( HighlightBackgroundProperty ); }
            set { SetValue( HighlightBackgroundProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for HighlightBackground.
        /// </summary>
        public static readonly DependencyProperty HighlightBackgroundProperty =
            DependencyProperty.Register( "HighlightBackground",
                                         typeof( Brush ),
                                         typeof( MetroDatePicker ),
                                         new PropertyMetadata(
                                             new SolidColorBrush(
                                                 Color.FromArgb( 102, 27, 161, 226 ) ) )
                                       );

        /// <summary>
        /// Gets or sets the calendar dropdown's foreground color.
        /// </summary>
        public Brush CalendarForeground {
            get { return ( Brush )GetValue( CalendarForegroundProperty ); }
            set { SetValue( CalendarForegroundProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for CalendarForeground.
        /// </summary>
        public static readonly DependencyProperty CalendarForegroundProperty =
            DependencyProperty.Register( "CalendarForeground",
                                         typeof( Brush ),
                                         typeof( MetroDatePicker ),
                                         new PropertyMetadata(
                                             new SolidColorBrush(
                                                 Color.FromArgb( 255, 51, 51, 51 ) ) )
                                       );

        /// <summary>
        /// Gets or sets the calendar dropdown's background color.
        /// </summary>
        public Color CalendarBackground {
            get { return ( Color )GetValue( CalendarBackgroundProperty ); }
            set { SetValue( CalendarBackgroundProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for CalendarBackground.
        /// </summary>
        public static readonly DependencyProperty CalendarBackgroundProperty =
            DependencyProperty.Register( "CalendarBackground",
                                         typeof( Color ),
                                         typeof( MetroDatePicker ),
                                         new PropertyMetadata(
                                             Color.FromArgb( 255, 250, 250, 250 ) )
                                       );

        /// <summary>
        /// Gets or sets the calendar dropdown's header color.
        /// </summary>
        public Color CalendarHeaderColor {
            get { return ( Color )GetValue( CalendarHeaderColorProperty ); }
            set { SetValue( CalendarHeaderColorProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for CalendarHeaderColor.
        /// </summary>
        public static readonly DependencyProperty CalendarHeaderColorProperty =
            DependencyProperty.Register( "CalendarHeaderColor",
                                         typeof( Color ),
                                         typeof( MetroDatePicker ),
                                         new PropertyMetadata(
                                             Color.FromArgb( 255, 27, 161, 226 ) )
                                       );

        /// <summary>
        /// Gets or sets the calendar blackout date icon overlay color.
        /// </summary>
        public Brush BlackoutIconColor {
            get { return ( Brush )GetValue( BlackoutIconColorProperty ); }
            set { SetValue( BlackoutIconColorProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for BlackoutIconColor.
        /// </summary>
        public static readonly DependencyProperty BlackoutIconColorProperty =
            DependencyProperty.Register( "BlackoutIconColor",
                                         typeof( Brush ),
                                         typeof( MetroDatePicker ),
                                         new PropertyMetadata(
                                             new SolidColorBrush(
                                                 Color.FromArgb( 255, 229, 20, 0 ) ) )
                                       );

        /// <summary>
        /// Gets or sets the calendar selected date border color.
        /// </summary>
        public Brush SelectedBorderColor {
            get { return ( Brush )GetValue( SelectedBorderColorProperty ); }
            set { SetValue( SelectedBorderColorProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for SelectedBorderColor.
        /// </summary>
        public static readonly DependencyProperty SelectedBorderColorProperty =
            DependencyProperty.Register( "SelectedBorderColor",
                                         typeof( Brush ),
                                         typeof( MetroDatePicker ),
                                         new PropertyMetadata(
                                             new SolidColorBrush(
                                                 Color.FromArgb( 255, 27, 161, 226 ) ) )
                                       );

        /// <summary>
        /// Gets or sets the calendar header foreground color.
        /// </summary>
        public Brush HeaderForeground {
            get { return ( Brush )GetValue( HeaderForegroundProperty ); }
            set { SetValue( HeaderForegroundProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for HeaderForeground.
        /// </summary>
        public static readonly DependencyProperty HeaderForegroundProperty =
            DependencyProperty.Register( "HeaderForeground",
                                         typeof( Brush ),
                                         typeof( MetroDatePicker ),
                                         new PropertyMetadata(
                                             new SolidColorBrush(
                                                 Color.FromArgb( 255, 250, 250, 250 ) ) )
                                       );

        /* Event Handlers
           ---------------------------------------------------------------------------------------*/

        private void MetroDatePicker_PreviewKeyDown( object sender, KeyEventArgs e ) {
            if( e.Key == Key.Up || e.Key == Key.Down ) {
                int direction = e.Key == Key.Up ? 1 : -1;
                DateTime result;

                if( !DateTime.TryParse( this.Text, out result ) )
                    return;

                result = result.AddDays( direction );
                while( this.BlackoutDates.Contains( result ) ) {
                    result = result.AddDays( direction );
                }

                this.SelectedDate = result;
            }
        }

        /* Methods
           ---------------------------------------------------------------------------------------*/

        /// <summary>
        /// Invoked whenever application code or internal processes call ApplyTemplate.
        /// </summary>
        public override void OnApplyTemplate() {
            base.OnApplyTemplate();
        }
    }
}
