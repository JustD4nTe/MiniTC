using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
