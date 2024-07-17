using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using Wpf.Ui.Controls;
using WpfApp3.Models;

namespace WpfApp3 {

    public class MainViewModel : INotifyPropertyChanged {

        private ObservableCollection<Product> _productsCollection;

        public ObservableCollection<Product> ProductsCollection {
            get { return _productsCollection; }
            set {
                _productsCollection = value;
                OnPropertyChanged("ProductsCollection");
            }
        }

        private ObservableCollection<Product> _productsCollection2;

        public ObservableCollection<Product> ProductsCollection2 {
            get { return _productsCollection2; }
            set {
                _productsCollection2 = value;
                OnPropertyChanged("ProductsCollection2");
            }
        }

        public MainViewModel() {
            ProductsCollection = new ObservableCollection<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 10.0m, IsSelected = false,IsSelected2 = true },
                new Product { Id = 2, Name = "Product 2", Price = 20.0m, IsSelected = true ,IsSelected2 = true},
                new Product { Id = 3, Name = "Product 3", Price = 30.0m, IsSelected = false ,IsSelected2 = true},
              
            };

            ProductsCollection2 = new ObservableCollection<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 10.0m, IsSelected = false,IsSelected2 = true },
                new Product { Id = 2, Name = "Product 2", Price = 20.0m, IsSelected = true ,IsSelected2 = true},
                new Product { Id = 3, Name = "Product 3", Price = 30.0m, IsSelected = false ,IsSelected2 = true},
                new Product { Id = 4, Name = "Product 2", Price = 20.0m, IsSelected = true ,IsSelected2 = true},
                new Product { Id = 5, Name = "Product 2", Price = 20.0m, IsSelected = true ,IsSelected2 = true},
                
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

       

    }
}
