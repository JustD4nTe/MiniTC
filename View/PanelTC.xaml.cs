using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        public static readonly DependencyProperty SelectedFileProperty =
            DependencyProperty.Register(
                nameof(SelectedFile),
                typeof(string),
                typeof(PanelTC),
                new FrameworkPropertyMetadata(null)
            );

        public string SelectedFile
        {
            get { return (string)GetValue(SelectedLogicalDriveProperty); }
            set { SetValue(SelectedLogicalDriveProperty, value); }
        }
        
        public static readonly DependencyProperty TextPathProperty =
            DependencyProperty.Register(
                nameof(TextPath),
                typeof(string),
                typeof(PanelTC),
                new FrameworkPropertyMetadata(null)
            );

        public string TextPath
        {
            get { return (string)GetValue(TextPathProperty); }
            set { SetValue(TextPathProperty, value); }
        }
        #endregion

        #region Register Events
        public static readonly RoutedEvent FileDoubleClickedEvent =
            EventManager.RegisterRoutedEvent(nameof(FileDoubleClicked),
                         RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                         typeof(PanelTC));

        public event RoutedEventHandler FileDoubleClicked
        {
            add { AddHandler(FileDoubleClickedEvent, value); }
            remove { RemoveHandler(FileDoubleClickedEvent, value); }
        }
        #endregion

        public PanelTC()
        {
            InitializeComponent();
        }

        private void listOfFiles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        => RaiseEvent(new RoutedEventArgs(FileDoubleClickedEvent));
    }
}
