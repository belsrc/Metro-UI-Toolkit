// -------------------------------------------------------------------------------
//    MetroScrollBar.cs
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
    using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows;

    /// <summary>
    /// Represents a Metro UI scrollbar control.
    /// </summary>
    /// <remarks>
    /// Public Properties:
    ///     BarColor   : Brush
    ///     ThumbColor : Brush
    /// </remarks>
    public class MetroScrollBar : ScrollBar {
        /// <summary>
        /// Initializes a new instance of the MetroScrollBar class.
        /// </summary>
        public MetroScrollBar()
            : base() {
            DefaultStyleKey = typeof( MetroScrollBar );
        }

        /// <summary>
        /// Gets or sets the the scrollbar's color.
        /// </summary>
        public Brush BarColor {
            get { return ( Brush )GetValue( BarColorProperty ); }
            set { SetValue( BarColorProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for BarColor.
        /// </summary>
        public static readonly DependencyProperty BarColorProperty =
            DependencyProperty.Register( "BarColor",
                                         typeof( Brush ),
                                         typeof( MetroScrollBar ),
                                         new PropertyMetadata(
                                             new SolidColorBrush(
                                                 Color.FromArgb( 255, 225, 225, 225 ) ) )
                                       );

        /// <summary>
        /// Gets or sets the scrollbar's thumb color.
        /// </summary>
        public Brush ThumbColor {
            get { return ( Brush )GetValue( ThumbColorProperty ); }
            set { SetValue( ThumbColorProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for ThumbColor.
        /// </summary>
        public static readonly DependencyProperty ThumbColorProperty =
            DependencyProperty.Register( "ThumbColor",
                                         typeof( Brush ),
                                         typeof( MetroScrollBar ),
                                         new PropertyMetadata(
                                             new SolidColorBrush(
                                                 Color.FromArgb( 255, 51, 51, 51 ) ) )
                                       );

        /// <summary>
        /// Invoked whenever application code or internal processes call ApplyTemplate.
        /// </summary>
        public override void OnApplyTemplate() {
            base.OnApplyTemplate();
        }
    }
}