using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MetroUiToolkit {
    /// <summary>
    /// Interaction logic for ButtonDropdown.xaml
    /// </summary>
    public partial class ButtonDropdown : UserControl {
        private Timer _popTimer;

        public ButtonDropdown() {
            InitializeComponent();
            this.DataContext = this;
        }

        public StackPanel Presenter {
            get { return this.DropdownContent; }
        }

        public string Text {
            get { return ( string )GetValue( TextProperty ); }
            set { SetValue( TextProperty, value ); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register( "Text",
                                         typeof( string ),
                                         typeof( ButtonDropdown ),
                                         new PropertyMetadata( "DropdownButton" )
                                       );

        /// <summary>
        /// Gets or sets the source items.
        /// </summary>
        public ObservableCollection<object> ItemsSource {
            get { return ( ObservableCollection<object> )GetValue( ItemsSourceProperty ); }
            set { SetValue( ItemsSourceProperty, value ); }
        }

        /// <summary>
        /// Dependency Property for ItemsSource.
        /// </summary>
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register( "ItemsSource",
                                         typeof( ObservableCollection<object> ),
                                         typeof( ButtonDropdown ),
                                         new PropertyMetadata( new ObservableCollection<object>(),
                                             new PropertyChangedCallback( ItemsChanged ) )
                                       );


        public bool IsDropDownOpen {
            get { return ( bool )GetValue( IsDropDownOpenProperty ); }
            set { SetValue( IsDropDownOpenProperty, value ); }
        }

        public static readonly DependencyProperty IsDropDownOpenProperty =
            DependencyProperty.Register( "IsDropDownOpen",
                                         typeof( bool ),
                                         typeof( ButtonDropdown ),
                                         new PropertyMetadata( false )
                                       );

        
        public double MaxDropDownHeight {
            get { return ( double )GetValue( MaxDropDownHeightProperty ); }
            set { SetValue( MaxDropDownHeightProperty, value ); }
        }

        public static readonly DependencyProperty MaxDropDownHeightProperty =
            DependencyProperty.Register( "MaxDropDownHeight",
                                         typeof( double ),
                                         typeof( ButtonDropdown ),
                                         new PropertyMetadata( 90.0 )
                                       );

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
                                         typeof( ButtonDropdown ),
                                         new PropertyMetadata(
                                             new SolidColorBrush(
                                                 Color.FromArgb( 255, 255, 255, 255 ) ) )
                                       );

        private static void ItemsChanged( DependencyObject d, DependencyPropertyChangedEventArgs e ) {
            ButtonDropdown bdd = ( ButtonDropdown )d;
            if( bdd.ItemsSource != null ) {
                bdd.DropdownContent.Children.Clear();
                foreach( var item in bdd.ItemsSource ) {
                    bdd.DropdownContent.Children.Add( new CheckBox() { Content = item.ToString(), Margin = new Thickness( 5, 3, 5, 3 ) } );
                }
            }
        }

        private void me_MouseLeftButtonDown( object sender, MouseButtonEventArgs e ) {
            PART_Popup.IsOpen = !PART_Popup.IsOpen;
        }

        private void PopUp_MouseEnter( object sender, MouseEventArgs e ) {
            if( this._popTimer != null ) {
                this._popTimer.Dispose();
            }
        }

        private void PopUp_MouseLeave( object sender, MouseEventArgs e ) {
            if( ( sender as Popup ).Name == "PART_Popup" && Content.IsFocused ) {
                return;
            }

            this._popTimer = new Timer( Timer_Elapsed, null, TimeSpan.FromMilliseconds( 500 ), TimeSpan.FromMilliseconds( 500 ) );
        }

        private void me_LostFocus( object sender, RoutedEventArgs e ) {
            PART_Popup.IsOpen = false;
        }

        private void Timer_Elapsed( object state ) {
            Dispatcher.BeginInvoke( ( Action )delegate {
                PART_Popup.IsOpen = false;
                this._popTimer.Dispose();
            }, DispatcherPriority.Normal );
        }

        public void HidePopUp() {
            PART_Popup.IsOpen = false;
        }
    }
}
