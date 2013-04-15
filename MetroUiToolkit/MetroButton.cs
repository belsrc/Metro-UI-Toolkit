// -------------------------------------------------------------------------------
//    MetroButton.cs
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
    /// Represents a Metro UI button control.
    /// </summary>
    /// <remarks>
    /// Public Properties:
    ///     DisabledBackground : Brush
    ///     DisabledForeground : Brush
    /// </remarks>
    public class MetroButton : Button {
        /// <summary>
        /// Initializes a new instance of the MetroButton class.
        /// </summary>
        public MetroButton()
            : base() {
            DefaultStyleKey = typeof( MetroButton );
        }

        /// <summary>
        /// Gets or sets the background color brush for the button's disabled state.
        /// </summary>
        public Brush DisabledBackground {
            get { return ( Brush )GetValue( DisabledBackgroundProperty ); }
            set { SetValue( DisabledBackgroundProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for DisabledBackground.
        /// </summary>
        public static readonly DependencyProperty DisabledBackgroundProperty =
            DependencyProperty.Register( "DisabledBackground",
                                         typeof( Brush ),
                                         typeof( MetroButton ),
                                         new PropertyMetadata(
                                             new SolidColorBrush(
                                                 Color.FromArgb( 255, 204, 204, 204 ) ) )
                                       );

        /// <summary>
        /// Gets or sets the background color brush for the button's disabled state.
        /// </summary>
        public Brush DisabledForeground {
            get { return ( Brush )GetValue( DisabledForegroundProperty ); }
            set { SetValue( DisabledForegroundProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for DisabledBackground.
        /// </summary>
        public static readonly DependencyProperty DisabledForegroundProperty =
            DependencyProperty.Register( "DisabledForeground",
                                         typeof( Brush ),
                                         typeof( MetroButton ),
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