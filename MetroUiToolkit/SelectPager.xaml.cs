// -------------------------------------------------------------------------------
//    SelectPager.xaml.cs
//    Copyright (c) 2012 Bryan Kizer
//    All rights reserved.
//    https://github.com/belsrc/ModernUIControls
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

    /// <summary>
    /// Interaction logic for Paginator.xaml
    /// </summary>
    /// <remarks>
    /// Public Properties:
    ///     CurrentPage: int
    ///     PageCount: int
    /// 
    /// Public Event
    ///     PageChanged: Bubble
    /// </remarks>
    public partial class SelectPager : UserControl {
        /// <summary>
        /// Initializes a new instance of the SelectPager class.
        /// </summary>
        public SelectPager() {
            InitializeComponent();
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
        public static readonly RoutedEvent PageChangedEvent = EventManager.RegisterRoutedEvent( "PageChanged",
                                                                                                RoutingStrategy.Bubble,
                                                                                                typeof( RoutedEventHandler ),
                                                                                                typeof( SelectPager )
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
        public static readonly DependencyProperty CurrentPageProperty = DependencyProperty.Register( "CurrentPage",
                                                                                                     typeof( int ),
                                                                                                     typeof( SelectPager ),
                                                                                                     new PropertyMetadata( 1,
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
        public static readonly DependencyProperty PageCountProperty = DependencyProperty.Register( "PageCount",
                                                                                                     typeof( int ),
                                                                                                     typeof( SelectPager ),
                                                                                                     new PropertyMetadata( 1 )
                                                                                                   );

        /* Event Handlers
           ---------------------------------------------------------------------------------------*/

        private static void CurrentPageChanged( DependencyObject obj, DependencyPropertyChangedEventArgs e ) {
            SelectPager page = obj as SelectPager;

            // Dont want 0 or negative values
            if( page.CurrentPage < 1 ) {
                page.CurrentPage = 1;
            }

            // Dont want a value greater than max
            if( page.CurrentPage > page.PageCount ) {
                page.CurrentPage = page.PageCount;
            }

            // Set the text boxes content.
            page.txtCurrent.Text = page.CurrentPage.ToString();

            // Enable/disable the back controls and set the value
            if( page.CurrentPage > 1 ) {
                page.btnFirst.IsEnabled = true;
                page.btnBack.IsEnabled = true;
                page.btnBack.Content = page.CurrentPage - 1;
            }
            else {
                page.btnFirst.IsEnabled = false;
                page.btnBack.IsEnabled = false;
                page.btnBack.Content = "-";
            }

            // Enable/disable the forward controls and set the value
            if( page.CurrentPage < page.PageCount ) {
                page.btnLast.IsEnabled = true;
                page.btnForward.IsEnabled = true;
                page.btnForward.Content = page.CurrentPage + 1;
            }
            else {
                page.btnLast.IsEnabled = false;
                page.btnForward.IsEnabled = false;
                page.btnForward.Content = "-";
            }

            // Fire the public event
            page.RaiseEvent( new RoutedEventArgs( PageChangedEvent, page ) );
        }

        private void PageControl_KeyDown( object sender, KeyEventArgs e ) {
            if( e.Key == Key.Enter ) {
                int tmp = 0;

                if( int.TryParse( txtCurrent.Text, out tmp ) ) {
                    this.CurrentPage = tmp;
                }
                else {
                    txtCurrent.Text = this.CurrentPage.ToString();
                }
            }
        }

        private void btnBack_Click( object sender, RoutedEventArgs e ) {
            int tmp;
            if( int.TryParse( btnBack.Content.ToString(), out tmp ) ) {
                this.CurrentPage = tmp;
            }
        }

        private void btnFirst_Click( object sender, RoutedEventArgs e ) {
            this.CurrentPage = 1;
        }

        private void btnForward_Click( object sender, RoutedEventArgs e ) {
            int tmp;
            if( int.TryParse( btnForward.Content.ToString(), out tmp ) ) {
                this.CurrentPage = tmp;
            }
        }

        private void btnLast_Click( object sender, RoutedEventArgs e ) {
            this.CurrentPage = this.PageCount;
        }

        private void PageControl_LostFocus( object sender, RoutedEventArgs e ) {
            txtCurrent.Text = this.CurrentPage.ToString();
        }
    }
}
