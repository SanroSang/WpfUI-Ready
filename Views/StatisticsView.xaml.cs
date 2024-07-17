using System.Windows.Controls;

namespace WpfApp3 {
    /// <summary>
    /// StatisticsView.xaml 的交互逻辑
    /// </summary>
    public partial class StatisticsView : UserControl
    {
        public StatisticsView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
