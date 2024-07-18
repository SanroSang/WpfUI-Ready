using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Controls;

namespace WpfApp3 {
    /// <summary>
    /// SettingsView.xaml 的交互逻辑
    /// </summary>
    public partial class ItemsListView : UserControl
    {
        public ItemsListView()
        {
            InitializeComponent();
        }

        private void TabPin_Click(object sender, RoutedEventArgs e) {
            if (TabPin.IsEnabled) {
                ((SymbolIcon)TabPin.Icon).Symbol = SymbolRegular.PinOff24;
                TabPin.IsEnabled = true;
            } else {
                ((SymbolIcon)TabPin.Icon).Symbol = SymbolRegular.Pin24;
                TabPin.IsEnabled = true;
            }
        }

    }
}
