using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MiniTC
{
    /// <summary>
    /// Interaction logic for PanelTC.xaml
    /// </summary>
    public partial class PanelTC : UserControl
    {
        #region Register DependencyProperty
        public static readonly DependencyProperty LogicalDriversProperty =
            DependencyProperty.Register(
                nameof(LogicalDrivers),
                typeof(string[]),
                typeof(PanelTC),
                new FrameworkPropertyMetadata(null)
            );

        public string[] LogicalDrivers
        {
            get { return (string[])GetValue(LogicalDriversProperty); }
            set { SetValue(LogicalDriversProperty, value); }
        }

        public static readonly DependencyProperty SelectedLogicalDriveProperty =
            DependencyProperty.Register(
                nameof(SelectedLogicalDrive),
                typeof(string),
                typeof(PanelTC),
                new FrameworkPropertyMetadata(null)
            );

        public string SelectedLogicalDrive
        {
            get { return (string)GetValue(SelectedLogicalDriveProperty); }
            set { SetValue(SelectedLogicalDriveProperty, value); }
        }

        public static readonly DependencyProperty ListOfFilesProperty =
            DependencyProperty.Register(
                nameof(ListOfFiles),
                typeof(List<string>),
                typeof(PanelTC),
                new FrameworkPropertyMetadata(null)
            );

        public List<string> ListOfFiles
        {
            get { return (List<string>)GetValue(ListOfFilesProperty); }
            set { SetValue(ListOfFilesProperty, value); }
        }
        #endregion

        #region Register Events
        public static readonly RoutedEvent LogicDriveChangedEvent =
            EventManager.RegisterRoutedEvent(nameof(LogicDriveChanged),
                         RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                         typeof(PanelTC));

        public event RoutedEventHandler LogicDriveChanged
        {
            add { AddHandler(LogicDriveChangedEvent, value); }
            remove { RemoveHandler(LogicDriveChangedEvent, value); }
        }
        #endregion

        public PanelTC()
        {
            InitializeComponent();
        }

        private void logicalDrivers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        => RaiseEvent(new RoutedEventArgs(LogicDriveChangedEvent));
    }
}
