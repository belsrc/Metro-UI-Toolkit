// -------------------------------------------------------------------------------
//    MetroComboBox.cs
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
    using System.Windows.Media;

    /// <summary>
    /// Represents a Metro UI combo box control.
    /// </summary>
    /// <remarks>
    /// Public Properties:
    ///     ListBackground        : Brush
    ///     ListForeground        : Brush
    ///     ButtonHoverBackground : Brush
    ///     ButtonHoverForeground : Brush
    ///     SelectedBackground    : Brush
    ///     SelectedForeground    : Brush
    ///     SeperatorColor        : Brush
    /// </remarks>
    public class MetroComboBox : ComboBox {
        /// <summary>
        /// Initializes a new instance of the MetroComboBox class.
        /// </summary>
        public MetroComboBox()
            : base() {
            DefaultStyleKey = typeof( MetroComboBox );
        }

        /// <summary>
        /// Gets or sets the dropdown list background color.
        /// </summary>
        public Brush ListBackground {
            get { return ( Brush )GetValue( ListBackgroundProperty ); }
            set { SetValue( ListBackgroundProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for ListBackground.
        /// </summary>
        public static readonly DependencyProperty ListBackgroundProperty =
            DependencyProperty.Register( "ListBackground",
                                         typeof( Brush ),
                                         typeof( MetroComboBox ),
                                         new PropertyMetadata(
                                             new SolidColorBrush(
                                                 Color.FromArgb( 255, 255, 255, 255 ) ) )
                                       );

        /// <summary>
        /// Gets or sets the dropdown list foreground color.
        /// </summary>
        public Brush ListForeground {
            get { return ( Brush )GetValue( ListForegroundProperty ); }
            set { SetValue( ListForegroundProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for ListForeground.
        /// </summary>
        public static readonly DependencyProperty ListForegroundProperty =
            DependencyProperty.Register( "ListForeground",
                                         typeof( Brush ),
                                         typeof( MetroComboBox ),
                                         new PropertyMetadata(
                                             new SolidColorBrush(
                                                 Color.FromArgb( 255, 51, 51, 51 ) ) )
                                       );

        /// <summary>
        /// Gets or sets the button background color while in the hover-over state.
        /// </summary>
        public Brush ButtonHoverBackground {
            get { return ( Brush )GetValue( ButtonHoverBackgroundProperty ); }
            set { SetValue( ButtonHoverBackgroundProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for ButtonHoverBackground.
        /// </summary>
        public static readonly DependencyProperty ButtonHoverBackgroundProperty =
            DependencyProperty.Register( "ButtonHoverBackground",
                                         typeof( Brush ),
                                         typeof( MetroComboBox ),
                                         new PropertyMetadata(
                                             new SolidColorBrush(
                                                 Color.FromArgb( 255, 27, 161, 226 ) ) )
                                       );

        /// <summary>
        /// Gets or sets the button foreground color while in the hover-over state.
        /// </summary>
        public Brush ButtonHoverForeground {
            get { return ( Brush )GetValue( ButtonHoverForegroundProperty ); }
            set { SetValue( ButtonHoverForegroundProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for ButtonHoverForeground.
        /// </summary>
        public static readonly DependencyProperty ButtonHoverForegroundProperty =
            DependencyProperty.Register( "ButtonHoverForeground",
                                         typeof( Brush ),
                                         typeof( MetroComboBox ),
                                         new PropertyMetadata(
                                             new SolidColorBrush(
                                                 Color.FromArgb( 255, 255, 255, 255 ) ) )
                                       );

        /// <summary>
        /// Gets or sets the list item background color while in the selected state.
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
                                         typeof( MetroComboBox ),
                                         new PropertyMetadata(
                                             new SolidColorBrush(
                                                 Color.FromArgb( 255, 27, 161, 226 ) ) )
                                       );

        /// <summary>
        /// Gets or sets the list item foreground color while in the selected state.
        /// </summary>
        public Brush SelectedForeground {
            get { return ( Brush )GetValue( SelectedForegroundProperty ); }
            set { SetValue( SelectedForegroundProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for SelectedForeground.
        /// </summary>
        public static readonly DependencyProperty SelectedForegroundProperty =
            DependencyProperty.Register( "SelectedForeground",
                                         typeof( Brush ),
                                         typeof( MetroComboBox ),
                                         new PropertyMetadata(
                                             new SolidColorBrush(
                                                 Color.FromArgb( 255, 255, 255, 255 ) ) )
                                       );

        /// <summary>
        /// Gets or sets the list item separator color.
        /// </summary>
        public Brush SeparatorColor {
            get { return ( Brush )GetValue( SeparatorColorProperty ); }
            set { SetValue( SeparatorColorProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for SeparatorColor.
        /// </summary>
        public static readonly DependencyProperty SeparatorColorProperty =
            DependencyProperty.Register( "SeparatorColor",
                                         typeof( Brush ),
                                         typeof( MetroComboBox ),
                                         new PropertyMetadata(
                                             new SolidColorBrush(
                                                 Color.FromArgb( 255, 204, 204, 204 ) ) )
                                       );

        /// <summary>
        /// Invoked whenever application code or internal processes call ApplyTemplate.
        /// </summary>
        public override void OnApplyTemplate() {
            base.OnApplyTemplate();
        }
    }
}
