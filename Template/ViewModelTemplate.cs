using DEMO_WPF.NET8.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DEMO_WPF.NET8.Template
{
    #region Template

    public class ViewModelTemplate : ViewModelBase
    {
        DbContext db = new DbContext();

        private ObservableCollection<Model> _models;
        public ObservableCollection<Model> Models
        {
            get { return _models; }
            set
            {
                _models = value;
                OnPropertyChanged("Models");
            }
        }

        private Model _selectedItem;
        public Model SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        private string _searchQuery;
        public string SearchQuery
        {
            get { return _searchQuery; }
            set
            {
                if (_searchQuery != value)
                {
                    _searchQuery = value;
                    OnPropertyChanged(nameof(SearchQuery));
                    RefreshModels();
                }
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand ChangeCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ViewModelTemplate()
        {
            db.Models.Load();
            Models = db.Models.Local.ToObservableCollection();

            AddCommand = new RelayCommand(AddModel);
            ChangeCommand = new RelayCommand(SaveChanges, CanExecute);
            DeleteCommand = new RelayCommand(DeleteExecute, CanExecute);
        }

        private void AddModel(object parametr)
        {
            Window window = new AddWindow();
            window.ShowDialog();
        }

        private void RefreshModels()
        {
            var query = GetBaseModelsQuery();

            if (!string.IsNullOrEmpty(SearchQuery))
            {
                bool isNumber = int.TryParse(SearchQuery, out int searchId);

                query = query.Where(o => (isNumber && o.Id == searchId) ||
                                         o.Attribute.Contains(SearchQuery));
            }
            Drivers = new ObservableCollection<Model>(query.ToList());
        }

        private IQueryable<Model> GetBaseModelsQuery()
        {
            return from model in db.Models
                   select new Model
                   {
                       Id = model.Id,
                       Attribute = model.Attribute
                   };
        }

        private void SaveChanges(object obj)
        {
            db.SaveChanges();
        }

        private void DeleteExecute(object parametr)
        {
            if (SelectedItem != null)
            {
                var model = db.Models.FirstOrDefault(o => o.Id == SelectedItem.Id);
                if (model != null)
                {
                    db.Models.Remove(model);
                    db.SaveChanges();
                    RefreshModels();
                }
            }
        }

        private bool CanExecute(object obj)
        {
            return SelectedItem != null;
        }
    }


    public class AddViewModel : ViewModelBase
    {
        DbContext db = new DbContext();

        private string _attribute;
        public string Attribute
        {
            get { return _attribute; }
            set
            {
                _attribute = value;
                OnPropertyChanged(nameof(Attribute));
            }
        }

        public ICommand AddCommand { get; }

        public AddViewModel()
        {
            AddCommand = new RelayCommand(AddExecute, CanExecute);
        }

        private bool CanExecute(object parameter)
        {
            return Attribute != null;
        }


        public void AddExecute(object parameter)
        {
            var model = new Model
            {
                Attribute = _attribute
            };

            db.Model.Add(model);
            db.SaveChanges();
        }
    }

    #endregion
}