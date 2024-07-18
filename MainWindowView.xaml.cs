using System;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace WpfApp3 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window {

        public MainWindowView() {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.StateChanged += OnWindowStateChanged;
            _currentApplicationTheme = ApplicationThemeManager.GetAppTheme();
            UpdateThemeIcon();
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
                Content = "未保存的内容将会丢失！",
                PrimaryButtonText = "关闭",
                CloseButtonText = "取消",
            };

            var result = await meg.ShowDialogAsync();
            if (result == Wpf.Ui.Controls.MessageBoxResult.Primary) {
                this.Close();
            }
        }

        private void SwitchLightOrDark_Click(object sender, RoutedEventArgs e) {
            if (_currentApplicationTheme == ApplicationTheme.Light) {
                OnChangeTheme("theme_dark");
            } else {
                OnChangeTheme("theme_light");
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

        private void UpdateThemeIcon() {
            if (_currentApplicationTheme == ApplicationTheme.Dark) {
                ((SymbolIcon)ThemeIcon.Icon).Symbol = SymbolRegular.WeatherMoon24;
                ((SymbolIcon)ThemeIcon.Icon).Filled = true;
            } else {
                ((SymbolIcon)ThemeIcon.Icon).Symbol = SymbolRegular.WeatherSunny24;
                ((SymbolIcon)ThemeIcon.Icon).Filled = true;
            }
        }

        private ApplicationTheme _currentApplicationTheme;

        public ICommand ChangeThemeCommand { get; }

        private void OnChangeTheme(object parameter) {
            if (parameter is string theme) {
                switch (theme) {
                    case "theme_light":
                        if (_currentApplicationTheme == ApplicationTheme.Light)
                            break;

                        ApplicationThemeManager.Apply(ApplicationTheme.Light);
                        _currentApplicationTheme = ApplicationTheme.Light;
                        break;

                    case "theme_dark":
                        if (_currentApplicationTheme == ApplicationTheme.Dark)
                            break;

                        ApplicationThemeManager.Apply(ApplicationTheme.Dark);
                        _currentApplicationTheme = ApplicationTheme.Dark;
                        break;

                    default:
                        break;
                }
            }
            UpdateThemeIcon();
        }

        //private async void PanelLeft_Click(object sender, RoutedEventArgs e) {
        //    MainNavigationView.PaneDisplayMode = NavigationViewPaneDisplayMode.Left;
        //}
        //private async void PanelLeftFluent_Click(object sender, RoutedEventArgs e) {
        //    MainNavigationView.PaneDisplayMode = NavigationViewPaneDisplayMode.LeftFluent;
        //}
        //private async void PanelTop_Click(object sender, RoutedEventArgs e) {
        //    MainNavigationView.PaneDisplayMode = NavigationViewPaneDisplayMode.Top;
        //}
        //private async void PanelBottom_Click(object sender, RoutedEventArgs e) {
        //    MainNavigationView.PaneDisplayMode = NavigationViewPaneDisplayMode.Bottom;
        //}

    }
}
