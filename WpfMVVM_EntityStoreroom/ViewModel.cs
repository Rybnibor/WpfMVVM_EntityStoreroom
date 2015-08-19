using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace WpfMVVM_EntityStoreroom
{
    class ViewModel : INotifyPropertyChanged
    {
        private ModelStoreroomContainer _model;
        private int _toDelete;
        private Products _produkt;
        
        public int ToDelete
        {
            get { return _toDelete; }
            set
            {
                _toDelete = value;
                OnPropertyChanged("ToDelete");
            }
        }

        public int ProductID
        {
            get { return _produkt.ProductID; }
            set
            {
                _produkt.ProductID = value;
                OnPropertyChanged("ProductID");
            }
        }

        public string Name
        {
            get { return _produkt.Name; }
            set
            {
                _produkt.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Model
        {
            get { return _produkt.Model; }
            set
            {
                _produkt.Model = value;
                OnPropertyChanged("Model");
            }
        }

        public int Quantity
        {
            get { return _produkt.Quantity; }
            set
            {
                _produkt.Quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        public string Rack
        {
            get { return _produkt.Rack; }
            set
            {
                _produkt.Rack = value;
                OnPropertyChanged("Rack");
            }
        }

        
        

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ViewModel()
        {
            _toDelete = 0;
            _model = new ModelStoreroomContainer();
            _produkt = new Products
            {
                Name="",
                Model="",
                Quantity=0,
                Rack=""
            };
            //_person = new Person();
        }

        public ICommand Edit { get { return new RelayCommand(EditExcute, CanEditExcute); } }

        private void EditExcute()
        {
            //MessageBox.Show("aaaaaa dziala");
            StoreroomEdit storeroomEditPage = new StoreroomEdit();
            // TODO: MVVM navigation to change
            ((MainWindow)System.Windows.Application.Current.MainWindow).NavigationService.Navigate(storeroomEditPage);
        }

        private bool CanEditExcute()
        {
            return true; 
        }

        public ICommand View { get { return new RelayCommand(ViewExcute, CanViewExcute); } }

        private void ViewExcute()
        {          
            StoreroomView storeroomViewPage = new StoreroomView();
            var query = from c in _model.ProductsSet
                        where c.ProductID > -1
                        select new { c.ProductID, c.Name, c.Model, c.Quantity, c.Rack };

            var results = query.ToList();
            storeroomViewPage.dataGrid1.ItemsSource = results;
            // TODO: MVVM navigation to change
            ((MainWindow)System.Windows.Application.Current.MainWindow).NavigationService.Navigate(storeroomViewPage);
        }

        private bool CanViewExcute()
        {
            return true; 
        }

        public ICommand Add { get { return new RelayCommand(AddExcute, CanAddExcute); } }

        private void AddExcute()
        {
            //MessageBox.Show("aaaaaa dziala");
            clearProduct();
            StoreroomAdd storeroomAddPage = new StoreroomAdd();
            // TODO: MVVM navigation to change
            ((MainWindow)System.Windows.Application.Current.MainWindow).NavigationService.Navigate(storeroomAddPage);
        }

        private bool CanAddExcute()
        {
            return true;
        }

        public ICommand AddData { get { return new RelayCommand(AddDataExcute, CanAddDataExcute); } }

        private void AddDataExcute()
        {
            _model.ProductsSet.Add(_produkt);
            _model.SaveChanges();
            // TODO: MVVM - remove MessageBox and do some bindings
            MessageBox.Show(_produkt.Name+" added to database.");
            clearProduct();
        }

        private bool CanAddDataExcute()
        {
            return true; 
        }

        public ICommand DeleteData { get { return new RelayCommand(DeleteDataExcute, CanDeleteDataExcute); } }

        private void DeleteDataExcute()
        {
            // TODO: MVVM - remove MessageBox and do some bindings
            if (MessageBox.Show("Do you really want do delete position with ID " + ToDelete, "Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                try
                {
                    //Products whatToDelete = new Products();
                    var whatToDelete = _model.ProductsSet.Find(ToDelete);
                    _model.ProductsSet.Remove(whatToDelete);
                    _model.SaveChanges();
                    // TODO: MVVM - remove MessageBox and do some bindings
                    MessageBox.Show("Positin with ID " + ToDelete + " deleted successfully", "Success");
                }
                catch (Exception)
                {
                    // TODO: MVVM - remove MessageBox and do some bindings
                    //MessageBox.Show("Something went wrong " + e.ToString(), "Error");
                    MessageBox.Show("I can't find positin with ID " + ToDelete, "Error");
                }
                
                
            }
        }

        private bool CanDeleteDataExcute()
        {
            return true;
        }

        public ICommand ShowIt { get { return new RelayCommand(ShowItExcute, CanShowItExcute); } }

        private void ShowItExcute()
        {

            try
            {
                //Products whatToDelete = new Products();
                var whatToDelete = _model.ProductsSet.Find(ToDelete);
                //ProductID = whatToDelete.ProductID;
                Name = whatToDelete.Name;
                Model = whatToDelete.Model;
                Quantity = whatToDelete.Quantity;
                Rack = whatToDelete.Rack;

            }
            catch (Exception)
            {
                // TODO: MVVM - remove MessageBox and do some bindings
                //MessageBox.Show("Something went wrong " + e.ToString(), "Error");
                MessageBox.Show("I can't find positin with ID " + ToDelete, "Error");
            }
        }

        private bool CanShowItExcute()
        {
            return true;
        }

        public ICommand SaveData { get { return new RelayCommand(SaveDataExcute, CanSaveDataExcute); } }

        private void SaveDataExcute()
        {
            try
            {
                var whatToDelete = _model.ProductsSet.Find(ToDelete);
                whatToDelete.Name = Name;
                whatToDelete.Model = Model;
                whatToDelete.Quantity = Quantity;
                whatToDelete.Rack = Rack;
                _model.ProductsSet.Attach(whatToDelete);
                _model.Entry(whatToDelete).State = System.Data.Entity.EntityState.Modified;
                _model.SaveChanges();

                // TODO: MVVM - remove MessageBox and do some bindings
                MessageBox.Show(Name + " saved to database.");
                //clearProduct();
            }
            catch (Exception)
            {
                // TODO: MVVM - remove MessageBox and do some bindings
                MessageBox.Show("I can't find positin with ID " + ToDelete, "Error");
            }
            
        }

        private bool CanSaveDataExcute()
        {
            return true;
        }

        private void clearProduct()
        {
            ToDelete = 0;
            //ProductID = 0;
            Name = "";
            Model = "";
            Quantity = 0;
            Rack = "";
        }
    }
}
