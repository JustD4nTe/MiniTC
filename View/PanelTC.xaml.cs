using System.Windows;
using System.Windows.Controls;

namespace MiniTC
{
    /// <summary>
    /// Interaction logic for PanelTC.xaml
    /// </summary>
    public partial class PanelTC : UserControl
    {
        public static readonly DependencyProperty LogicalDriversProperty =
            DependencyProperty.Register(
                "LogicalDrivers",
                typeof(string[]),
                typeof(PanelTC),
                new FrameworkPropertyMetadata(null)
            );

        public string[] LogicalDrivers
        {
            get { return (string[])GetValue(LogicalDriversProperty); }
            set { SetValue(LogicalDriversProperty, value); }
        }

        public PanelTC()
        {
            InitializeComponent();
        }
    }
}
