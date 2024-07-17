using System;
using System.Windows;
using Wpf.Ui.Controls;

namespace WpfApp3 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.StateChanged += OnWindowStateChanged;
        }

        private void Mini_Click(object sender, RoutedEventArgs e) {
            this.WindowState = WindowState.Minimized;
        }

        private void MaxOrNormal_Click(object sender, RoutedEventArgs e) {
            if (this.WindowState == WindowState.Maximized) {
                this.WindowState = WindowState.Normal;
            } else {
                this.WindowState = WindowState.Maximized;
            }
        }

        private async void Close_Click(object sender, RoutedEventArgs e) {

            var meg = new Wpf.Ui.Controls.MessageBox {
                Title = "是否关闭主界面：",
                Content = "关闭后为保存的内容将会丢失！",
                PrimaryButtonText = "确认",
                SecondaryButtonText = "取消",
                CloseButtonText = "返回",
                ShowTitle = true
            };

            var result = await meg.ShowDialogAsync();
            if (result == Wpf.Ui.Controls.MessageBoxResult.Primary) {
                this.Close();
            }
        }

        private void OnWindowStateChanged(object sender, EventArgs e) {
            UpdateMaxOrNormalButtonIcon();
        }

        private void UpdateMaxOrNormalButtonIcon() {
            if (this.WindowState == WindowState.Maximized) {
                ((SymbolIcon)MaxOrNormalButton.Icon).Symbol = SymbolRegular.SquareMultiple32;
            } else {
                ((SymbolIcon)MaxOrNormalButton.Icon).Symbol = SymbolRegular.Square32;
            }
        }

    }
}
