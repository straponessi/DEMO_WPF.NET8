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

namespace DEMO_WPF.NET8.Views
{
    /// <summary>
    /// Логика взаимодействия для WorkerPage.xaml
    /// </summary>
    public partial class WorkerPage : Page
    {
        public WorkerPage()
        {
            InitializeComponent();
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
                    RefreshDrivers();
                }
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand ChangeCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public DriversVM()
        {
            CheckAutoRiz();
            db.Drivers.Load();
            Drivers = db.Drivers.Local.ToObservableCollection();

            AddCommand = new RelayCommand(AddDriver);
            ChangeCommand = new RelayCommand(SaveChanges, CanExecute);
            DeleteCommand = new RelayCommand(DeleteExecute, CanExecute);
        }

        private void AddDriver(object parametr)
        {
            Window window = new AddDriverWindow();
            window.ShowDialog();
        }

        private void RefreshDrivers()
        {
            var query = GetBaseDriversQuery();

            if (!string.IsNullOrEmpty(SearchQuery))
            {
                bool isNumber = int.TryParse(SearchQuery, out int searchId);

                query = query.Where(o => (isNumber && o.Id == searchId) ||
                                         o.Fullname.Contains(SearchQuery) ||
                                         o.Contact.Contains(SearchQuery) ||
                                         o.License.Contains(SearchQuery)); 
            }
            Drivers = new ObservableCollection<Driver>(query.ToList());
        }

        private IQueryable<Driver> GetBaseDriversQuery()
        {
            return from driver in db.Drivers
                   select new Driver
                   {
                       Id = driver.Id,
                       Fullname = driver.Fullname,
                       Contact = driver.Contact,
                       License = driver.License,
                       Status = driver.Status,
                   };
        }