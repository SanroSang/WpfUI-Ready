using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfApp3 {
    public partial class HomeView : UserControl {
        private bool isFullScreen = false;
        private ColumnDefinition[] originalColumns;
        private RowDefinition[] originalRows;

        public HomeView() {
            this.DataContext = new HomeViewModel();
            InitializeComponent();
            // 保存原始列和行定义
            originalColumns = MainGrid.ColumnDefinitions.ToArray();
            originalRows = MainGrid.RowDefinitions.ToArray();
        }

        private void FullScreenButton_Click(object sender, RoutedEventArgs e) {
            string buttonName = (sender as FrameworkElement)?.Name;
            if (!isFullScreen) {
                SetFullScreenLayout(buttonName);
            } else {
                RestoreOriginalLayout();
            }
            isFullScreen = !isFullScreen;
        }

        private void SetFullScreenLayout( string buttonName) {
            // 清空当前的列和行定义
            MainGrid.ColumnDefinitions.Clear();
            MainGrid.RowDefinitions.Clear();

            // 添加一个占据所有空间的列和行
            MainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            MainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            // 获取点击按钮的名称
            if (buttonName != null) {
                // 根据按钮名称决定显示哪个边框
                switch (buttonName) {
                    case "Image1_btn":
                        ShowBorder(Border1);
                        break;
                    case "Image2_btn":
                        ShowBorder(Border2);
                        break;
                    case "Image3_btn":
                        ShowBorder(Border3);
                        break;
                    case "Image4_btn":
                        ShowBorder(Border4);
                        break;
                    default:
                        break;
                }
            }
        }

        private void ShowBorder(Border borderToShow) {
            // 隐藏所有边框
            Border1.Visibility = Visibility.Collapsed;
            Border2.Visibility = Visibility.Collapsed;
            Border3.Visibility = Visibility.Collapsed;
            Border4.Visibility = Visibility.Collapsed;

            // 显示指定的边框
            borderToShow.Visibility = Visibility.Visible;
        }

        private void RestoreOriginalLayout() {
            // 清空当前的列和行定义
            MainGrid.ColumnDefinitions.Clear();
            MainGrid.RowDefinitions.Clear();

            // 恢复原始的列和行定义
            foreach (var column in originalColumns) {
                MainGrid.ColumnDefinitions.Add(column);
            }
            foreach (var row in originalRows) {
                MainGrid.RowDefinitions.Add(row);
            }

            // 恢复每个元素的位置
            foreach (UIElement child in MainGrid.Children) {
                if (child is Border border) {
                    var row = Grid.GetRow(border);
                    var column = Grid.GetColumn(border);

                    // 将边框放回原始的行和列位置
                    Grid.SetRow(border, row);
                    Grid.SetColumn(border, column);

                    // 恢复边框的可见性
                    border.Visibility = Visibility.Visible;
                }
            }
        }

    }
}