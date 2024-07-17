using System.ComponentModel;
using System.Windows.Input;
using Wpf.Ui.Controls;

namespace WpfApp3 {
    public class HomeViewModel : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand OpenSnackbarCommand { get; }

        public HomeViewModel() {
            OpenSnackbarCommand = new RelayCommand(OpenSnackbar);
        }

        private void OpenSnackbar(object parameter) {
            var snackbar = parameter as Snackbar;
            if (snackbar != null) {
                snackbar.Title = "Snackbar Title";
                snackbar.Content = "This is a Snackbar message!";
                snackbar.Show();
            }
            //输出运行提示
            System.Console.WriteLine("Snackbar shown successfully.");
        }

    }
}
