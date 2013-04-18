// -------------------------------------------------------------------------------
//    MetroTabItem.cs
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
    /// Represents a Metro UI tab item.
    /// </summary>
    /// <remarks>
    /// Public Properties:
    ///     IsClosable         : bool
    ///     
    /// Public Events:
    ///     TabCloseClick : Bubble
    /// </remarks>
    public class MetroTabItem : TabItem {
        /// <summary>
        /// Initializes a new instance of the MetroTabItem class.
        /// </summary>
        public MetroTabItem()
            : base() {
            DefaultStyleKey = typeof( MetroTabItem );
        }

        /// <summary>
        /// Adds or removes the event handler for the TabCloseClick event.
        /// </summary>
        public event RoutedEventHandler TabCloseClick {
            add { AddHandler( TabCloseClickEvent, value ); }
            remove { RemoveHandler( TabCloseClickEvent, value ); }
        }

        /// <summary>
        /// Routed event register for the TabCloseClick event.
        /// </summary>
        public static readonly RoutedEvent TabCloseClickEvent =
            EventManager.RegisterRoutedEvent( "TabCloseClick",
                                              RoutingStrategy.Bubble,
                                              typeof( RoutedEventHandler ),
                                              typeof( MetroTabItem )
                                            );

        /// <summary>
        /// Gets or sets a value indicating whether the tab item is closable or not.
        /// </summary>
        public bool IsClosable {
            get { return ( bool )GetValue( IsClosableProperty ); }
            set { SetValue( IsClosableProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for IsClosable.
        /// </summary>
        public static readonly DependencyProperty IsClosableProperty =
            DependencyProperty.Register( "IsClosable",
                                         typeof( bool ),
                                         typeof( MetroTabItem ),
                                         new PropertyMetadata( true )
                                       );

        private void closeButton_Click( object sender, System.Windows.RoutedEventArgs e ) {
            this.RaiseEvent( new RoutedEventArgs( TabCloseClickEvent, this ) );
        }

        /// <summary>
        /// Invoked whenever application code or internal processes call ApplyTemplate.
        /// </summary>
        /// <remarks>
        /// Gets the button from the template and adds the click event handler to the tab close button.
        /// </remarks>
        public override void OnApplyTemplate() {
            base.OnApplyTemplate();

            Button closeButton = base.GetTemplateChild( "CloseBtn" ) as Button;
            if( closeButton != null ) {
                closeButton.Click += new RoutedEventHandler( closeButton_Click );
            }
        }
    }
}
